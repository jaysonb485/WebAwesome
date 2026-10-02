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
| DefaultVideoControls | VideoControls | `VideoControls.Full` | The controls preset forwarded to each child WAVideo |
| Videos | RenderFragment | | The WAVideos to render in the playlist. |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| VideoChanged (VideoChangedCallbackArgs) | Emitted when the active video changes. Provides previous video index, current (new) video index, and new video metadata. |

#### VideoChangedCallbackArgs
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| PreviousIndex | int |  | The index of the previous video in the playlist. |
| CurrentIndex | int |  | The index of the current (new) video in the playlist. |
| Video | VideoMetadata |  | The metadata of the current (new) video in the playlist. |

#### VideoMetadata
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Title | string |  | The title of the video. |
| PosterUrl | string |  | The URL of the video's poster image. |
| Sources | string[] |  | The list of video source URLs. |
| Tracks | string[] |  | The list of video track URLs. |

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
