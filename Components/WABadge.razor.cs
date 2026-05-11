using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor.Components
{
    public partial class WABadge : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The badge's visual appearance. Valid options for badge are: Accent, AccentOutlined, Filled, FilledOutlined, Outlined.
        /// </summary>
        [Parameter]
        public BadgeAppearance Appearance { get; set; } = BadgeAppearance.Accent;
        /// <summary>
        /// Draws a pill-style badge with rounded edges.
        /// </summary>
        [Parameter]
        public bool Pill { get; set; } = false;

        /// <summary>
        /// Adds an animation to draw attention to the badge.
        /// </summary>
        [Parameter]
        public BadgePulse Pulse { get; set; } = BadgePulse.None;

        /// <summary>
        /// The color of the badge's pulse effect when using attention="pulse".
        /// </summary>
        [Parameter]
        public string? PulseColor { get; set; }

        /// <summary>
        /// The text to display in the badge.
        /// </summary>
        [Parameter]
        public string? Text { get; set; }

        /// <summary>
        /// The badge's theme variant. Defaults to brand if not within another element with a variant.
        /// </summary>
        [Parameter]
        public BadgeVariant Variant { get; set; } = BadgeVariant.Brand;

        /// <summary>
        /// The name of the icon to draw in the start slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? StartIconName { get; set; }
        /// <summary>
        /// The icon to draw in the start slot. Alernatively, use StartIconName to specify the name of an icon in the icon library.
        /// </summary>
        [Parameter]
        public Icon? StartIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw in the end slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? EndIconName { get; set; }

        /// <summary>
        /// /// The icon to draw in the end slot. Alernatively, use EndIconName to specify the name of an icon in the icon library.
        /// </summary>
        [Parameter]
        public Icon? EndIcon { get; set; }


        #endregion

        #region Computed  Properties
        string VariantString
        {
            get
            {
                return Variant switch
                {
                    BadgeVariant.Brand => "brand",
                    BadgeVariant.Success => "success",
                    BadgeVariant.Neutral => "neutral",
                    BadgeVariant.Warning => "warning",
                    BadgeVariant.Danger => "danger",
                    _ => "brand"
                };
            }
        }
        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    BadgeAppearance.Accent => "accent",
                    BadgeAppearance.AccentOutlined => "accent outlined",
                    BadgeAppearance.Filled => "filled",
                    BadgeAppearance.FilledOutlined => "filled-outlined",
                    BadgeAppearance.Outlined => "outlined",
                    _ => "accent"
                    //Plain is not valid for badge
                };
            }
        }

        string PulseString
        {
            get
            {
                return Pulse switch
                {
                    BadgePulse.None => "none",
                    BadgePulse.Pulse => "pulse",
                    BadgePulse.Bounce => "bounce",
                    _ => "none"
                };
            }
        }

        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--pulse-color: {PulseColor}", !String.IsNullOrEmpty(PulseColor))
        );
        #endregion


    }
}
