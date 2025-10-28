using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WATree : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The selection behavior of the tree. Single selection allows only one node to be selected at a time. Multiple displays checkboxes and allows more than one node to be selected. Leaf allows only leaf nodes to be selected.
        /// </summary>
        [Parameter]
        public TreeSelection SelectionMode { get; set; } = TreeSelection.Single;

        /// <summary>
        /// Emitted when a tree item is selected or deselected. Provides array list of tree item values. Requires value property set on each tree item.
        /// </summary>
        [Parameter]
        public EventCallback<string[]> SelectionChanged { get; set; }

        /// <summary>
        /// The size of the indentation for nested items.
        /// </summary>
        [Parameter]
        public string? IndentSize { get; set; }

        /// <summary>
        /// The color of the indentation line.
        /// </summary>
        [Parameter]
        public string? IndentGuideColor { get; set; }

        /// <summary>
        /// The amount of vertical spacing to leave between the top and bottom of the indentation line's starting position.
        /// </summary>
        [Parameter]
        public string? IndentGuideOffset { get; set; }

        /// <summary>
        /// The style of the indentation line, e.g. solid, dotted, dashed.
        /// </summary>
        [Parameter]
        public TreeIndentStyle IndentGuideStyle { get; set; } = TreeIndentStyle.Solid;

        /// <summary>
        /// The width of the indentation line. Defaults to 0px.
        /// </summary>
        [Parameter]
        public string? IndentGuideWidth { get; set; }

        /// <summary>
        /// The icon to show when the tree item is expanded. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ExpandIconName { get; set; }

        /// <summary>
        /// The icon to show when the tree item is expanded.
        /// </summary>
        [Parameter]
        public Icon? ExpandIcon { get; set; }

        /// <summary>
        /// The icon to show when the tree item is collapsed. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? CollapseIconName { get; set; }

        /// <summary>
        /// The icon to show when the tree item is collapsed
        /// </summary>
        [Parameter]
        public Icon? CollapseIcon { get; set; }


        #endregion

        #region Computed  Properties
        private string SelectionString
        {
            get
            {
                return SelectionMode switch
                {
                    TreeSelection.Single => "single",
                    TreeSelection.Multiple => "multiple",
                    TreeSelection.Leaf => "leaf",
                    _ => "single"
                };
            }
        }

        private string IndentStyleString
        {
            get
            {
                return IndentGuideStyle switch
                {
                    TreeIndentStyle.Solid => "solid",
                    TreeIndentStyle.Dashed => "dashed",
                    TreeIndentStyle.Dotted => "dotted",
                    _ => "solid"
                };
            }
        }

        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--indent-size: {IndentSize}", !String.IsNullOrEmpty(IndentSize)),
            ($"--indent-guide-color: {IndentGuideColor}", !String.IsNullOrEmpty(IndentGuideColor)),
            ($"--indent-guide-offset: {IndentGuideOffset}", !String.IsNullOrEmpty(IndentGuideOffset)),
            ($"--indent-guide-style: {IndentStyleString}", !String.IsNullOrEmpty(IndentStyleString)),
            ($"--indent-guide-width: {IndentGuideWidth}", !String.IsNullOrEmpty(IndentGuideWidth))
            );
        #endregion
        #region Lifecycle
        protected override void OnInitialized()
        {
            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= [];

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.tree.initialize", Id, objRef);
            }
        }

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    // if (IsRenderComplete)
                    // await JSRuntime.InvokeVoidAsync("window.blazorBootstrap.modal.dispose", Id);
                }
                catch (JSDisconnectedException)
                {
                    // do nothing
                }

                objRef?.Dispose();


            }

            await base.DisposeAsyncCore(disposing);
        }

        #endregion

        #region State
        private DotNetObjectReference<WATree> objRef = default!;
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleSelectionChanged(string[] selectedIds)
        {
            if(SelectionChanged.HasDelegate) await SelectionChanged.InvokeAsync(selectedIds);
        }
        #endregion

    }


}
