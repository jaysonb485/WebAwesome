# WANumberInput
## WebAwesomeBlazor.Components.WANumberInput

```HTML+Razor
<WANumberInput @bind-Value="inputNumber" TValue="int" />
```

### Description
Number inputs allow users to enter and edit numeric values with optional stepper buttons.

[Web Awesome docs](https://webawesome.com/docs/components/number-input)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Appearance | NumberInputAppearance | NumberInputAppearance.Outlined | The input's visual appearance. |
| Autocomplete | string |  | Specifies what permission the browser has to provide assistance in filling out form field values. Refer to [this page on MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete) for available values.. |
| Autofocus | bool | false | Automatically focuses the input when the component is rendered. |
| DecrementIcon | [Icon](/docs/IconClass.md) || An icon to use in lieu of the default decrement icon. Alternatively, use DecrementIconName to specify the name of the icon. |
| DecrementIconName | string | | An icon to use in lieu of the default decrement icon. Available names depend on the icon library being used. |
| Disabled | bool | false | Maked the input disabled. |
| EndIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. Alternatively, use EndIconName to specify the name of the icon. |
| EndIconName    | string  |       |The name of the icon to draw in the end slot. Available names depend on the icon library being used.  |
| EnterKeyHint | NumberInputEnterKeyHint |  | Used to customize the label or icon of the Enter key on virtual keyboards. |
| Hint | string |  | The input's hint text. |
| IncrementIcon | [Icon](/docs/IconClass.md) || An icon to use in lieu of the default increment icon. Alternatively, use IncrementIconName to specify the name of the icon. |
| IncrementIconName | string | | An icon to use in lieu of the default increment icon.  Available names depend on the icon library being used. |
| Label | string |  | The input's label |
| Max | double |  | The input's maximum value |
| Min | double |  | The input's minimum value |
| Pill | bool | False | Draws a pill-style input with rounded edges. |
| Placeholder | string |  | Placeholder text to show as a hint when the input is empty. |
| ReadOnly | bool | false | Makes the input readonly. |
| Required | bool | false | Makes the input a required field. |
| Size | NumberInputSize | NumberInputSize.Medium | The input's size. |
| StartIcon | [Icon](/docs/IconClass.md) || The icon to draw in the start slot. Alternatively, use StartIconName to specify the name of the icon. |
| StartIconName | string | | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| Step | decimal |  | Specifies the granularity that the value must adhere to. |
| TValue | Type | int | The numeric type of the input (e.g., int, double, decimal). |
| Value | TValue |  | The current value of the input |
| WithoutSteppers | bool | false | Hides the increment/decrement stepper buttons. Defaults to false. |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| ValueChanged (\<TValue>)  | Triggered when the input's value has changed |


### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetValueAsync  | value: string   | Sets the value of the input |
| SetFocusAsync |  | Sets focus to the input element. |
| StepUpAsync |  | Increments the value by the amount specified in the Step property. |
| StepDownAsync |  | Decrements the value by the amount specified in the Step property. |

### Examples

#### Basic Usage
```HTML+Razor
    <WANumberInput TValue="int"
                   @bind-Value="@inputNumber"
                   Label="Input Number"
                   Placeholder="Enter a number"
                   Hint="This is a number input" />
```

#### Decimal input with minimum and maximum values
```HTML+Razor
    <WANumberNumber TValue="decimal"
                   @bind-Value="@inputDecimal"
                   Label="Input Decimal"
                   Placeholder="Enter a decimal"
                   Hint="This is a decimal number input with minimum and maximum values"
                   Max="5"
                   Min="3" />
```

#### Custom increment and decrement icons, without steppers
```HTML+Razor
    <WANumberInput TValue="int"
                   @bind-Value="@inputNumber"
                   Label="Custom Icons"
                   Placeholder="Enter a number"
                   Hint="This number input uses custom increment and decrement icons"
                   IncrementIconName="caret-up"
                   DecrementIconName="caret-down"
                   />
```
