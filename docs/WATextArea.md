# WATextArea
## WebAwesomeBlazor.Components.WATextArea

```HTML+Razor
<WATextArea />
```

### Description
Textareas collect data from the user and allow multiple lines of text.

[WebAwesome docs](https://webawesome.com/docs/components/textarea/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value |  |  | The current value of the input |
| Rows | int | 4 | The number of rows to display by default. |
| Appearance | TextAreaAppearance | TextAreaAppearance.Outlined | The textarea's visual appearance. |
| Size | TextAreaSize | TextAreaSize.Inherit | The textarea's size. |
| Label | string |  | The textarea's label |
| Hint | string |  | The textarea's hint text. |
| Placeholder | string |  | Placeholder text to show as a hint when the textarea is empty. |
| ReadOnly | bool | false | Makes the textarea readonly. |
| Disabled | bool | false | Disables the textarea. |
| Required | bool | false | Makes the textarea a required field. |
| ResizeMode | TextAreaResize | TextAreaResize.Vertical | Controls how the textarea can be resized. Defaults to vertical. |
| AutoCorrectEnabled | bool | true | Indicates whether the browser's autocorrect feature is on or off. |
| Spellcheck | bool | true | Enables spell checking on the textarea. |
| AutoCapitalize | TextAreaAutoCapitalize |  | Controls whether and how text input is automatically capitalized as it is entered by the user. (Off, None, On, Sentences, Words, Characters) |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetValue  | value: string   | Set the value of the text area      |
| SetValueAsync  | value: string   | Set the value of the text area      |
| SetFocus |  | Sets focus to the text area. |
| SetFocusAsync |  | Sets focus to the  text area. |

### Examples

#### Basic Usage
```HTML+Razor
<WATextArea Label="Enter some text" Hint="Be as detailed as possible."/>
```

#### Filled appearance
```HTML+Razor
<WATextArea Label="Enter some text" Hint="Be as detailed as possible." Appearance="TextAreaAppearance.Filled" Rows="8" />
```

![WATextArea](https://github.com/user-attachments/assets/ca12665a-7f29-42f1-966a-aaddb9fa6ce8)