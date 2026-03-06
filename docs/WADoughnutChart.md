# WADoughnutChart
## WebAwesomeBlazor.Components.WADoughnutChart

```HTML+Razor
<WADoughnutChart />
```

### Description
Doughnut charts show proportional data as slices of a ring with a hollow center. They offer a cleaner look than pie charts and work well in dashboards where the center space can provide additional context.

[WebAwesome docs](https://webawesome.com/docs/components/doughnut-chart)

> [!IMPORTANT]
> WebAwesome charts require access to WebAwesome Pro.

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| RenderChartAsync  | categoryLabels: string[], <br/> dataSets: DoughnutChartDataSet[], <br /> doughnutChartOptions: DoughnutChartOptions    | Provides the data and configuration for the chart. Can only be executed after render.      |

#### DoughnutChartDataSet Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string |  | The label for the dataset which appears in the legend and tooltips. |
| Data | double[] |  | An array of values representing the set data |
| FillColor | string[]? |  | An array of CSS colors for the fill color of each doughnut slice in CSS color. If not provided, colors associated with the WA Theme will be selected. |
| BorderColor | string[]? | | An array of CSS colors for the border color of each doughnut slice in CSS color.  If not provided, colors associated with the WA Theme will be selected. |

#### DoughnutChartOptions Properties
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
| CutoutSize | string? | `50%` | The size of the center hole. The default is '50%'. Use a higher percentage for a thinner ring or a lower one for a thicker ring. |


### Examples

#### Basic Usage
```HTML+Razor
<WADoughnutChart @ref="doughnutChart" />

@code 
{
	WADoughnutChart doughnutChart = default!;


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            DoughnutChartDataSet DataSet =
                new DoughnutChartDataSet
                {
                    Label = "Sales",
                    Data = [10, 58, 23, 71],
                    BorderColor = ["black"]
                };

            var labels = new string[] { "Online", "In-Store", "Wholesale", "Telephone" };
            var chartOptions = new DoughnutChartOptions()
            {
                Label = "Q1 Sales volume by channel",
                LegendPosition = ChartLegendPosition.Right,
                Description = "A doughnut  chart showing the sales split for the each channel in the first quarter.",
                GridLines = ChartGridLines.HorizontalOnly,

            };
            await doughnutChart.RenderChartAsync(labels, DataSet, chartOptions);
        }
    }

}
```
