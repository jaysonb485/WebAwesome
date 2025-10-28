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

namespace WebAwesomeBlazor.Components
{
    public partial class WAInputNumber<TValue> : WAComponentBase
    {
        #region Parameters
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;
        [Parameter]
        public TValue Value { get; set; } = default!;
        [Parameter]
        public EventCallback<TValue?> ValueChanged { get; set; } = default!;

        [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; } = default!;

        /// <summary>
        /// The input's visual appearance.
        /// </summary>
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


        /// <summary>
        /// Hides the browser's built-in increment/decrement spin buttons for number inputs. Defaults to false.
        /// </summary>

        [Parameter]
        public bool WithoutSpinButtons { get; set; } = false;
        /// <summary>
        /// Specifies the granularity that the value must adhere to
        /// </summary>
        /// <remarks>
        /// Default value is null.
        /// </remarks>
        [Parameter]
        public double? Step { get; set; }

        /// <summary>
        /// The input's maximum value
        /// Max ignored if EnableMinMax="false".
        /// </summary>
        [Parameter]
        public TValue? Max { get; set; } = default!;

        /// <summary>
        /// The input's minimum value.
        /// Min ignored if EnableMinMax="false".
        /// </summary>
        [Parameter]
        public TValue? Min { get; set; } = default!;

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

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    // if (IsRenderComplete)
                    // await JSRuntime.InvokeVoidAsync("window.blazorBootstrap.modal.dispose", Id);
                }
                catch (JSDisconnectedException)
                {
                    // do nothing
                }

                objRef?.Dispose();

                // if (ModalService is not null && IsServiceModal)
                //     ModalService.OnShow -= OnShowAsync;
            }

            await base.DisposeAsyncCore(disposing);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                

                var currentValue = Value; // object

                if (currentValue is null || !TryParseValue(currentValue, out var value))
                    Value = default!;
                //else if (Min is not null && IsLeftGreaterThanRight(Min, Value)) // value < min
                //    Value = Min;
                //else if (Max is not null && IsLeftGreaterThanRight(Value, Max)) // value > max
                //    Value = Max;
                else
                    Value = value;

                await JSRuntime.InvokeVoidAsync("window.vengage.input.initialize", Id, objRef, Value);

                await ValueChanged.InvokeAsync(Value);
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);


            if (Min is not null && Max is not null && IsLeftGreaterThanRight(Min, Max))
                throw new InvalidOperationException("The Min parameter value is greater than the Max parameter value.");

            if (!(typeof(TValue) == typeof(sbyte)
                  || typeof(TValue) == typeof(sbyte?)
                  || typeof(TValue) == typeof(short)
                  || typeof(TValue) == typeof(short?)
                  || typeof(TValue) == typeof(int)
                  || typeof(TValue) == typeof(int?)
                  || typeof(TValue) == typeof(long)
                  || typeof(TValue) == typeof(long?)
                  || typeof(TValue) == typeof(float)
                  || typeof(TValue) == typeof(float?)
                  || typeof(TValue) == typeof(double)
                  || typeof(TValue) == typeof(double?)
                  || typeof(TValue) == typeof(decimal)
                  || typeof(TValue) == typeof(decimal?)
                 ))
                throw new InvalidOperationException($"{typeof(TValue)} is not supported.");

            AdditionalAttributes ??= new Dictionary<string, object>();

            if (ValueExpression != null)
                fieldIdentifier = FieldIdentifier.Create(ValueExpression);

            step = Step.HasValue ? $"{Step.Value}" : "any";

            await base.OnInitializedAsync();
        }
        #endregion

        #region Event Handlers
        private async Task OnValueChanged(ChangeEventArgs e)
        {
            var oldValue = Value;
            var newValue = e.Value; // object

            if (newValue is null || !TryParseValue(newValue, out var value))
                Value = default!;
            //else if (Min is not null && IsLeftGreaterThanRight(Min, value)) // value < min
            //    Value = Min;
            //else if (Max is not null && IsLeftGreaterThanRight(value, Max)) // value > max
            //    Value = Max;
            else
                Value = value;

            if (oldValue!.Equals(Value))
                await JSRuntime.InvokeVoidAsync("window.vengage.input.setValue", Id, Value);

            await SetValue(Value);
        }
        protected override async Task OnParametersSetAsync()
        {
            if (!previousValue!.Equals(Value))
            {
                previousValue = Value;

                // Run your JS update logic here
                await JSRuntime.InvokeVoidAsync("window.vengage.input.setValue", Id, Value);
            }
        }

            [JSInvokable]
        public async Task HandleInputClear()
        {
            await ValueChanged.InvokeAsync();
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        [JSInvokable]
        public async Task HandleInputChange(string newValue)
        {
            if (newValue is null || !TryParseValue(newValue, out var value))
                Value = default!;
            //else if (Min is not null && IsLeftGreaterThanRight(Min, value)) // value < min
            //    Value = Min;
            //else if (Max is not null && IsLeftGreaterThanRight(value, Max)) // value > max
            //    Value = Max;
            else
                Value = value;

            await ValueChanged.InvokeAsync(Value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }
        #endregion

        #region State
        private FieldIdentifier fieldIdentifier = default!;
        private DotNetObjectReference<WAInputNumber<TValue>> objRef = default!;
        private string step = default!;
        private TValue previousValue = default!;

        #endregion

        #region Private Methods
        /// <summary>
        /// Determines where the left input is greater than the right input.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>bool</returns>
        private bool IsLeftGreaterThanRight(TValue left, TValue right)
        {
            // sbyte
            if (typeof(TValue) == typeof(sbyte))
            {
                var l = Convert.ToSByte(left);
                var r = Convert.ToSByte(right);

                return l > r;
            }
            // sbyte?

            if (typeof(TValue) == typeof(sbyte?))
            {
                var l = left as sbyte?;
                var r = right as sbyte?;

                return l.HasValue && r.HasValue && l > r;
            }
            // short / int16

            if (typeof(TValue) == typeof(short))
            {
                var l = Convert.ToInt16(left);
                var r = Convert.ToInt16(right);

                return l > r;
            }
            // short? / int16?

            if (typeof(TValue) == typeof(short?))
            {
                var l = left as short?;
                var r = right as short?;

                return l.HasValue && r.HasValue && l > r;
            }
            // int

            if (typeof(TValue) == typeof(int))
            {
                var l = Convert.ToInt32(left);
                var r = Convert.ToInt32(right);

                return l > r;
            }
            // int?

            if (typeof(TValue) == typeof(int?))
            {
                var l = left as int?;
                var r = right as int?;

                return l.HasValue && r.HasValue && l > r;
            }
            // long

            if (typeof(TValue) == typeof(long))
            {
                var l = Convert.ToInt64(left);
                var r = Convert.ToInt64(right);

                return l > r;
            }
            // long?

            if (typeof(TValue) == typeof(long?))
            {
                var l = left as long?;
                var r = right as long?;

                return l.HasValue && r.HasValue && l > r;
            }
            // float / single

            if (typeof(TValue) == typeof(float))
            {
                var l = Convert.ToSingle(left);
                var r = Convert.ToSingle(right);

                return l > r;
            }
            // float? / single?

            if (typeof(TValue) == typeof(float?))
            {
                var l = left as float?;
                var r = right as float?;

                return l.HasValue && r.HasValue && l > r;
            }
            // double

            if (typeof(TValue) == typeof(double))
            {
                var l = Convert.ToDouble(left);
                var r = Convert.ToDouble(right);

                return l > r;
            }
            // double?

            if (typeof(TValue) == typeof(double?))
            {
                var l = left as double?;
                var r = right as double?;

                return l.HasValue && r.HasValue && l > r;
            }
            // decimal

            if (typeof(TValue) == typeof(decimal))
            {
                var l = Convert.ToDecimal(left);
                var r = Convert.ToDecimal(right);

                return l > r;
            }
            // decimal?

            if (typeof(TValue) == typeof(decimal?))
            {
                var l = left as decimal?;
                var r = right as decimal?;

                return l.HasValue && r.HasValue && l > r;
            }

            return false;
        }

        private bool TryParseValue(object value, out TValue newValue)
        {
            try
            {
                // sbyte? / sbyte
                if (typeof(TValue) == typeof(sbyte?) || typeof(TValue) == typeof(sbyte))
                {
                    newValue = (TValue)Convert.ChangeType(value, typeof(sbyte));

                    return true;
                }
                // short? / short

                if (typeof(TValue) == typeof(short?) || typeof(TValue) == typeof(short))
                {
                    newValue = (TValue)Convert.ChangeType(value, typeof(short));

                    return true;
                }
                // int? / int

                if (typeof(TValue) == typeof(int?) || typeof(TValue) == typeof(int))
                {
                    newValue = (TValue)Convert.ChangeType(value, typeof(int));

                    return true;
                }
                // long? / long

                if (typeof(TValue) == typeof(long?) || typeof(TValue) == typeof(long))
                {
                    newValue = (TValue)Convert.ChangeType(value, typeof(long));

                    return true;
                }
                // float? / float

                if (typeof(TValue) == typeof(float?) || typeof(TValue) == typeof(float))
                {
                    newValue = (TValue)Convert.ChangeType(value, typeof(float), CultureInfo.InvariantCulture);

                    return true;
                }
                // double? / double

                if (typeof(TValue) == typeof(double?) || typeof(TValue) == typeof(double))
                {
                    newValue = (TValue)Convert.ChangeType(value, typeof(double), CultureInfo.InvariantCulture);

                    return true;
                }
                // decimal? / decimal

                if (typeof(TValue) == typeof(decimal?) || typeof(TValue) == typeof(decimal))
                {
                    newValue = (TValue)Convert.ChangeType(value, typeof(decimal), CultureInfo.InvariantCulture);

                    return true;
                }

                newValue = default!;

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"exception: {ex.Message}");
                newValue = default!;

                return false;
            }
        }
        #endregion

        #region Public Methods
        public async Task SetValue(TValue value)
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.input.setValue", Id, value);
            await ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        public async Task SetFocusAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.input.setFocus", Id);
        }
        #endregion

    }


}
