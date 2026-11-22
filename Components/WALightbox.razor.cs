using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WALightbox : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The zero-based index of the current item. Set this before opening to choose which item the lightbox starts on.
        /// </summary>
        [Parameter]
        public int ItemIndex { get; set; } = 0;

        /// <summary>
        /// Optional close icon to use instead of the default. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? CloseIconName { get; set; }

        /// <summary>
        /// Optional play icon to use instead of the default. 
        /// </summary>
        [Parameter]
        public Icon? CloseIcon { get; set; }

        /// <summary>
        /// A label that describes the lightbox to assistive devices, e.g. "Vacation photos".
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// Wraps around when navigating past the first or last item with the buttons or the keyboard.
        /// </summary>
        [Parameter]
        public bool Loop { get; set; } = false;

        /// <summary>
        /// Optional next icon to use instead of the default. . Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? NextIconName { get; set; }

        /// <summary>
        /// Optional next icon to use instead of the default. 
        /// </summary>
        [Parameter]
        public Icon? NextIcon { get; set; }

        /// <summary>
        /// Optional previous icon to use instead of the default. . Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? PreviousIconName { get; set; }

        /// <summary>
        /// Optional play icon to use instead of the default. 
        /// </summary>
        [Parameter]
        public Icon? PreviousIcon { get; set; }

        /// <summary>
        /// Indicates whether or not the lightbox is open.  Use OpenAsync() and CloseAsync() to change the value.
        /// </summary>
        [Parameter]
        public bool Open { get; set; } = false;
        /// <summary>
        /// Shows the counter that shows the current item's position.
        /// </summary>
        [Parameter]
        public bool ShowCounter { get; set; } = true;
        /// <summary>
        /// Shows the previous and next buttons. When hidden, swiping and the arrow keys still work. The buttons are always hidden on touch screens, where swiping takes their place.
        /// </summary>
        [Parameter]
        public bool ShowNavigation { get; set; } = true;

        /// <summary>
        /// Enables zooming and shows the zoom button.
        /// </summary>
        [Parameter]
        public bool ShowZoom { get; set; } = true;

        /// <summary>
        /// Gets or sets whether thumbnails are displayed.
        /// </summary>
        [Parameter]
        public bool ShowThumbnails { get; set; } = false;
        /// <summary>
        /// Optional Zoom In icon to use instead of the default. . Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ZoomInIconName { get; set; }

        /// <summary>
        /// Optional Zoom In icon to use instead of the default. 
        /// </summary>
        [Parameter]
        public Icon? ZoomInIcon { get; set; }
        /// <summary>
        /// Optional zoom out icon to use instead of the default. . Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ZoomOutIconName { get; set; }

        /// <summary>
        /// Optional zoom out icon to use instead of the default. 
        /// </summary>
        [Parameter]
        public Icon? ZoomOutIcon { get; set; }

        /// <summary>
        /// Emitted when the lightbox opens. Set args.Cancel = true to prevent opening.
        /// </summary>
        [Parameter]
        public EventCallback<LightboxShowingEventArgs> Showing { get; set; }

        /// <summary>
        /// Emitted when the lightbox is requested to close. Set args.Cancel = false to prevent closing.
        /// </summary>
        [Parameter]
        public EventCallback<LightboxHidingEventArgs> Hiding { get; set; }

        /// <summary>
        /// Emitted when the current item changes.
        /// </summary>
        [Parameter]
        public EventCallback<LightboxItemChangeEventArgs> ItemChanged { get; set; }

        /// <summary>
        /// Emitted after the lightbox opens and all animations are complete.
        /// </summary>
        [Parameter]
        public EventCallback Shown { get; set; }
        /// <summary>
        /// Emitted after the lightbox closes and all animations are complete.
        /// </summary>
        [Parameter]
        public EventCallback Hidden { get; set; }
        /// <summary>
        /// Extra buttons to show in the lightbox's toolbar, such as download or share. Works best with <WAButton>, which is styled to match the built-in controls
        /// </summary>
        [Parameter]
        public RenderFragment? Actions { get; set; }
        #endregion

        #region Computed Properties

        #endregion
        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Element!, objRef);
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

        #region Public Methods
        public async Task CloseAsync()
        {
            Open = false;
            await InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Shows the next item.
        /// </summary>
        public async Task NextItemAsync()
        {
            await SafeInvokeVoidAsync("next", Element);
        }

        public void NextItem()
        {
            _ = NextItemAsync();
        }

        public async Task OpenAsync()
        {
            Open = true;
            await InvokeAsync(StateHasChanged);
        }
        /// <summary>
        /// Shows the previous item.
        /// </summary>
        public async Task PreviousItemAsync()
        {
            await SafeInvokeVoidAsync("previous", Element);
        }

        public void PreviousItem()
        {
            _ = PreviousItemAsync();
        }
        /// <summary>
        /// Zooms in on the current image.
        /// </summary>
        public async Task ZoomInAsync()
        {
            await SafeInvokeVoidAsync("zoomIn", Element);
        }

        public void ZoomIn()
        {
            _ = ZoomInAsync();
        }
        /// <summary>
        /// Zooms out of the current image.
        /// </summary>
        public async Task ZoomOutAsync()
        {
            await SafeInvokeVoidAsync("zoomOut", Element);
        }

        public void ZoomOut()
        {
            _ = ZoomOutAsync();
        }

        #endregion
        #region State
        private DotNetObjectReference<WALightbox> objRef = default!;
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task<bool> HandleLightboxShow()
        {

            var args = new LightboxShowingEventArgs();
            await Showing.InvokeAsync(args);
            return args.Cancel;
        }

        [JSInvokable]
        public async Task<bool> HandleLightboxHide()
        {
            var args = new LightboxHidingEventArgs();
            await Hiding.InvokeAsync(args);
            return args.Cancel;
        }

        [JSInvokable]
        public async Task HandleItemChange(int index, int prevIndex)
        {
            await ItemChanged.InvokeAsync(new LightboxItemChangeEventArgs() { Index = index, PreviousIndex = prevIndex });
        }

        [JSInvokable]
        public async Task HandleLightboxShown()
        {
            Open = true;
            await Shown.InvokeAsync();
        }

        [JSInvokable]
        public async Task HandleLightboxHidden()
        {
            Open = false;
            await Hidden.InvokeAsync();
        }
        #endregion

    }
}
