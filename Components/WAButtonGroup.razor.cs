using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WAButtonGroup : WAComponentBase
    {
        #region Parameters

        /// <summary>
        /// The button group's theme variant. Defaults to neutral if not within another element with a variant.
        /// </summary>
        [Parameter]
        public ButtonGroupVariant Variant { get; set; } = ButtonGroupVariant.Neutral;
        /// <summary>
        /// A label to use for the button group. This won't be displayed on the screen, but it will be announced by assistive devices when interacting with the control and is strongly recommended.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The button group's orientation.
        /// </summary>
        [Parameter]
        public ButtonGroupOrientation Orientation { get; set; } = ButtonGroupOrientation.Horizontal;
        #endregion

        #region Computed  Properties
        string VariantString
        {
            get
            {
                return Variant switch
                {
                    ButtonGroupVariant.Brand => "brand",
                    ButtonGroupVariant.Success => "success",
                    ButtonGroupVariant.Neutral => "neutral",
                    ButtonGroupVariant.Warning => "warning",
                    ButtonGroupVariant.Danger => "danger",
                    ButtonGroupVariant.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }
        string OrientationString
        {
            get
            {
                return (Orientation == ButtonGroupOrientation.Horizontal) ? "horizontal" : "vertical";
            }
        }
        #endregion


    }
}
