using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WAZoomableFrame : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The name of the icon to draw for the ZoomIn icon. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ZoomInIconName { get; set; }

        /// <summary>
        /// The icon to draw for the ZoomIn icon.
        /// </summary>
        [Parameter]
        public Icon? ZoomInIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw for the ZoomOut icon. Rotates on open and close. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ZoomOutIconName { get; set; }

        /// <summary>
        /// The icon to draw for the ZoomOut icon.
        /// </summary>
        [Parameter]
        public Icon? ZoomOutIcon { get; set; }

        /// <summary>
        /// The URL of the content to display.
        /// </summary>
        [Parameter]
        public string? SourceUrl { get; set; }

        /// <summary>
        /// Inline HTML to display.
        /// </summary>
        [Parameter]
        public string? SourceHtml { get; set; }

        /// <summary>
        /// Allows fullscreen mode.
        /// </summary>
        [Parameter]
        public bool AllowFullScreen { get; set; } = false;

        /// <summary>
        /// Controls iframe loading behavior. Default is eager loading.
        /// </summary>
        [Parameter]
        public bool LazyLoad { get; set; } = false;

        /// <summary>
        /// Controls referrer information.
        /// </summary>
        [Parameter]
        public string? ReferrerPolicy { get; set; }

        /// <summary>
        /// Security restrictions for the iframe.
        /// </summary>
        [Parameter]
        public string? Sandbox { get; set; }

        /// <summary>
        /// The current zoom of the frame, e.g. 0 = 0% and 1 = 100%.
        /// </summary>
        [Parameter]
        public double Zoom { get; set; } = 1;

        /// <summary>
        /// The zoom levels to step through when using zoom controls. This does not restrict programmatic changes to the zoom.
        /// Provide space-separated values, e.g. "25% 50% 75% 100% 125% 150% 175% 200%".
        /// </summary>
        [Parameter]
        public string ZoomLevels { get; set; } = "25% 50% 75% 100% 125% 150% 175% 200%";

        /// <summary>
        /// Removes the zoom controls.
        /// </summary>
        [Parameter]
        public bool HideZoomControls { get; set; } = false;

        /// <summary>
        /// Disables interaction.
        /// </summary>
        [Parameter]
        public bool DisableInteraction { get; set; } = false;
        /// <summary>
        /// Emitted when the internal iframe when it finishes loading.
        /// </summary>
        [Parameter]
        public EventCallback Loaded { get; set; }
        /// <summary>
        /// Emitted from the internal iframe when it fails to load.
        /// </summary>
        [Parameter]
        public EventCallback<string> LoadError { get; set; }
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
                await JSRuntime.InvokeVoidAsync("window.vengage.zoomable.initialize", Id, objRef);
            }
        }

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                objRef?.Dispose();
            }

            await base.DisposeAsyncCore(disposing);
        }

        #endregion

        #region State
        private DotNetObjectReference<WAZoomableFrame> objRef = default!;
        #endregion

        #region Private Methods
        [JSInvokable]
        public async Task HandleZoomableLoaded()
        {
            if (Loaded.HasDelegate)
                await Loaded.InvokeAsync();
        }

        [JSInvokable]
        public async Task HandleZoomableError(int HttpErrorCode)
        {
            if (LoadError.HasDelegate)
                await LoadError.InvokeAsync(HttpErrorCode.ToString());
        }
        #endregion


        #region Public Methods
        /// <summary>
        /// Zooms in to the next available zoom level.
        /// </summary>
        public async Task ZoomInAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.zoomable.zoomIn", Id);
        }
        /// <summary>
        /// Zooms out to the previous available zoom level.
        /// </summary>
        public async Task ZoomOutAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.zoomable.zoomOut", Id);
        }
        #endregion
    }


}
