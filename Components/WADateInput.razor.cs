using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Linq.Expressions;

namespace WebAwesomeBlazor.Components
{
    public partial class WADateInput : WAComponentBase
    {
        #region Parameters

        [CascadingParameter] private EditContext EditContext { get; set; } = default!;

        [Parameter]
        public DateOnly? Value { get; set; } = default!;

        [Parameter]
        public EventCallback<DateOnly?> ValueChanged { get; set; } = default!;

        [Parameter] public Expression<Func<DateOnly?>> ValueExpression { get; set; } = default!;

        [Parameter]
        public DateRange? ValueRange { get; set; } = default!;

        [Parameter]
        public EventCallback<DateRange?> ValueRangeChanged { get; set; } = default!;
        [Parameter] public Expression<Func<DateRange?>> ValueRangeExpression { get; set; } = default!;


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
        /// An array of dates that are not selectable.
        /// </summary>
        [Parameter]
        public DateOnly[]? DisabledDates { get; set; }

        /// <summary>
        /// A list of days of the week that are not selectable.
        /// </summary>
        [Parameter]
        public List<DatePickerDayOfTheWeek> DisabledDaysOfTheWeek { get; set; } = new();

        /// <summary>
        /// Disables selection of future dates after today.
        /// </summary>
        [Parameter]
        public bool DisableFutureDates { get; set; } = false;

        /// <summary>
        /// Disables selection of past dates before today.
        /// </summary>
        [Parameter]
        public bool DisablePastDates { get; set; } = false;

        /// <summary>
        /// Distance in pixels between the popup and the input.
        /// </summary>
        [Parameter]
        public int PopupDistance { get; set; } = 0;

        /// <summary>
        /// The first day of the week. The default uses the current locale's week info.
        /// </summary>
        [Parameter]
        public DatePickerDayOfTheWeek? FirstDayOfWeek { get; set; }


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
        /// The latest selectable date 
        /// </summary>
        [Parameter]
        public DateOnly? MaximumDate { get; set; }

        /// <summary>
        /// Maximum range length in days (mode="range" only). 0 disables the check.
        /// </summary>
        [Parameter]
        public int? MaximumRange { get; set; } = 0;
        /// <summary>
        /// The earliest selectable date
        /// </summary>
        [Parameter]
        public DateOnly? MinimumDate { get; set; }
        /// <summary>
        /// Minimum range length in days (mode="range" only). 0 disables the check.
        /// </summary>
        [Parameter]
        public int? MinimumRange { get; set; } = 0;

        [Parameter]
        public DatePickerSelectionMode SelectionMode { get; set; } = DatePickerSelectionMode.Single;

        [Parameter]
        public bool ShowTwoMonths { get; set; } = false;

        /// <summary>
        /// Whether previous and next page by the visible range or on month at a time. The default is true (page by month).
        /// </summary>
        [Parameter]
        public bool PageByMonths { get; set; } = true;



        /// <summary>
        /// Draws a pill-style input with rounded edges.
        /// </summary>
        [Parameter]
        public bool Pill { get; set; } = false;

        [Parameter]
        public DateInputPlacement PopupPlacement { get; set; } = DateInputPlacement.BottomStart;


        /// <summary>
        /// Makes the input readonly.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;
        /// <summary>
        /// Ensures a child radio is checked before allowing the containing form to submit.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;


        /// <summary>
        /// The input's size.
        /// </summary>
        [Parameter]
        public InputSize Size { get; set; } = InputSize.Medium;

        [Parameter]
        public DateOnly? Today { get; set; }


        /// <summary>
        /// Adds a clear button (with-clear) when the input is not empty.
        /// </summary>
        [Parameter]
        public bool Clearable { get; set; } = false;




        /// <summary>
        /// An icon used for the previous paging slot.
        /// </summary>
        [Parameter]
        public string? PreviousIconName { get; set; }
        /// <summary>
        /// An icon used for the previous paging slot.
        /// </summary>
        [Parameter]
        public Icon? PreviousIcon { get; set; }
        /// <summary>
        /// An icon used for the next paging slot
        /// </summary>
        [Parameter]
        public string? NextIconName { get; set; }
        /// <summary>
        /// An icon used for the next paging slot
        /// </summary>
        [Parameter]
        public Icon? NextIcon { get; set; }

        /// <summary>
        /// Indicates that the input should receive focus on page load.
        /// </summary>
        [Parameter]
        public bool Autofocus { get; set; } = false;

        /// <summary>
        /// Show leading/trailing days from adjacent months in the popup calendar.
        /// </summary>
        [Parameter]
        public bool ShowOutsideDays { get; set; } = false;

        /// <summary>
        /// Show ISO 8601 week numbers in the popup calendar.
        /// </summary>
        [Parameter]
        public bool ShowWeekNumbers { get; set; } = false;


        [Parameter]
        public RenderFragment? FooterContent { get; set; }

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

        string DisabledDatesString
        {
            get
            {
                if (DisabledDates is null) return string.Empty;

                return string.Join(" ", DisabledDates.Select(d => d.ToString("yyyy-MM-dd")));
            }
        }

        string DisabledDaysOfTheWeekString
        {
            get
            {
                var disabledDays = new List<string>();
                disabledDays = [.. DisabledDaysOfTheWeek.Select(d => d switch
                {
                    DatePickerDayOfTheWeek.Sunday => "sun",
                    DatePickerDayOfTheWeek.Monday => "mon",
                    DatePickerDayOfTheWeek.Tuesday => "tue",
                    DatePickerDayOfTheWeek.Wednesday => "wed",
                    DatePickerDayOfTheWeek.Thursday => "thu",
                    DatePickerDayOfTheWeek.Friday => "fri",
                    DatePickerDayOfTheWeek.Saturday => "sat",
                    _ => ""
                })];

                return string.Join(" ", disabledDays);
            }
        }

        string FirstDayOfTheWeekString
        {
            get
            {
                return FirstDayOfWeek switch
                {
                    DatePickerDayOfTheWeek.Sunday => "sun",
                    DatePickerDayOfTheWeek.Monday => "mon",
                    DatePickerDayOfTheWeek.Tuesday => "tue",
                    DatePickerDayOfTheWeek.Wednesday => "wed",
                    DatePickerDayOfTheWeek.Thursday => "thu",
                    DatePickerDayOfTheWeek.Friday => "fri",
                    DatePickerDayOfTheWeek.Saturday => "sat",
                    _ => "auto"
                };
            }
        }

        string SelectionModeString
        {
            get
            {
                return SelectionMode switch
                {
                    DatePickerSelectionMode.Single => "single",
                    DatePickerSelectionMode.Range => "range",
                    _ => "single"
                };
            }
        }

        string PopupPlacementString
        {
            get
            {
                return PopupPlacement switch
                {
                    DateInputPlacement.BottomStart => "bottom-start",
                    DateInputPlacement.BottomEnd => "bottom-end",
                    DateInputPlacement.TopStart => "top-start",
                    DateInputPlacement.TopEnd => "top-end",
                    DateInputPlacement.Top => "top",
                    DateInputPlacement.Bottom => "bottom",
                    DateInputPlacement.Right => "right",
                    DateInputPlacement.RightStart => "right-start",
                    DateInputPlacement.RightEnd => "right-end",
                    DateInputPlacement.Left => "left",
                    DateInputPlacement.LeftStart => "left-start",
                    DateInputPlacement.LeftEnd => "left-end",
                    _ => "bottom-start"
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

                if (SelectionMode == DatePickerSelectionMode.Single)
                {
                    await SetValueAsync(oldValue, Value);
                }
                else
                {
                    await SetValueRangeAsync(oldValueRange, ValueRange);
                }

                //await ValueChanged.InvokeAsync(Value);
            }

            await base.OnAfterRenderAsync(firstRender);

        }

        protected override async Task OnInitializedAsync()
        {

            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= [];

            if (ValueExpression != null)
                fieldIdentifier = FieldIdentifier.Create(ValueExpression);

            if (ValueRangeExpression != null)
                fieldIdentifier = FieldIdentifier.Create(ValueRangeExpression);

            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (SelectionMode == DatePickerSelectionMode.Single)
            {
                if ((oldValue is null && Value is not null)
                    || (oldValue is not null && Value is null)
                    || !oldValue!.Equals(Value))
                {
                    await SetValueAsync(oldValue!, Value);
                    oldValue = Value;
                }
            }
            else
            {
                if ((oldValueRange is null && ValueRange is not null)
                    || (oldValueRange is not null && ValueRange is null)
                    || (oldValueRange is not null && !oldValueRange!.Equals(ValueRange)))
                {
                    await SetValueRangeAsync(oldValueRange!, ValueRange);
                    oldValueRange = ValueRange;
                }
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
            if (SelectionMode == DatePickerSelectionMode.Single)
            {

                await ValueChanged.InvokeAsync(default!);
                EditContext?.NotifyFieldChanged(fieldIdentifier);
            }
            else
            {
                await ValueRangeChanged.InvokeAsync(default!);
                EditContext?.NotifyFieldChanged(fieldIdentifier);
            }
        }

        [JSInvokable]
        public async Task HandleInputChange(string value)
        {
            if (SelectionMode == DatePickerSelectionMode.Single)
            {
                if (DateOnly.TryParse(value, out DateOnly newValue))
                {
                    await ValueChanged.InvokeAsync(newValue);
                    EditContext?.NotifyFieldChanged(fieldIdentifier);
                }
            }
            else
            {
                var parts = value.Split("/");
                if (parts.Length == 2
                    && DateOnly.TryParse(parts[0], out DateOnly start)
                    && DateOnly.TryParse(parts[1], out DateOnly end))
                {
                    var newValue = new DateRange(start, end);
                    await ValueRangeChanged.InvokeAsync(newValue);
                    EditContext?.NotifyFieldChanged(fieldIdentifier);
                }
            }


        }

        #endregion

        #region State
        private string? formattedValue;
        private DateOnly? oldValue;
        private DateRange? oldValueRange;

        private FieldIdentifier fieldIdentifier = default!;
        private DotNetObjectReference<WADateInput> objRef = default!;
        #endregion

        #region Private Methods


        private async Task SetValueAsync(DateOnly? oldValue, DateOnly? newValue)
        {
            if (newValue is null)
            {
                Value = default!;
                formattedValue = "";
            }
            else
            {
                Value = newValue;
                formattedValue = Value.Value.ToString("yyyy-MM-dd");
            }



            if (oldValue is null || oldValue!.Equals(Value))
            {
                await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
                await SafeInvokeVoidAsync("setValue", Id!, formattedValue);
            }

            await ValueChanged.InvokeAsync(Value);

            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        private async Task SetValueRangeAsync(DateRange? oldValueRange, DateRange? newValueRange)
        {
            if (newValueRange is null)
            {
                ValueRange = default!;
                formattedValue = "";
            }
            else
            {
                ValueRange = newValueRange;
                formattedValue = $"{ValueRange.Start:yyyy-MM-dd}/{ValueRange.End:yyyy-MM-dd}";
            }

            if (oldValueRange is null || oldValueRange!.Equals(ValueRange))
            {
                await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
                await SafeInvokeVoidAsync("setValue", Id!, formattedValue);
            }

            await ValueRangeChanged.InvokeAsync(ValueRange);

            EditContext?.NotifyFieldChanged(fieldIdentifier);

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

    public class DateRange(DateOnly start, DateOnly end)
    {
        public DateOnly Start { get; set; } = start;
        public DateOnly End { get; set; } = end;
    }
}


