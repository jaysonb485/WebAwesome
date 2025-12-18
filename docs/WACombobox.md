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
| Value | string |  | The combobox's value.  |
| Label | string |  | The combobox's label.  |
| Size | ComboboxSize | ComboboxSize.Medium | The combobox's size. |
| Hint | string |  | The combobox's hint. |
| Placeholder | string |  | Placeholder text to show as a hint when the select is empty. |
| Clearable | bool | false | Adds a clear button (with-clear) when the select is not empty. |
| Required | bool | false | The combobox's required attribute. |
| Appearance | ComboboxAppearance | ComboboxAppearance.Outlined | The combobox's visual appearance. |
| Disabled | bool | false | Disables the combobox control. |
| Pill | bool | false | Draws a pill-style combobox with rounded edges. |
| StartIconName | string |  | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| StartIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the start slot. |
| EndIconName | string |  | The name of the icon to draw in the end slot. Available names depend on the icon library being used. |
| EndIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. |
| ClearIconName | string |  | The name of the icon to draw in the clear slot. Available names depend on the icon library being used. |
| ClearIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the clear slot. |
| ExpandIconName | string |  | The name of the icon to draw in the when the control is expanded and collapsed. Rotates on open and close. Available names depend on the icon library being used. |
| ExpandIcon | [Icon](/docs/IconClass.md) |  | The name of the icon to draw in the when the control is expanded and collapsed. Rotates on open and close. |
| ShowDuration | string | `100ms` | The duration of the show animation. |
| HideDuration | string | `100ms` | The duration of the hide animation. |
| Placement | ComboboxPlacement | ComboboxPlacement.Bottom | The preferred placement of the combobox's menu. Note that the actual placement may vary as needed to keep the listbox inside of the viewport. |
| Autocomplete | ComboboxAutocomplete | ComboboxAutocomplete.List | The autocomplete behavior of the combobox. <br /> ``List``: When the popup is triggered, it presents suggested values that complete or logically correspond to the characters typed in the combobox. The character string the user has typed will become the value of the combobox unless the user selects a value in the popup. <br /> ``None``: The combobox is editable, and when the popup is triggered, the suggested values it contains are the same regardless of the characters typed in the combobox. |
| AllowCustomValue | bool | false | When true, allows the user to enter a value that doesn't match any of the options. Only applies to single-select comboboxes. When false, the combobox will only accept values that match an option. |

### Methods
 Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| Show |    | Shows the option list.      |
| ShowAsync |    | Shows the option list.      |
| Hide |  | Hides the option list. |
| HideAsync |  | Hides the option list. |
| GetInputValueAsync |  | Gets the current value of the text input box. |

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

![WACombobox](https://github.com/user-attachments/assets/071a539e-791f-4f5d-a93e-d87d3e9334ac)