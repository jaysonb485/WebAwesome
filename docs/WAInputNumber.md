# WAInputNumber
## WebAwesomeBlazor.Components.WAInputNumber

```HTML+Razor
<WAInputNumber @bind-Value="inputNumber" TValue="int" />
```

### Description
A numeric input component that allows users to enter and manipulate numerical values with ease. It supports features like min/max limits, step increments, and formatting options.

[Web Awesome docs](https://webawesome.com/docs/components/input/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Appearance | InputAppearance | InputAppearance.Outlined | The input's visual appearance. |
| Autofocus | bool | false | Automatically focuses the input when it is rendered. |
| Autocomplete | string |  | Specifies what permission the browser has to provide assistance in filling out form field values. Refer to [this page on MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete) for available values. |
| Clearable | bool | false | Adds a clear button when the input is not empty. |
| Disabled | bool | false | Maked the input disabled. |
| EndIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. Alternatively, use EndIconName to specify the name of the icon. |
| EndIconName    | string  |       |The name of the icon to draw in the end slot. Available names depend on the icon library being used.  |
| Hint | string |  | The input's hint text. |
| Label | string |  | The input's label |
| Max | double |  | The input's maximum value |
| Min | double |  | The input's minimum value |
| Pill | bool | False | Draws a pill-style input with rounded edges. |
| Placeholder | string |  | Placeholder text to show as a hint when the input is empty. |
| ReadOnly | bool | false | Makes the input readonly. |
| Required | bool | false | Makes the input a required field. |
| Size | InputSize | InputSize.Inherit | The input's size. |
| StartIcon | [Icon](/docs/IconClass.md) || The icon to draw in the start slot. Altneratively, use StartIconName to specify the name of the icon. |
| StartIconName | string | | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| Step | decimal |  | Specifies the granularity that the value must adhere to. |
| TValue | Type | int | The numeric type of the input (e.g., int, double, decimal). |
| Value | TValue |  | The current value of the input |

| WithoutSpinButtons | bool | false | Hides the browser's built-in increment/decrement spin buttons for number inputs. Defaults to false. |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| ValueChanged (\<TValue>) | Triggered when the input's value has changed |


### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetValueAsync  | value: string   | Sets the value of the input |
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