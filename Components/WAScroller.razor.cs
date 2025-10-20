using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
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
        /// Set the orientation of the line. Defaults to horizontal.
        /// </summary>
        [Parameter]
        public ScrollerOrientation Orientation { get; set; } = ScrollerOrientation.Vertical;

        #endregion

        #region Computed  Properties
        string OrientationString
        {
            get
            {
                return (Orientation == ScrollerOrientation.Vertical) ? "vertical" : "horizontal";
            }
        }
        #endregion

    }


}
