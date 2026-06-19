# WADatePicker
## WebAwesomeBlazor.Components.WADatePicker
## WebAwesomeBlazor.Components.WADatePickerDay

```HTML+Razor
<WADatePicker @bind-Value="myDate" />
<WADatePicker @bind-ValueRange="myDateRange" SelectionMode="DatePickerSelectionMode.Range" />
<WADatePicker @bind-Value="myDate">
    <CustomDayContent>
        <WADatePickerDay Date="@(new DateOnly(2026,06,30))" Title="End of financial year">💸</WADatePickerDay>
    </CustomDayContent>
</WADatePicker>
```

### Description
Date pickers display a month grid for selecting a single date or a date range inline. Use them when dates need to remain visible, such as in scheduling interfaces or embedded inside another form control.

[Web Awesome docs](https://webawesome.com/docs/components/date-picker)

> [!IMPORTANT]
> WebAwesome charts require access to WebAwesome Pro.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| TValue | Type | |The type of value the input will process. Accepted types are DateOnly, DateOnly?, DateTime, DateTime? |
| Value | TValue |  | The current value of the input |
| ValueChanged | EventCallback\<TValue> |  | Triggered when the input's value has changed |
| ValueRange | DateRange\<TValue> |  | The current value range of the input. When set, the input will allow selection of a date range instead of a single date. |
| ValueRangeChanged | EventCallback<DateRange\<TValue>> |  | Triggered when the input's value range has changed |
| CustomDayContent | RenderFragment |  | Customise the content of day cells in the date picker. Use type `<WADatePickerDay>` |
| Disabled | bool | false | Maked the input disabled. |
| DisabledDates | DateOnly[]? |  | An array of dates that should be disabled for selection. |
| DisabledDaysOfTheWeek | List\<DatePickerDayOfTheWeek> |  | A list of days of the week that should be disabled for selection. |
| DisableFutureDates | bool | false | Disables selection of future dates. |
| DisablePastDates | bool | false | Disables selection of past dates. |
| FirstDayOfWeek | DatePickerDayOfTheWeek | | The first day of the week to use in the calendar. The default uses the current locale's week info. |
| FooterContent | RenderFragment? |  | Custom content to show in the popup calendar's footer. |
| HeaderContent | RenderFragment | | Replaces the entire header row including title and navigation buttons. Advanced use only. |
| Locale | string | | BCP-47 locale override. When empty, the inherited lang attribute is used. |
| MaximumDate | DateOnly? |  | The maximum date that can be selected. |
| MaximumRange | int? | 0 | The maximum number of days that can be selected when ValueRange is set. 0 disables the check.|
| MinimumDate | DateOnly? |  | The minimum date that can be selected. |
| MinimumRange | int? | 0 | The minimum number of days that can be selected when ValueRange is set. 0 disables the check. |
| PageByMonths | bool | true | Whether previous and next page by the visible range or on month at a time. The default is true (page by month). |
| ReadOnly | bool | false | Makes the input readonly. |
| Required | bool | false | Makes the input a required field. |
| SelectionMode | DatePickerSelectionMode | DatePickerSelectionMode.Single | The selection mode of the input. Valid values are Single or Range. |
| ShowOutsideDays | bool | false | Show leading/trailing days from adjacent months in the popup calendar. |
| ShowTwoMonths | bool | false | When true, the popup calendar will show two months side by side. |
| ShowWeekNumbers | bool | false | Show week numbers in the popup calendar. |
| Size | InputSize | InputSize.Medium | The input's size. |
| PreviousIcon    | [Icon](/docs/IconClass.md) |  | An icon used for the previous paging slot. Alternatively, use EndIconName to specify the name of the icon. |
| PreviousIconName    | string  |       |An icon used for the previous paging slot.. Available names depend on the icon library being used.  |
| NextIcon | [Icon](/docs/IconClass.md) || An icon used for the next paging slot.. Altneratively, use StartIconName to specify the name of the icon. |
| NextIconName | string | | An icon used for the next paging slot.. Available names depend on the icon library being used. |
| WeekdayFormat | DatePickerWeekdayFormat | DatePickerWeekdayFormat.Short | Weekday header format. Values are narrow, short, long. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetFocus |  | Sets focus to the input element. |
| SetFocusAsync |  | Sets focus to the input element. |
| GoToDateAsync | | Scrolls the view to show the given date and sets the focused day |
| GoToTodayAsync | | Equivalent to GoToDateAsync(Today) |

### Examples

#### Basic Usage - Single date selection
```HTML+Razor
<WADatePicker Label="Select a date" @bind-Value="myDate" />

Selected date: @myDate

@code {
	DateOnly? myDate {get; set;}
}
```

#### Basic Usage - Date range selection
```HTML+Razor
<WADatePicker Label="Select a date range" @bind-ValueRange="myDateRange" />

Selected date range: @(myDateRange is not null ? $"{myDateRange.Start} to {myDateRange.End}" : "not set")

@code {
	DateRange<DateOnly?> myDateRange {get; set;} = default!;
}
```
#### Customise day content and paging icons
```HTML+Razor
<WADatePicker Label="Select a date range" NextIconName="hand-point-right" PreviousIconName="hand-point-left">
    <CustomDayContent>
        <WADatePickerDay Date="@(new DateOnly(2026,06,30))" Title="End of financial year">💸</WADatePickerDay>
    </CustomDayContent>
</WADateInput>
```
