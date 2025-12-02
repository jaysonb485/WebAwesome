# WAInput
## WebAwesomeBlazor.Components.WAInput

```HTML+Razor
<WAInput @bind-Value="" />
```

### Description
Inputs collect data from the user.

[WebAwesome docs](https://webawesome.com/docs/components/input/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value | string |  | The current value of the input |
| Type | InputType | InputType.Text | The type of input (Valid input types are Date, DateTimeLocal, Email, Number, Password, Search, Telephone, Text, Time, Url). |
| ValueChanged | EventCallback<string> |  | Triggered when the input's value has changed |
| Appearance | InputAppearance | InputAppearance.Outlined | The input's visual appearance. |
| Size | InputSize | InputSize.Inherit | The input's size. |
| Pill | bool | False | Draws a pill-style input with rounded edges. |
| Label | string |  | The input's label |
| Hint | string |  | The input's hint text. |
| Placeholder | string |  | Placeholder text to show as a hint when the input is empty. |
| Clearable | bool | false | Adds a clear button when the input is not empty. |
| ReadOnly | bool | false | Makes the input readonly. |
| Disabled | bool | false | Maked the input disabled. |
| PasswordToggle | bool | false | Adds a button to toggle the password's visibility. Only applies to password types. |
| Required | bool | false | Makes the input a required field. |
| WithoutSpinButtons | bool | false | Hides the browser's built-in increment/decrement spin buttons for number inputs. Defaults to false. |
| EndIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. Alternatively, use EndIconName to specify the name of the icon. |
| EndIconName    | string  |       |The name of the icon to draw in the end slot. Available names depend on the icon library being used.  |
| StartIcon | [Icon](/docs/IconClass.md) || The icon to draw in the start slot. Altneratively, use StartIconName to specify the name of the icon. |
| StartIconName | string | | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetValue  | value: string   | Sets the value of the input |
| SetValueAsync  | value: string   | Sets the value of the input |
| SetFocus |  | Sets focus to the input element. |
| SetFocusAsync |  | Sets focus to the input element. |


### Examples

#### Basic Usage
```HTML+Razor
<WAInput @bind-Value="@inputValue" 
	Label="Enter some text"
	Hint="You can enter anything"
	Placeholder="Text" />
```

#### Clearable, password type with start icon, and password toggle
```HTML+Razor
<WAInput @bind-Value="@userPassword"
	Label="Enter your password"
	Type="InputType.Password"
	Clearable="true"
	PasswordToggle="true"
	StartIconName="lock" />
```

![WAInput](https://github.com/user-attachments/assets/8bb3c022-a348-4f1f-8998-75a92703d3fe)