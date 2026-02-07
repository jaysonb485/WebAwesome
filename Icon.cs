namespace WebAwesomeBlazor
{
    public class Icon
    {
        /// <summary>
        /// The name of the icon to draw. Available names depend on the icon library being used.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        ///<summary>
        /// The family of icons to choose from.For Font Awesome Free, valid options include classic and brands. For Font Awesome Pro subscribers, valid options include, classic, sharp, duotone, sharp-duotone, and brands. A valid kit code must be present to show pro icons via CDN.You can set<html data-fa-kit-code = "..." > to provide one.
        ///</summary>
        public string? Family { get; set; } = string.Empty;

        /// <summary>
        /// The name of the icon's variant. For Font Awesome, valid options include thin, light, regular, and solid for the classic and sharp families. Some variants require a Font Awesome Pro subscription. Custom icon libraries may or may not use this property.
        /// </summary>
        public string? Variant { get; set; } = string.Empty;
        /// <summary>
        /// Sets the width of the icon to match the cropped SVG viewBox.This operates like the Font fa-width-auto class.
        /// </summary>
        public bool AutoWidth { get; set; } = false;
        /// <summary>
        /// Swaps the opacity of duotone icons.
        /// </summary>
        public bool SwapOpacity { get; set; } = false;

        /// <summary>
        /// An external URL of an SVG file.Be sure you trust the content you are including, as it will be executed as code and can result in XSS attacks.
        /// </summary>
        public string? SourceUrl { get; set; } = string.Empty;
        /// <summary>
        /// An alternate description to use for assistive devices. If omitted, the icon will be considered presentational and ignored by assistive devices.
        /// </summary>
        public string? Label { get; set; } = string.Empty;

        /// <summary>
        /// The name of a registered custom icon library.
        /// </summary>
        public string Library { get; set; } = "default";

        /// <summary>
        /// Sets the animation for the icon
        /// </summary>
        public IconAnimation Animation { get; set; } = IconAnimation.None;

        /// <summary>
        /// Sets the flip direction of the icon along the horizontal (x), vertical (y), or 'both' axes.
        /// </summary>
        public IconFlip Flip { get; set; } = IconFlip.None;

        /// <summary>
        /// Sets the rotation degree of the icon
        /// </summary>
        public int? Rotate { get; set; } = 0;
    }

    public static class Icons
    {
        public static Icon Copy => new() { Name = "copy" };
        public static Icon Check => new() { Name = "check" };
        public static Icon XMark => new() { Name = "xmark" };
    }
}
