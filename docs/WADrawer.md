# WADrawer
## WebAwesomeBlazor.Components.WADrawer.md

```HTML+Razor
<WADrawer Title="">
    <HeaderActions></HeaderActions>
    <DrawerFooter></DrawerFooter>
    <DrawerBody></DrawerBody>
</WADrawer>
```

### Description
Drawers slide in from a container to expose additional options and information.

[WebAwesome docs](https://webawesome.com/docs/components/drawer/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Title | string |  | The drawer's title as displayed in the header. You should always include a relevant title, as it is required for proper accessibility. |
| DrawerFooter  | RenderFragment |  | The drawer's footer, usually one or more buttons representing various options. |
| DrawerBody | RenderFragment |  | The drawer's main content. |
| HeaderActions | RenderFragment |  | Optional actions to add to the header. Works best with WAButton. |
| LightDismiss | bool | true | When enabled, the drawer will be closed when the user clicks outside of it. Defaults to true. |
| Placement |DrawerPlacement  | DrawerPlacement.End | The direction from which the drawer will open. Valid options are top, end, bottom, start. Default is end. |
| DrawerClosed  | EventCallback<string>  |   | Triggered when the drawer is closed. Argument provides ID of the triggering component  |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| ShowAsync |    | Shows the drawer.      |
| HideAsync |  | Hides the drawer. |

### Examples

#### Basic Usage
```HTML+Razor
<WADrawer @ref="infoDrawer" Title="Dialog title">
    <DrawerBody>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit.
    </DrawerBody>
    <DrawerFooter>
        <WAButton OnClick="@(() => infoDrawer.HideAsync())">Close Dialog</WAButton>
    </DrawerFooter>
</WADrawer>

<WAButton OnClick="@(() => infoDrawer.ShowAsync())">Open Drawer</WAButton>

@code {
    WADrawer infoDrawer { get; set; } = default!;
}
```
<img width="577" height="273" alt="image" src="https://github.com/user-attachments/assets/74b059a7-eb36-4d16-befe-6c86ff261fde" />

