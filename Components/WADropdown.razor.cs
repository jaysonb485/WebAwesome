using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WADropdown : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public RenderFragment? DropdownItems { get; set; } = default!;
        /// <summary>
        /// Text to display on the trigger button.
        /// </summary>
        [Parameter]
        public RenderFragment? TriggerButtonContent { get; set; }
        /// <summary>
        /// Show the caret arrow indicating a dropdown action. Defaults to true.
        /// </summary>
        [Parameter]
        public bool ShowTriggerCaret { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the trigger button should be hidden.
        /// </summary>
        [Parameter]
        public bool HideTriggerButton { get; set; } = false;
        /// <summary>
        /// The trigger button's theme variant. Defaults to neutral if not within another element with a variant.
        /// </summary>
        [Parameter]
        public ButtonVariant TriggerButtonVariant { get; set; } = ButtonVariant.Inherit;

        /// <summary>
        /// The button's visual appearance.
        /// </summary>
        [Parameter]
        public ButtonAppearance TriggerButtonAppearance { get; set; } = ButtonAppearance.Accent;
        [Parameter]
        public DropdownPlacement PanelPlacement { get; set; } = DropdownPlacement.BottomStart;
        /// <summary>
        /// Disables the dropdown so the panel will not open.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// By default, the dropdown is closed when an item is selected. This attribute will keep it open instead. Useful for dropdowns that allow for multiple interactions.
        /// </summary>
        [Parameter]
        public bool StayOpenOnSelect { get; set; } = false;

        /// <summary>
        /// The distance in pixels from which to offset the panel away from its trigger.
        /// </summary>
        [Parameter]
        public int Distance { get; set; } = 0;

        /// <summary>
        /// The distance in pixels from which to offset the panel along its trigger.
        /// </summary>
        [Parameter]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Opens the menu when the user hovers over the trigger button.
        /// Closes the menu when the users mouse exits the component.
        /// </summary>
        [Parameter]
        public bool OpenOnHover { get; set; } = false;

        [Parameter]
        public bool Open { get; set; } = false;
        #endregion

        #region Computed  Properties
        string PlacementString
        {
            get
            {
                return PanelPlacement switch
                {
                    DropdownPlacement.Top => "top",
                    DropdownPlacement.TopStart => "top-start",
                    DropdownPlacement.TopEnd => "top-end",
                    DropdownPlacement.Bottom => "bottom",
                    DropdownPlacement.BottomStart => "bottom-start",
                    DropdownPlacement.BottomEnd => "bottom-end",
                    DropdownPlacement.Right => "right",
                    DropdownPlacement.RightStart => "right-start",
                    DropdownPlacement.RightEnd => "right-end",
                    DropdownPlacement.Left => "left",
                    DropdownPlacement.LeftStart => "left-start",
                    DropdownPlacement.LeftEnd => "left-end",
                    _ => "bottom-start"
                };
            }
        }

        string TriggerButtonAppearanceString
        {
            get
            {
                return TriggerButtonAppearance switch
                {
                    ButtonAppearance.Accent => "accent",
                    ButtonAppearance.Filled => "filled",
                    ButtonAppearance.OutlinedFilled => "filled outlined",
                    ButtonAppearance.Outlined => "outlined",
                    ButtonAppearance.Plain => "plain",
                    _ => "accent"
                };
            }
        }


        string TriggerButtonVariantString
        {
            get
            {
                return TriggerButtonVariant switch
                {
                    ButtonVariant.Brand => "brand",
                    ButtonVariant.Success => "success",
                    ButtonVariant.Neutral => "neutral",
                    ButtonVariant.Warning => "warning",
                    ButtonVariant.Danger => "danger",
                    ButtonVariant.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }
        #endregion

    }
}
