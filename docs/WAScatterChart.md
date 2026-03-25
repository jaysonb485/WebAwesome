# WAScatterChart
## WebAwesomeBlazor.Components.WAScatterChart

```HTML+Razor
<WAScatterChart />
```

### Description
Scatter charts reveal relationships between two variables by plotting data points on a grid. They are ideal for identifying correlations, clusters, and outliers in datasets.

[WebAwesome docs](https://webawesome.com/docs/components/scatter-chart)

> [!IMPORTANT]
> WebAwesome charts require access to WebAwesome Pro.

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| RenderChartAsync  | categoryLabels: string[], <br/> dataSets: ScatterChartDataSet[], <br /> scatterChartOptions: ScatterChartOptions    | Provides the data and configuration for the chart. Can only be executed after render.      |

#### ScatterChartDataSet Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string |  | The label for the dataset which appears in the legend and tooltips. |
| Data | ScatterPoint[] |  | An array of ScatterPoint values representing the set data |
| FillColor | string? |  | The fill color for the line area, if FillArea = `true` in CSS color. If not provided, colors associated with the WA Theme will be selected. |
| BorderColor | string? | | The line color in CSS color.  If not provided, colors associated with the WA Theme will be selected. |

#### ScatterPoint Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| X | double | | The x value |
| Y | double | | The y value |


#### ScatterChartOptions Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string? |  | A title for the chart, also used for accessibility. |
| XLabel | string? |  | A label for the x-axis. |
| YLabel | string? |  | A label for the y-axis. |
| ShowLegend | bool | `true` | Shows the legend |
| Animate | bool | `true` | Enables chart animations |
| ShowTooltips | bool | `true` | Shows tooltips over data points. |
| Description | string? | | A description of the chart, used for accessibility. |
| LegendPosition | ChartLegendPosition | `ChartLegendPosition.Top` | The position of the legend relative to the chart. |
| GridLines | ChartGridLines | `ChartGridLines.Both` | Which axes to show grid lines on. |
| GridBorderWidth | string? | | Border width for chart grid lines and axis borders in CSS units. |
| GridColor | string? | | CSS color of the chart grid lines and axis borders. |
| PointRadius | string? | | Radius of data point dots in CSS units |


### Examples

#### Basic Usage
```HTML+Razor
<WAScatterChart @ref="scatterChart" />

@code
{
    WAScatterChart scatterChart = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ScatterChartDataSet[] DataSet =
            [
                new ScatterChartDataSet
                {
                    Label = "Group A",
                    Data = [
                        new ScatterPoint { X = 3, Y = 70},
                        new ScatterPoint { X = 4, Y = 75},
                        new ScatterPoint { X = 5, Y = 82},
                        new ScatterPoint { X = 6, Y = 85},
                        new ScatterPoint { X = 7, Y = 90},
                    ]
                },
                new ScatterChartDataSet
                {
                    Label = "Group B",
                    Data = [
                        new ScatterPoint { X = 2, Y = 60},
                        new ScatterPoint { X = 4, Y = 68},
                        new ScatterPoint { X = 5, Y = 74},
                        new ScatterPoint { X = 7, Y = 80},
                        new ScatterPoint { X = 8, Y = 88},
                    ]
                }
            ];

            var labels = new string[] { "Q1", "Q2", "Q3", "Q4" };
            var chartOptions = new ScatterChartOptions()
            {
                Label = "Group comparison",
                LegendPosition = ChartLegendPosition.Right,
                GridLines = ChartGridLines.VerticalOnly,
                PointRadius = "6px"

            };
            await scatterChart.RenderChartAsync(labels, DataSet, chartOptions);
        }
    }

}
```
