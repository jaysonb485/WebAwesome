using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace WebAwesomeBlazor.Components
{
    public partial class WAVideoPlaylist : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The WAVideos to render in the playlist.
        /// </summary>
        [Parameter]
        public RenderFragment? Videos { get; set; }

        /// <summary>
        /// The controls preset forwarded to each child WAVideo
        /// </summary>
        [Parameter]
        public VideoControls DefaultVideoControls { get; set; } = VideoControls.Full;

        /// <summary>
        /// Emitted when the active video changes.
        /// </summary>
        [Parameter]
        public EventCallback<VideoChangedCallbackArgs> VideoChanged { get; set; }
        #endregion

        #region Computed  Properties
        string ControlsString
        {
            get
            {
                return DefaultVideoControls switch
                {
                    VideoControls.None => "none",
                    VideoControls.Full => "full",
                    VideoControls.Standard => "standard",
                    _ => "standard"
                };
            }
        }


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
        /// <summary>
        /// 	Emitted when the active video changes.
        /// </summary>
        [JSInvokable]
        public async Task HandleVideoChanged(VideoChangedCallbackArgs args)
        {
            if (VideoChanged.HasDelegate)
                await VideoChanged.InvokeAsync(args);
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Jumps to the video at the given index
        /// </summary>
        /// <param name="VideoIndex">The index of the video to jump to.</param>
        public async Task GoToVideoIndexAsync(int VideoIndex)
        {
            await SafeInvokeVoidAsync("goToVideo", Id!, VideoIndex);
        }

        /// <summary>
        /// Plays the next video in the playlist.
        /// </summary>
        public async Task NextVideoAsync()
        {
            await SafeInvokeVoidAsync("nextVideo", Id!);
        }

        /// <summary>
        /// Plays the previous video in the playlist.
        /// </summary>
        public async Task PreviousVideoAsync()
        {
            await SafeInvokeVoidAsync("previousVideo", Id!);
        }
        #endregion

        #region State
        private DotNetObjectReference<WAVideoPlaylist> objRef = default!;
        #endregion



    }

    public class VideoChangedCallbackArgs
    {
        public int PreviousIndex { get; set; }

        public int CurrentIndex { get; set; }

        public VideoMetadata Video { get; set; } = new();
    }

    public class VideoMetadata
    {
        public string? Title { get; set; }
        [JsonPropertyName("poster")]
        public string? PosterUrl { get; set; }
        public string[]? Sources { get; set; }
        public string[]? Tracks { get; set; }
    }


}
