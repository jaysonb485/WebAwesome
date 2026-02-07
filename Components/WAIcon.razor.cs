using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor.Components
{
    public partial class WAIcon : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Sets the icon to draw. Alternatively, you can set the individual icon parameters instead of using this parameter.
        /// </summary>
        [Parameter]
        public Icon? Icon { get; set; }

        /// <summary>
        /// The name of the icon to draw . Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string IconName { get; set; } = string.Empty;
        /// <summary>
        /// The family of icons to choose from . For Font Awesome Free (default), valid options include classic and brands. For Font Awesome Pro subscribers, valid options include, classic, sharp, duotone, and brands. Custom icon libraries may or may not use this property.
        /// </summary>
        [Parameter]
        public string IconFamily { get; set; } = string.Empty;
        /// <summary>
        /// The name icon's variant. For Font Awesome, valid options include thin, light, regular, and solid for the classic and sharp families. Some variants require a Font Awesome Pro subscription. Custom icon libraries may or may not use this property.
        /// </summary>
        [Parameter]
        public string? IconVariant { get; set; } = string.Empty;

        /// <summary>
        /// An alternate description to use for assistive devices. If omitted, the icon will be considered presentational and ignored by assistive devices.
        /// </summary>
        [Parameter]
        public string? Label { get; set; } = string.Empty;

        /// <summary>
        /// Sets the width of the icon to match the cropped SVG viewBox. This operates like the Font fa-width-auto class.
        /// </summary>
        [Parameter]
        public bool AutoWidth { get; set; } = false;

        /// <summary>
        /// Swaps the opacity of duotone icons.
        /// </summary>
        [Parameter]
        public bool SwapOpacity { get; set; } = false;

        /// <summary>
        /// The name of a registered custom icon library.
        /// </summary>
        [Parameter]
        public string? Library { get; set; } = "default";

        /// <summary>
        /// An external URL of an SVG file. Be sure you trust the content you are including, as it will be executed as code and can result in XSS attacks.
        /// </summary>
        [Parameter]
        public string? IconSourceUrl { get; set; } = string.Empty;

        /// <summary>
        /// Sets a duotone icon's primary color.
        /// </summary>
        [Parameter]
        public string? PrimaryColor { get; set; } = string.Empty;

        /// <summary>
        /// Sets a duotone icon's secondary color.
        /// </summary>
        [Parameter]
        public string? SecondaryColor { get; set; } = string.Empty;

        /// <summary>
        /// Sets a duotone icon's primary opacity.
        /// </summary>
        [Parameter]
        public string? PrimaryOpacity { get; set; } = string.Empty;
        /// <summary>
        /// Sets a duotone icon's secondary opacity.
        /// </summary>
        [Parameter]
        public string? SecondaryOpacity { get; set; } = string.Empty;

        #endregion

        #region Computed  Properties
        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--primary-color: {PrimaryColor}", !String.IsNullOrEmpty(PrimaryColor)),
            ($"--secondary-color: {SecondaryColor}", !String.IsNullOrEmpty(SecondaryColor)),
            ($"--primary-opacity: {PrimaryOpacity}", !String.IsNullOrEmpty(PrimaryOpacity)),
            ($"--secondary-opacity: {SecondaryOpacity}", !String.IsNullOrEmpty(SecondaryOpacity))
        );
        #endregion

        #region Private Methods
        private Dictionary<string, object> GetAttributesWithIcon()
        {
            Dictionary<string, object> AdditionalAttributesWithIcon = new();
            if (AdditionalAttributes is not null)
            {
                foreach (var attr in AdditionalAttributes)
                {
                    AdditionalAttributesWithIcon.Add(attr.Key, attr.Value);
                }
            }

            if (Icon != null)
            {
                AdditionalAttributesWithIcon["name"] = Icon.Name;
                AdditionalAttributesWithIcon["variant"] = Icon.Variant ?? string.Empty;
                AdditionalAttributesWithIcon["family"] = Icon.Family ?? string.Empty;
                AdditionalAttributesWithIcon["label"] = Icon.Label ?? string.Empty;
                AdditionalAttributesWithIcon["auto-width"] = Icon.AutoWidth;
                AdditionalAttributesWithIcon["swap-opacity"] = Icon.SwapOpacity;
                AdditionalAttributesWithIcon["src"] = Icon.SourceUrl ?? string.Empty;
                AdditionalAttributesWithIcon["library"] = Icon.Library ?? "default";
                AdditionalAttributesWithIcon["animation"] = Icon.Animation switch
                {
                    IconAnimation.None => string.Empty,
                    IconAnimation.Beat => "beat",
                    IconAnimation.Fade => "fade",
                    IconAnimation.BeatFade => "beat-fade",
                    IconAnimation.Bounce => "bounce",
                    IconAnimation.Flip => "flip",
                    IconAnimation.Shake => "shake",
                    IconAnimation.Spin => "spin",
                    _ => string.Empty
                };
                AdditionalAttributesWithIcon["flip"] = Icon.Flip switch
                {
                    IconFlip.None => string.Empty,
                    IconFlip.Horizontal => "x",
                    IconFlip.Vertical => "y",
                    IconFlip.Both => "both",
                    _ => string.Empty
                };
                AdditionalAttributesWithIcon["rotate"] = Icon.Rotate ?? 0;

                return AdditionalAttributesWithIcon;
            }
            ;

            AdditionalAttributesWithIcon["name"] = IconName;
            AdditionalAttributesWithIcon["variant"] = IconVariant ?? string.Empty;
            AdditionalAttributesWithIcon["family"] = IconFamily ?? string.Empty;
            AdditionalAttributesWithIcon["label"] = Label ?? string.Empty;
            AdditionalAttributesWithIcon["auto-width"] = AutoWidth;
            AdditionalAttributesWithIcon["swap-opacity"] = SwapOpacity;
            AdditionalAttributesWithIcon["src"] = IconSourceUrl ?? string.Empty;
            AdditionalAttributesWithIcon["library"] = Library ?? "default";

            return AdditionalAttributesWithIcon;
        }
        #endregion

    }


}
