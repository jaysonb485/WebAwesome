# WAVideo
## WebAwesomeBlazor.Components.WAVideo

```HTML+Razor
<WAVideo VideoUrl="" Title="" />
```

### Description
Videos are used to embed and play video content with custom controls and captions.

[Web Awesome docs](https://webawesome.com/docs/components/video/)

> [!IMPORTANT]
> WAVideo requires access to Web Awesome Pro.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Autoplay | bool | `false` | Enables autoplay when the component connects. |
| AutoplayMuted | bool | `false` | Enables autoplay in a muted state. |
| AutoplayOnVisible | bool | `false` | Automatically resumes playback when the player scrolls back into view after being paused by scrolling out. |
| Controls | VideoControls | `VideoControls.Standard` | Specifies which controls to display on the video player. <br />  `None` no controls are shown. <br />`Standard`: shows the timeline, play/pause, volume, captions, and fullscreen. <br />`Full`: all of the above plus playback speed and picture-in-picture.|
| Loop | bool | `false` | Enables looping of the video. |
| PosterImageUrl | string |  | URL of the image to show before the video plays. |
| Preload | VideoPreload | `VideoPreload.Metadata` | Specifies how the video should be preloaded. <br /> `None`: the video should not be preloaded. <br /> `Metadata`: only preload metadata (e.g., duration, dimensions). <br /> `Auto`: preload the entire video when the page loads. |
| VideoUrl | string |  | URL of the video to play. |
| ThumbnailsUrl | string |  | A URL pointing to a WebVTT file for timeline thumbnail previews. |
| Title | string |  | The title of the video. |
| ExitFullscreenIcon    | [Icon](/docs/IconClass.md) |  |Icon shown on the fullscreen button when in fullscreen. Alternatively, use ExitFullscreenIconName to specify the name of the icon. |
| ExitFullscreenIconName    | string  |       |Icon shown on the fullscreen button when in fullscreen. Available names depend on the icon library being used.  |
| FullscreenIcon    | [Icon](/docs/IconClass.md) |  |Icon shown on the fullscreen button when not in fullscreen. Alternatively, use FullscreenIconName to specify the name of the icon. |
| FullscreenIconName    | string  |       |Icon shown on the fullscreen button when not in fullscreen. Available names depend on the icon library being used.  |
| MuteIcon    | [Icon](/docs/IconClass.md) |  |Icon shown on the volume/mute button when muted or volume is 0. Alternatively, use MuteIconName to specify the name of the icon. |
| MuteIconName    | string  |       |Icon shown on the volume/mute button when muted or volume is 0. Available names depend on the icon library being used.  |
| PauseIcon    | [Icon](/docs/IconClass.md) |  |Icon shown on the play/pause button when playing. Alternatively, use PauseIconName to specify the name of the icon. |
| PauseIconName    | string  |       |Icon shown on the play/pause button when playing. Available names depend on the icon library being used.  |
| PlayIcon    | [Icon](/docs/IconClass.md) |  |Icon shown on the play/pause button when paused. Alternatively, use PlayIconName to specify the name of the icon. |
| PlayIconName    | string  |       |Icon shown on the play/pause button when paused. Available names depend on the icon library being used.  |
| PosterIcon    | [Icon](/docs/IconClass.md) |  |Icon shown on the volume/mute button when audio is active. Alternatively, use PosterIconName to specify the name of the icon. |
| PosterIconName    | string  |       |Icon shown on the volume/mute button when audio is active. Available names depend on the icon library being used.  |
| VolumeIcon    | [Icon](/docs/IconClass.md) |  |Icon shown on the volume/mute button when audio is active. Alternatively, use VolumeIconName to specify the name of the icon. |
| VolumeIconName    | string  |       |Icon shown on the volume/mute button when audio is active. Available names depend on the icon library being used.  |
| ControlsAfterPlay | RenderFragment |  | Optional additional content inserted immediately after the play/pause button. |
| ControlsStart | RenderFragment | | Optional additional content inserted at the start of the controls bar (before play/pause). |
| VideoEnded | EventCallback |  | Triggered when the video has finished playing. |
| VideoPaused | EventCallback |  | Triggered when the video is paused. |
| PlaybackStarted | EventCallback |  | Triggered when video playback starts. |
| VolumeChanged | EventCallback\<decimal> |  | Triggered when the volume is changed, including when the video is muted or unmuted. |
| TimeUpdated | EventCallback\<decimal> |  | Triggered when the current playback time is updated. |
| LoadedMetadata | EventCallback |  | Triggered when the video's metadata has finished loading. |
| Error | EventCallback\<string> |  | Triggered when an error occurs during video loading or playback. The error message is passed as a parameter. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| ExitFullscreenAsync  |    | Description of what methodName does      |
| GetPlaybackStateAsync\<VideoPlaybackState> |  | Returns a `VideoPlaybackState` object representing the current playback time, duration, muted state, playback rate, playing state, and volume |
| PauseVideoAsync |  | Pauses video playback. |
| PlayVideoAsync |  | Starts or resumes video playback. |
| SeekAsync | timeInSeconds: decimal | Seeks to a specific time in the video in seconds. |
| SetVolumeAsync | volumeLevel: int | Sets the volume to a specific level between 0 (muted) and 100 (maximum volume). |
| SetPlaybackRateAsync | playbackRate: decimal | Sets the playback rate to a specific value, where 1 is normal speed, 0.5 is half speed, and 2 is double speed. |
| TogggleMuteAsync |  | Toggles the muted state of the video. If the video is currently muted, it will be unmuted, and if it is currently unmuted, it will be muted. |
| TogglePlaybackAsync |  | Toggles between playing and pausing the video. If the video is currently playing, it will be paused, and if it is currently paused, it will start playing. |
| RequestFullscreenAsync | | Requests to enter fullscreen mode for the video player. |

### Examples

#### Basic Usage
```HTML+Razor
<WAVideo VideoUrl="https://example.com/video.mp4" Title="Example Video" />
```

#### Advanced Usage - Custom icons and custom buttons to control the speed.
```HTML+Razor
<WAVideo @ref="video" VideoUrl="https://uploads.webawesome.com/waks_compressed.mp4" Title="Example Video" Autoplay="true" Controls="VideoControls.Full" Loop="true" PosterImageUrl="https://webawesome.com/assets/images/fa-part-1.jpg" ExitFullscreenIconName="compress" FullscreenIconName="expand" MuteIconName="volume-xmark" VolumeIconName="volume-high" PlayIconName="play" PauseIconName="pause">
    <ControlsAfterPlay>
        <WAButton Appearance="ButtonAppearance.Plain" Size="ButtonSize.Small" OnClick="() => SetPlaybackRateAsync(2)">2x Speed</WAButton>
        <WAButton Appearance="ButtonAppearance.Plain" Size="ButtonSize.Small" OnClick="() => SetPlaybackRateAsync(0.5m)">0.5x Speed</WAButton>
    </ControlsAfterPlay>
</WAVideo>

@code
{
    private WAVideo video;
    private async Task SetPlaybackRateAsync(decimal rate)
    {
        await video.SetPlaybackRateAsync(rate);
    }
}

```