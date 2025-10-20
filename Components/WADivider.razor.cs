using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WADivider : WAComponentBase
    {
        #region Parameters
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

        /// <summary>
        ///The color of the divider. Use CSS named colors or hex values
        /// </summary>
        [Parameter]
        public string? Color { get; set; }

        /// <summary>
        /// Set the orientation of the line. Defaults to horizontal.
        /// </summary>
        [Parameter]
        public DividerOrientation Orientation { get; set; } = DividerOrientation.Horizontal;
        #endregion

        #region Computed  Properties

        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--spacing: {Spacing}", !String.IsNullOrEmpty(Spacing)),
            ($"--width: {Width}", !String.IsNullOrEmpty(Width)),
            ($"--color: {Color}", !String.IsNullOrEmpty(Color))
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
        #endregion


    }
}
