using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WAScroller : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Shows the shadows.
        /// </summary>
        [Parameter]
        public bool ShowShadow { get; set; } = true;

        /// <summary>
        /// Shows the visible scrollbar.
        /// </summary>
        [Parameter]
        public bool ShowScrollbar { get; set; } = true;
        /// <summary>
        /// The scroller's orientation.
        /// </summary>
        [Parameter]
        public ScrollerOrientation Orientation { get; set; } = ScrollerOrientation.Horizontal;

        /// <summary>
        /// The base color of the shadow. Default var(--wa-color-surface-default)
        /// </summary>
        [Parameter]
        public string? ShadowColor { get; set; }
        /// <summary>
        /// The size of the shadow. Default 2rem.
        /// </summary>
        [Parameter]
        public string? ShadowSize { get; set; }
        #endregion

        #region Computed  Properties
        string OrientationString
        {
            get
            {
                return (Orientation == ScrollerOrientation.Vertical) ? "vertical" : "horizontal";
            }
        }


        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--shadow-color:{ShadowColor}", !String.IsNullOrEmpty(ShadowColor)),
            ($"--shadow-size:{ShadowSize}", !String.IsNullOrEmpty(ShadowSize))
            );

        #endregion

    }


}
