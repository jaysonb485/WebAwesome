# WABadge
## Vengage.WebAwesome.Components.WABadge

```html
<WABadge Text="Badge" />
```

### Description
Badges are used to draw attention and display statuses or counts.

[WebAwesome docs](https://webawesome.com/docs/badge/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Appearance    | BadgeAppearance | BadgeAppearance.Accent | The badge's visual appearance. Valid options for badge are: Accent, AccentOutlined, Filled, FilledOutlined, Outlined.                     |
| Pill    | bool | false       | Draws a pill-style badge with rounded edges.                     |
| Pulse    | BadgePulse | BadgePulse.None   | Adds an animation to draw attention to the badge (None, Pulse, Bounce).                     |
| PulseColor | string |        | The color of the badge's pulse effect when using `BadgePulse.Pulse`. Provide a CSS-valid color value.                     |
| Text    | string |        | The text to display inside the badge.                     |
| Variant | BadgeVariant | BadgeVariant.Brand | The badge's theme variant. Defaults to brand if not within another element with a variant.  |

### Examples

#### Basic Usage
```HTML+Razor
<WABadge Text="Badge" />
```

#### Pulsing Badge
```HTML+Razor
<WABadge Text="New" Pulse="BadgePulse.Pulse" PulseColor="#FF0000" />
```

#### Used within a button
```HTML+Razor
<WAButton>Alerts <WABadge Text="3" Pill="true" Appearance="BadgeAppearance.Filled" /></WAButton>
```