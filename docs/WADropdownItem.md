# WADropdownItem
## WebAwesomeBlazor.Components.WADropdownItem

```HTML+Razor
<WADropdown>
    <TriggerButtonContent></TriggerButtonContent>
    <DropdownItems>
        <WADropdownItem></WADropdownItem>
    </DropdownItems>
</WADropdown>
```

### Description
Represents an individual item within a dropdown menu, supporting standard items, checkboxes, and submenus.

[WebAwesome docs](https://webawesome.com/docs/component)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| DetailsContent | RenderFragment |  | Additional content or details to display after the label. |
| IsSubMenu | bool | false | If true, the menu item is rendered as a submenu item. |
| Value | string |  | An optional value for the menu item.  |
| Variant | DropdownItemVariant | DropdownItemVariant.Default | The type of menu item to render. |
| Disabled | bool | false | Adds the disabled attribute to disable the menu item so it cannot be selected. |
| Label | string |  | The text to display on the menu item |
| Loading | bool | false | Adds a loading spinner to indicate that a menu item is busy. Like a disabled menu item, clicks will be suppressed until the loading state is removed. |
| IsCheckbox | bool | false | Indicates the menu item can be checked. To use Checked, this value must be true. |
| Checked | bool | false | Draws the item in a checked state. |
| OnClick | EventCallback<MouseEventArgs?> |  | Triggered when the dropdown item is clicked |
| SubmenuOpen | bool | false | Whether the submenu is currently open. |
| Icon | [Icon](/docs/IconClass.md) |  | An optional icon to display before the label. |
| IconName | string |  | An optional icon to display before the label. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetLoading  | LoadingState: bool   | Turn off or on the loading indicator.     |
| SetLoadingAsync  | LoadingState: bool   | Turn off or on the loading indicator.     |

### Examples

#### Basic Usage
```HTML+Razor
<WADropdown>
    <TriggerButtonContent>
        Options
    </TriggerButtonContent>
    <DropdownItems>
        <WADropdownItem>Option 1</WADropdownItem>
        <WADropdownItem>Option 2</WADropdownItem>
        <WADropdownItem>Option 3</WADropdownItem>
    </DropdownItems>
</WADropdown>
```

#### With checkbox, icon and danger.
```HTML+Razor
<WADropdown Open="true">
    <TriggerButtonContent>
        Options
    </TriggerButtonContent>
    <DropdownItems>
        <WADropdownItem IsCheckbox="true" Checked="true">Option 1</WADropdownItem>
        <WADropdownItem IconName="2">Option 2</WADropdownItem>
        <WADropdownItem Variant="DropdownItemVariant.Danger">Delete</WADropdownItem>
    </DropdownItems>
</WADropdown>
```
<img width="175" height="187" alt="image" src="https://github.com/user-attachments/assets/d34858e5-9cae-4019-807f-133f779225c5" />
