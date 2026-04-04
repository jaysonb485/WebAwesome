using System.Data;
using System.Text.Json.Serialization;

namespace WebAwesomeBlazor.Components
{
    public partial class WAPieChart : WAComponentBase
    {
        #region Parameters

        private PieChartOptions ChartOptions { get; set; } = new();
        private PieChartDataSet DataSet = new();

        private string[] CategoryLabels = [];

        #endregion

        #region Computed  Properties

        protected override string? StyleNames => BuildStyleNames(Style,
            [.. DataSet.FillColor
                .Select((ds, i) => new[]
                {
                    ((string?)$"--fill-color-{i + 1}: {ds}", !string.IsNullOrWhiteSpace(ds)),
                })
                .SelectMany(x => x)
                .Concat(
                    [
                        ((string?)$"--grid-border-width: {ChartOptions.GridBorderWidth}", !string.IsNullOrWhiteSpace(ChartOptions.GridBorderWidth)),
                        ((string?)$"--grid-color: {ChartOptions.GridColor}", !string.IsNullOrWhiteSpace(ChartOptions.GridColor))
                    ])
                .Concat(
                [.. DataSet.BorderColor
                    .Select((ds, i) => new []
                    {
                        ((string?)$"--border-color-{i + 1}: {ds}", !string.IsNullOrWhiteSpace(ds))
                    })
                    .SelectMany(x => x)
                ])
                ]
            );

        #endregion

        #region Public Methods
        public async Task RenderChartAsync(string[] categoryLabels, PieChartDataSet dataSet, PieChartOptions? pieChartOptions = null)
        {
            DataSet = dataSet;
            CategoryLabels = categoryLabels;
            ChartOptions = pieChartOptions ?? new();
            await InvokeAsync(StateHasChanged);

            var dataSets = new[] { new { label = DataSet.Label, data = DataSet.Data } };
            await LoadModuleAsync("./_content/WebAwesomeBlazor/WAChart.js");
            await InvokeVoidAsync("render", Id!, CategoryLabels, dataSets);
        }
        #endregion
    }

    public class PieChartDataSet
    {
        public string Label { get; set; } = string.Empty;
        public double[] Data { get; set; } = [];
        [JsonIgnore] public string[] FillColor { get; set; } = [];
        [JsonIgnore] public string[] BorderColor { get; set; } = [];
    }

    public class PieChartOptions
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
