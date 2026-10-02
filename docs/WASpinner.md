# WASpinner
## WebAwesomeBlazor.Components.WASpinner

```HTML+Razor
<WASpinner />
```

### Description
Spinners are used to show the progress of an indeterminate operation.

[Web Awesome docs](https://webawesome.com/docs/components/spinner/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| IndicatorColor | string |  | The colour of the indicator. Defaults to the track width. |
| Label | string |  | A custom label for assistive devices. |
| Size | string |  |  Size of the spinner in CSS font-size units. If not defined, the parent element's font size will be used. |
| Speed | string | `2s` | The time it takes for the spinner to complete one animation cycle. Default is two seconds. |
| TrackColor | string |  | The colour of the track  in CSS units. |
| TrackWidth | string |  | The width of the track  in CSS units. |

### Examples

#### Basic Usage
```HTML+Razor
<WASpinner />
```

#### Larger, coloured, slower spin
```HTML+Razor
<WASpinner Speed="4s" TrackWidth="10px" TrackColor="darkred" IndicatorColor="pink" Size="3rem" />
```

![WASpinner](https://github.com/user-attachments/assets/b02186d2-2e67-4f44-a063-fe30489cecff)