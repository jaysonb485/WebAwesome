# WAPieChart
## WebAwesomeBlazor.Components.WAPieChart

```HTML+Razor
<WAPieChart />
```

### Description
Pie charts show the proportional composition of a whole as slices of a circle. They work best with a small number of categories where the relative proportions matter more than exact values.

[WebAwesome docs](https://webawesome.com/docs/components/pie-chart)

> [!IMPORTANT]
> WebAwesome charts require access to WebAwesome Pro.

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| RenderChartAsync  | categoryLabels: string[], <br/> dataSets: PieChartDataSet[], <br /> pieChartOptions: PieChartOptions    | Provides the data and configuration for the chart. Can only be executed after render.      |

#### PieChartDataSet Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string |  | The label for the dataset which appears in the legend and tooltips. |
| Data | double[] |  | An array of values representing the set data |
| FillColor | string[]? |  | An array of CSS colors for the fill color of each pie slice in CSS color. If not provided, colors associated with the WA Theme will be selected. |
| BorderColor | string[]? | | An array of CSS colors for the border color of each pie slice in CSS color.  If not provided, colors associated with the WA Theme will be selected. |

#### PieChartOptions Properties
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
<WAPieChart @ref="pieChart" />

@code 
{
	WAPieChart pieChart = default!;


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            PieChartDataSet DataSet =
                new PieChartDataSet
                {
                    Label = "Sales",
                    Data = [10, 58, 23, 71],
                    BorderColor = ["black"]
                };

            var labels = new string[] { "Online", "In-Store", "Wholesale", "Telephone" };
            var chartOptions = new PieChartOptions()
            {
                Label = "Q1 Sales volume by channel",
                LegendPosition = ChartLegendPosition.Right,
                Description = "A pie chart showing the sales split for the each channel in the first quarter.",
                GridLines = ChartGridLines.HorizontalOnly,

            };
            await pieChart.RenderChartAsync(labels, DataSet, chartOptions);
        }
    }

}
```
