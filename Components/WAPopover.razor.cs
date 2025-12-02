using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WAPopover : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The ID of the popover's anchor element. This must be an interactive/focusable element such as a button.
        /// </summary>
        [Parameter, EditorRequired]
        public string? TargetId { get; set; }

        /// <summary>
        /// The preferred placement of the popover. Note that the actual placement may vary as needed to keep the popover inside of the viewport.
        /// </summary>
        [Parameter]
        public PopoverPlacement Placement { get; set; } = PopoverPlacement.Top;

        /// <summary>
        /// Shows or hides the popover.
        /// </summary>
        [Parameter]
        public bool Open { get; set; } = false;

        /// <summary>
        /// The distance in pixels from which to offset the popover away from its trigger.
        /// </summary>
        [Parameter]
        public int Distance { get; set; } = 0;

        /// <summary>
        /// The distance in pixels from which to offset the popover along its target.
        /// </summary>
        [Parameter]
        public int Skidding { get; set; } = 0;

        /// <summary>
        /// Removes the arrow from the popover.
        /// </summary>
        [Parameter]
        public bool WithoutArrow { get; set; } = false;
        #endregion

        #region Computed  Properties
        string PlacementString
        {
            get
            {
                return Placement switch
                {
                    PopoverPlacement.Top => "top",
                    PopoverPlacement.TopStart => "top-start",
                    PopoverPlacement.TopEnd => "top-end",
                    PopoverPlacement.Bottom => "bottom",
                    PopoverPlacement.BottomStart => "bottom-start",
                    PopoverPlacement.BottomEnd => "bottom-end",
                    PopoverPlacement.Right => "right",
                    PopoverPlacement.RightStart => "right-start",
                    PopoverPlacement.RightEnd => "right-end",
                    PopoverPlacement.Left => "left",
                    PopoverPlacement.LeftStart => "left-start",
                    PopoverPlacement.LeftEnd => "left-end",
                    _ => "top"
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
                await JSRuntime.InvokeVoidAsync("window.vengage.popover.initialize", Id, objRef);
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

                // if (ModalService is not null && IsServiceModal)
                //     ModalService.OnShow -= OnShowAsync;
            }

            await base.DisposeAsyncCore(disposing);
        }
        #endregion

        #region Event Handlers
        [JSInvokable]
        public void HandlePopoverHide(string eventType, EventArgs eventArgs)
        {
            if (Open)
                Open = false;
        }

        [JSInvokable]
        public void HandlePopoverShow(string eventType, EventArgs eventArgs)
        {
            if (!Open)
                Open = true;
        }

        #endregion

        #region State
        private DotNetObjectReference<WAPopover> objRef = default!;
        #endregion




        #region Private Methods

        #endregion

        #region Public Methods
        /// <summary>
        /// Shows the popover
        /// </summary>
        public async Task ShowPopoverAsync()
        {
            Open = true;
            await JSRuntime.InvokeVoidAsync("window.vengage.popover.show", Id);
        }

        public void ShowPopover() => _ = ShowPopoverAsync();

        /// <summary>
        /// Hides the popover
        /// </summary>
        public async Task HidePopoverAsync()
        {
            Open = false;
            await JSRuntime.InvokeVoidAsync("window.vengage.popover.hide", Id);
        }

        public void HidePopover() => _ = HidePopoverAsync();

        /// <summary>
        /// Toggles the popover
        /// </summary>
        public async Task TogglePopoverAsync()
        {
            Open = !Open;
            if (Open)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.popover.show", Id);
                return;
            }
            await JSRuntime.InvokeVoidAsync("window.vengage.popover.hide", Id);


        }

        public void TogglePopover() => _ = TogglePopoverAsync();

        #endregion


    }


}
