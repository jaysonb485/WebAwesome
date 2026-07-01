# WAIcon
## WebAwesomeBlazor.Components.WAIcon

```HTML+Razor
<WAIcon Icon="" />
```

### Description
Icons are symbols that can be used to represent various options within an application.

[WebAwesome docs](https://webawesome.com/docs/components/icon/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Animation | IconAnimation | | An optional animation to apply to the icon. |
| AutoWidth | bool | false | (Deprecated - use Canvas property instead.) Sets the width of the icon to match the cropped SVG viewBox. This operates like the Font fa-width-auto class. |
| Canvas| IconCanvas | IconCanvas.Fixed | Sets the icon canvas — the box the icon is centered within. Default is fixed. |
| Flip | IconFlip | | An optional flip transformation to apply to the icon. |
| Icon | [Icon](/docs/IconClass.md) |  | Sets the icon to draw. Alternatively, you can set the individual icon parameters instead of using this parameter. |
| IconName | string |  | The name of the icon to draw . Available names depend on the icon library being used. |
| IconFamily | string |  | The family of icons to choose from . For Font Awesome Free (default), valid options include classic and brands. For Font Awesome Pro subscribers, valid options include, classic, sharp, duotone, and brands. Custom icon libraries may or may not use this property.  |
| IconSourceUrl | string |  | An external URL of an SVG file. Be sure you trust the content you are including, as it will be executed as code and can result in XSS attacks. |
| IconVariant | string |  | The name icon's variant. For Font Awesome, valid options include thin, light, regular, and solid for the classic and sharp families. Some variants require a Font Awesome Pro subscription. Custom icon libraries may or may not use this property. |
| Label | string |  | An alternate description to use for assistive devices. If omitted, the icon will be considered presentational and ignored by assistive devices. |
| Library | string | "default" | The name of a registered custom icon library. Read more about registering icon libraries [here](https://webawesome.com/docs/components/icon/#icon-libraries)  |
| PrimaryColor | string |  | For duotone icons, sets the icon's primary color. |
| PrimaryOpacity | string |  | For duotone icons, sets the icon's primary opacity. |
| Rotate | int | 0 | An optional rotation in degrees to apply to the icon. |
| SecondaryColor | string |  | For duotone icons, sets the icon's secondary color. |
| SecondaryOpacity | string |  | For duotone icons, sets the icon's secondary opacity. |
| SwapOpacity | bool | false | Swaps the opacity of duotone icons. |
| Tooltip | string |  | If set, displays a tooltip with the provided text when the user hovers over the icon. Default parameters for WATooltip are used. |

### Examples

#### Basic Usage
```HTML+Razor
<WAIcon IconName="square-check" />
<WAIcon IconName="square-check" IconVariant="regular" />
<WAIcon Icon="@(new() { Name = "web-awesome", Family = "brands" })" Style="color: #f36944" />
```
<img width="149" height="42" alt="image" src="https://github.com/user-attachments/assets/a77e5b23-fca5-4173-a981-ae0055e7f28d" />
