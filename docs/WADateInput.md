# WADateInput
## WebAwesomeBlazor.Components.WADateInput

```HTML+Razor
<WADateInput @bind-Value="myDate" />
<WADateInput @bind-ValueRange="myDateRange" />
```

### Description
Date inputs let users enter a date through a segmented field or select one visually from a popup calendar. They support locale-aware segment order, min and max constraints, and form validation.

[Web Awesome docs](https://webawesome.com/docs/components/date-input)

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
| Appearance | InputAppearance | InputAppearance.Outlined | The input's visual appearance. |
| Autocomplete | string |  | Specifies what permission the browser has to provide assistance in filling out form field values. Refer to [this page on MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete) for available values.. |
| Autofocus | bool | false | Automatically focuses the input when it is rendered. |
| Clearable | bool | false | Adds a clear button when the input is not empty. |
| CustomDayContent | RenderFragment |  | Customise the content of day cells in the date picker. Use type `<WADatePickerDay>` |
| Disabled | bool | false | Maked the input disabled. |
| DisabledDates | DateOnly[]? |  | An array of dates that should be disabled for selection. |
| DisabledDaysOfTheWeek | List\<DatePickerDayOfTheWeek> |  | A list of days of the week that should be disabled for selection. |
| DisableFutureDates | bool | false | Disables selection of future dates. |
| DisablePastDates | bool | false | Disables selection of past dates. |
| FirstDayOfWeek | DatePickerDayOfTheWeek | | The first day of the week to use in the calendar. The default uses the current locale's week info. |
| FooterContent | RenderFragment? |  | Custom content to show in the popup calendar's footer. |
| Hint | string |  | The input's hint text. |
| Label | string |  | The input's label |
| MaximumDate | DateOnly? |  | The maximum date that can be selected. |
| MaximumRange | int? | 0 | The maximum number of days that can be selected when ValueRange is set. 0 disables the check.|
| MinimumDate | DateOnly? |  | The minimum date that can be selected. |
| MinimumRange | int? | 0 | The minimum number of days that can be selected when ValueRange is set. 0 disables the check. |
| PageByMonths | bool | true | Whether previous and next page by the visible range or on month at a time. The default is true (page by month). |
| Pill | bool | False | Draws a pill-style input with rounded edges. |
| PopupDistance | int | 0 | The distance in pixels between the input and the popup calendar. |
| PopupPlacement | DateInputPlacement | DateInputPlacement.BottomStart | The placement of the popup calendar relative to the input. |
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
| WeekdayFormat | DatePickerWeekdayFormat | DatePickerWeekdayFormat.Short | Weekday header format in the popup calendar. Values are narrow, short, long. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetFocus |  | Sets focus to the input element. |
| SetFocusAsync |  | Sets focus to the input element. |
| ShowPickerAsync | | Shows the date picker | 
| HidePickerAsync | | Hides the date picker |

### Examples

#### Basic Usage - Single date selection
```HTML+Razor
<WADateInput Label="Select a date" @bind-Value="myDate" />

Selected date: @myDate

@code {
	DateOnly? myDate {get; set;}
}
```

#### Basic Usage - Date range selection
```HTML+Razor
<WADateInput Label="Select a date range" @bind-ValueRange="myDateRange" />

Selected date range: @(myDateRange is not null ? $"{myDateRange.Start} to {myDateRange.End}" : "not set")

@code {
	DateRange<DateOnly?> myDateRange {get; set;} = default!;
}
```
#### Customise day content and paging icons
```HTML+Razor
<WADateInput Label="Select a date range" NextIconName="hand-point-right" PreviousIconName="hand-point-left">
    <CustomDayContent>
        <WADatePickerDay Date="@(new DateOnly(2026,06,30))" Title="End of financial year">💸</WADatePickerDay>
    </CustomDayContent>
</WADateInput>
```
