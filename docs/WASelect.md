# WASelect
## WebAwesomeBlazor.Components.WASelect

```HTML+Razor
<WASelect Value="">
	<WASelectOption Value=""></WASelectOption>
</WASelect>
```

### Description
Selects allow you to choose items from a menu of [WASelectOption](/docs/WASelectOption).

[Web Awesome docs](https://webawesome.com/docs/components/select/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Appearance | SelectAppearance | SelectAppearance.Outlined | The select's visual appearance. |
| Clearable | bool | false | Adds a clear button (with-clear) when the select is not empty. |
| Disabled | bool | false | Disables the select control. |
| ClearIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the clear slot. |
| ClearIconName | string |  | The name of the icon to draw in the clear slot. Available names depend on the icon library being used. |
| EndIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. |
| EndIconName | string |  | The name of the icon to draw in the end slot. Available names depend on the icon library being used. |
| ExpandIcon | [Icon](/docs/IconClass.md) |  | The name of the icon to draw in the when the control is expanded and collapsed. Rotates on open and close. |
| ExpandIconName | string |  | The name of the icon to draw in the when the control is expanded and collapsed. Rotates on open and close. Available names depend on the icon library being used. |
| HideDuration | string | `100ms` | The duration of the hide animation. |
| Hint | string |  | The select's hint. |
| Label | string |  | The select's label.  |
| MaxOptionsVisible | int | 3 | The maximum number of selected options to show when Multiselect is true. After the maximum, "+n" will be shown to indicate the number of additional items that are selected. Set to 0 to remove the limit. |
| Multiselect | bool | false | Allows more than one option to be selected. |
| Pill | bool | false | Draws a pill-style select with rounded edges. |
| Placeholder | string |  | Placeholder text to show as a hint when the select is empty. |
| Required | bool | false | The select's required attribute. |
| ShowDuration | string | `100ms` | The duration of the show animation. |
| Size | SelectSize | SelectSize.Inherit | The select's size. |
| StartIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the start slot. |
| StartIconName | string |  | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| Value | string |  | The select's value. Only available where multiselect = false |
| Values | string[] | | The select's values. Only available where multiselect = true |


### Examples

#### Basic Usage
```HTML+Razor
    <WASelect Label="Select an option" Hint="It can be any">
        <WASelectOption Value="Option1">Option 1</WASelectOption>
        <WASelectOption Value="Option2">Option 2</WASelectOption>
        <WASelectOption Value="Option3">Option 3</WASelectOption>
    </WASelect>
```

#### Clearable, filled appearance, with a start icon
```HTML+Razor
    <WASelect Appearance="SelectAppearance.Filled"
        Clearable="true" 
        Label="Select an option" 
        Hint="It can be any" 
        Value="Option1"
        StartIconName="user">
        <WASelectOption Value="Option1">Option 1</WASelectOption>
        <WASelectOption Value="Option2">Option 2</WASelectOption>
        <WASelectOption Value="Option3">Option 3</WASelectOption>
    </WASelect>
```

![WASelect](https://github.com/user-attachments/assets/35178b92-b1a7-472b-9019-f4c32e61412a)