using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor.Components
{
    public partial class WADivider : WAComponentBase
    {
        #region Parameters

        /// <summary>
        ///The color of the divider. Use CSS named colors or hex values
        /// </summary>
        [Parameter]
        public string? Color { get; set; }


        /// <summary>
        /// The length of the line between the divider's edge and a label placed at the start or end.
        /// </summary>
        [Parameter]
        public string? LabelOffset { get; set; }
        /// <summary>
        /// Where the label sits along the divider.
        /// </summary>
        [Parameter]
        public DividerLabelPlacement LabelPlacement { get; set; } = DividerLabelPlacement.Center;

        /// <summary>
        /// The amount of space between the label and the divider's lines.
        /// </summary>
        [Parameter]
        public string? LabelSpacing { get; set; }
        /// <summary>
        /// Set the orientation of the line. Defaults to horizontal.
        /// </summary>
        [Parameter]
        public DividerOrientation Orientation { get; set; } = DividerOrientation.Horizontal;

        /// <summary>
        /// The width of the gap around the divider. In any CSS unit, e.g. px, rem, pts
        /// </summary>
        [Parameter]
        public string? Spacing { get; set; }

        /// <summary>
        /// The width of the divider. In any CSS unit, e.g. px, rem, pts
        /// </summary>
        [Parameter]
        public string? Width { get; set; }


        #endregion

        #region Computed  Properties

        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--spacing: {Spacing}", !String.IsNullOrEmpty(Spacing)),
            ($"--width: {Width}", !String.IsNullOrEmpty(Width)),
            ($"--color: {Color}", !String.IsNullOrEmpty(Color)),
            ($"--label-spacing: {LabelSpacing}", !String.IsNullOrEmpty(LabelSpacing)),
            ($"--label-offset: {LabelOffset}", !String.IsNullOrEmpty(LabelOffset))
        );

        string OrientationString
        {
            get
            {
                return Orientation switch
                {
                    DividerOrientation.Horizontal => "horizontal",
                    DividerOrientation.Vertical => "vertical",
                    _ => "horizontal"
                };
            }
        }

        string LabelPlacementString
        {
            get
            {
                return LabelPlacement switch
                {
                    DividerLabelPlacement.Center => "center",
                    DividerLabelPlacement.Start => "start",
                    DividerLabelPlacement.End => "end",
                    _ => "center"
                };
            }
        }
        #endregion


    }
}
