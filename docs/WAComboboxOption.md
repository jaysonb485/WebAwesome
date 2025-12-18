# WAComboboxOption
## WebAwesomeBlazor.Components.componentname

```HTML+Razor
<WACombobox Value="">
	<WAComboboxOption Value=""></WAComboboxOption>
</WACombobox>
```

### Description
Options define the selectable items within a Combobox component.

This component must be used as a child of [WACombobox](/docs/WACombobox.md).

[WebAwesome docs](https://webawesome.com/docs/components/combobox/)

> [!IMPORTANT]
> WACombobox requires access to WebAwesome Pro.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value | string |  | The option's value. |
| Label | string |  | The option's label. Alternatively, the label will be the ChildContent |
| Disabled | bool | false | Disables the option |
| StartIconName | string |  | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| StartIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the start slot. |
| EndIconName | string |  | The name of the icon to draw in the end slot. Available names depend on the icon library being used. |
| EndIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. |

### Examples

#### Basic Usage
```HTML+Razor
    <WACombobox Label="Select an option" Hint="It can be any">
        <WAComboboxOption Value="Option1">Option 1</WAComboboxOption>
        <WAComboboxOption Value="Option2">Option 2</WAComboboxOption>
        <WAComboboxOption Value="Option3">Option 3</WAComboboxOption>
    </WACombobox>
```

#### With icons, disabled
```HTML+Razor
    <WACombobox Label="Select an option" Hint="It can be any" Value="Option1">
        <WAComboboxOption Value="Option1" StartIconName="user">Option 1</WAComboboxOption>
        <WAComboboxOption Value="Option2" EndIconName="gear">Option 2</WAComboboxOption>
        <WAComboboxOption Value="Option3" Disabled="true">Option 3</WAComboboxOption>
    </WACombobox>
``` 

![WAComboboxOption](https://github.com/user-attachments/assets/071a539e-791f-4f5d-a93e-d87d3e9334ac)