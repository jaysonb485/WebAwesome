using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WAZoomableFrame : WAComponentBase
    {
        #region Parameters

        /// <summary>
        /// Allows fullscreen mode.
        /// </summary>
        [Parameter]
        public bool AllowFullScreen { get; set; } = false;
        /// <summary>
        /// A Permissions Policy that controls which features the embedded content can use, e.g. clipboard-write; fullscreen. The browser reads this when the frame loads, so changing it afterwards has no effect until the frame navigates again.
        /// </summary>
        [Parameter]
        public string? AllowPolicy { get; set; }

        /// <summary>
        /// Disables interaction.
        /// </summary>
        [Parameter]
        public bool DisableInteraction { get; set; } = false;

        /// <summary>
        /// Removes the zoom controls.
        /// </summary>
        [Parameter]
        public bool HideZoomControls { get; set; } = false;

        /// <summary>
        /// An accessible name for the frame. Screen readers announce it when moving between frames, so set one that describes the frame's content.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// Controls iframe loading behavior. Default is eager loading.
        /// </summary>
        [Parameter]
        public bool LazyLoad { get; set; } = false;

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
        /// Inline HTML to display.
        /// </summary>
        [Parameter]
        public string? SourceHtml { get; set; }
        /// <summary>
        /// The URL of the content to display.
        /// </summary>
        [Parameter]
        public string? SourceUrl { get; set; }

        /// <summary>
        /// Enables automatic theme syncing (light/dark mode and theme selector classes) from the host document to the iframe.
        /// </summary>
        [Parameter]
        public bool SyncThemes { get; set; } = false;

        /// <summary>
        /// The current zoom of the frame, e.g. 0 = 0% and 1 = 100%.
        /// </summary>
        [Parameter]
        public double Zoom { get; set; } = 1;
        /// <summary>
        /// The icon to draw for the ZoomIn icon.
        /// </summary>
        [Parameter]
        public Icon? ZoomInIcon { get; set; }
        /// <summary>
        /// The name of the icon to draw for the ZoomIn icon. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ZoomInIconName { get; set; }

        /// <summary>
        /// The zoom levels to step through when using zoom controls. This does not restrict programmatic changes to the zoom.
        /// Provide space-separated values, e.g. "25% 50% 75% 100% 125% 150% 175% 200%".
        /// </summary>
        [Parameter]
        public string ZoomLevels { get; set; } = "25% 50% 75% 100% 125% 150% 175% 200%";


        /// <summary>
        /// The icon to draw for the ZoomOut icon.
        /// </summary>
        [Parameter]
        public Icon? ZoomOutIcon { get; set; }


        /// <summary>
        /// The name of the icon to draw for the ZoomOut icon. Rotates on open and close. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ZoomOutIconName { get; set; }



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
            await SafeInvokeVoidAsync("zoomIn", Id!);
        }

        public void ZoomIn() => _ = ZoomInAsync();
        /// <summary>
        /// Zooms out to the previous available zoom level.
        /// </summary>
        public async Task ZoomOutAsync()
        {
            await SafeInvokeVoidAsync("zoomOut", Id!);
        }
        public void ZoomOut() => _ = ZoomOutAsync();
        #endregion
    }


}
