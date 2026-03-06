using Microsoft.JSInterop;
using System.Data;
using System.Text.Json.Serialization;

namespace WebAwesomeBlazor.Components
{
    public partial class WADoughnutChart : WAComponentBase
    {
        #region Parameters

        private DoughnutChartOptions ChartOptions { get; set; } = new();
        private DoughnutChartDataSet DataSet = new();

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
        public async Task RenderChartAsync(string[] categoryLabels, DoughnutChartDataSet dataSet, DoughnutChartOptions? doughnutChartOptions = null)
        {
            DataSet = dataSet;
            CategoryLabels = categoryLabels;
            ChartOptions = doughnutChartOptions ?? new();
            await InvokeAsync(StateHasChanged);

            var doughnutOptions = new { Cutout = ChartOptions.CutoutSize };

            var dataSets = new[] { new { label = DataSet.Label, data = DataSet.Data } };

            await JSRuntime.InvokeVoidAsync("window.vengage.chart.render", Id, CategoryLabels, dataSets, doughnutOptions);
        }
        #endregion
    }

    public class DoughnutChartDataSet
    {
        public string Label { get; set; } = string.Empty;
        public double[] Data { get; set; } = [];
        [JsonIgnore]
        public string[] FillColor { get; set; } = [];
        [JsonIgnore]
        public string[] BorderColor { get; set; } = [];
    }

    public class DoughnutChartOptions
    {
        /// <summary>
        /// A title for the chart, also used for accessibility.
        /// </summary>
        public string? Label { get; set; }

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

        /// <summary>
        /// Control the size of the center hole. The default is '50%'. Use a higher percentage for a thinner ring or a lower one for a thicker ring.
        /// </summary>
        [JsonPropertyName("cutout")]
        public string CutoutSize { get; set; } = "50%";

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
