using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WASplitPanel : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Content to place in the start panel.
        /// </summary>
        [Parameter, EditorRequired]
        public RenderFragment StartContent { get; set; } = default!;
        /// <summary>
        /// Content to place in the end panel.
        /// </summary>
        [Parameter, EditorRequired]
        public RenderFragment EndContent { get; set; } = default!;

        /// <summary>
        /// The current position of the divider from the primary panel's edge as a percentage 0-100. Defaults to 50% of the container's initial size.
        /// </summary>
        [Parameter]
        public int? PositionPercent { get; set; } = 50;

        /// <summary>
        /// The current position of the divider from the primary panel's edge in pixels.
        /// </summary>
        [Parameter]
        public int? PositionPixels { get; set; }

        /// <summary>
        /// Sets the split panel's orientation.
        /// </summary>
        [Parameter]
        public SplitPanelOrientation Orientation { get; set; } = SplitPanelOrientation.Horizontal;

        /// <summary>
        /// Disables resizing. Note that the position may still change as a result of resizing the host element.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// If no primary panel is designated, both panels will resize proportionally when the host element is resized. If a primary panel is designated, it will maintain its size and the other panel will grow or shrink as needed when the host element is resized.
        /// </summary>
        [Parameter]
        public SplitPanelPrimaryPanel? PrimaryPanel { get; set; }
        /// <summary>
        /// One or more space-separated values at which the divider should snap. Values can be in pixels or percentages, e.g. "100px 50%".
        /// </summary>
        [Parameter]
        public string? SnapPoints { get; set; }

        /// <summary>
        /// How close the divider must be to a snap point until snapping occurs.
        /// </summary>
        [Parameter]
        public int SnapThreshold { get; set; } = 12;

        /// <summary>
        /// The name of the icon to draw for the Divider. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? DividerIconName { get; set; }

        /// <summary>
        /// The icon to draw for the Divider.
        /// </summary>
        [Parameter]
        public Icon? DividerIcon { get; set; }

        /// <summary>
        /// If set, defines the minimum allowed width of the primary panel in CSS units.
        /// </summary>
        [Parameter]
        public string? PrimaryMinWidth { get; set; }

        /// <summary>
        /// Height of the container in CSS units.
        /// </summary>
        [Parameter]
        public string? Height { get; set; }

        /// <summary>
        /// Width of the container in CSS units.
        /// </summary>
        [Parameter]
        public string? Width { get; set; }


        /// <summary>
        /// If set, defines the maximum allowed width of the primary panel in CSS units.
        /// </summary>
        [Parameter]
        public string? PrimaryMaxWidth { get; set; }
        #endregion

        #region Computed  Properties
        string OrientationString
        {
            get
            {
                return Orientation switch
                {
                    SplitPanelOrientation.Horizontal => "horizontal",
                    SplitPanelOrientation.Vertical => "vertical",
                    _ => "horizontal"
                };
            }
        }

        string? PrimaryPanelString
        {
            get
            {
                return PrimaryPanel switch
                {
                    SplitPanelPrimaryPanel.Start => "start",
                    SplitPanelPrimaryPanel.End => "end",
                    _ => null
                };
            }
        }

        protected override string StyleNames => BuildStyleNames(Style,
            ($"--min: {PrimaryMinWidth}", !String.IsNullOrEmpty(PrimaryMinWidth)),
            ($"--max: {PrimaryMaxWidth}", !String.IsNullOrEmpty(PrimaryMaxWidth)),
            ($"height: {Height}", !String.IsNullOrEmpty(Height)),
            ($"width: {Width}", !String.IsNullOrEmpty(Width))
        );
        #endregion

        #region Events
        //TODO: Add wa-reposition event listener
        #endregion

    }


}
