using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static WebAwesomeBlazor.Components.WAInput;

namespace WebAwesomeBlazor.Components
{
    public partial class WAInputDateTime<TValue> : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The type of input.
        /// </summary>
        [Parameter]
        public DateTimeInputType InputType { get; set; } = DateTimeInputType.DateTimeLocal;

        [CascadingParameter] private EditContext EditContext { get; set; } = default!;

        [Parameter]
        public TValue Value { get; set; } = default!;

        [Parameter]
        public EventCallback<TValue?> ValueChanged { get; set; } = default!;

        [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; } = default!;

        [Parameter]
        public InputAppearance Appearance { get; set; } = InputAppearance.Outlined;

        /// <summary>
        /// The input's size.
        /// </summary>
        [Parameter]
        public InputSize Size { get; set; } = InputSize.Inherit;

        /// <summary>
        /// Draws a pill-style input with rounded edges.
        /// </summary>
        [Parameter]
        public bool Pill { get; set; } = false;

        /// <summary>
        /// The input's label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The input's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }

        /// <summary>
        /// Placeholder text to show as a hint when the input is empty.
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// Adds a clear button (with-clear) when the input is not empty.
        /// </summary>
        [Parameter]
        public bool Clearable { get; set; } = false;

        /// <summary>
        /// Makes the input readonly.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Makes the input disabled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;


        /// <summary>
        /// Ensures a child radio is checked before allowing the containing form to submit.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;

        /// <summary>
        /// An icon placed at the start of the input control.
        /// </summary>
        [Parameter]
        public string? StartIconName { get; set; }
        /// <summary>
        /// An icon placed at the start of the input control.
        /// </summary>
        [Parameter]
        public Icon? StartIcon { get; set; }
        /// <summary>
        /// An icon placed at the end of the input control.
        /// </summary>
        [Parameter]
        public string? EndIconName { get; set; }
        /// <summary>
        /// An icon placed at the end of the input control.
        /// </summary>
        [Parameter]
        public Icon? EndIcon { get; set; }

        #endregion

        #region Computed  Properties
        string InputTypeString
        {
            get
            {
                return InputType switch
                {
                    DateTimeInputType.Date => "date",
                    DateTimeInputType.DateTimeLocal => "datetime-local",
                    DateTimeInputType.Time => "time",
                    DateTimeInputType.Text => "text",
                    _ => "datetime-local"
                };
            }
        }
        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    InputAppearance.Filled => "filled",
                    InputAppearance.Outlined => "outlined",
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
                    InputSize.Small => "small",
                    InputSize.Medium => "medium",
                    InputSize.Large => "large",
                    InputSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }

        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                var currentValue = Value;

                if (currentValue is null || !TryParseValue(currentValue, out var value))
                {
                    Value = default!;
                }
                else
                {
                    Value = value;
                }

                formattedValue = GetFormattedValue(Value!);

                await JSRuntime.InvokeVoidAsync("window.vengage.input.initialize", Id, objRef, Value);

                //await ValueChanged.InvokeAsync(Value);
            }

            await base.OnAfterRenderAsync(firstRender);

        }

        protected override async Task OnInitializedAsync()
        {

            if (!(typeof(TValue) == typeof(DateOnly)
                  || typeof(TValue) == typeof(DateOnly?)
                  || typeof(TValue) == typeof(DateTime)
                  || typeof(TValue) == typeof(DateTime?)
                  || typeof(TValue) == typeof(TimeOnly)
                  || typeof(TValue) == typeof(TimeOnly?)
                 ))
                throw new InvalidOperationException($"{typeof(TValue)} is not supported.");

            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= new Dictionary<string, object>();

            if (ValueExpression != null)
                fieldIdentifier = FieldIdentifier.Create(ValueExpression);

            Disabled = Disabled;

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
        #endregion

        #region Event Handlers
        private async Task OnValueChanged(ChangeEventArgs e)
        {
            var oldValue = Value;
            var newValue = e.Value; // object

            // When pressing 0 first the component falls back to default value
            // We can avoid this by checking for an empty string first
            if (e.Value is string tmp && tmp != string.Empty) await SetValueAsync(oldValue, newValue);

            this.oldValue = Value;
        }

        [JSInvokable]
        public async Task HandleInputClear()
        {
            await ValueChanged.InvokeAsync(default!);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
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
        private string formattedValue = default!;
        private TValue? oldValue;
        private readonly string defaultDateTimeFormat = "yyyy-MM-ddTHH:mm";
        private readonly string defaultDateOnlyFormat = "yyyy-MM-dd";
        private readonly string defaultTimeOnlyFormat = "HH:mm";

        private FieldIdentifier fieldIdentifier = default!;
        private DotNetObjectReference<WAInputDateTime<TValue>> objRef = default!;
        #endregion

        #region Private Methods
        private string GetFormattedValue(object value)
        {
            var formattedDate = "";

            try
            {
                if (value is null)
                    return formattedDate;

                // DateOnly / DateOnly?
                if (typeof(TValue) == typeof(DateOnly) || typeof(TValue) == typeof(DateOnly?))
                {
                    if (DateTime.TryParse(value.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out var dt)) formattedDate = dt.ToString(defaultDateOnlyFormat);
                }

                // TimeOnly / TimeOnly?
                if (typeof(TValue) == typeof(TimeOnly) || typeof(TValue) == typeof(TimeOnly?))
                {
                    if (DateTime.TryParse(value.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out var dt)) formattedDate = dt.ToString(defaultTimeOnlyFormat);
                }
                // DateTime / DateTime?
                else if (typeof(TValue) == typeof(DateTime) || typeof(TValue) == typeof(DateTime?))
                {
                    var d = Convert.ToDateTime(value, CultureInfo.CurrentCulture); // TODO: update this with .NET 8 upgrade
                    formattedDate = d.ToString(defaultDateTimeFormat);
                }

            }
            catch (FormatException)
            {
                return formattedDate;
            }

            return formattedDate;
        }

        private async Task SetValueAsync(TValue oldValue, object? newValue)
        {
            if (newValue is null || !TryParseValue(newValue, out var value))
            {
                Value = default!;
            }
            else
            {
                Value = value;
            }

            formattedValue = GetFormattedValue(Value!);

            if (oldValue!.Equals(Value))
                await JSRuntime.InvokeVoidAsync("window.vengage.input.setValue", Id, formattedValue);

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

     
    }


}
