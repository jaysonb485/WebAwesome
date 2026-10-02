# WAInput
## WebAwesomeBlazor.Components.WAInput

```HTML+Razor
<WAInput @bind-Value="" />
```

### Description
Inputs collect data from the user.

[Web Awesome docs](https://webawesome.com/docs/components/input/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Appearance | InputAppearance | InputAppearance.Outlined | The input's visual appearance. |
| AutoCapitalize | InputAutoCapitalize | `null` | Controls whether and how text input is automatically capitalized as it is entered/edited by the user. |
| Autocomplete | string |  | Specifies what permission the browser has to provide assistance in filling out form field values. Refer to [this page on MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete) for available values.. |
| AutoCorrect | bool | true | Indicates whether the browser's autocorrect feature is on or off. |
| Autofocus | bool | false | Automatically focuses the input when it is rendered. |
| Clearable | bool | false | Adds a clear button when the input is not empty. |
| Disabled | bool | false | Maked the input disabled. |
| EndIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. Alternatively, use EndIconName to specify the name of the icon. |
| EndIconName    | string  |       |The name of the icon to draw in the end slot. Available names depend on the icon library being used.  |
| EnterKeyHint | InputEnterKeyHint | `null` | Used to customize the label or icon of the Enter key on virtual keyboards. |
| Hint | string |  | The input's hint text. |
| InputMode | InputInputMode | InputInputMode.Text | Tells the browser what type of data will be entered by the user, allowing it to display the appropriate virtual keyboard on supportive devices. |
| Label | string |  | The input's label |
| PasswordToggle | bool | false | Adds a button to toggle the password's visibility. Only applies to password types. |
| Pill | bool | False | Draws a pill-style input with rounded edges. |
| Placeholder | string |  | Placeholder text to show as a hint when the input is empty. |
| ReadOnly | bool | false | Makes the input readonly. |
| Required | bool | false | Makes the input a required field. |
| Size | InputSize | InputSize.Inherit | The input's size. |
| Spellcheck | bool | false | Enables spellchecking on the input |
| StartIcon | [Icon](/docs/IconClass.md) || The icon to draw in the start slot. Altneratively, use StartIconName to specify the name of the icon. |
| StartIconName | string | | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| Type | InputType | InputType.Text | The type of input (Valid input types are Date, DateTimeLocal, Email, Number, Password, Search, Telephone, Text, Time, Url). |
| Value | string |  | The current value of the input |
| WithoutSpinButtons | bool | false | Hides the browser's built-in increment/decrement spin buttons for number inputs. Defaults to false. |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| ValueChanged (string) | Triggered when the input's value has changed |


### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetValueAsync  | value: string   | Sets the value of the input |
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