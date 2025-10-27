# WADropdown
## WebAwesomeBlazor.Components.WADropdown

```HTML+Razor
<WADropdown>
    <TriggerButtonContent></TriggerButtonContent>
    <DropdownItems>
        <WADropdownItem></WADropdownItem>
    </DropdownItems>
</WADropdown>
```

### Description
A brief description of what the Component Name does and its purpose within the Vengage WebAwesome library.

[WebAwesome docs](https://webawesome.com/docs/component)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| DropdownItems | RenderFragment |  | The dropdown options to be shown - use [<WADropdownItem>](/docs/WADropdownItem.md) |
| TriggerButtonContent | RenderFragment |  | Text to display on the trigger button |
| ShowTriggerCaret | bool | true | Show the caret arrow indicating a dropdown action. Defaults to true. |
| HideTriggerButton | bool | false | Gets or sets a value indicating whether the trigger button should be hidden. |
| TriggerButtonVariant | ButtonVariant | ButtonVariant.Inherit | The trigger button's theme variant. Defaults to neutral if not within another element with a variant. |
| TriggerButtonAppearance | ButtonAppearance | ButtonAppearance.Accent | The trigger button's visual appearance. |
| PanelPlacement | DropdownPlacement | DropdownPlacement.BottomStart | The placement of the dropdown menu in reference to the trigger. The menu will shift to a more optimal location if the preferred placement doesn't have enough room. |
| Disabled | bool | false | Disables the dropdown so the panel will not open. |
| StayOpenOnSelect | bool | false | By default, the dropdown is closed when an item is selected. This attribute will keep it open instead. Useful for dropdowns that allow for multiple interactions. |
| Distance | int | 0 | The distance in pixels from which to offset the panel away from its trigger. |
| Offset | int | 0 | The distance in pixels from which to offset the panel along its trigger. |
| OpenOnHover | bool | false | Opens and closes the menu when the user hovers over the trigger button. |
| Open | bool | false | Opens or closes the dropdown. |

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

#### Add an icon to the trigger button
```HTML+Razor
<WADropdown TriggerButtonAppearance="ButtonAppearance.Outlined" TriggerButtonVariant="ButtonVariant.Brand">
    <TriggerButtonContent>
        <WAIcon Slot="start" IconName="gear" />
    </TriggerButtonContent>
    <DropdownItems>
        <WADropdownItem>Option 1</WADropdownItem>
        <WADropdownItem>Option 2</WADropdownItem>
        <WADropdownItem>Option 3</WADropdownItem>
    </DropdownItems>
</WADropdown>

```
<img width="280" height="189" alt="image" src="https://github.com/user-attachments/assets/70ab8fe0-a026-4521-998e-5eec2d93801b" />
