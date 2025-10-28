# WABreadcrumbItem
## WebAwesomeBlazor.Components.WABreadcrumbItem

```HTML+Razor
<WABreadcrumb>
    <WABreadcrumbItem>Item one</WABreadcrumbItem>
    <WABreadcrumbItem>Item two</WABreadcrumbItem>
</WABreadcrumb>
```

### Description
Breadcrumb Items are used inside [WABreadcrumb](/docs/WABreadcrumb.md) to represent different links.

[WebAwesome docs](https://webawesome.com/docs/components/breadcrumb-item/)


### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| EndIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. Alternatively, use EndIconName to specify the name of the icon. |
| EndIconName    | string  |       |The name of the icon to draw in the end slot. Available names depend on the icon library being used.  |
| SeparatorIcon    | [Icon](/docs/IconClass.md) |   | The icon to draw in the separator slot. Alternatively, use SeparatorIconName to specify the name of the icon.  This will only change the separator for this item.  If you want to change it for all items in the group, set the separator on <WABreadcrumb> instead. |
| SeparatorIconName | string | | The name of the icon to draw in the separator slot. Available names depend on the icon library being used.  This will only change the separator for this item.  If you want to change it for all items in the group, set the separator on <WABreadcrumb> instead. |
| StartIcon | [Icon](/docs/IconClass.md) || The icon to draw in the start slot. Altneratively, use StartIconName to specify the name of the icon. |
| StartIconName | string | | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| OncClick | EventCallBack<MouseEventArgs?> | | Triggered when the breadcrumb item is clicked. |

### Examples

#### Basic Usage
```HTML+Razor
<WABreadcrumb>
    <WABreadcrumbItem>Item one</WABreadcrumbItem>
    <WABreadcrumbItem>Item two</WABreadcrumbItem>
</WABreadcrumb>
```

#### With icons
```HTML+Razor
<WABreadcrumb>
    <WABreadcrumbItem StartIconName="triangle-exclamation">Start icon  triangle exclamation</WABreadcrumbItem>
    <WABreadcrumbItem SeparatorIconName="caret-right">Separator caret right</WABreadcrumbItem>
    <WABreadcrumbItem EndIcon="@(new() { Name="check" })">End icon check</WABreadcrumbItem>
</WABreadcrumb>
```
<img width="665" height="117" alt="image" src="https://github.com/user-attachments/assets/0df00131-f524-4d32-8e42-cbd0d8f99ea5" />
