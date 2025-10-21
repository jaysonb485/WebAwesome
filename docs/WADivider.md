# WADivider
## Vengage.WebAwesome.Components.WADivider

```HTML+Razor
<WADivider />
```

### Description
Dividers are used to visually separate or group elements.

[WebAwesome docs](https://webawesome.com/docs/components/divider/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Spacing | string |   | The width of the gap around the divider. In CSS units, e.g. px, rem, pts  |
| Width  | string |   | The width of the divider. In any CSS unit, e.g. px, rem, pts  |
| Color  | string |   |  The color of the divider. Use CSS named colors or hex values |
| Orientation  | DividerOrientation | DividerOrientation.Horizontal  | Set the orientation of the line. Defaults to horizontal.  |

### Examples

#### Basic Usage
```HTML+Razor
<WADivider />
```

#### Vertical divider, green and wider
```HTML+Razor
<WADivider Orientation="DividerOrientation.Vertical" Color="green" Width="5px" />
```

<img width="457" height="79" alt="image" src="https://github.com/user-attachments/assets/ec65bdb9-bd6d-458b-aa98-da084b383ae9" />
