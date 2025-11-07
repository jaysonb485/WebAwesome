using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Extended
{
    public partial class WANavTree : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The selection behavior of the tree. Single selection allows only one node to be selected at a time. Multiple displays checkboxes and allows more than one node to be selected. Leaf allows only leaf nodes to be selected.
        /// </summary>
        [Parameter]
        public NavTreeSelection? Selection { get; set; } = NavTreeSelection.Single;

        /// <summary>
        /// The name of the icon to draw for the expand indicator. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ExpandIconName { get; set; }

        /// <summary>
        /// The icon to draw for the expand indicator
        /// </summary>
        [Parameter]
        public Icon? ExpandIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw on for the collapse indicator. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? CollapseIconName { get; set; }

        /// <summary>
        /// The icon to draw for the expand indicator
        /// </summary>
        [Parameter]
        public Icon? CollapseIcon { get; set; }
        #endregion

        #region Computed  Properties
        private string SelectionString
        {
            get
            {
                return Selection switch
                {
                    NavTreeSelection.Single => "single",
                    NavTreeSelection.Multiple => "multiple",
                    NavTreeSelection.Leaf => "leaf",
                    _ => "single"
                };
            }
        }

        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                objRef = DotNetObjectReference.Create(this);
                await JSRuntime.InvokeVoidAsync("window.vengage.navtree.initialize", Id, objRef);
            }
        }
        #endregion

        #region State
        private DotNetObjectReference<WANavTree> objRef = default!;
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleNavTreeSelect(string href)
        {
            //if (TreeItemSelected.HasDelegate)
            //{
            //    await TreeItemSelected.InvokeAsync(href);
            //}
            Console.WriteLine($"navtree item Selected: {href}");
        }
        #endregion
    }
}

