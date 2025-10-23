# WAInputDateTime
## Vengage.WebAwesome.Components.WAInputDateTime

```HTML+Razor
<WAInputDateTime TValue="DateOnly" @bind-Value="inputDate" InputType="DateTimeInputType.Date" />
```

### Description
An input component that accepts date only, date time, or time selection.

[WebAwesome docs](https://webawesome.com/docs/components/input/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| TValue | Type | |The type of value the input will process. Accepted types are DateOnly, DateOnly?, DateTime, DateTime?, TimeOnly, TimeOnly?
| Value | TValue |  | The current value of the input |
| Type | DateTimeInputType | DateTimeInputType.DateTimeLocal | The type of input (Valid input types are Date, DateTimeLocal, Text, Time). |
| ValueChanged | EventCallback<TValue> |  | Triggered when the input's value has changed |
| Appearance | InputAppearance | InputAppearance.Outlined | The input's visual appearance. |
| Size | InputSize | InputSize.Inherit | The input's size. |
| Pill | bool | False | Draws a pill-style input with rounded edges. |
| Label | string |  | The input's label |
| Hint | string |  | The input's hint text. |
| Placeholder | string |  | Placeholder text to show as a hint when the input is empty. |
| Clearable | bool | false | Adds a clear button when the input is not empty. |
| ReadOnly | bool | false | Makes the input readonly. |
| Disabled | bool | false | Maked the input disabled. |
| Required | bool | false | Makes the input a required field. |
| EndIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. Alternatively, use EndIconName to specify the name of the icon. |
| EndIconName    | string  |       |The name of the icon to draw in the end slot. Available names depend on the icon library being used.  |
| StartIcon | [Icon](/docs/IconClass.md) || The icon to draw in the start slot. Altneratively, use StartIconName to specify the name of the icon. |
| StartIconName | string | | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |

### Examples

#### Basic Usage
```HTML+Razor
<WAInputDateTime Label="Select a date" 
	TValue="DateOnly" 
	@bind-Value="inputDate"
	InputType="DateTimeInputType.Date" 
	Hint="It can be any date, past, now or future" />
```
