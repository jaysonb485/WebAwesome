# WASelectOption
## Vengage.WebAwesome.Components.componentname

```HTML+Razor
<WASelect Value="">
	<WASelectOption Value=""></WASelectOption>
</WASelect>
```

### Description
Options define the selectable items within a select component.

This component must be used as a child of [WASelect](/docs/WASelect).

[WebAwesome docs](https://webawesome.com/docs/components/option/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value | string |  | The option's value. |
| Label | string |  | The option's label. Alternatively, the label will be the ChildContent |
| Disabled | bool | false | Disables the option |
| StartIconName | string |  | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| StartIcon | Icon |  | The icon to draw in the start slot. |
| EndIconName | string |  | The name of the icon to draw in the end slot. Available names depend on the icon library being used. |
| EndIcon | Icon |  | The icon to draw in the end slot. |

### Examples

#### Basic Usage
```HTML+Razor
    <WASelect Label="Select an option" Hint="It can be any">
        <WASelectOption Value="Option1">Option 1</WASelectOption>
        <WASelectOption Value="Option2">Option 2</WASelectOption>
        <WASelectOption Value="Option3">Option 3</WASelectOption>
    </WASelect>
```

#### With icons, disabled
```HTML+Razor
    <WASelect Label="Select an option" Hint="It can be any" Value="Option1">
        <WASelectOption Value="Option1" StartIconName="user">Option 1</WASelectOption>
        <WASelectOption Value="Option2" EndIconName="gear">Option 2</WASelectOption>
        <WASelectOption Value="Option3" Disabled="true">Option 3</WASelectOption>
    </WASelect>
```

![WASelectOption](https://github.com/user-attachments/assets/150e54e3-d8c1-4a71-806f-d41e6790487e)