# WACarousel
## WebAwesomeBlazor.Components.WACarousel

```HTML+Razor
<WACarousel>
    <WACarouselItem>
        @ChildContent
    </WACarouselItem>
</WACarousel>
```

### Description
Carousels display an arbitrary number of content slides along a horizontal or vertical axis.

[WebAwesome docs](https://webawesome.com/docs/components/carousel/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| ShowPagination    | bool | false | When true, show the carousel's pagination indicators.                     |
| AllowLooping    | bool | false       | When true, allows the user to navigate the carousel in the same direction indefinitely.                     |
| ShowNavigation    | bool | false   | When true, show the carousel's navigation.                     |
| Autoplay | bool | false | When true, the slides will scroll automatically when the user is not interacting with them. |
| AutoplayInterval | int | 3000 | Specifies the amount of time, in milliseconds, between each automatic scroll when Autoplay is true. |
| SlidesPerPage | int | 1 | Specifies how many slides should be shown at a given time. |
| SlidesPerMove | int | 1 | Specifies the number of slides the carousel will advance when scrolling, useful when specifying a slides-per-page greater than one. It can't be higher than slides-per-page. |
| Orientation | CarouselOrientation | CarouselOrientation.Horizontal | Specifies the orientation in which the carousel will lay out. |
| MouseDraggingEnabled | bool | false | When true, it is possible to scroll through the slides by dragging them with the mouse. |
| AspectRatio | string | `16/9` | The aspect ratio of each slide. Default is 16/9 |
| ScrollHint | string |  | The amount of padding to apply to the scroll area, allowing adjacent slides to become partially visible as a scroll hint. |
| SlideGap | string | `var(--wa-space-m)` | The space between each slide. |
| SlideChanged | EventCallback<int> |  | Triggered when the active slide has changed. Provides the index of the new slide. |


### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| GoToSlide  | index: int   | Scrolls the carousel to the slide specified by index.      |
| GoToSlideAsync  | index: int   | Scrolls the carousel to the slide specified by index.      |
| NextSlide |  | Move the carousel forward by SlidesPerMove slides.|
| NextSlideAsync |  | Move the carousel forward by SlidesPerMove slides.|
| PreviousSlide |  | Move the carousel backward by SlidesPerMove slides. |
| PreviousSlideAsync |  | Move the carousel backward by SlidesPerMove slides. |

### Examples

#### Basic Usage with navigation buttons
```HTML+Razor
<WACarousel ShowNavigation="true">
    <WACarouselItem>
        <img src="https://picsum.photos/200" />
    </WACarouselItem>
    <WACarouselItem>
        <img src="https://picsum.photos/200" />
    </WACarouselItem>
    <WACarouselItem>
        <img src="https://picsum.photos/200" />
    </WACarouselItem>
    <WACarouselItem>
        <img src="https://picsum.photos/200" />
    </WACarouselItem>
</WACarousel>
```

#### Horizontal with autoplay
```HTML+Razor
<WACarousel Orientation="CarouselOrientation.Horizontal" Autoplay="true" AutoplayInterval="750">
    <WACarouselItem>
        <img src="https://picsum.photos/200" />
    </WACarouselItem>
    <WACarouselItem>
        <img src="https://picsum.photos/200" />
    </WACarouselItem>
    <WACarouselItem>
        <img src="https://picsum.photos/200" />
    </WACarouselItem>
    <WACarouselItem>
        <img src="https://picsum.photos/200" />
    </WACarouselItem>
</WACarousel>
```

![WACarousel](https://github.com/user-attachments/assets/aa9a54c5-9757-442a-8fb9-e53054e97e44)
