using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WATreeItem : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Expands the tree item.
        /// </summary>
        [Parameter]
        public bool Expanded { get; set; } = false;

        /// <summary>
        /// Disables the tree item.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The animation duration when expanding tree items.
        /// </summary>
        [Parameter]
        public string ShowDuration { get; set; } = "200ms";

        /// <summary>
        /// The animation duration when collapsing tree items.
        /// </summary>
        [Parameter]
        public string HideDuration { get; set; } = "200ms";

        /// <summary>
        /// The value of the tree item. The value will be passed when selection chage is emitted on the WATree
        /// </summary>
        [Parameter]
        public string? Value { get; set; }

        #endregion

        #region Computed  Properties
        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--show-duration: {ShowDuration}", !String.IsNullOrWhiteSpace(ShowDuration)),
            ($"--hide-duration: {HideDuration}", !String.IsNullOrWhiteSpace(HideDuration))
            );
        #endregion

    }


}
