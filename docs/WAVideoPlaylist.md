# WAVideoPlaylist
## WebAwesomeBlazor.Components.WAVideoPlaylist

```HTML+Razor
<WAVideoPlaylist >
	<WAVideo VideoUrl="" Title="" />
	<WAVideo VideoUrl="" Title="" />
	<WAVideo VideoUrl="" Title="" />
</WAVideoPlaylist>
```

### Description
Video playlists wrap multiple [WAVideo](/docs/WAVideo.md) elements into a playlist with navigation controls.

[Web Awesome docs](https://webawesome.com/docs/components/video-playlist/)

> [!IMPORTANT]
> WAVideo and WAVideoPlaylist require access to Web Awesome Pro.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Videos | RenderFragment | | The WAVideos to render in the playlist. |
| DefaultVideoControls | VideoControls | `VideoControls.Full` | The controls preset forwarded to each child WAVideo |
| VideoChanged | EventCallback\<VideoChangedCallbackArgs> | | Emitted when the active video changes. Provides previous video index, current (new) video index, and new video metadata. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| GoToVideoIndexAsync  | VideoIndex: int   | Jumps to the video at the given index     |
| NextVideoAsync |  | Plays the next video in the playlist. |
| PreviousVideoAsync |  | Plays the previous video in the playlist. |

### Examples

#### Basic Usage
```HTML+Razor
<WAVideoPlaylist>
    <WAVideo VideoUrl="https://example.com/video1.mp4" Title="Video 1" />
    <WAVideo VideoUrl="https://example.com/video2.mp4" Title="Video 2" />
    <WAVideo VideoUrl="https://example.com/video3.mp4" Title="Video 3" />
</WAVideoPlaylist>
```
