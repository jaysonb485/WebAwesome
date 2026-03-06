# WABarChart
## WebAwesomeBlazor.Components.WABarChart

```HTML+Razor
<WABarChart />
```

### Description
Bar charts compare quantities across categories using rectangular bars. They work well for showing rankings, highlighting differences between groups, and tracking changes across time periods.

[WebAwesome docs](https://webawesome.com/docs/components/bar-chart)

> [!IMPORTANT]
> WebAwesome charts require access to WebAwesome Pro.

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| RenderChartAsync  | categoryLabels: string[], <br/> dataSets: BarChartDataSet[], <br /> barChartOptions: BarChartOptions    | Provides the data and configuration for the chart. Can only be executed after render.      |

#### BarChartDataSet Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string |  | The label for the dataset which appears in the legend and tooltips. |
| Data | double[] |  | An array of values representing the set data |
| FillColor | string? |  | The bar fill color in CSS color. If not provided, colors associated with the WA Theme will be selected. |
| BorderColor | string? | | The bar border color in CSS color.  If not provided, colors associated with the WA Theme will be selected. |

#### BarChartOptions Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string? |  | A title for the chart, also used for accessibility. |
| XLabel | string? |  | A label for the x-axis. |
| YLabel | string? |  | A label for the y-axis. |
| ShowLegend | bool | `true` | Shows the legend |
| Animate | bool | `true` | Enables chart animations |
| ShowTooltips | bool | `true` | Shows tooltips over data points. |
| Horizontal | bool | `false` | Displays the chart horizontally |
| Stacked | bool | `false` | Stacks datasets on top of each other along the value axis |
| Min | double? | | The minimum value for the value axis |
| Max | double? | | The maximum value for the value axis |
| Description | string? | | A description of the chart, used for accessibility. |
| LegendPosition | ChartLegendPosition | `ChartLegendPosition.Top` | The position of the legend relative to the chart. |
| GridLines | ChartGridLines | `ChartGridLines.Both` | Which axes to show grid lines on. |
| BorderRadius | string? | | Border radius for bar charts in CSS units. |
| BorderWidth | string? | | Border width for bars in CSS units. |
| GridBorderWidth | string? | | Border width for chart grid lines and axis borders in CSS units. |
| GridColor | string? | | CSS color of the chart grid lines and axis borders. |


### Examples

#### Basic Usage
```HTML+Razor
<WABarChart @ref="barChart" />

@code 
{
	WABarChart barChart = default!;

	protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            BarChartDataSet[] DataSet =
            [
                new BarChartDataSet
                {
                    Label = "Online",
                    Data = [42, 58, 63, 71],
                    BorderColor = "black"
                },
                new BarChartDataSet
                {
                    Label = "In-store",
                    Data = [65, 53, 48, 52 ],
                },
                new BarChartDataSet
                {
                    Label = "Wholesale",
                    Data = [28, 32, 35, 40 ],
                }
            ];

            var labels = new string[] { "Q1", "Q2", "Q3", "Q4" };
            var chartOptions = new BarChartOptions()
            {
                Label = "Quarterly Sales by Channel",
                XLabel = "Quarter",
                YLabel = "Sales ($thousands)",
                LegendPosition = ChartLegendPosition.Right,
                Description = "A bar chart showing the sales for each channel by quarter.",
                GridLines = ChartGridLines.HorizontalOnly,

            };
            await barChart.RenderChartAsync(labels, DataSet, chartOptions);
        }
    }

}
```
