using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WALayoutContent : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public LayoutSlots LayoutSlot { get; set; }
        #endregion

        #region Computed  Properties

        new string Slot
        {
            get
            {
                return LayoutSlot switch
                {
                    LayoutSlots.Banner => "banner",
                    LayoutSlots.Header => "header",
                    LayoutSlots.SubHeader => "subheader",
                    LayoutSlots.Menu => "menu",
                    LayoutSlots.NavigationHeader => "navigation-header",
                    LayoutSlots.Navigation => "navigation",
                    LayoutSlots.NavigationFooter => "navigation-footer",
                    LayoutSlots.NavigationToggle => "navigation-toggle",
                    LayoutSlots.NavigationToggleIcon => "navigation-toggle-icon",
                    LayoutSlots.MainHeader => "main-header",
                    LayoutSlots.MainFooter => "main-footer",
                    LayoutSlots.Aside => "aside",
                    LayoutSlots.SkipToContent => "skip-to-content",
                    LayoutSlots.Footer => "footer",
                    LayoutSlots.MainContent => "",
                    _ => ""
                };
            }
        }
        #endregion

    }

}
