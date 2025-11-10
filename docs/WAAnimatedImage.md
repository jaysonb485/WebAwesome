# WAAnimatedImage
## WebAwesomeBlazor.Components.WAAnimatedImage

```HTML+Razor
<WAAnimatedImage AnimationUrl="" AltText="" />
```

### Description
A component for displaying animated GIFs and WEBPs that play and pause on interaction.

[WebAwesome docs](https://webawesome.com/docs/components/animated-image/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| AnimationUrl | string |  | The path to the image to load. |
| AltText | string |  | A description of the image used by assistive devices. |
| PlayIcon | [Icon](/docs/IconClass.md) |  | Optional play icon to use instead of the default. Alternatively use PlayIconName.|
| PauseIcon | [Icon](/docs/IconClass.md) |  | Optional pause icon to use instead of the default. Alternatively use PauseIconName. |
| PlayIconName | string |  | Optional play icon to use instead of the default. Alternatively use PlayIcon. |
| PauseIconName | string |  | Optional pause icon to use instead of the default. Alternatively use PauseIcon |
| ControlBoxSize | string |  | The size of the icon box in CSS size units. |
| IconSize | string |  | The size of the play/pause icons in CSS size units. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| TogglePlay  |  | Plays or pauses the animation       |
| Play |  | Plays the animation |
| Pause |  | Pauses the animation |

### Examples

#### Basic Usage
```HTML+Razor
<WAAnimatedImage @ref="AnimatedImage" AnimationUrl="https://shoelace.style/assets/images/walk.gif" AltText="Walking with untied shoelaces" />

<WAButton OnClick="ToggleAnimation" Text="Toggle" />

@code {
    WAAnimatedImage AnimatedImage;

    void ToggleAnimation()
    {
        AnimatedImage.TogglePlay();
    }
}
```

![WAAnimatedImage](https://github.com/user-attachments/assets/8ad768af-c9a0-4f15-8f14-7fc030fd241e)