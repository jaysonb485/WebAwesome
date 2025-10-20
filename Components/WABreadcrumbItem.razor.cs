using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WABreadcrumbItem : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public EventCallback<MouseEventArgs?> OnClick { get; set; }

        /// <summary>
        /// The icon to draw in the start slot. Altneratively, use StartIconName to specify the name of the icon.
        /// </summary>
        [Parameter]
        public Icon? StartIcon { get; set; }

        /// <summary>
        /// The icon to draw in the start slot. Alternatively, use EndIconName to specify the name of the icon.
        /// </summary>
        [Parameter]
        public Icon? EndIcon { get; set; }

        /// <summary>
        /// The icon to draw in the start slot. Alternatively, use SeparatorIconName to specify the name of the icon.
        /// </summary>
        [Parameter]
        public Icon? SeparatorIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw in the start slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? SeparatorIconName { get; set; }

        /// <summary>
        /// The name of the icon to draw in the start slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? StartIconName { get; set; }
        /// <summary>
        /// The name of the icon to draw in the end slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? EndIconName { get; set; }
        #endregion

    }
}
