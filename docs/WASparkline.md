# WASparkline
## WebAwesomeBlazor.Components.WASparkline

```HTML+Razor
<WASparkline Data="@(new string[]{"10","0", "25","36","28","-10","90"})" />
```

### Description
Sparklines display inline data trends as compact, visual charts.

[WebAwesome docs](https://webawesome.com/docs/components/sparkline)

> [!IMPORTANT]
> WASparkline requires access to WebAwesome Pro.


### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string |  | An accessible label describing the sparkline for screen readers. |
| Data | string[] |  | An array of data points to be plotted on the sparkline, where each value is a string that can be parsed into a number. The sparkline will automatically scale to fit the range of the provided data. |
| Appearance | SparklineAppearance | SparklineAppearance.Solid; | The visual fill style of the sparkline. |
| Curve | SparklineCurve | SparklineCurve.Linear | The type of curve used to connect data points. |
| Trend | SparklineTrend |  | An optional trend to indicate, which will affect the sparkline's default color. |
| LineColor | string |  | The color of the sparkline stroke. |
| FillColor | string |  | The fill color for the area under the line. |
| LineWidth | string |  | The width of the sparkline stroke in CSS units  |


### Examples

#### Basic Usage
```HTML+Razor
<WASparkline 
	Data="@(new string[]{"10","0", "25","36","28","-10","90"})"
	Label="Sparkline showing trends" />
```
