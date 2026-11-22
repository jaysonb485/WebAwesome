using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor.Components
{
    public partial class WALightboxItem : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Alternative text for the full-size media. Defaults to the slotted thumbnail's alt.
        /// </summary>
        [Parameter]
        public string? AltText { get; set; }
        /// <summary>
        /// A plain text caption to show with the item in the lightbox.
        /// </summary>
        [Parameter]
        public string? Caption { get; set; }
        /// <summary>
        /// The intrinsic height of the full-size media in pixels.
        /// </summary>
        [Parameter]
        public int? Height { get; set; }
        /// <summary>
        /// Optional play icon to use instead of the default. . Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? PlayIconName { get; set; }

        /// <summary>
        /// Optional play icon to use instead of the default. 
        /// </summary>
        [Parameter]
        public Icon? PlayIcon { get; set; }

        /// <summary>
        /// The sizes to use with srcset. When omitted, the lightbox uses the viewport width, and the zoomed width once the image is zoomed in.
        /// </summary>
        [Parameter]
        public string? Sizes { get; set; }
        /// <summary>
        /// The URL of the full-size image or video. The thumbnail links to it, so the item still works without JavaScript and when opened in a new tab.
        /// </summary>
        [Parameter]
        public string? SourceUrl { get; set; }
        /// <summary>
        /// A set of image sources for the full-size image, in the same format as the <img> srcset attribute.
        /// </summary>
        [Parameter]
        public string? SourceSet { get; set; }
        /// <summary>
        /// The URL of a thumbnail to use in the lightbox's thumbnail strip and as a placeholder while the full-size media loads. Only needed when no <img> is slotted in.
        /// </summary>
        [Parameter]
        public string? ThumbnailUrl { get; set; }
        /// <summary>
        /// The kind of media the item shows in the lightbox. Videos show a play button over their thumbnail.
        /// </summary>
        [Parameter]
        public LightboxItemMediaType MediaType { get; set; } = LightboxItemMediaType.Image;
        /// <summary>
        /// The intrinsic width of the full-size media in pixels. Set this with height so the lightbox can size the slide before the media loads.
        /// </summary>
        [Parameter]
        public int? Width { get; set; }
        #endregion
    }
}
