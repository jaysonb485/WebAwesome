# WAIntersectionObserver
## Vengage.WebAwesome.Components.WAIntersectionObserver

```HTML+Razor
<WAIntersectionObserver>
	@ChildContent
</WAIntersectionObserver>
```

### Description
Tracks immediate child elements and fires events as they move in and out of view.

[WebAwesome docs](https://webawesome.com/docs/components/intersection-observer)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| RootElementId | string |  | Element ID to define the viewport boundaries for tracked targets. |
| RootMargin | string | 0px | Offset space around the root boundary. Accepts values like CSS margin syntax. |
| Threshold | string | 0 | One or more space-separated values representing visibility percentages that trigger the observer callback. |
| ShowOnce | bool | false | If enabled, observation ceases after initial intersection. |
| IntersectClass | string |  | CSS class applied to elements when they intersect the viewport. |
| Disabled | bool | false | If true, disables the intersection observer functionality. |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| OnIntersecting   | Fired when a tracked element begins intersecting. |
| OnLeaving | Fired when a tracked element ceases intersecting. |

### Examples

#### Basic Usage
Threshold = 1 requires the box to be entirely in view before OnIntersecting triggers.
```HTML+Razor
<div class="wa-stack wa-gap-xl" style="max-width:320px;">
    <div style="height: 400px;">
        Scroll down to see the box change.
    </div>
    <WAIntersectionObserver
        Threshold="1"
        OnIntersecting="UpdateMessageIntersecting"
        OnLeaving="UpdateMessageLeaving">
        <div class="box">
            @message
        </div>
    </WAIntersectionObserver>
    <div style="height: 400px;">
        
    </div>
</div>
@code {
    string message { get; set; } = "Waiting to be completely in view...";

    void UpdateMessageIntersecting()
    {
        message = "The box is now in view!"; 
    }

    void UpdateMessageLeaving()
    {
        message = "Waiting to be completely in view...";
    }

}
```


![WAIntersectionObserver](https://github.com/user-attachments/assets/cde99c73-600a-4331-91b5-767d2612a52d)