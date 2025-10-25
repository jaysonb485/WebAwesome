using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WASelectOption : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The option's value. When selected, the containing form control will receive this value. The value must be unique from other options in the same group. Values may not contain spaces, as spaces are used as delimiters when listing multiple values.
        /// </summary>
        [Parameter,EditorRequired]
        public string? Value { get; set; }

        /// <summary>
        /// The option's label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// Disables the option
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The name of the icon to draw in the start slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? StartIconName { get; set; }
        /// <summary>
        /// The icon to draw in the start slot.
        /// </summary>
        [Parameter]
        public Icon? StartIcon { get; set; }
        /// <summary>
        /// The name of the icon to draw in the end slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? EndIconName { get; set; }
        /// <summary>
        /// The icon to draw in the end slot.
        /// </summary>
        [Parameter]
        public Icon? EndIcon { get; set; }

        #endregion

    }


}
