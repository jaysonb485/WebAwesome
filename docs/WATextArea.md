# WATextArea
## WebAwesomeBlazor.Components.WATextArea

```HTML+Razor
<WATextArea />
```

### Description
Textareas collect data from the user and allow multiple lines of text.

[Web Awesome docs](https://webawesome.com/docs/components/textarea/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Appearance | TextAreaAppearance | TextAreaAppearance.Outlined | The textarea's visual appearance. |
| AutoCapitalize | TextAreaAutoCapitalize |  | Controls whether and how text input is automatically capitalized as it is entered by the user. (Off, None, On, Sentences, Words, Characters) |
| AutoCorrectEnabled | bool | true | Indicates whether the browser's autocorrect feature is on or off. |
| Disabled | bool | false | Disables the textarea. |
| Hint | string |  | The textarea's hint text. |
| Label | string |  | The textarea's label |
| Placeholder | string |  | Placeholder text to show as a hint when the textarea is empty. |
| ReadOnly | bool | false | Makes the textarea readonly. |
| Required | bool | false | Makes the textarea a required field. |
| ResizeMode | TextAreaResize | TextAreaResize.Vertical | Controls how the textarea can be resized. Defaults to vertical. |
| Rows | int | 4 | The number of rows to display by default. |
| Size | TextAreaSize | TextAreaSize.Inherit | The textarea's size. |
| Spellcheck | bool | true | Enables spell checking on the textarea. |
| Value |  |  | The current value of the input |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetValueAsync  | value: string   | Set the value of the text area      |
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