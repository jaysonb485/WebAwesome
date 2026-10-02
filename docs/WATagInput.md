# WATagInput
## WebAwesomeBlazor.Components.WATagInput

```HTML+Razor
<WATagInput @bind-Value="" />
```

### Description
Tag inputs allow users to enter and manage a list of tags.

[Web Awesome docs](https://webawesome.com/docs/components/tag-input/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
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
| Value | string[] |  | The current value of the input |

### Events
| TagCreating (InputTagCreatingEventArgs) | Triggered when a tag is being created. Prevent tag creation with `args.Cancel = true` |
| Blur  | Triggered when the input loses focus. |
| Focus | Triggered when the input receives focus. |

#### InputTagCreatingEventArgs
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Tag | string |  | The tag that is being created. |
| Cancel | bool | false | Set to `true` to cancel the tag creation. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetValueAsync  | value: string[]   | Sets the value of the input |
| SetFocusAsync |  | Sets focus to the input element. |


### Examples

#### Basic Usage
```HTML+Razor
<WATagInput @bind-Value="tagValues"  />
```

#### Stop tag creation
```HTML+Razor
<WATagInput @bind-Value="tags" TagCreating="TagCreating" />
<WASwitch @bind-Value="shouldPrevent" Label="Prevent new tag" />

@code 
{
    string[] tags { get; set; } = [];
    bool shouldPrevent { get; set; } = false;

    async Task TagCreating(InputTagCreatingEventArgs e)
    {
        /// if shouldPrevent toggle is true, then stop the creation of new tags.
        e.Cancel = shouldPrevent;
    }
}
```