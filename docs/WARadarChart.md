# WARadarChart
## WebAwesomeBlazor.Components.WARadarChart

```HTML+Razor
<WARadarChart />
```

### Description
Radar charts compare multiple variables at once by plotting data on a radial grid. They are well-suited for comparing profiles across several dimensions, such as skill assessments, product attributes, or performance metrics.

[WebAwesome docs](https://webawesome.com/docs/components/radar-chart)

> [!IMPORTANT]
> WebAwesome charts require access to WebAwesome Pro.

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| RenderChartAsync  | categoryLabels: string[], <br/> dataSets: RadarChartDataSet[], <br /> radarChartOptions: RadarChartOptions    | Provides the data and configuration for the chart. Can only be executed after render.      |

#### RadarChartDataSet Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string |  | The label for the dataset which appears in the legend and tooltips. |
| Data | double[] |  | An array of values representing the set data |
| FillArea | bool | `false` | Fill the area beneath the line |
| FillColor | string? |  | The fill color for the line area, if FillArea = `true` in CSS color. If not provided, colors associated with the WA Theme will be selected. |
| BorderColor | string? | | The border color in CSS color.  If not provided, colors associated with the WA Theme will be selected. |


#### RadarChartOptions Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string? |  | A title for the chart, also used for accessibility. |
| ShowLegend | bool | `true` | Shows the legend |
| Animate | bool | `true` | Enables chart animations |
| ShowTooltips | bool | `true` | Shows tooltips over data points. |
| Description | string? | | A description of the chart, used for accessibility. |
| LegendPosition | ChartLegendPosition | `ChartLegendPosition.Top` | The position of the legend relative to the chart. |
| GridLines | ChartGridLines | `ChartGridLines.Both` | Which axes to show grid lines on. |
| GridBorderWidth | string? | | Border width for chart grid lines and axis borders in CSS units. |
| GridColor | string? | | CSS color of the chart grid lines and axis borders. |


### Examples

#### Basic Usage
```HTML+Razor
<WARadarChart @ref="radarChart" />

@code
{
    WARadarChart radarChart = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            RadarChartDataSet[] DataSet =
            [
                new RadarChartDataSet
                {
                    Label = "Product A",
                    Data = [85, 90, 75, 80, 70, 88],
                },
                new RadarChartDataSet
                {
                    Label = "Product B",
                    Data = [70, 80, 90, 85, 92, 75],
                    FillArea = true
                },
            ];

            var labels = new string[] { "Speed", "Reliability", "Ease of Use", "Features", "Support", "Value" };
            var chartOptions = new RadarChartOptions()
            {
                Label = "Product Comparison",
                LegendPosition = ChartLegendPosition.Right,
                GridLines = ChartGridLines.HorizontalOnly,

            };
            await radarChart.RenderChartAsync(labels, DataSet, chartOptions);
        }
    }

}
```
