# WAInputNumber
## WebAwesomeBlazor.Components.WAInputNumber

```HTML+Razor
<WAInputNumber @bind-Value="inputNumber" TValue="int" />
```

### Description
A numeric input component that allows users to enter and manipulate numerical values with ease. It supports features like min/max limits, step increments, and formatting options.

[WebAwesome docs](https://webawesome.com/docs/component)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| TValue | Type | int | The numeric type of the input (e.g., int, double, decimal). |
| Value | TValue |  | The current value of the input |
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
| WithoutSpinButtons | bool | false | Hides the browser's built-in increment/decrement spin buttons for number inputs. Defaults to false. |
| EndIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. Alternatively, use EndIconName to specify the name of the icon. |
| EndIconName    | string  |       |The name of the icon to draw in the end slot. Available names depend on the icon library being used.  |
| StartIcon | [Icon](/docs/IconClass.md) || The icon to draw in the start slot. Altneratively, use StartIconName to specify the name of the icon. |
| StartIconName | string | | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| Step | decimal |  | Specifies the granularity that the value must adhere to. |
| Max | double |  | The input's maximum value |
| Min | double |  | The input's minimum value |


### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetValue  | value: string   | Sets the value of the input |
| SetFocusAsync |  | Sets focus to the input element. |

### Examples

#### Basic Usage
```HTML+Razor
    <WAInputNumber TValue="int"
                   @bind-Value="@inputNumber"
                   Label="Input Number"
                   Placeholder="Enter a number"
                   Hint="This is a number input" />
```

#### Decimal input with minimum and maximum values
```HTML+Razor
    <WAInputNumber TValue="decimal"
                   @bind-Value="@inputDecimal"
                   Label="Input Decimal"
                   Placeholder="Enter a decimal"
                   Hint="This is a decimal number input with minimum and maximum values"
                   Max="5"
                   Min="3" />
```

![WAInputNumber](https://github.com/user-attachments/assets/7e22e905-35f8-4a82-b811-0903b14c6986)