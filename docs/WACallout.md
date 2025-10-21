# WACallout
## Vengage.WebAwesome.Components.WACallout

```HTML+Razor
<WACallout>@ChildContent</WACallout>
```

### Description
Callouts are used to display important messages inline.

[WebAwesome docs](https://webawesome.com/docs/components/callout/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Icon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the prefix slot. Alternatively, use EndIconName to specify the name of the icon. |
| IconName    | string  |       |The name of the icon to draw in the prefix slot. Available names depend on the icon library being used.  |
| Variant    | CalloutVariant | CalloutVariant.Inherit   | The callout's theme variant. Defaults to brand if not within another element with a variant.                     |
| Appearance | CalloutAppearance | CalloutAppearance.OutlinedFilled | The callout's visual appearance. |
| Size | CalloutSize | CalloutSize.Inherit | The callout's size. |

### Examples

#### Basic Usage
```HTML+Razor
<WACallout>Some text to be called out</WACallout>
```

#### Advanced Usage
```HTML+Razor
<WACallout IconName="circle-exclamation" Variant="CalloutVariant.Danger">
    <strong>Warning text</strong><br />
    This is important - pay attention.
</WACallout>
```
<img width="507" height="204" alt="image" src="https://github.com/user-attachments/assets/450e4155-b7bb-4236-a471-436ec1ed6068" />
