# WAResizeObserver
## WebAwesomeBlazor.Components.WAResizeObserver

```HTML+Razor
<WAResizeObserver>
	@ChildContent
</WAResizeObserver>
```

### Description
The resize observer will report changes to the dimensions of the elements it wraps.

[WebAwesome docs](https://webawesome.com/docs/components/resize-observer/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Disabled | bool | false | Disables the observer. |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| Resized   | Triggered when the element is resized. Provides `ResizeEventArgs` containing height and width.  |

### Examples

#### Basic Usage
```HTML+Razor
<div style="max-width:1024px; max-height: 1024px;">
    <WAResizeObserver Resized="ElementResized">
        <div style="width:100%; height: 100%">
            <p>Content</p>
            <p>Height: @contentHeight</p>
            <p>Width: @contentWidth</p>
        </div>
    </WAResizeObserver>
</div>

@code {
    decimal contentHeight { get; set; }
    decimal contentWidth { get; set; }

    void ElementResized(WebAwesomeBlazor.Components.WAResizeObserver.ResizeEventArgs eventArgs)
    {
        contentHeight = eventArgs.Height ?? 0;
        contentWidth = eventArgs.Width ?? 0;
    }
}
```