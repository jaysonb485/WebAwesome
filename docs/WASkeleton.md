# WASkeleton
## WebAwesomeBlazor.Components.WASkeleton

```HTML+Razor
<WASkeleton />
```

### Description
Skeletons are used to provide a visual representation of where content will eventually be drawn.

[Web Awesome docs](https://webawesome.com/docs/components/skeleton/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| BorderRadius | string |  | The border radius of the skeleton. |
| Color | string |  | The color of the skeleton. |
| Effect | SkeletonEffect | SkeletonEffect.None | Determines which effect the skeleton will use. |
| Height | string |  | The height of the skeleton in CSS Units |
| SheenColor | string |  | The sheen color when the skeleton is in its loading state. |
| Width | string |  | The width of the skeleton. |

### Examples

#### Basic Usage
```HTML+Razor
<WASkeleton />
```

#### Sheen effect with sheen color
```HTML+Razor
<WASkeleton Effect="SkeletonEffect.Sheen" SheenColor="skyblue" />
```

#### Pulse effect, custom shape
```HTML+Razor
<WASkeleton Class="skeletonAvatar" Effect="SkeletonEffect.Pulse" Height="100px" Width="100px" />

<style>
    .skeletonAvatar::part(indicator) {
        border-radius: var(--wa-border-radius-circle);
    }
</style>
````
![WASkeleton](https://github.com/user-attachments/assets/55180ac5-4524-4064-b6bb-4fd0ab9c5983)