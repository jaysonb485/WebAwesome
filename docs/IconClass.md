# Icon
## WebAwesomeBlazor.Icon

### Description
The Icon class provides properties for defining an icon to be displayed throughout various components in the library.
Where an Icon can be used, the component will also provide an alternative IconName string parameter to use. Use the IconName property to select an icon from the default library using just the name. Use the Icon class if you need to define more specific icon to use, e.g. different family, variant etc.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Name | string |  | The name of the icon to draw. Available names depend on the icon library being used. |
| Family | string |  | The family of icons to choose from.For Font Awesome Free, valid options include classic and brands. For Font Awesome Pro subscribers, valid options include, classic, sharp, duotone, sharp-duotone, and brands. A valid kit code must be present to show pro icons via CDN.You can set `<html data-fa-kit-code = "..." >` to provide one. |
| Variant | string |  | The name of the icon's variant. For Font Awesome, valid options include thin, light, regular, and solid for the classic and sharp families. Some variants require a Font Awesome Pro subscription. Custom icon libraries may or may not use this property. |
| AutoWidth | bool | false | Sets the width of the icon to match the cropped SVG viewBox.This operates like the Font fa-width-auto class. |
| SwapOpacity | bool | false | Swaps the opacity of duotone icons. |
| SourceUrl | string |  | An external URL of an SVG file. Be sure you trust the content you are including, as it will be executed as code and can result in XSS attacks. |
| Label | string |  | An alternate description to use for assistive devices. If omitted, the icon will be considered presentational and ignored by assistive devices. |
| Library | string | `default` | The name of a registered custom icon library. |
| Animation | IconAnimation | | An optional animation to apply to the icon. |
| Flip | IconFlip | | An optional flip transformation to apply to the icon. |
| Rotate | int | 0 | An optional rotation in degrees to apply to the icon. |

#### Pre-defined Icons
Some Icons are pre-defined for ease of access:
WebAwesomeBlazor.Icons.[Copy](https://fontawesome.com/icons/copy?f=classic&s=solid) 
WebAwesomeBlazor.Icons.[Check](https://fontawesome.com/icons/check?f=classic&s=solid) 
WebAwesomeBlazor.Icons.[XMark](https://fontawesome.com/icons/xmark?f=classic&s=solid) 


### Examples

#### Basic Usage
```HTML+Razor
<WAIcon Icon="@(new(){ Name="user",  Variant="regular", Label="User"})" />
```

#### Use in a button
```HTML+Razor
<WAButton StartIcon="@(new() { Name = "web-awesome", Variant = "brands" })" Text="Web Awesome" />
```

#### Using the icon name only
```HTML+Razor
<WAButton StartIconName="font-awesome" Text="Font Awesome" />
```

![Icon](https://github.com/user-attachments/assets/f7744d9b-bb5d-4169-8847-f087f5db8d0f)