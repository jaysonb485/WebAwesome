# WAIcon
## Vengage.WebAwesome.Components.WAIcon

```HTML+Razor
<WAIcon Icon="" />
```

### Description
Icons are symbols that can be used to represent various options within an application.

[WebAwesome docs](https://webawesome.com/docs/components/icon/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Icon | [Icon](/docs/IconClass.md) |  | Sets the icon to draw. Alternatively, you can set the individual icon parameters instead of using this parameter. |
| IconName | string |  | The name of the icon to draw . Available names depend on the icon library being used. |
| IconFamily | string |  | The family of icons to choose from . For Font Awesome Free (default), valid options include classic and brands. For Font Awesome Pro subscribers, valid options include, classic, sharp, duotone, and brands. Custom icon libraries may or may not use this property.  |
| IconVariant | string |  | The name icon's variant. For Font Awesome, valid options include thin, light, regular, and solid for the classic and sharp families. Some variants require a Font Awesome Pro subscription. Custom icon libraries may or may not use this property. |
| Label | string |  | An alternate description to use for assistive devices. If omitted, the icon will be considered presentational and ignored by assistive devices. |
| AutoWidth | bool | false | Sets the width of the icon to match the cropped SVG viewBox. This operates like the Font fa-width-auto class. |
| SwapOpacity | bool | false | Swaps the opacity of duotone icons. |
| Library | string | "default" | The name of a registered custom icon library. Read more about registering icon libraries [here](https://webawesome.com/docs/components/icon/#icon-libraries)  |
| IconSourceUrl | string |  | An external URL of an SVG file. Be sure you trust the content you are including, as it will be executed as code and can result in XSS attacks. |
| PrimaryColor | string |  | For duotone icons, sets the icon's primary color. |
| SecondaryColor | string |  | For duotone icons, sets the icon's string color. |
| PrimaryOpacity | string |  | For duotone icons, sets the icon's primary opacity. |
| SecondaryOpacity | string |  | For duotone icons, sets the icon's primary opacity. |

### Examples

#### Basic Usage
```HTML+Razor
<WAIcon IconName="square-check" />
<WAIcon IconName="square-check" IconVariant="regular" />
<WAIcon Icon="@(new() { Name = "web-awesome", Family = "brands" })" Style="color: #f36944" />
```
<img width="149" height="42" alt="image" src="https://github.com/user-attachments/assets/a77e5b23-fca5-4173-a981-ae0055e7f28d" />
