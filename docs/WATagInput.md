# WATagInput
## WebAwesomeBlazor.Components.WATagInput

```HTML+Razor
<WATagInput @bind-Value="" />
```

### Description
Tag inputs allow users to enter and manage a list of tags.

[WebAwesome docs](https://webawesome.com/docs/components/tag-input/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value | string[] |  | The current value of the input |
| ValueChanged | EventCallback<string[]> |  | Triggered when the input's value has changed |
| AllowDuplicates | bool | false | Allows duplicate tags to be added. |
| Appearance | TagInputAppearance | TagInputAppearance.Outlined | The input's visual appearance. |
| AutoCapitalize | TagInputAutoCapitalize | `null` | Controls whether and how text input is automatically capitalized as it is entered/edited by the user. |
| Autocomplete | string |  | Specifies what permission the browser has to provide assistance in filling out form field values. Refer to [this page on MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete) for available values.. |
| AutoCorrectEnabled | bool | true | Indicates whether the browser's autocorrect feature is on or off. |
| Clearable | bool | false | Adds a clear button when the input is not empty. |
| Delimeter | string | "" | The character(s) that turn typed text into a tag. Each character is a separate delimiter, so ",;" accepts both commas and semicolons. Empty string for enter. |
| Disabled | bool | false | Maked the input disabled. |
| Hint | string |  | The input's hint text. |
| Label | string |  | The input's label |
| MaxTags | int | | The maximum number of tags allowed. |
| MinTags | int |  | The minimum number of tags required. |
| Pill | bool | False | Draws a pill-style tag input, and pill-style tags, with rounded edges. |
| Placeholder | string |  | Placeholder text to show as a hint when the tag input is empty. Hidden once the maximum number of tags is reached. |
| ReadOnly | bool | false | Makes the input readonly. |
| Required | bool | false | Makes the input a required field. |
| Size | TagInputSize | TagInputSize.Medium | The input's size. |
| Spellcheck | bool | false | Enables spellchecking on the input |


### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetValue  | value: string[]   | Sets the value of the input |
| SetValueAsync  | value: string[]   | Sets the value of the input |
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