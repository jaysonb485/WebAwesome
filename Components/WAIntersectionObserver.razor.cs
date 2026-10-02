using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
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

        [Obsolete("Use Intersecting instead.")]
        [Parameter]
        public EventCallback OnIntersecting { get; set; }

        [Obsolete("Use Leaving instead.")]
        [Parameter]
        public EventCallback OnLeaving { get; set; }

        /// <summary>
        /// Event triggered when an observed element enters the viewport.
        /// </summary>
        [Parameter]
        public EventCallback Intersecting { get; set; }

        /// <summary>
        /// Event triggered when an observed element exits the viewport.
        /// </summary>
        [Parameter]
        public EventCallback Leaving { get; set; }
        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {

                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Id!, objRef);
            }
        }

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    if (_instance is not null)
                        await _instance.InvokeVoidAsync("dispose");
                }
                catch (JSDisconnectedException)
                {
                }
                objRef?.Dispose();

            }

        }

        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);
            await base.OnInitializedAsync();
        }

        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleIntersecting()
        {
            await IntersectingCallback.InvokeAsync(null);
        }

        [JSInvokable]
        public async Task HandleLeaving()
        {
            await LeavingCallback.InvokeAsync(null);
        }

        #endregion

        #region State
        private DotNetObjectReference<WAIntersectionObserver> objRef = default!;

#pragma warning disable CS0618 // Type or member is obsolete
        private EventCallback IntersectingCallback => Intersecting.HasDelegate ? Intersecting : OnIntersecting;
        private EventCallback LeavingCallback => Leaving.HasDelegate ? Leaving : OnLeaving;
#pragma warning restore CS0618 // Type or member is obsolete
        #endregion

    }


}
