# WASlider
## WebAwesomeBlazor.Components.WASlider

```HTML+Razor
<WASlider Value=""/>
```

### Description
Ranges allow the user to select a single value within a given range using a slider.

[Web Awesome docs](https://webawesome.com/docs/components/slider/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Disabled | bool | false | Disables the slider. |
| Hint | string |  | The slider hint. If you need to display HTML, use the hint slot instead. |
| IndicatorOffset | int |  | The starting value from which to draw the slider's fill, which is based on its current value. |
| IsRange | bool | false | Converts the slider to a range slider with two thumbs. |
| Label | string |  | The slider's label. If you need to provide HTML in the label, use the label slot instead. |
| MaximumValue | int | 50 | The maximum acceptable value of the slider. |
| MinimumValue | int | 0 | The minimum acceptable value of the slider. |
| Orientation | SliderOrientation | SliderOrientation.Horizontal | The orientation of the slider. Defaults to horizontal. |
| ReadOnly | bool | false | Makes the slider a read-only field. |
| ShowMarkers | bool | false | Draws markers at each step along the slider. |
| ShowTooltip | bool | true | Shows the tooltip. Defaults to true. |
| Size | SliderSize | SliderSize.Medium | The slider's size |
| Step | int | 1 | The interval at which the slider will increase and decrease. |
| TooltipPlacement | SliderTooltipPlacement | SliderTooltipPlacement.Top | The preferred placement of the slider tooltip. |
| Value | int |  | The slider's value |

### Examples

#### Basic Usage
```HTML+Razor
<WASlider Value="25" />
```
![WASlider](https://github.com/user-attachments/assets/cbd88374-9d8b-45cd-b7e3-59f1cd83bc42)
