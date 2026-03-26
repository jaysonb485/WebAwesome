using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor.Components
{
    public partial class WASparkline : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// An accessible label describing the sparkline for screen readers.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }


        /// <summary>
        /// The visual fill style of the sparkline.
        /// </summary>
        [Parameter]
        public SparklineAppearance Appearance { get; set; } = SparklineAppearance.Solid;

        /// <summary>
        /// An array of data points to be plotted on the sparkline, where each value is a string that can be parsed into a number. The sparkline will automatically scale to fit the range of the provided data.
        /// </summary>
        [Parameter]
        public string[] Data { get; set; } = [];

        /// <summary>
        /// The type of curve used to connect data points.
        /// </summary>
        [Parameter]
        public SparklineCurve Curve { get; set; } = SparklineCurve.Linear;

        /// <summary>
        /// An optional trend to indicate, which will affect the sparkline's default color.
        /// </summary>
        [Parameter]
        public SparklineTrend? Trend { get; set; }

        /// <summary>
        /// The color of the sparkline stroke.
        /// </summary>
        [Parameter]
        public string? LineColor { get; set; }

        /// <summary>
        /// The fill color for the area under the line.
        /// </summary>
        [Parameter]
        public string? FillColor { get; set; }

        /// <summary>
        ///  The width of the sparkline stroke in CSS units
        /// </summary>
        [Parameter]
        public string? LineWidth { get; set; }

        #endregion

        #region Computed  Properties

        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    SparklineAppearance.Line => "line",
                    SparklineAppearance.Solid => "solid",
                    SparklineAppearance.Gradient => "gradient",
                    _ => "solid"
                };
            }
        }

        string CurveString
        {
            get
            {
                return Curve switch
                {
                    SparklineCurve.Linear => "linear",
                    SparklineCurve.Step => "step",
                    SparklineCurve.Natural => "natural",
                    _ => "linear"
                };
            }
        }

        string TrendString
        {
            get
            {
                return Trend switch
                {
                    SparklineTrend.Positive => "positive",
                    SparklineTrend.Negative => "negative",
                    SparklineTrend.Neutral => "neutral",
                    _ => ""
                };
            }
        }

        string DataString => string.Join(" ", Data);

        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--fill-color: {FillColor}", !String.IsNullOrEmpty(FillColor)),
            ($"--line-color: {LineColor}", !String.IsNullOrEmpty(LineColor)),
            ($"--line-width: {LineWidth}", !String.IsNullOrEmpty(LineWidth))
            );

        #endregion


    }


}
