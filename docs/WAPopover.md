# WAPopover
## WebAwesomeBlazor.Components.WAPopover

```HTML+Razor
<WAPopover TargetId="">
    @ChildContent
</WAPopover>
```

### Description
Popovers display contextual content and interactive elements in a floating panel.

[WebAwesome docs](https://webawesome.com/docs/components/popover/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| TargetId | string |  |  The ID of the popover's anchor element. This must be an interactive/focusable element such as a button. |
| Placement | PopoverPlacement | PopoverPlacement.Top | The preferred placement of the popover. Note that the actual placement may vary as needed to keep the popover inside of the viewport. |
| Open | bool | false | Shows or hides the popover. |
| Distance | int | 0 | The distance in pixels from which to offset the popover away from its trigger. |
| Skidding | int | 0 | The distance in pixels from which to offset the popover along its target. |
| WithoutArrow | bool | false | Removes the arrow from the popover. |


### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| ShowPopover  |   | Shows the popover      |
| ShowPopoverAsync  |   | Shows the popover      |
| HidePopover  |   | Hides the popover      |
| HidePopoverAsync  |   | Hides the popover      |
| TogglePopover  |   | Toggles the popover      |
| TogglePopoverAsync  |   | Toggles the popover      |

### Examples

#### Basic Usage
```HTML+Razor
<WAPopover TargetId="triggerButton" Placement="PopoverPlacement.BottomEnd">
    <p>This is some helpful text</p>
</WAPopover>

<WAButton Id="triggerButton" Text="Click me" />
```
![WAPopover](https://github.com/user-attachments/assets/cd14e3f0-924a-42c5-928b-ed30e3a26f54)