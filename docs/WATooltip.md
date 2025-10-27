# WATooltip
## Vengage.WebAwesome.Components.WATooltip

```HTML+Razor
<WATooltip TargetId="HoverButton">Tooltip text</WATooltip>
<WAButton Id="HoverButton" Text="Hover me" />
```

### Description
Tooltips display additional information based on a specific action.

[WebAwesome docs](https://webawesome.com/docs/component)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| TargetId | string |  | Required. ID of the component to attach the tooltip to |
| ArrowSize | int |  | Size of the tooltip arrow. Set to 0 to hide the arrow. |
| MaxWidth | int |  | Maximum width the tooltip can grow to before wrapping. |
| Placement | TooltipPlacement | TooltipPlacement.Top | The preferred placement of the tooltip. Note that the actual placement may vary as needed to keep the tooltip inside of the viewport. |
| Disabled | bool | false | Disables the tooltip so it won't show when triggered. |
| Distance | int | 8 | The distance in pixels from which to offset the tooltip away from its target. |
| Offset | int | 0 | The distance in pixels from which to offset the tooltip along its target. (Skidding) |
| ShowDelay | int | 150 | The amount of time to wait before showing the tooltip when the user mouses in. |
| HideDelay | int | 0 | The amount of time to wait before hiding the tooltip when the user mouses out. |
| WithoutArrow | bool | false | Removes the arrow from the tooltip. |
| Open | bool | false | Indicates whether or not the tooltip is open.  |
| Trigger | TooltipTrigger | TooltipTrigger.Hover \| TooltipTrigger.Focus | Controls how the tooltip is activated. Possible options include click, hover, focus, and manual. When manual is used, the tooltip must be activated programmatically. |



### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| Show  |   | Shows the tool tip      |
| Hide |  | Hides the tool tip |

### Examples

#### Basic Usage
```HTML+Razor
<WATooltip TargetId="HoverButton">Tooltip text</WATooltip>
<WAButton Id="HoverButton" Text="Hover me" />
```

![WATooltip](https://github.com/user-attachments/assets/320fe1be-5f6c-4047-b0ec-81829cb97140)