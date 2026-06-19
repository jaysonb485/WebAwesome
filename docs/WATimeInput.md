# WATimeInput
## WebAwesomeBlazor.Components.WATimeInput

```HTML+Razor
<WATimeInput @bind-Value="myTime" />
```

### Description
Date inputs let users enter a date through a segmented field or select one visually from a popup calendar. They support locale-aware segment order, min and max constraints, and form validation.

[Web Awesome docs](https://webawesome.com/docs/components/time-input)

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
| Clearable | bool | false | Adds a clear button when the input is not empty. |
| Disabled | bool | false | Maked the input disabled. |
| EndContent | RenderFragment | | An element placed at the end of the input. |
| FooterContent | RenderFragment? |  | Custom content to show in the popup calendar's footer. |
| Hint | string |  | The input's hint text. |
| HourFormat | TimeInputHourFormat | TimeInputHourFormat.Auto | Whether the UI uses a 12-hour or 24-hour clock. Auto follows the resolved locale. |
| Label | string |  | The input's label |
| MaximumTime | TimeOnly? |  | The maximum time that can be selected. |
| MinimumTime | TimeOnly? |  | The minimum time that can be selected. |
| Pill | bool | False | Draws a pill-style input with rounded edges. |
| PopupDistance | int | 0 | The distance in pixels between the input and the popup calendar. |
| PopupPlacement | DateInputPlacement | DateInputPlacement.BottomStart | The placement of the popup calendar relative to the input. |
| ReadOnly | bool | false | Makes the input readonly. |
| Required | bool | false | Makes the input a required field. |
| Size | InputSize | InputSize.Medium | The input's size. |
| ShowNowButton | bool | false | Renders a "Now" button in the popup footer. |
| StartContent | RenderFragment | | An element placed at the start of the input. |
| Step | int | | The granularity, in seconds. Values below 60 reveal the seconds segment. | 
| ClearIcon    | [Icon](/docs/IconClass.md) |  |An icon to use in lieu of the default clear icon. |
| ClearIconName    | string  |       |An icon to use in lieu of the default clear icon.  |
| ExpandIcon | [Icon](/docs/IconClass.md) || The icon to show on the popup toggle button. Defaults to a clock icon. Alternatively, use ExpandIconName to specify the name of the icon. |
| ExpandIconName | string | | The icon to show on the popup toggle button. Defaults to a clock icon. Available names depend on the icon library being used. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetFocus |  | Sets focus to the input element. |
| SetFocusAsync |  | Sets focus to the input element. |
| ShowPickerAsync | | Shows the time picker | 
| HidePickerAsync | | Hides the time picker |

### Examples

#### Basic Usage
```HTML+Razor
<WATimeInput @ref="TimeInput" @bind-Value="selectedTime" Label="Select a time" />

Selected time: @(selectedTime is not null ? selectedTime.Value.ToLongTimeString() : "not set")

@code {
	TimeOnly? selectedTime {get; set;}
}
```
