using System.Data;
using System.Text.Json.Serialization;

namespace WebAwesomeBlazor.Components
{
    public partial class WABarChart : WAComponentBase
    {
        #region Parameters

        private BarChartOptions ChartOptions { get; set; } = new();
        private BarChartDataSet[] DataSets = [];

        private string[] CategoryLabels = [];

        #endregion

        #region Computed  Properties

        protected override string? StyleNames => BuildStyleNames(Style,
            [.. DataSets
                .Select((ds, i) => new[]
                {
                    ((string?)$"--fill-color-{i + 1}: {ds.FillColor}", !string.IsNullOrWhiteSpace(ds.FillColor)),
                    ((string?)$"--border-color-{i + 1}: {ds.BorderColor}", !string.IsNullOrWhiteSpace(ds.BorderColor))
                })
                .SelectMany(x => x)
                .Concat(
                    [
                        ((string?)$"--border-radius: {ChartOptions.BorderRadius}", !string.IsNullOrWhiteSpace(ChartOptions.BorderRadius)),
                        ((string?)$"--border-width: {ChartOptions.BorderWidth}", !string.IsNullOrWhiteSpace(ChartOptions.BorderWidth)),
                        ((string?)$"--grid-border-width: {ChartOptions.GridBorderWidth}", !string.IsNullOrWhiteSpace(ChartOptions.GridBorderWidth)),
                        ((string?)$"--grid-color: {ChartOptions.GridColor}", !string.IsNullOrWhiteSpace(ChartOptions.GridColor))
                    ])
                ]
            );

        #endregion

        #region Public Methods
        public async Task RenderChartAsync(string[] categoryLabels, BarChartDataSet[] dataSets, BarChartOptions? barChartOptions = null)
        {
            DataSets = dataSets;
            CategoryLabels = categoryLabels;
            ChartOptions = barChartOptions ?? new();
            await InvokeAsync(StateHasChanged);

            await LoadModuleAsync("./_content/WebAwesomeBlazor/WAChart.js");
            await InvokeVoidAsync("render", Id!, CategoryLabels, DataSets);
        }
        #endregion
    }

    public class BarChartDataSet
    {
        public string Label { get; set; } = string.Empty;
        public double[] Data { get; set; } = [];
        [JsonIgnore]
        public string? FillColor { get; set; }
        [JsonIgnore]
        public string? BorderColor { get; set; }
    }

    public class BarChartOptions
    {
        /// <summary>
        /// A title for the chart, also used for accessibility.
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// A label for the x-axis.
        /// </summary>
        public string? XLabel { get; set; }
        /// <summary>
        /// A label for the y-axis.
        /// </summary>
        public string? YLabel { get; set; }
        /// <summary>
        /// Shows the legend, default.
        /// </summary>
        public bool ShowLegend { get; set; } = true;

        /// <summary>
        /// Enables chart animations, default
        /// </summary>
        public bool Animate { get; set; } = true;

        /// <summary>
        /// Shows tooltips over data points, default
        /// </summary>
        public bool ShowTooltips { get; set; } = true;
        /// <summary>
        /// Displays the chart horizontally.
        /// </summary>
        public bool Horizontal { get; set; } = false;
        /// <summary>
        /// Stacks datasets on top of each other along the value axis.
        /// </summary>
        public bool Stacked { get; set; } = false;

        /// <summary>
        /// The minimum value for the value axis.
        /// </summary>
        public double? Min { get; set; }

        /// <summary>
        /// The maximum value for the value axis.
        /// </summary>
        public double? Max { get; set; }

        /// <summary>
        /// A description of the chart, used for accessibility.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The position of the legend relative to the chart.
        /// </summary>
        public ChartLegendPosition LegendPosition { get; set; } = ChartLegendPosition.Top;
        /// <summary>
        /// Which axes to show grid lines on.
        /// </summary>
        public ChartGridLines GridLines { get; set; } = ChartGridLines.Both;

        /// <summary>
        /// Border radius for bar charts.
        /// </summary>
        public string? BorderRadius { get; set; }
        /// <summary>
        /// Border width for bars and arcs.
        /// </summary>
        public string? BorderWidth { get; set; }
        /// <summary>
        /// Border width for chart grid lines and axis borders.
        /// </summary>
        public string? GridBorderWidth { get; set; }
        /// <summary>
        /// Color of the chart grid lines and axis borders.
        /// </summary>
        public string? GridColor { get; set; }


        internal string LegendPositionString
        {
            get
            {
                return LegendPosition switch
                {
                    ChartLegendPosition.Top => "top",
                    ChartLegendPosition.Bottom => "bottom",
                    ChartLegendPosition.Left => "left",
                    ChartLegendPosition.Right => "right",
                    ChartLegendPosition.Start => "start",
                    ChartLegendPosition.End => "end",
                    _ => "top",
                };
            }
        }

        internal string GridLinesString
        {
            get
            {
                return GridLines switch
                {
                    ChartGridLines.Both => "both",
                    ChartGridLines.HorizontalOnly => "y",
                    ChartGridLines.VerticalOnly => "x",
                    ChartGridLines.None => "none",
                    _ => "both"
                };
            }
        }

    }


}
