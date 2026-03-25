# WALineChart
## WebAwesomeBlazor.Components.WALineChart

```HTML+Razor
<WALineChart />
```

### Description
Line charts show trends over time by connecting data points with line segments. Use them when the x-axis represents a sequential dimension and you want to emphasize the shape and direction of the data.

[WebAwesome docs](https://webawesome.com/docs/components/line-chart)

> [!IMPORTANT]
> WebAwesome charts require access to WebAwesome Pro.

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| RenderChartAsync  | categoryLabels: string[], <br/> dataSets: LineChartDataSet[], <br /> lineChartOptions: LineChartOptions    | Provides the data and configuration for the chart. Can only be executed after render.      |

#### LineChartDataSet Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string |  | The label for the dataset which appears in the legend and tooltips. |
| Data | double[] |  | An array of values representing the set data |
| FillArea | bool | `false` | Fill the area beneath the line |
| FillColor | string? |  | The fill color for the line area, if FillArea = `true` in CSS color. If not provided, colors associated with the WA Theme will be selected. |
| BorderColor | string? | | The line color in CSS color.  If not provided, colors associated with the WA Theme will be selected. |

#### LineChartOptions Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string? |  | A title for the chart, also used for accessibility. |
| XLabel | string? |  | A label for the x-axis. |
| YLabel | string? |  | A label for the y-axis. |
| ShowLegend | bool | `true` | Shows the legend |
| Animate | bool | `true` | Enables chart animations |
| ShowTooltips | bool | `true` | Shows tooltips over data points. |
| Stacked | bool | `false` | Stacks datasets on top of each other along the value axis |
| Min | double? | | The minimum value for the value axis |
| Max | double? | | The maximum value for the value axis |
| Description | string? | | A description of the chart, used for accessibility. |
| LegendPosition | ChartLegendPosition | `ChartLegendPosition.Top` | The position of the legend relative to the chart. |
| GridLines | ChartGridLines | `ChartGridLines.Both` | Which axes to show grid lines on. |
| GridBorderWidth | string? | | Border width for chart grid lines and axis borders in CSS units. |
| GridColor | string? | | CSS color of the chart grid lines and axis borders. |
| LineBorderWidth | string? | | Border width for line and radar charts. |
| PointRadius | string? | | Radius of data point dots in CSS units |


### Examples

#### Basic Usage
```HTML+Razor
<WALineChart @ref="lineChart" />

@code
{
    WALineChart lineChart = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            LineChartDataSet[] DataSet =
            [
                new LineChartDataSet
                {
                    Label = "Online",
                    Data = [42, 58, 63, 71],
                    FillArea = true
                },
                new LineChartDataSet
                {
                    Label = "In-store",
                    Data = [65, 53, 48, 52 ],
                    FillArea = true
                },
                new LineChartDataSet
                {
                    Label = "Wholesale",
                    Data = [28, 32, 35, 40 ],
                    FillArea = true
                }
            ];

            var labels = new string[] { "Q1", "Q2", "Q3", "Q4" };
            var chartOptions = new LineChartOptions()
            {
                Label = "Quarterly Sales by Channel",
                XLabel = "Quarter",
                YLabel = "Sales ($thousands)",
                LegendPosition = ChartLegendPosition.Right,
                Description = "A line chart showing the sales for each channel by quarter.",
                GridLines = ChartGridLines.HorizontalOnly,
                Stacked = true

            };
            await lineChart.RenderChartAsync(labels, DataSet, chartOptions);
        }
    }

}
```
