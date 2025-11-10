using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WACard : WAComponentBase
    {
        #region Parameters

        /// <summary>
        /// An optional footer for the card.
        /// </summary>
        [Parameter]
        public RenderFragment? CardFooter { get; set; }

        /// <summary>
        /// An optional media section to render at the start of the card.
        /// </summary>
        [Parameter]
        public RenderFragment? CardMedia { get; set; }

        /// <summary>
        /// An optional header for the card.
        /// </summary>
        [Parameter]
        public RenderFragment? CardHeader { get; set; }

        /// <summary>
        /// The card's main content.
        /// </summary>
        [Parameter]
        public RenderFragment? CardBody { get; set; }


        /// <summary>
        /// An optional actions section to render at the end for the horizontal card.
        /// </summary>
        [Parameter]
        public RenderFragment? HorizontalActions { get; set; }
        /// <summary>
        /// An optional actions section to render in the header of the vertical card.
        /// </summary>
        [Parameter]
        public RenderFragment? HeaderActions { get; set; }

        /// <summary>
        /// An optional actions section to render in the footer of the vertical card.
        /// </summary>
        [Parameter]
        public RenderFragment? FooterActions { get; set; }

        /// <summary>
        /// CSS class to apply to the footer section of the card.
        /// </summary>
        [Parameter]
        public string? FooterCSSClass { get; set; }

        /// <summary>
        /// CSS class to apply to the header section of the card.
        /// </summary>
        [Parameter]
        public string? HeaderCSSClass { get; set; }

        /// <summary>
        /// The card's visual appearance.
        /// </summary>
        [Parameter]
        public CardAppearance Appearance { get; set; } = CardAppearance.Outlined;
        /// <summary>
        /// An optional image to render at the start of the card.
        /// </summary>
        [Parameter]
        public string? ImageSource { get; set; }
        /// <summary>
        /// Alt text for the optional image.
        /// </summary>
        [Parameter]
        public string? ImageAltText { get; set; }

        /// <summary>
        /// Renders the card's orientation.
        /// </summary>
        [Parameter]
        public CardOrientation Orientation { get; set; } = CardOrientation.Vertical;

        /// <summary>
        /// The amount of space around and between sections of the card. Expects a single value.
        /// Default is var(--wa-space-l).
        /// </summary>
        [Parameter]
        public string? Spacing { get; set; }


        #endregion

        #region Computed  Properties
        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    CardAppearance.Accent => "accent",
                    CardAppearance.Filled => "filled",
                    CardAppearance.FilledOutlined => "filled-outlined",
                    CardAppearance.Outlined => "outlined",
                    CardAppearance.Plain => "plain",
                    _ => "outlined"
                };
            }
        }



        string _orientationString
        {
            get
            {
                return Orientation switch
                {
                    CardOrientation.Horizontal => "horizontal",
                    CardOrientation.Vertical => "vertical",
                    _ => "vertical"
                };
            }
        }
        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--spacing: {Spacing}", !String.IsNullOrEmpty(Spacing))
        );
        #endregion


    }
}
