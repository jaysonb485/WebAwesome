using System.Data;
using System.Text.Json.Serialization;

namespace WebAwesomeBlazor.Components
{
    public partial class WAScatterChart : WAComponentBase
    {
        #region Parameters

        private ScatterChartOptions ChartOptions { get; set; } = new();
        private ScatterChartDataSet[] DataSets = [];

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
                        ((string?)$"--grid-border-width: {ChartOptions.GridBorderWidth}", !string.IsNullOrWhiteSpace(ChartOptions.GridBorderWidth)),
                        ((string?)$"--grid-color: {ChartOptions.GridColor}", !string.IsNullOrWhiteSpace(ChartOptions.GridColor)),
                        ((string?)$"--point-radius: {ChartOptions.PointRadius}", !string.IsNullOrWhiteSpace(ChartOptions.PointRadius))
                    ])
                ]
            );

        #endregion

        #region Public Methods
        public async Task RenderChartAsync(string[] categoryLabels, ScatterChartDataSet[] dataSets, ScatterChartOptions? scatterChartOptions = null)
        {
            DataSets = dataSets;
            CategoryLabels = categoryLabels;
            ChartOptions = scatterChartOptions ?? new();
            await InvokeAsync(StateHasChanged);
            await LoadModuleAsync("./_content/WebAwesomeBlazor/WAChart.js");
            await InvokeVoidAsync("render", Id!, CategoryLabels, DataSets);
        }
        #endregion
    }

    public class ScatterChartDataSet
    {
        public string Label { get; set; } = string.Empty;
        public ScatterPoint[] Data { get; set; } = [];
        [JsonIgnore] public string? FillColor { get; set; }
        [JsonIgnore] public string? BorderColor { get; set; }
    }

    public class ScatterPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class ScatterChartOptions
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
        /// Radius of data point dots.
        /// </summary>
        public string? PointRadius { get; set; }



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
