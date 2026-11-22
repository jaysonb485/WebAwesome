# WALightbox
## WebAwesomeBlazor.Components.WALightbox

```HTML+Razor
<WALightbox>
	<WALightboxItem SourceUrl="http://img.jpg>
		<img src="http://img.jpg" />
	</WALightboxItem>
</WALightbox>
```

### Description
Lightboxes show images and videos in a full-screen viewer that opens from their thumbnails. Use them for photo galleries, product images, or any media that deserves a closer look.

[Web Awesome docs](https://webawesome.com/docs/components/lightbox/)

### Properties
| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `ItemIndex` | `int` | `0` | The zero-based index of the currently displayed item. Set this before opening the lightbox to control which item is shown first. |
| `CloseIconName` | `string?` | `null` | The name of a custom close icon. Available icon names depend on the configured icon library. |
| `CloseIcon` | `Icon?` | `null` | A custom close icon to display instead of the default icon. |
| `Label` | `string?` | `null` | Accessible label used by assistive technologies to describe the lightbox. |
| `Loop` | `bool` | `false` | Enables continuous navigation by wrapping from the last item back to the first, and vice versa. |
| `NextIconName` | `string?` | `null` | The name of a custom next-navigation icon. Available icon names depend on the configured icon library. |
| `NextIcon` | `Icon?` | `null` | A custom next-navigation icon to display instead of the default icon. |
| `PreviousIconName` | `string?` | `null` | The name of a custom previous-navigation icon. Available icon names depend on the configured icon library. |
| `PreviousIcon` | `Icon?` | `null` | A custom previous-navigation icon to display instead of the default icon. |
| `Open` | `bool` | `false` | Indicates whether the lightbox is open and visible. Use `OpenAsync()` and `CloseAsync()` to change the value. |
| `ShowCounter` | `bool` | `true` | Displays a counter showing the current item's position within the collection. |
| `ShowNavigation` | `bool` | `true` | Shows the previous and next navigation buttons. Keyboard navigation and swipe gestures remain available when disabled. |
| `ShowZoom` | `bool` | `true` | Enables zoom functionality and displays zoom controls. |
| `ShowThumbnails` | `bool` | `false` | Displays item thumbnails for quick navigation between items. |
| `ZoomInIconName` | `string?` | `null` | The name of a custom zoom-in icon. Available icon names depend on the configured icon library. |
| `ZoomInIcon` | `Icon?` | `null` | A custom zoom-in icon to display instead of the default icon. |
| `ZoomOutIconName` | `string?` | `null` | The name of a custom zoom-out icon. Available icon names depend on the configured icon library. |
| `ZoomOutIcon` | `Icon?` | `null` | A custom zoom-out icon to display instead of the default icon. |
| `Showing` | `EventCallback<LightboxShowingEventArgs>` | - | Invoked before the lightbox opens. Set `args.Cancel = true` to prevent opening. |
| `Hiding` | `EventCallback<LightboxHidingEventArgs>` | - | Invoked before the lightbox closes. Set `args.Cancel = true` to prevent closing. |
| `ItemChanged` | `EventCallback<LightboxItemChangeEventArgs>` | - | Invoked whenever the currently displayed item changes. |
| `Shown` | `EventCallback` | - | Invoked after the lightbox has opened and all animations have completed. |
| `Hidden` | `EventCallback` | - | Invoked after the lightbox has closed and all animations have completed. |
| `Actions` | `RenderFragment?` | `null` | Custom content rendered in the lightbox toolbar, typically used for actions such as download, share, or custom commands. |

### WALightboxItem Properties
| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `AltText` | `string?` | `null` | Alternative text for the full-size media. When not specified, the thumbnail image's alt text is used. |
| `Caption` | `string?` | `null` | Plain text caption displayed with the item in the lightbox. |
| `Height` | `int?` | `null` | The intrinsic height of the full-size media in pixels. |
| `PlayIconName` | `string?` | `null` | The name of a custom play icon. Available icon names depend on the configured icon library. |
| `PlayIcon` | `Icon?` | `null` | A custom play icon to display instead of the default icon for video items. |
| `Sizes` | `string?` | `null` | Specifies responsive image sizes for use with `SourceSet`. When omitted, the viewport width and zoomed width are used automatically. |
| `SourceUrl` | `string?` | `null` | The URL of the full-size image or video displayed by the lightbox. |
| `SourceSet` | `string?` | `null` | A set of image sources in the same format as the HTML `srcset` attribute, enabling responsive image selection. |
| `ThumbnailUrl` | `string?` | `null` | The URL of the thumbnail image used in the thumbnail strip and as a placeholder while the full-size media loads. |
| `MediaType` | `LightboxItemMediaType` | `Image` | Specifies whether the item represents an image or video. Video items display a play button overlay. |
| `Width` | `int?` | `null` | The intrinsic width of the full-size media in pixels. Set together with `Height` to allow the lightbox to size the slide before the media loads. |

### Methods

| Method | Parameters | Description |
|----------|----------|-------------|
| `CloseAsync` | None | Closes the lightbox. |
| `NextItemAsync` | None | Navigates to the next item in the collection. |
| `OpenAsync` | None | Opens the lightbox. |
| `PreviousItemAsync` | None | Navigates to the previous item in the collection. |
| `ZoomInAsync` | None | Zooms in on the currently displayed image or content. |
| `ZoomOutAsync` | None | Zooms out of the currently displayed image or content. |


### Examples

#### Basic Usage
```HTML+Razor
<WALightbox Label="Landscape photos">
  <WALightboxItem
    SourceUrl="https://images.unsplash.com/photo-1426604966848-d7adac402bff?w=1600&h=1067&fit=crop&q=80"
    Caption="Sunlight breaking over the mountains. Photo by Adam Kool on Unsplash."
    Width="1600"
    Height="1067"
  >
    <img
      src="https://images.unsplash.com/photo-1426604966848-d7adac402bff?w=480&h=320&fit=crop&q=60"
      alt="The sun shines on the mountains and trees"
    />
  </WALightboxItem>
  <WALightboxItem
    SourceUrl="https://images.unsplash.com/photo-1473448912268-2022ce9509d8?w=1600&h=1067&fit=crop&q=80"
    Caption="A river winding through an evergreen forest. Photo by Luca Bravo on Unsplash."
    Width="1600"
    Height="1067"
  >
    <img
      src="https://images.unsplash.com/photo-1473448912268-2022ce9509d8?w=480&h=320&fit=crop&q=60"
      alt="A river winding through an evergreen forest"
    />
  </WALightboxItem>
  <WALightboxItem
    SourceUrl="https://images.unsplash.com/photo-1499002238440-d264edd596ec?w=1600&h=1067&fit=crop&q=80"
    Caption="Sunset over a lavender field. Photo by Leonard Cotte on Unsplash."
    Width="1600"
    Height="1067">
    <img
      src="https://images.unsplash.com/photo-1499002238440-d264edd596ec?w=480&h=320&fit=crop&q=60"
      alt="The sun is setting over a lavender field"
    />
  </WALightboxItem>
  <WALightboxItem
    SourceUrl="https://images.unsplash.com/photo-1475113548554-5a36f1f523d6?w=1600&h=1067&fit=crop&q=80"
    Caption="Evening light across a field of grass. Photo by Sapan Patel on Unsplash."
    Width="1600"
    Height="1067"
  >
    <img
      src="https://images.unsplash.com/photo-1475113548554-5a36f1f523d6?w=480&h=320&fit=crop&q=60"
      alt="A field of grass with the sun setting in the background"
    />
  </WALightboxItem>
</WALightbox>

```

#### Prevent showing
```HTML+Razor

<WALightbox Label="Landscape photos" Showing="LightboxShowing">

@* ... Lightbox items ... *@

</WALightbox>

<WACheckbox @bind-Value="preventShow" Label="Prevent showing" />


@code
{
    bool preventShow { get; set; }

    async Task LightboxShowing(LightboxShowingEventArgs args)
    {
        // Only allow showing the lightbox if the Prevent showing checkbox is not checked.
        args.Cancel = preventShow;
    }
}
```