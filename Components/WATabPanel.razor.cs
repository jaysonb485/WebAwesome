using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WATabPanel : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public RenderFragment? PanelContent { get; set; }

        [Parameter]
        public RenderFragment? TabContent { get; set; }
        /// <summary>
        /// The text to display in the tab nav
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// Allow the tab to be closed.
        /// </summary>
        //[Parameter]
        //public bool Closeable { get; set; } = false;

        //TODO: Allow closeable tabs

        /// <summary>
        /// The name of the tab panel this tab is associated with.
        /// </summary>
        [Parameter, EditorRequired]
        public string? Name { get; set; }

        /// <summary>
        /// Disables the tab and prevents selection.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;
        /// <summary>
        /// The tab panel's padding.
        /// </summary>
        [Parameter]
        public string? PanelPadding { get; set; }
        /// <summary>
        /// CSS Panel attributes to apply to the tab panel.
        /// </summary>
        [Parameter]
        public string? PanelStyle { get; set; }
        /// <summary>
        /// CSS Class attrributes to apply to the tab panel.
        /// </summary>
        [Parameter]
        public string? PanelClass { get; set; }
        #endregion
        #region Computed Properties

        #endregion

        #region State
        private string? PanelStyleNames => BuildStyleNames(PanelStyle,
         ($"--padding: {PanelPadding}", !String.IsNullOrEmpty(PanelPadding))
        );
        private string? PanelClassNames => BuildClassNames(PanelClass);
        #endregion

    }


}
