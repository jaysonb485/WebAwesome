# WADetails
## Vengage.WebAwesome.Components.WADetails

```HTML+Razor
<WADetails Title="More information">
    <DetailsBody>
        Detail content
    </DetailsBody>
</WADetails>
```

### Description
Details show a brief summary and expand to show additional content.

[WebAwesome docs](https://webawesome.com/docs/component)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Appearance  | DetailsAppearance  | DetailsAppearance.Outlined  | The element's visual appearance.  |
| Disabled  |  bool | false  | Disables the details so it can't be toggled.  |
| Title | string  |   |  The summary to show in the header. |
| DetailsTitle  | RenderFragment  |   | The details' summary. Alternatively, you can use the Title property.  |
| DetailsBody  | RenderFragment  |   |  The details' main content. |
| IsOpen  | bool  | false  | Indicates whether or not the details is open.  |
| ExpandIcon  | Icon  |   | The name of the icon to draw for the expand indicator.  |
| ExpandIconName  | string  |   |  The name of the icon to draw for the expand indicator. Available names depend on the icon library being used. |
| CollapseIcon  | Icon |   |  The name of the icon to draw on for the collapse indicator. |
| CollapseIconName | string |   | The name of the icon to draw on for the collapse indicator. Available names depend on the icon library being used.  |
| GroupName  | string  |   | Groups related details elements. When one opens, others with the same name will close.  |
| IconPlacement  | DetailsIconPlacement  | DetailsIconPlacement.End  | The location of the expand/collapse icon. |

### Examples

#### Basic Usage
```HTML+Razor
<WADetails Title="Cupcakes">
    <DetailsBody>
        Gummies sugar plum pastry lemon drops apple pie tart marshmallow chocolate bar dessert. Soufflé marzipan dessert soufflé sesame snaps danish danish gummies caramels. Cookie powder lollipop chocolate muffin wafer.
    </DetailsBody>
</WADetails>
```
#### Open by default
```HTML+Razor
<WADetails Title="Cupcakes" IsOpen="true">
    <DetailsBody>
            Gummies sugar plum pastry lemon drops apple pie tart marshmallow chocolate bar dessert. Soufflé marzipan dessert soufflé sesame snaps danish danish gummies caramels. Cookie powder lollipop chocolate muffin wafer.
    </DetailsBody>
</WADetails>
```

#### Formatted title and custom collapse icon
```HTML+Razor
<WADetails CollapseIcon="@(new() { Name = "circle-right", Variant = "regular" })" IsOpen="true">
    <DetailsTitle>
        <div class="wa-cluster">
            <WAIcon IconName="cake-candles" />
            <strong>Candeled cakes</strong>
        </div>
    </DetailsTitle>
    <DetailsBody>
        Gummies sugar plum pastry lemon drops apple pie tart marshmallow chocolate bar dessert. Soufflé marzipan dessert soufflé sesame snaps danish danish gummies caramels. Cookie powder lollipop chocolate muffin wafer.
    </DetailsBody>
</WADetails>
```
<img width="629" height="490" alt="image" src="https://github.com/user-attachments/assets/c3ab9533-8b34-4d2f-804a-7c3413a43df7" />
