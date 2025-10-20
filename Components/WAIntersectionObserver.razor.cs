using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WAIntersectionObserver : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Element ID to define the viewport boundaries for tracked targets.
        /// </summary>
        [Parameter]
        public string? RootElementId { get; set; }

        /// <summary>
        /// Offset space around the root boundary. Accepts values like CSS margin syntax.
        /// </summary>
        [Parameter]
        public string RootMargin { get; set; } = "0px";

        /// <summary>
        /// One or more space-separated values representing visibility percentages that trigger the observer callback.
        /// </summary>
        [Parameter]
        public string? Threshold { get; set; } = "0";

        /// <summary>
        /// CSS class applied to elements during intersection. Automatically removed when elements leave the viewport, enabling pure CSS styling based on visibility state.
        /// </summary>
        [Parameter]
        public string? IntersectClass { get; set; }

        /// <summary>
        /// If enabled, observation ceases after initial intersection.
        /// </summary>
        [Parameter]
        public bool ShowOnce { get; set; } = false;

        /// <summary>
        /// Deactivates the intersection observer functionality.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        [Parameter]
        public EventCallback OnIntersecting { get; set; }

        [Parameter]
        public EventCallback OnLeaving { get; set; }
        #endregion



        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                objRef = DotNetObjectReference.Create(this);
                await JSRuntime.InvokeVoidAsync("window.vengage.interceptObserver.initialize", Id, objRef);
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
        public async Task HandleIntersecting()
        {
            Console.WriteLine($"Intersecting: ");
            await OnIntersecting.InvokeAsync(null);
        }

        [JSInvokable]
        public async Task HandleLeaving()
        {
            Console.WriteLine($"Leaving: ");
            await OnLeaving.InvokeAsync(null);
        }

        #endregion

        #region State
        private DotNetObjectReference<WAIntersectionObserver> objRef = default!;
        #endregion

    }


}
