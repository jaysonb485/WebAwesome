# WAProgressBar
## WebAwesomeBlazor.Components.WAProgressBar

```HTML+Razor
<WAProgressBar @bind-Value="progressValue" />
```

### Description
Progress bars are used to show the status of an ongoing operation.

[Web Awesome docs](https://webawesome.com/docs/components/progress-bar/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Indeterminate | bool | false | When true, percentage is ignored, the label is hidden, and the progress bar is drawn in an indeterminate state. |
| IndicatorColor | string |  | The color of the indicator. |
| Label | string |  |  A custom label for assistive devices. |
| Text | string |  | Text to display over the progress bar. |
| TrackColor | string |  |  The color of the track. |
| TrackHeight | string |  | Height of the progress bar in CSS units. |
| Value | decimal | 0 | The current progress as a percentage, 0 to 100. |

### Examples

#### Basic Usage
```HTML+Razor
<WAProgressBar Value="50" Text="50%" />
```

#### Indeterminate with height and color.
```HTML+Razor
<WAProgressBar Indeterminate="true" TrackHeight="1.5lh" TrackColor="darkgray" IndicatorColor="var(--wa-color-success-fill-loud)" />
```

![WAProgressBar](https://github.com/user-attachments/assets/0340e690-078b-4bda-beea-84241dad7548)