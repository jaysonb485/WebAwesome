using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WAZoomableFrame : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The name of the icon to draw for the ZoomIn icon. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ZoomInIconName { get; set; }

        /// <summary>
        /// The icon to draw for the ZoomIn icon.
        /// </summary>
        [Parameter]
        public Icon? ZoomInIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw for the ZoomOut icon. Rotates on open and close. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ZoomOutIconName { get; set; }

        /// <summary>
        /// The icon to draw for the ZoomOut icon.
        /// </summary>
        [Parameter]
        public Icon? ZoomOutIcon { get; set; }

        /// <summary>
        /// The URL of the content to display.
        /// </summary>
        [Parameter]
        public string? SourceUrl { get; set; }

        /// <summary>
        /// Inline HTML to display.
        /// </summary>
        [Parameter]
        public string? SourceHtml { get; set; }

        /// <summary>
        /// Allows fullscreen mode.
        /// </summary>
        [Parameter]
        public bool AllowFullScreen { get; set; } = false;

        /// <summary>
        /// Controls iframe loading behavior. Default is eager loading.
        /// </summary>
        [Parameter]
        public bool LazyLoad { get; set; } = false;

        /// <summary>
        /// Controls referrer information.
        /// </summary>
        [Parameter]
        public string? ReferrerPolicy { get; set; }

        /// <summary>
        /// Security restrictions for the iframe.
        /// </summary>
        [Parameter]
        public string? Sandbox { get; set; }

        /// <summary>
        /// The current zoom of the frame, e.g. 0 = 0% and 1 = 100%.
        /// </summary>
        [Parameter]
        public double Zoom { get; set; } = 1;

        /// <summary>
        /// The zoom levels to step through when using zoom controls. This does not restrict programmatic changes to the zoom.
        /// Provide space-separated values, e.g. "25% 50% 75% 100% 125% 150% 175% 200%".
        /// </summary>
        [Parameter]
        public string ZoomLevels { get; set; } = "25% 50% 75% 100% 125% 150% 175% 200%";

        /// <summary>
        /// Removes the zoom controls.
        /// </summary>
        [Parameter]
        public bool HideZoomControls { get; set; } = false;

        /// <summary>
        /// Disables interaction when present.
        /// </summary>
        [Parameter]
        public bool DisableInteraction { get; set; } = false;
        #endregion


    }


}
