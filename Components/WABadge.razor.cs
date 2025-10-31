using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
