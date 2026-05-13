using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WAVideo : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Enables autoplay when the component connects.
        /// </summary>
        [Parameter]
        public bool? Autoplay { get; set; } = false;

        /// <summary>
        /// Enables autoplay in a muted state.
        /// </summary>
        [Parameter]
        public bool? AutoplayMuted { get; set; } = false;

        /// <summary>
        /// Automatically resumes playback when the player scrolls back into view after being paused by scrolling out.
        /// </summary>
        [Parameter]
        public bool? AutoplayOnVisible { get; set; } = false;

        /// <summary>
        /// The video's controls preset. None: no controls are shown. Standard: shows the timeline, play/pause, volume, captions, and fullscreen. Full: all of the above plus playback speed and picture-in-picture.
        /// </summary>
        [Parameter]
        public VideoControls? Controls { get; set; } = VideoControls.Standard;

        /// <summary>
        /// Loops the video when playback ends.
        /// </summary>
        [Parameter]
        public bool? Loop { get; set; } = false;

        /// <summary>
        /// Poster image URL
        /// </summary>
        [Parameter]
        public string? PosterImageUrl { get; set; }

        /// <summary>
        /// Controls how the browser preloads the video. Defaults to 'metadata' to minimize data usage.
        /// </summary>
        [Parameter]
        public VideoPreload? Preload { get; set; } = VideoPreload.Metadata;

        /// <summary>
        /// The URL of the video source. For multiple formats, use <source> elements instead.
        /// </summary>
        [Parameter]
        public string? VideoUrl { get; set; }

        /// <summary>
        /// A URL pointing to a WebVTT file for timeline thumbnail previews.
        /// </summary>
        [Parameter]
        public string? ThumbnailsUrl { get; set; }

        /// <summary>
        /// The video's title.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// The video's volume.
        /// </summary>
        [Parameter]
        public decimal? Volume { get; set; } = 1;

        /// <summary>
        /// Icon shown on the fullscreen button when in fullscreen.
        /// </summary>
        [Parameter]
        public Icon? ExitFullscreenIcon { get; set; }

        /// <summary>
        /// Name of the icon shown on the fullscreen button when in fullscreen. Alternatively use ExitFullscreenIcon.
        /// </summary>
        [Parameter]
        public string? ExitFullscreenIconName { get; set; }
        /// <summary>
        /// Icon shown on the fullscreen button when not in fullscreen.
        /// </summary>
        [Parameter]
        public Icon? FullscreenIcon { get; set; }

        /// <summary>
        /// Name of the icon shown on the fullscreen button when not in fullscreen. Alternatively use FullscreenIcon.
        /// </summary>
        [Parameter]
        public string? FullscreenIconName { get; set; }
        /// <summary>
        /// Icon shown on the volume/mute button when muted or volume is 0.
        /// </summary>
        [Parameter]
        public Icon? MuteIcon { get; set; }

        /// <summary>
        /// Name of the icon shown on the volume/mute button when muted or volume is 0. Alternatively use MuteIcon.
        /// </summary>
        [Parameter]
        public string? MuteIconName { get; set; }
        /// <summary>
        /// Icon shown on the play/pause button when playing.
        /// </summary>
        [Parameter]
        public Icon? PauseIcon { get; set; }

        /// <summary>
        /// Name of the icon shown on the play/pause button when playing. Alternatively use PauseIcon.
        /// </summary>
        [Parameter]
        public string? PauseIconName { get; set; }
        /// <summary>
        /// Icon shown on the play/pause button when paused.
        /// </summary>
        [Parameter]
        public Icon? PlayIcon { get; set; }

        /// <summary>
        /// Name of the icon shown on the play/pause button when paused. Alternatively use PlayIcon.
        /// </summary>
        [Parameter]
        public string? PlayIconName { get; set; }
        /// <summary>
        /// Icon shown on the poster play button. Defaults to a play-circle icon.
        /// </summary>
        [Parameter]
        public Icon? PosterIcon { get; set; }

        /// <summary>
        /// Name of the icon shown on the poster play button. Defaults to a play-circle icon. Alternatively use PosterIcon.
        /// </summary>
        [Parameter]
        public string? PosterIconName { get; set; }
        /// <summary>
        /// Icon shown on the volume/mute button when audio is active.
        /// </summary>
        [Parameter]
        public Icon? VolumeIcon { get; set; }

        /// <summary>
        /// Name of the icon shown on the volume/mute button when audio is active. Alternatively use VolumeIcon.
        /// </summary>
        [Parameter]
        public string? VolumeIconName { get; set; }

        /// <summary>
        /// Content inserted immediately after the play/pause button. 
        /// </summary>
        [Parameter]
        public RenderFragment? ControlsAfterPlay { get; set; }

        /// <summary>
        /// Content inserted at the start of the controls bar (before play/pause).
        /// </summary>
        [Parameter]
        public RenderFragment? ControlsStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EventCallback VideoEnded { get; set; }
        [Parameter]
        public EventCallback<string> Error { get; set; }
        [Parameter]
        public EventCallback LoadedMetadata { get; set; }
        [Parameter]
        public EventCallback<decimal> TimeUpdated { get; set; }
        [Parameter]
        public EventCallback<decimal> VolumeChanged { get; set; }
        [Parameter]
        public EventCallback PlaybackStarted { get; set; }
        [Parameter]
        public EventCallback VideoPaused { get; set; }

        #endregion

        #region Computed  Properties
        string ControlsString
        {
            get
            {
                return Controls switch
                {
                    VideoControls.None => "none",
                    VideoControls.Full => "full",
                    VideoControls.Standard => "standard",
                    _ => "standard"
                };
            }
        }

        string PreloadString
        {
            get
            {
                return Preload switch
                {
                    VideoPreload.Auto => "auto",
                    VideoPreload.Metadata => "metadata",
                    VideoPreload.None => "none",
                    _ => "metadata"
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
        /// Emitted when playback ends.
        /// </summary>
        [JSInvokable]
        public async Task HandleVideoEnded()
        {
            if (VideoEnded.HasDelegate)
                await VideoEnded.InvokeAsync();
        }

        [JSInvokable]
        public async Task HandleVideoError(string errorMessage)
        {
            if (Error.HasDelegate)
                await Error.InvokeAsync(errorMessage);
        }

        [JSInvokable]
        public async Task HandleLoadedMetadata()
        {
            if (LoadedMetadata.HasDelegate)
                await LoadedMetadata.InvokeAsync();
        }
        [JSInvokable]
        public async Task HandleTimeUpdated(decimal time)
        {
            if (TimeUpdated.HasDelegate)
                await TimeUpdated.InvokeAsync(time);
        }

        [JSInvokable]
        public async Task HandleVolumeChanged(decimal volume)
        {
            if (VolumeChanged.HasDelegate)
                await VolumeChanged.InvokeAsync(volume);
        }

        [JSInvokable]
        public async Task HandleVideoPlayed()
        {
            if (PlaybackStarted.HasDelegate)
                await PlaybackStarted.InvokeAsync();
        }

        [JSInvokable]
        public async Task HandleVideoPaused()
        {
            if (VideoPaused.HasDelegate)
                await VideoPaused.InvokeAsync();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Exits fullscreen mode.
        /// </summary>
        public async Task ExitFullscreenAsync()
        {
            await SafeInvokeVoidAsync("exitFullscreen", Id!);
        }

        /// <summary>
        /// Gets the current playback state.
        /// </summary>
        /// <returns>VideoPlaybackState object including current time, duration, and playback state</returns>
        public async Task<VideoPlaybackState> GetPlaybackStateAsync()
        {
            return await SafeInvokeAsync<VideoPlaybackState>("getPlaybackState", Id!);
        }

        /// <summary>
        /// Pauses the video
        /// </summary>
        public async Task PauseVideoAsync()
        {
            await SafeInvokeVoidAsync("pauseVideo", Id!);
        }

        /// <summary>
        /// Starts playback
        /// </summary>
        public async Task PlayVideoAsync()
        {
            await SafeInvokeVoidAsync("playVideo", Id!);
        }

        /// <summary>
        /// Enters fullscreen mode
        /// </summary>
        public async Task RequestFullscreenAsync()
        {
            await SafeInvokeVoidAsync("requestFullscreen", Id!);
        }

        /// <summary>
        /// Seeks to a specific time in the video.
        /// </summary>
        /// <param name="time">Decimal representing the time in seconds to seek to</param>
        public async Task SeekAsync(decimal time)
        {
            await SafeInvokeVoidAsync("seekVideo", Id!, time);
        }

        /// <summary>
        /// Sets the volume level
        /// </summary>
        /// <param name="volume">A value from 0 to 100</param>
        public async Task SetVolumeAsync(int volume)
        {
            await SafeInvokeVoidAsync("setVolume", Id!, volume);
        }

        /// <summary>
        /// Sets the playback rate (speed)
        /// </summary>
        /// <param name="rate">The playback rate (e.g., 1.0 for normal speed, 2.0 for double speed)</param>
        public async Task SetPlaybackRateAsync(decimal rate)
        {
            await SafeInvokeVoidAsync("setPlaybackRate", Id!, rate);
        }

        /// <summary>
        /// Toggles the muted state
        /// </summary>
        public async Task ToggleMuteAsync()
        {
            await SafeInvokeVoidAsync("toggleMute", Id!);
        }

        /// <summary>
        /// Toggles between play and pause.
        /// </summary>
        public async Task TogglePlaybackAsync()
        {
            await SafeInvokeVoidAsync("togglePlay", Id!);
        }

        #endregion

        #region State
        private DotNetObjectReference<WAVideo> objRef = default!;
        #endregion



    }

    public class VideoPlaybackState
    {
        public decimal? CurrentTime { get; set; }
        public decimal? Duration { get; set; }
        public bool? Muted { get; set; }
        public decimal? PlaybackRate { get; set; }
        public bool? Playing { get; set; }
        public decimal? Volume { get; set; }
    }

}
