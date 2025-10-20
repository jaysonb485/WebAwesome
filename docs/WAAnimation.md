# WAAnimation
## Vengage.WebAwesome.Components.WAAnimation

```html
<WAAnimation>
	@ChildContent
</WAAnimation>
```

### Description
To animate an element, wrap it in `<WAAnimation>` and set an animation `Name`. The animation will start automatically if `AutoPlay` is `true` or can be manually triggered using `StartAnimation`. 

[WebAwesome docs](https://webawesome.com/docs/animation)

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

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| StartAnimation  |   | Starts the animation |
| StopAnimation | | Stops the animation |


### Examples
#### Basic Usage
```html
<WAAnimation Name="AnimationName.bounce" AutoStart="true">
	<div class="box">Bounce Animation</div>
</WAAnimation>
```
