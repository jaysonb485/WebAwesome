# WACombobox
## WebAwesomeBlazor.Components.WACombobox

```HTML+Razor
<WACombobox Value="">
	<WAComboboxOption Value=""></WAComboboxOption>
</WACombobox>
```

### Description
Selects allow you to choose items from a menu of [WAComboboxOption](/docs/WAComboboxOption.md).

[WebAwesome docs](https://webawesome.com/docs/components/combobox/)

> [!IMPORTANT]
> WACombobox requires access to WebAwesome Pro.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| AllowCreate | bool | false |  If the user types text that doesn't match any existing option, a "Create [value]" option appears in the listbox. Listen to the `OptionCreating` event to use the value |
| AllowCustomValue | bool | false | When true, allows the user to enter a value that doesn't match any of the options. Only applies to single-select comboboxes. When false, the combobox will only accept values that match an option. |
| Appearance | ComboboxAppearance | ComboboxAppearance.Outlined | The combobox's visual appearance. |
| AutoCapitalize | ComboboxAutoCapitalize | `null` | Controls whether and how text input is automatically capitalized as it is entered/edited by the user. |
| Autocomplete | ComboboxAutocomplete | ComboboxAutocomplete.List | The autocomplete behavior of the combobox. <br /> ``List``: When the popup is triggered, it presents suggested values that complete or logically correspond to the characters typed in the combobox. The character string the user has typed will become the value of the combobox unless the user selects a value in the popup. <br /> ``None``: The combobox is editable, and when the popup is triggered, the suggested values it contains are the same regardless of the characters typed in the combobox. |
| AutoCorrect | bool | true | Indicates whether the browser's autocorrect feature is on or off. |
| Clearable | bool | false | Adds a clear button (with-clear) when the select is not empty. |
| ClearIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the clear slot. |
| ClearIconName | string |  | The name of the icon to draw in the clear slot. Available names depend on the icon library being used. |
| Disabled | bool | false | Disables the combobox control. |
| EndIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. |
| EndIconName | string |  | The name of the icon to draw in the end slot. Available names depend on the icon library being used. |
| EnterKeyHint | ComboboxEnterKeyHint | `null` | Used to customize the label or icon of the Enter key on virtual keyboards. |
| ExpandIcon | [Icon](/docs/IconClass.md) |  | The name of the icon to draw in the when the control is expanded and collapsed. Rotates on open and close. |
| ExpandIconName | string |  | The name of the icon to draw in the when the control is expanded and collapsed. Rotates on open and close. Available names depend on the icon library being used. |
| HideDuration | string | `100ms` | The duration of the hide animation. |
| Hint | string |  | The combobox's hint. |
| InputMode | ComboboxInputMode | ComboboxInputMode.Text | Tells the browser what type of data will be entered by the user, allowing it to display the appropriate virtual keyboard on supportive devices. |
| Label | string |  | The combobox's label.  |
| MaxOptionsVisible | int | 3 | The maximum number of selected options to show when Multiselect is true. After the maximum, "+n" will be shown to indicate the number of additional items that are selected. Set to 0 to remove the limit. |
| Multiselect | bool | false | Allows more than one option to be selected. |
| Pill | bool | false | Draws a pill-style combobox with rounded edges. |
| Placement | ComboboxPlacement | ComboboxPlacement.Bottom | The preferred placement of the combobox's menu. Note that the actual placement may vary as needed to keep the listbox inside of the viewport. |
| Placeholder | string |  | Placeholder text to show as a hint when the select is empty. |
| Required | bool | false | The combobox's required attribute. |
| ServerSideData | bool | false | When true,  will trigger the `DataRequested` event when the user types in the input box. Any WAComboboxOption items added to the combobox will be replaced with the server data |
| ShowDuration | string | `100ms` | The duration of the show animation. |
| Size | ComboboxSize | ComboboxSize.Medium | The combobox's size. |
| Spellcheck | bool | false | Enables spellchecking on the combobox |
| StartIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the start slot. |
| StartIconName | string |  | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| Value | string |  | The combobox's value. Only available where multiselect = false |
| Values | string[] | | The select's values. Only available where multiselect = true |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| DataRequested (ComboboxDataRequestEventArgs e) | Triggered when the user types in the input box and `ServerSideData` is true. Set e.Options to the list of options to display. |
| OptionCreating (string text) | Triggered when a new option is created via `AllowCreate`. The option is not created automatically; handle the creation of the new item, add to the options list and select the new option. |


### Methods
 Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| GetInputValueAsync |  | Gets the current value of the text input box. |
| HideAsync |  | Hides the option list. |
| ShowAsync |    | Shows the option list.      |

### Examples

#### Basic Usage
```HTML+Razor
    <WACombobox Label="Select an option" Hint="It can be any">
        <WAComboboxOption Value="Option1">Option 1</WAComboboxOption>
        <WAComboboxOption Value="Option2">Option 2</WAComboboxOption>
        <WAComboboxOption Value="Option3">Option 3</WAComboboxOption>
    </WACombobox>
```

#### Clearable, filled appearance, with a start icon
```HTML+Razor
    <WACombobox Appearance="SelectAppearance.Filled"
        Clearable="true" 
        Label="Select an option" 
        Hint="It can be any" 
        Value="Option1"
        StartIconName="user">
        <WAComboboxOption Value="Option1">Option 1</WAComboboxOption>
        <WAComboboxOption Value="Option2">Option 2</WAComboboxOption>
        <WAComboboxOption Value="Option3">Option 3</WAComboboxOption>
    </WACombobox>
```

#### Handle a new option created via AllowCreate and OptionCreating callback
```HTML+Razor
    <WACombobox AllowCreate="true" OptionCreating="AddNewOption" @bind-Value="selectedValue">
        @foreach (KeyValuePair<string, string> option in options)
        {
            <WAComboboxOption Value="@option.Key" Label="@option.Value" />
        }
    </WACombobox>

    @code
    {
        string selectedValue { get; set; } = default!;

        Dictionary<string, string> options { get; set; } = new Dictionary<string, string>
            {
                { "UK", "London, Manchester, Birmingham" },
                { "USA", "Chicago, New York, Washington" },
                { "India", "Mumbai, New Delhi, Pune" }
            };

        async Task AddNewOption(string text)
        {
            options.Add(text, text);
            selectedValue = text;
        }
    }
```

### Server Data
```HTML+Razor
<WACombobox ServerSideData="true" DataRequested="DataRequested" />
@code
{
    async Task DataRequested(ComboboxDataRequestEventArgs e)
    {
        // Simulate data fetching from a server
        await Task.Delay(500); // Simulate network delay
        // Example data source
        var allData = new List<ComboboxOption>
            {
                new ComboboxOption { Label = "Apple", Value = "Item1" }, 
                new ComboboxOption { Label = "Banana", Value = "Item2" },
                new ComboboxOption { Label = "Cherry", Value = "Item3" },
                new ComboboxOption { Label = "Date", Value = "Item4" },
                new ComboboxOption { Label = "Elderberry", Value = "Item5" },
                new ComboboxOption { Label = "Fig", Value = "Item6" },
                new ComboboxOption { Label = "Grape", Value = "Item7" },
                new ComboboxOption { Label = "Honeydew", Value = "Item8" }
            };

        // Filter data based on search text (e.Query)
        var filteredData = allData
            .Where(item => item.Label.Contains(e.Query, StringComparison.OrdinalIgnoreCase))
            .ToList();
        e.Options = filteredData;
    }
}

```

![WACombobox](https://github.com/user-attachments/assets/071a539e-791f-4f5d-a93e-d87d3e9334ac)