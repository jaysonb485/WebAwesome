# WABubbleChart
## WebAwesomeBlazor.Components.WABubbleChart

```HTML+Razor
<WABubbleChart />
```

### Description
Bubble charts add a third dimension to scatter plots by varying the size of each data point. They are useful for visualizing relationships where a third variable adds meaning beyond a simple x/y correlation.

[WebAwesome docs](https://webawesome.com/docs/components/bubble-chart)

> [!IMPORTANT]
> WebAwesome charts require access to WebAwesome Pro.

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| RenderChartAsync  | categoryLabels: string[], <br/> dataSets: BubbleChartDataSet[], <br /> bubbleChartOptions: BubbleChartOptions    | Provides the data and configuration for the chart. Can only be executed after render.      |

#### BubbleChartDataSet Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string |  | The label for the dataset which appears in the legend and tooltips. |
| Data | BubbleChartPoint[] |  | An array of BubbleChartPoint objects representing the set data as an x,y,r point |
| BorderColor | string? | | The bubble color in CSS color.  If not provided, colors associated with the WA Theme will be selected. |

#### BubbleChartPoint Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| X | double | | The X value |
| Y | double | | The Y value |
| Radius | double | | The bubble radius in pixels (not scaled) |

#### BubbleChartOptions Properties
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


### Examples

#### Basic Usage
```HTML+Razor
<WABubbleChart @ref="bubbleChart" />

@code 
{
	WABubbleChart bubbleChart = default!;

	protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            BubbleChartDataSet[] DataSet =
            [
                new BubbleChartDataSet
                {
                    Label = "Technology",
                    Data = [
                        new BubbleChartPoint { X = 70, Y = 8.5, Radius = 18},
                        new BubbleChartPoint { X = 55, Y = 7.8, Radius = 14},
                        new BubbleChartPoint { X = 65, Y = 8.2, Radius = 12},
                    ],
                    BorderColor = "black"
                },
                new BubbleChartDataSet
                {
                    Label = "Healthcare",
                    Data = [
                        new BubbleChartPoint { X = 40, Y = 7.2, Radius = 16},
                        new BubbleChartPoint { X = 50, Y = 7.6, Radius = 18},
                        new BubbleChartPoint { X = 35, Y = 7.5, Radius = 12},
                    ]
                },
            ];

            var labels = new string[] { "Q1", "Q2", "Q3", "Q4" };
            var chartOptions = new BubbleChartOptions()
            {
                Label = "Industry comparison",
                LegendPosition = ChartLegendPosition.Bottom,
                GridLines = ChartGridLines.HorizontalOnly,


            };
            await bubbleChart.RenderChartAsync(labels, DataSet, chartOptions);
        }
    }

}
```
