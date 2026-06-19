using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Globalization;
using System.Linq.Expressions;

namespace WebAwesomeBlazor.Components
{
    public partial class WATimeInput<TValue> : WAComponentBase
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
        /// Distance in pixels between the popup and the input.
        /// </summary>
        [Parameter]
        public int PopupDistance { get; set; } = 0;

        /// <summary>
        /// The input's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }


        /// <summary>
        /// Whether the UI uses a 12-hour or 24-hour clock. Auto follows the resolved locale.
        /// </summary>
        [Parameter]
        public TimeInputHourFormat HourFormat { get; set; } = TimeInputHourFormat.Auto;

        /// <summary>
        /// The input's label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }


        /// <summary>
        /// The latest selectable time
        /// </summary>
        [Parameter]
        public TimeOnly? MaximumTime { get; set; }

        /// <summary>
        /// The earliest selectable time
        /// </summary>
        [Parameter]
        public TimeOnly? MinimumTime { get; set; }

        /// <summary>
        /// Draws a pill-style input with rounded edges.
        /// </summary>
        [Parameter]
        public bool Pill { get; set; } = false;

        [Parameter]
        public TimeInputPlacement PopupPlacement { get; set; } = TimeInputPlacement.BottomStart;

        /// <summary>
        /// Makes the input readonly.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;
        /// <summary>
        /// /// Makes the input required for form submission.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;

        /// <summary>
        /// The input's size.
        /// </summary>
        [Parameter]
        public InputSize Size { get; set; } = InputSize.Medium;

        /// <summary>
        /// The granularity, in seconds. Values below 60 reveal the seconds segment.
        /// </summary>
        [Parameter]
        public int? Step { get; set; }

        /// <summary>
        /// Adds a clear button (with-clear) when the input is not empty.
        /// </summary>
        [Parameter]
        public bool Clearable { get; set; } = false;

        /// <summary>
        /// An icon to use in lieu of the default clear icon..
        /// </summary>
        [Parameter]
        public string? ClearIconName { get; set; }
        /// <summary>
        ///An icon to use in lieu of the default clear icon.
        /// </summary>
        [Parameter]
        public Icon? ClearIcon { get; set; }
        /// <summary>
        /// The icon to show on the popup toggle button. Defaults to a clock icon.
        /// </summary>
        [Parameter]
        public string? ExpandIconName { get; set; }
        /// <summary>
        /// The icon to show on the popup toggle button. Defaults to a clock icon.
        /// </summary>
        [Parameter]
        public Icon? ExpandIcon { get; set; }

        /// <summary>
        /// Renders a "Now" button in the popup footer.
        /// </summary>
        [Parameter]
        public bool ShowNowButton { get; set; } = false;

        [Parameter]
        public RenderFragment? FooterContent { get; set; }

        [Parameter]
        public RenderFragment? EndContent { get; set; }
        [Parameter]
        public RenderFragment? StartContent { get; set; }

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


        string PopupPlacementString
        {
            get
            {
                return PopupPlacement switch
                {
                    TimeInputPlacement.BottomStart => "bottom-start",
                    TimeInputPlacement.BottomEnd => "bottom-end",
                    TimeInputPlacement.TopStart => "top-start",
                    TimeInputPlacement.TopEnd => "top-end",
                    TimeInputPlacement.Top => "top",
                    TimeInputPlacement.Bottom => "bottom",
                    TimeInputPlacement.Right => "right",
                    TimeInputPlacement.RightStart => "right-start",
                    TimeInputPlacement.RightEnd => "right-end",
                    TimeInputPlacement.Left => "left",
                    TimeInputPlacement.LeftStart => "left-start",
                    TimeInputPlacement.LeftEnd => "left-end",
                    _ => "bottom-start"
                };
            }
        }

        string HourFormatString
        {
            get
            {
                return HourFormat switch
                {
                    TimeInputHourFormat.Auto => "auto",
                    TimeInputHourFormat.Twelve => "12",
                    TimeInputHourFormat.TwentyFour => "24",
                    _ => "auto"
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

                await SetValueAsync(oldValue, Value);

                //await ValueChanged.InvokeAsync(Value);
            }

            await base.OnAfterRenderAsync(firstRender);

        }

        protected override async Task OnInitializedAsync()
        {

            if (!(typeof(TValue) == typeof(TimeOnly)
                  || typeof(TValue) == typeof(TimeOnly?)
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

        [JSInvokable]
        public async Task HandleInputClear()
        {

            await ValueChanged.InvokeAsync(default!);
            EditContext?.NotifyFieldChanged(fieldIdentifier);

        }

        [JSInvokable]
        public async Task HandleInputChange(string value)
        {

            _ = TryParseValue(value, out TValue newValue);
            await ValueChanged.InvokeAsync(newValue);
            EditContext?.NotifyFieldChanged(fieldIdentifier);


        }
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

        #endregion

        #region State
        private string? formattedValue;
        private TValue? oldValue;

        private FieldIdentifier fieldIdentifier = default!;
        private DotNetObjectReference<WATimeInput<TValue>> objRef = default!;
        #endregion

        #region Private Methods
        private static string GetFormattedValue(object value)
        {
            var formattedDate = "";

            try
            {
                if (value is null)
                    return formattedDate;

                // TimeOnly / TimeOnly?
                if (typeof(TValue) == typeof(TimeOnly) || typeof(TValue) == typeof(TimeOnly?))
                {
                    if (DateTime.TryParse(value.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out var dt)) formattedDate = dt.ToString("HH:mm:ss.fff");
                }

                // DateTime / DateTime?
                else if (typeof(TValue) == typeof(DateTime) || typeof(TValue) == typeof(DateTime?))
                {
                    var d = Convert.ToDateTime(value, CultureInfo.CurrentCulture); // TODO: update this with .NET 8 upgrade
                    formattedDate = d.ToString("HH:mm:ss.fff");
                }

            }
            catch (FormatException)
            {
                return formattedDate;
            }

            return formattedDate;
        }


        private async Task SetValueAsync(TValue? oldValue, TValue newValue)
        {
            if (newValue is null)
            {
                Value = default!;
                formattedValue = "";
            }
            else
            {
                Value = newValue;
                formattedValue = WATimeInput<TValue>.GetFormattedValue(Value);
            }



            if (oldValue is null || oldValue!.Equals(Value))
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
                // TimeOnly / TimeOnly?
                if (typeof(TValue) == typeof(TimeOnly) || typeof(TValue) == typeof(TimeOnly?))
                {
                    if (DateTime.TryParse(value.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out var dt))
                    {
                        newValue = (TValue)(object)TimeOnly.FromDateTime(dt);

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

        public async Task ShowPickerAsync()
        {
            await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
            await SafeInvokeVoidAsync("datetimeInputShowPicker", Id!);
        }
        public async Task HidePickerAsync()
        {
            await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
            await SafeInvokeVoidAsync("datetimeInputHidePicker", Id!);
        }
        #endregion
    }

}


