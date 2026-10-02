# WAZoomableFrame
## WebAwesomeBlazor.Components.WAZoomableFrame

```HTML+Razor
<WAZoomableFrame prop1="value1" prop2="value2" />
```

### Description
Zoomable frames render iframe content with zoom and interaction controls.

[Web Awesome docs](https://webawesome.com/docs/components/zoomable-frame)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| AllowFulLScreen | bool | false | Allows fullscreen mode. |
| AllowPolicy | string | | A [Permissions Policy](https://developer.mozilla.org/en-US/docs/Web/HTTP/Permissions_Policy) that controls which features the embedded content can use, e.g. `clipboard-write; fullscreen`. The browser reads this when the frame loads, so changing it afterwards has no effect until the frame navigates again.
| DisableInteraction | bool | false | Disables interaction. |
| HideZoomControls | bool | false | Removes the zoom controls. |
| Label | string | | An accessible name for the frame. Screen readers announce it when moving between frames, so set one that describes the frame's content. | 
| LazyLoad | bool | false | Controls iframe loading behavior. Default is eager loading. |
| ReferrerPolicy | string |  | Controls referrer information. |
| Sandbox | string |  | Security restrictions for the iframe. |
| SourceHtml | string |  | Inline HTML to display. |
| SourceUrl | string |  | The URL of the content to display. If both `SourceUrl` and `SourceHtml` are provided, `SourceHtml` takes precendence. |
| SyncThemes | bool | false | Enables automatic theme syncing (light/dark mode and theme selector classes) from the host document to the iframe. |
| Zoom | double |  | The current zoom of the frame, e.g. 0 = 0% and 1 = 100%. |
| ZoomInIcon | [Icon](/docs/IconClass.md) |  | The icon to draw for the ZoomIn icon. |
| ZoomInIconName | string |  | The name of the icon to draw for the ZoomIn icon. Available names depend on the icon library being used. |
| ZoomLevels | string |  | The zoom levels to step through when using zoom controls. This does not restrict programmatic changes to the zoom. Provide space-separated values, e.g. "25% 50% 75% 100% 125% 150% 175% 200%". |
| ZoomOutIcon | [Icon](/docs/IconClass.md) |  | The icon to draw for the ZoomOut icon. |
| ZoomOutIconName | string |  | The name of the icon to draw for the ZoomOut icon. Available names depend on the icon library being used. |


### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| Loaded   | Emitted when the internal iframe when it finishes loading. |
| LoadError | Emitted from the internal iframe when it fails to load. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| ZoomInAsync  |   | Zooms in to the next available zoom level.      |
| ZoomOutAsync |  | Zooms out to the previous available zoom level. |


### Examples

#### External URL, 25% zoom
```HTML+Razor
<WAZoomableFrame SourceUrl="https://webawesome.com/docs/components/zoomable-frame" Zoom="0.25" />
    
```

#### Inline Html with custom zoom icons
```HTML+Razor
<WAZoomableFrame SourceHtml="<html><body><h1>Hello, World!</h1><p>This is inline content.</p></body></html>" ZoomInIconName="magnifying-glass-plus" ZoomOutIconName="magnifying-glass-minus" />
```
![WAZoomableFrame](https://github.com/user-attachments/assets/5b927ed0-73c5-434b-b163-e919eaa237c1)