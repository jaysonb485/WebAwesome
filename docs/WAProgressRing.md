# WAProgressRing
## Vengage.WebAwesome.Components.WAProgressRing

```HTML+Razor
<WAProgressRing Value="" />
```

### Description
Progress rings are used to show the progress of a determinate operation in a circular fashion.

[WebAwesome docs](https://webawesome.com/docs/components/progress-ring/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value | int | 0 | The current progress as a percentage, 0 to 100. |
| Label | string |  | A custom label for assistive devices. |
| Text | string |  | Text to show inside the ring. |
| Size | string |  | Size of the progress ring in CSS units. |
| TrackWidth | string |  | The width of the track  in CSS units. |
| IndicatorWidth | string |  | The width of the indicator. Defaults to the track width. |
| TrackColor | string |  | The colour of the track  in CSS units. |
| IndicatorColor | string |  |  The colour of the indicator. Defaults to the track width. |

### Examples

#### Basic Usage
```HTML+Razor
<WAProgressRing Value="35" />
```

#### Text, Track width, color and indicator color
```HTML+Razor
<WAProgressRing Value="66" TrackWidth="10px" TrackColor="darkgray" IndicatorWidth="15px" IndicatorColor="#00FF00" />
```
![WAProgressRing](https://github.com/user-attachments/assets/e1b12ec7-ad3e-495f-9ea9-02621d3fe9af)
