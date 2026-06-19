using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Globalization;
using System.Linq.Expressions;

namespace WebAwesomeBlazor.Components
{
    public partial class WADatePicker<TValue> : WAComponentBase
    {
        #region Parameters

        [CascadingParameter] private EditContext EditContext { get; set; } = default!;

        [Parameter]
        public TValue Value { get; set; } = default!;

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; } = default!;

        [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; } = default!;

        [Parameter]
        public DateRange<TValue> ValueRange { get; set; } = default!;

        [Parameter]
        public EventCallback<DateRange<TValue>> ValueRangeChanged { get; set; } = default!;
        [Parameter] public Expression<Func<DateRange<TValue>>> ValueRangeExpression { get; set; } = default!;

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
        /// The first day of the week. The default uses the current locale's week info.
        /// </summary>
        [Parameter]
        public DatePickerDayOfTheWeek? FirstDayOfWeek { get; set; }

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

        [Parameter]
        public DateOnly? Today { get; set; }


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

        /// <summary>
        /// Customise the content of day cells in the date picker. Use type <WADatePickerDay>
        /// </summary>
        [Parameter]
        public RenderFragment? CustomDayContent { get; set; }

        [Parameter]
        public RenderFragment? HeaderContent { get; set; }

        /// <summary>
        /// The weekday header format.
        /// </summary>
        [Parameter]
        public DatePickerWeekdayFormat WeekdayFormat { get; set; } = DatePickerWeekdayFormat.Short;

        #endregion

        #region Computed  Properties

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


        string WeekdayFormatString
        {
            get
            {
                return WeekdayFormat switch
                {
                    DatePickerWeekdayFormat.Narrow => "narrow",
                    DatePickerWeekdayFormat.Short => "short",
                    DatePickerWeekdayFormat.Long => "long",
                    _ => "short"
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
                _ = TryParseValue(value, out TValue newValue);
                await ValueChanged.InvokeAsync(newValue);
                EditContext?.NotifyFieldChanged(fieldIdentifier);
            }
            else
            {
                var parts = value.Split("/");
                if (parts.Length == 2)
                {
                    _ = TryParseValue(parts[0], out TValue start);
                    _ = TryParseValue(parts[1], out TValue end);
                    var newValue = new DateRange<TValue>(start, end);
                    await ValueRangeChanged.InvokeAsync(newValue);
                    EditContext?.NotifyFieldChanged(fieldIdentifier);
                }
            }
        }
        private async Task OnValueChanged(ChangeEventArgs e)
        {
            var oldValue = Value;

            // When pressing 0 first the component falls back to default value
            // We can avoid this by checking for an empty string first
            if (e.Value is string tmp && tmp != string.Empty)
            {
                if (SelectionMode == DatePickerSelectionMode.Single)
                {
                    _ = TryParseValue(e.Value, out TValue newValue);
                    await SetValueAsync(oldValue, newValue);
                    this.oldValue = newValue;
                    await ValueChanged.InvokeAsync(newValue);
                    EditContext?.NotifyFieldChanged(fieldIdentifier);
                }
                else
                {
                    var parts = (e.Value as string)!.Split("/");
                    if (parts.Length == 2)
                    {
                        _ = TryParseValue(parts[0], out TValue start);
                        _ = TryParseValue(parts[1], out TValue end);
                        var newValue = new DateRange<TValue>(start, end);
                        await ValueRangeChanged.InvokeAsync(newValue);
                        EditContext?.NotifyFieldChanged(fieldIdentifier);
                        this.oldValueRange = newValue;
                    }
                }

            }
        }

        #endregion

        #region State
        private string? formattedValue;
        private TValue? oldValue;
        private DateRange<TValue>? oldValueRange;

        private FieldIdentifier fieldIdentifier = default!;
        private DotNetObjectReference<WADatePicker<TValue>> objRef = default!;
        #endregion

        #region Private Methods
        private static string GetFormattedValue(object value)
        {
            var formattedDate = "";

            try
            {
                if (value is null)
                    return formattedDate;

                // DateOnly / DateOnly?
                if (typeof(TValue) == typeof(DateOnly) || typeof(TValue) == typeof(DateOnly?))
                {
                    if (DateTime.TryParse(value.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out var dt)) formattedDate = dt.ToString("yyyy-MM-dd");
                }
                // DateTime / DateTime?
                else if (typeof(TValue) == typeof(DateTime) || typeof(TValue) == typeof(DateTime?))
                {
                    var d = Convert.ToDateTime(value, CultureInfo.CurrentCulture); // TODO: update this with .NET 8 upgrade
                    formattedDate = d.ToString("yyyy-MM-dd");
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
                formattedValue = WADatePicker<TValue>.GetFormattedValue(Value);
            }



            if (oldValue is null || oldValue!.Equals(Value))
            {
                await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
                await SafeInvokeVoidAsync("setValue", Id!, formattedValue);
            }

            await ValueChanged.InvokeAsync(Value);

            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        private async Task SetValueRangeAsync(DateRange<TValue>? oldValueRange, DateRange<TValue>? newValueRange)
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

        public async Task GoToDateAsync(DateOnly date)
        {
            await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
            await SafeInvokeVoidAsync("pickerGoToDate", Id!, GetFormattedValue(date));
        }

        public async Task GoToDateAsync(DateTime date)
        {
            await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
            await GoToDateAsync(DateOnly.FromDateTime(date));
        }

        public async Task GoToTodayAsync()
        {
            await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
            await SafeInvokeVoidAsync("pickerGoToToday", Id!);
        }
        #endregion
    }


}


