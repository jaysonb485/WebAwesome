using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WABreadcrumb : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The separator to use between breadcrumb items.
        /// </summary>
        [Parameter]
        public Icon? SeparatorIcon { get; set; }
        /// <summary>
        /// The separator to use between breadcrumb items. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? SeparatorIconName { get; set; }
   
        /// <summary>
        /// The label to use for the breadcrumb control. This will not be shown on the screen, but it will be announced by screen readers and other assistive devices to provide more context for users.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        #endregion

    }
}
