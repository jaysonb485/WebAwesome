using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Globalization;
using System.Linq.Expressions;

namespace WebAwesomeBlazor.Components
{


    public partial class WAKnownDate<TValue> : WAComponentBase
    {
        #region Parameters

        [CascadingParameter] private EditContext EditContext { get; set; } = default!;

        [Parameter]
        public TValue Value { get; set; } = default!;

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; } = default!;

        [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; } = default!;

        /// <summary>
        /// The input's visual appearance.
        /// </summary>
        [Parameter]
        public InputAppearance Appearance { get; set; } = InputAppearance.Outlined;


        /// <summary>
        /// Specifies what permission the browser has to provide assistance in filling out form field values. Refer to this page on MDN for available values.
        /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete"/>
        /// </summary>
        [Parameter]
        public string? Autocomplete { get; set; }


        /// <summary>
        /// Makes the input disabled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The input's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }


        /// <summary>
        /// The input's label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// BCP-47 locale override. When empty, the inherited lang attribute is used.
        /// </summary>
        [Parameter]
        public string? Locale { get; set; }

        /// <summary>
        /// The latest selectable date 
        /// </summary>
        [Parameter]
        public DateOnly? MaximumDate { get; set; }

        /// <summary>
        /// The earliest selectable date
        /// </summary>
        [Parameter]
        public DateOnly? MinimumDate { get; set; }

        /// <summary>
        /// Draws a pill-style input with rounded edges.
        /// </summary>
        [Parameter]
        public bool Pill { get; set; } = false;

        /// <summary>
        /// Makes the input readonly.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Makes the input required for form submission.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;


        /// <summary>
        /// The input's size.
        /// </summary>
        [Parameter]
        public InputSize Size { get; set; } = InputSize.Medium;

        #endregion

        #region Computed  Properties

        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    InputAppearance.Filled => "filled",
                    InputAppearance.Outlined => "outlined",
                    InputAppearance.FilledOutlined => "filled-outlined",
                    _ => "outlined"
                    //Only filled and outlined are valid for inputs
                };
            }
        }

        string SizeString
        {
            get
            {
                return Size switch
                {
                    InputSize.XSmall => "xs",
                    InputSize.Small => "s",
                    InputSize.Medium => "m",
                    InputSize.Large => "l",
                    InputSize.XLarge => "xl",
                    InputSize.Inherit => "inherit",
                    _ => "m"
                };
            }
        }


        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {

                await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Id!, objRef);

            }

            await base.OnAfterRenderAsync(firstRender);

        }

        protected override async Task OnInitializedAsync()
        {
            if (!(typeof(TValue) == typeof(DateOnly)
                  || typeof(TValue) == typeof(DateOnly?)
                  || typeof(TValue) == typeof(DateTime)
                  || typeof(TValue) == typeof(DateTime?)
                 ))
                throw new InvalidOperationException($"{typeof(TValue)} is not supported.");

            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= [];

            if (ValueExpression != null)
                fieldIdentifier = FieldIdentifier.Create(ValueExpression);

            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            if ((oldValue is null && Value is not null)
                || (oldValue is not null && Value is null)
                || !oldValue!.Equals(Value))
            {
                await SetValueAsync(oldValue!, Value);
                oldValue = Value;
            }
        }

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    if (_instance is not null)
                        await _instance.InvokeVoidAsync("dispose");
                }
                catch (JSDisconnectedException)
                {
                }

                objRef?.Dispose();

            }

        }
        #endregion

        #region Event Handlers
        private async Task OnValueChanged(ChangeEventArgs e)
        {
            var oldValue = Value;

            // When pressing 0 first the component falls back to default value
            // We can avoid this by checking for an empty string first
            if (e.Value is string tmp && tmp != string.Empty)
            {

                _ = TryParseValue(e.Value, out TValue newValue);
                await SetValueAsync(oldValue, newValue);
                this.oldValue = newValue;
                await ValueChanged.InvokeAsync(newValue);
                EditContext?.NotifyFieldChanged(fieldIdentifier);

            }
        }

        [JSInvokable]
        public async Task HandleInputChange(string value)
        {
            TryParseValue(value, out TValue newValue);
            await ValueChanged.InvokeAsync(newValue);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        #endregion

        #region State
        private string? formattedValue;
        private TValue? oldValue;

        private FieldIdentifier fieldIdentifier = default!;
        private DotNetObjectReference<WAKnownDate<TValue>> objRef = default!;
        #endregion

        #region Private Methods


        private async Task SetValueAsync(TValue? oldValue, TValue? newValue)
        {
            if (newValue is null || !TryParseValue(newValue, out var value))
            {
                Value = default!;
                formattedValue = "";
            }
            else
            {
                DateOnly? valueAsDate = value switch
                {
                    DateOnly d => d,
                    DateTime dt => DateOnly.FromDateTime(dt),
                    _ => null
                };

                if (MinimumDate.HasValue &&
                    valueAsDate < MinimumDate.Value)
                {
                    return;
                }

                if (MaximumDate.HasValue &&
                    valueAsDate > MaximumDate.Value)
                {
                    return;
                }

                Value = value;
                formattedValue = valueAsDate.HasValue ? valueAsDate.Value.ToString("yyyy-MM-dd") : "";
            }


            if (oldValue is null || !oldValue!.Equals(Value))
            {
                await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
                await SafeInvokeVoidAsync("setValue", Id!, formattedValue);
            }

            await ValueChanged.InvokeAsync(Value);

            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        private bool TryParseValue(object value, out TValue newValue)
        {
            try
            {
                // DateOnly / DateOnly?
                if (typeof(TValue) == typeof(DateOnly) || typeof(TValue) == typeof(DateOnly?))
                {
                    if (DateTime.TryParse(value.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out var dt))
                    {
                        newValue = (TValue)(object)DateOnly.FromDateTime(dt);

                        return true;
                    }

                    newValue = default!;

                    return false;
                }
                // DateTime / DateTime?

                if (typeof(TValue) == typeof(DateTime) || typeof(TValue) == typeof(DateTime?))
                {
                    newValue = (TValue)Convert.ChangeType(value, typeof(DateTime), CultureInfo.CurrentCulture);

                    return true;
                }

                newValue = default!;

                return false;
            }
            catch (Exception)
            {
                newValue = default!;

                return false;
            }
        }

        #endregion

        #region Public Methods
        public async Task SetFocusAsync()
        {
            await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
            await SafeInvokeVoidAsync("setFocus", Id!);
        }

        public void SetFocus() => _ = SetFocusAsync();
        #endregion
    }

}


