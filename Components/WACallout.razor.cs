using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WACallout : WAComponentBase
    {
        #region Parameters

        /// <summary>
        /// The name of the icon to draw in the prefix slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? IconName { get; set; }

        [Parameter]
        public Icon? Icon { get; set; }

        /// <summary>
        /// The callout's theme variant. Defaults to brand if not within another element with a variant.
        /// </summary>
        [Parameter]
        public CalloutVariant Variant { get; set; } = CalloutVariant.Inherit;
        /// <summary>
        /// The callout's visual appearance.
        /// </summary>
        [Parameter]
        public CalloutAppearance Appearance { get; set; } = CalloutAppearance.OutlinedFilled;

        /// <summary>
        /// The callout's size.
        /// </summary>
        [Parameter]
        public CalloutSize Size { get; set; } = CalloutSize.Inherit;
        #endregion

        #region Computed  Properties

        string VariantString
        {
            get
            {
                return Variant switch
                {
                    CalloutVariant.Brand => "brand",
                    CalloutVariant.Success => "success",
                    CalloutVariant.Neutral => "neutral",
                    CalloutVariant.Warning => "warning",
                    CalloutVariant.Danger => "danger",
                    CalloutVariant.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }


        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    CalloutAppearance.Accent => "accent",
                    CalloutAppearance.Filled => "filled",
                    CalloutAppearance.OutlinedFilled => "outlined filled",
                    CalloutAppearance.Outlined => "outlined",
                    CalloutAppearance.Plain => "plain",
                    _ => "outlined filled"
                };
            }
        }

        string SizeString
        {
            get
            {
                return Size switch
                {
                    CalloutSize.Small => "small",
                    CalloutSize.Medium => "medium",
                    CalloutSize.Large => "large",
                    CalloutSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }
        #endregion


    }
}
