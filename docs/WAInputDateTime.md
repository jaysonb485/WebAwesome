# WAInputDateTime
## WebAwesomeBlazor.Components.WAInputDateTime

```HTML+Razor
<WAInputDateTime TValue="DateOnly" @bind-Value="inputDate" InputType="DateTimeInputType.Date" />
```

### Description
An input component that accepts date only, date time, or time selection.

[Web Awesome docs](https://webawesome.com/docs/components/input/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Appearance | InputAppearance | InputAppearance.Outlined | The input's visual appearance. |
| Autocomplete | string |  | Specifies what permission the browser has to provide assistance in filling out form field values. Refer to [this page on MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete) for available values.. |
| Autofocus | bool | false | Automatically focuses the input when it is rendered. |
| Clearable | bool | false | Adds a clear button when the input is not empty. |
| Disabled | bool | false | Maked the input disabled. |
| EndIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. Alternatively, use EndIconName to specify the name of the icon. |
| EndIconName    | string  |       |The name of the icon to draw in the end slot. Available names depend on the icon library being used.  |
| Hint | string |  | The input's hint text. |
| Label | string |  | The input's label |
| Pill | bool | False | Draws a pill-style input with rounded edges. |
| Placeholder | string |  | Placeholder text to show as a hint when the input is empty. |
| ReadOnly | bool | false | Makes the input readonly. |
| Required | bool | false | Makes the input a required field. |
| Size | InputSize | InputSize.Inherit | The input's size. |
| StartIcon | [Icon](/docs/IconClass.md) || The icon to draw in the start slot. Altneratively, use StartIconName to specify the name of the icon. |
| StartIconName | string | | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| TValue | Type | |The type of value the input will process. Accepted types are DateOnly, DateOnly?, DateTime, DateTime?, TimeOnly, TimeOnly?
| Type | DateTimeInputType | DateTimeInputType.DateTimeLocal | The type of input (Valid input types are Date, DateTimeLocal, Text, Time). |
| Value | TValue |  | The current value of the input |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| ValueChanged (\<TValue>) | Triggered when the input's value has changed |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetFocusAsync |  | Sets focus to the input element. |

### Examples

#### Basic Usage
```HTML+Razor
<WAInputDateTime Label="Select a date" 
	TValue="DateOnly" 
	@bind-Value="inputDate"
	InputType="DateTimeInputType.Date" 
	Hint="It can be any date, past, now or future" />
```
![WAInputDateTime](https://github.com/user-attachments/assets/e044aaf8-1927-42e3-8fc1-15419ddbab26)