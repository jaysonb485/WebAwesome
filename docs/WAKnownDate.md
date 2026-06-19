# WAKnownDate
## WebAwesomeBlazor.Components.WAKnownDate

```HTML+Razor
<WAKnownDate TValue="DateOnly" @bind-Value="inputDate" InputType="DateTimeInputType.Date" />
```

### Description
An input component that accepts date only, date time, or time selection.

[WebAwesome docs](https://webawesome.com/docs/components/input/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| TValue | Type | |The type of value the input will process. Accepted types are DateOnly, DateOnly?, DateTime, DateTime?
| Value | TValue |  | The current value of the input |
| ValueChanged | EventCallback\<TValue> |  | Triggered when the input's value has changed |
| Appearance | InputAppearance | InputAppearance.Outlined | The input's visual appearance. |
| Autocomplete | string |  | Specifies what permission the browser has to provide assistance in filling out form field values. Refer to [this page on MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete) for available values.. |
| Autofocus | bool | false | Automatically focuses the input when it is rendered. |
| Disabled | bool | false | Maked the input disabled. |
| Hint | string |  | The input's hint text. |
| Label | string |  | The input's label |
| Locale | string | | BCP-47 locale override. When empty, the inherited lang attribute is used. |
| MaximumDate | DateOnly? | | The latest selectable date. |
| MinimumDate | DateOnly? | | The earliest selectable date. |
| Pill | bool | False | Draws a pill-style input with rounded edges. |
| Placeholder | string |  | Placeholder text to show as a hint when the input is empty. |
| Size | InputSize | InputSize.Inherit | The input's size. |
| ReadOnly | bool | false | Makes the input readonly. |
| Required | bool | false | Makes the input a required field. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetFocus |  | Sets focus to the input element. |
| SetFocusAsync |  | Sets focus to the input element. |

### Examples

#### Basic Usage
```HTML+Razor
<WAKnownDate Label="Enter your date of birth" @bind-Value="@selectedDate" MaximumDate="@(DateOnly.FromDateTime(DateTime.Now.AddYears(-18)))" Hint="You must be at least 18 years old" />
```
