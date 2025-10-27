# WASplitPanel
## Vengage.WebAwesome.Components.WASplitPanel

```HTML+Razor
<WASplitPanel>
	<StartContent>
		
	</StartContent>
	<EndContent>

	</EndContent>
</WASplitPanel>
```

### Description
A brief description of what the Component Name does and its purpose within the Vengage WebAwesome library.

[WebAwesome docs](https://webawesome.com/docs/component)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| StartContent | RenderFragment  |  | Content to place in the start panel. |
| EndContent | RenderFragment  |  | Content to place in the end panel. |
| PositionPercent | int | `50` | The current position of the divider from the primary panel's edge as a percentage 0-100. Defaults to 50% of the container's initial size. To set as a number of pixels use `PositionPixels`. |
| PositionPixels | int |  | The current position of the divider from the primary panel's edge in pixels. To set as a percentage of the primary panel's width, use `PositionPercent` |
| Orientation | SplitPanelOrientation | SplitPanelOrientation.Horizontal | Sets the split panel's orientation. |
| Disabled | bool | false | Disables resizing. Note that the position may still change as a result of resizing the host element. |
| PrimaryPanel | SplitPanelPrimaryPanel |  | If no primary panel is designated, both panels will resize proportionally when the host element is resized. If a primary panel is designated, it will maintain its size and the other panel will grow or shrink as needed when the host element is resized. |
| SnapPoints | string |  | One or more space-separated values at which the divider should snap. Values can be in pixels or percentages, e.g. "100px 50%". |
| SnapThreshold | int | `12` | How close the divider must be to a snap point until snapping occurs. |
| DividerIconName | string |  | The name of the icon to draw for the Divider. Available names depend on the icon library being used. |
| DividerIcon | [Icon](/docs/IconClass) |  | The icon to draw for the Divider. |
| PrimaryMinWidth | string |  | If set, defines the minimum allowed width of the primary panel in CSS units. |
| Height | string |  | Height of the container in CSS units. |
| Width | string |  | Width of the container in CSS units. |
| PrimaryMaxWidth | string |  | If set, defines the maximum allowed width of the primary panel in CSS units. |

### Examples

#### Basic Usage
```HTML+Razor
<WASplitPanel>
    <StartContent>
            <div style="height: 200px; background: var(--wa-color-surface-lowered); display: flex; align-items: center; justify-content: center; overflow: hidden;">
            Start
        </div>
    </StartContent>
    <EndContent>
            <div style="height: 200px; background: var(--wa-color-surface-lowered); display: flex; align-items: center; justify-content: center; overflow: hidden;">
                End
            </div>
    </EndContent>
</WASplitPanel>
```

#### Vertical orientation, divider icon and initial position in percent
```HTML+Razor
<WASplitPanel DividerIconName="arrow-down-up-across-line" Orientation="SplitPanelOrientation.Vertical" Height="200px" PositionPercent="25">
    <StartContent>
        <div style="height: 100%; background: var(--wa-color-surface-lowered); display: flex; align-items: center; justify-content: center; overflow: hidden;">
            Start
        </div>
    </StartContent>
    <EndContent>
        <div style="height: 100%; background: var(--wa-color-surface-lowered); display: flex; align-items: center; justify-content: center; overflow: hidden;">
            End
        </div>
    </EndContent>
</WASplitPanel>
```

![WASplitPanel](https://github.com/user-attachments/assets/e37bc9e5-3b19-413a-adaa-4d0f57f9e23e)