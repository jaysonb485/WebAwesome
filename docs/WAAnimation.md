# WAAnimation
## WebAwesomeBlazor.Components.WAAnimation

```html
<WAAnimation>
	@ChildContent
</WAAnimation>
```

### Description
To animate an element, wrap it in `<WAAnimation>` and set an animation `Name`. The animation will start automatically if `AutoPlay` is `true` or can be manually triggered using `StartAnimation`. 

[WebAwesome docs](https://webawesome.com/docs/components/animation/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Name    | AnimationName |  | The name of the built-in animation to use.                     |
| AutoStart    | bool | `true`       | Sets whether the animation will commence automatically when rendered.                     |
| Delay    | int | `0`   | The number of milliseconds to delay the start of the animation                     |
| Direction    | `AnimationDirection` | AnimationDirection.Normal | The direction of the animation (Normal, Reverse, Alternate, AlternateReverse)                     |
| Duration    | int | `1000`   | The number of milliseconds each iteration of the animation takes to complete                    |
| Easing	| string | `linear` | The easing function to use for the animation. This can be a Web Awesome easing function or a custom easing function such as cubic-bezier(0, 1, .76, 1.14).|
| EndDelay    | int | `0`   | The number of milliseconds to delay after the active period of an animation sequence.                    |
| Iterations    | int | `null`   | The number of iterations to run before the animation completes. Defaults to `null`, which loops. |
| AnimationCancelled | EventCallback |  | Triggered when the animation is cancelled |
| AnimationFinished | EventCallback |  | Triggered when the animation is finished |
| AnimationStarted | EventCallback |  | Triggered when the animation has started |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| StartAnimation  |   | Starts the animation |
| StartAnimationAsync  |   | Starts the animation |
| StopAnimation |  | Stops the animation |
| StopAnimationAsync |  | Stops the animation |
| FinishAnimation |  | Sets the playback time to the end of the animation corresponding to the current playback direction. Cannot finish Animation with an infinite target effect end. |
| FinishAnimationAsync |  | Sets the playback time to the end of the animation corresponding to the current playback direction. Cannot finish Animation with an infinite target effect end. |
| CancelAnimation |  | Clears all keyframe effects caused by this animation and aborts its playback. |
| CancelAnimationAsync |  | Clears all keyframe effects caused by this animation and aborts its playback. |


### Examples
#### Basic Usage
```html
<WAAnimation Name="AnimationName.bounce" AutoStart="true">
	<div class="box">Bounce Animation</div>
</WAAnimation>
```
![WAAnimation-bounce](https://github.com/user-attachments/assets/b2013315-ed32-4e8e-8ad0-88b0af7ff2ff)
