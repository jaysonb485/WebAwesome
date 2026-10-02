# WADivider
## WebAwesomeBlazor.Components.WADivider

```HTML+Razor
<WADivider />
```

### Description
Dividers are used to visually separate or group elements.

[Web Awesome docs](https://webawesome.com/docs/components/divider/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Color  | string |   |  The color of the divider. Use CSS named colors or hex values |
| LabelPlacement | DividerLabelPlacement | DividerLabelPlacement.Center | Where the label sits along the divider. |
| LabelOffset | string | | The length of the line between the divider's edge and a label placed at the start or end in CSS units |
| LabelSpacing | string | | The amount of space between the label and the divider's lines in CSS units |
| Orientation  | DividerOrientation | DividerOrientation.Horizontal  | Set the orientation of the line. Defaults to horizontal.  |
| Spacing | string |   | The width of the gap around the divider. In CSS units, e.g. px, rem, pts  |
| Width  | string |   | The width of the divider. In any CSS unit, e.g. px, rem, pts  |

### Examples

#### Basic Usage
```HTML+Razor
<WADivider />
```

#### Vertical divider, green and wider
```HTML+Razor
<WADivider Orientation="DividerOrientation.Vertical" Color="green" Width="5px" />
```

#### With label
```HTML+Razor
<WADivider>this or that</WADivider>
```

<img width="457" height="79" alt="image" src="https://github.com/user-attachments/assets/ec65bdb9-bd6d-458b-aa98-da084b383ae9" />
