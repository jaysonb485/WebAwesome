using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WAAnimatedImage : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The path to the image to load.
        /// </summary>
        [Parameter]
        public string? AnimationUrl { get; set; }
        /// <summary>
        /// A description of the image used by assistive devices.
        /// </summary>
        [Parameter]
        public string? AltText { get; set; }
        /// <summary>
        /// Optional play icon to use instead of the default.
        /// </summary>
        [Parameter]
        public Icon? PlayIcon { get; set; }
        /// <summary>
        /// Optional pause icon to use instead of the default
        /// </summary>
        [Parameter]
        public Icon? PauseIcon { get; set; }
        /// <summary>
        /// Optional play icon name to use instead of the default.  Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? PlayIconName { get; set; }
        /// <summary>
        /// Optional pause icon name to use instead of the default.  Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? PauseIconName { get; set; }
        /// <summary>
        /// The size of the icon box in CSS size units.
        /// </summary>
        [Parameter]
        public string? ControlBoxSize { get; set; }
        /// <summary>
        /// The size of the play/pause icons in CSS size units.
        /// </summary>
        [Parameter]
        public string? IconSize { get; set; }

        /// <summary>
        /// Triggered when the image loads successfully.
        /// </summary>
        [Parameter]
        public EventCallback ImageLoaded { get; set; }
        /// <summary>
        /// Triggered  when the image fails to load.
        /// </summary>
        [Parameter]
        public EventCallback LoadError { get; set; }
        #endregion

        #region Computed  Properties
        protected override string StyleNames => BuildStyleNames(Style,
            ($"--control-box-size: {ControlBoxSize}", !String.IsNullOrEmpty(ControlBoxSize)),
            ($"--icon-size: {IconSize}", !String.IsNullOrEmpty(IconSize))
        );
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

        #region State
        private bool IsPlaying { get; set; } = false;
        private DotNetObjectReference<WAAnimatedImage> objRef = default!;

        #endregion

        #region Public Methods
        /// <summary>
        /// Starts or stops the animation
        /// </summary>     
        public async Task TogglePlayAsync()
        {
            IsPlaying = !IsPlaying;
            await InvokeAsync(StateHasChanged);
        }

        public void TogglePlay() => _ = TogglePlayAsync();

        public async Task PlayAsync()
        {
            IsPlaying = true;
            await InvokeAsync(StateHasChanged);
        }

        public void Play() => _ = PlayAsync();

        public async Task PauseAsync()
        {
            IsPlaying = false;
            await InvokeAsync(StateHasChanged);
        }

        public void Pause() => _ = PauseAsync();
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleLoadError()
        {
            if (LoadError.HasDelegate)
                await LoadError.InvokeAsync();
        }

        [JSInvokable]
        public async Task HandleImageLoaded()
        {
            if (ImageLoaded.HasDelegate)
                await ImageLoaded.InvokeAsync();
        }
        #endregion

    }


}
