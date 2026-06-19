using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor.Components
{
    public partial class WACheckboxGroup : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// A custom label for assistive devices.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The Checkbox group's size. This size will be applied to all child Checkbox and Checkbox buttons, except when explicitly overridden.
        /// </summary>
        [Parameter]
        public CheckboxGroupSize? Size { get; set; }
        /// <summary>
        /// The radio groups's hint.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }

        /// <summary>
        /// The orientation in which to show Checkbox items.
        /// </summary>
        [Parameter]
        public CheckboxGroupOrientation Orientation { get; set; } = CheckboxGroupOrientation.Vertical;
        /// <summary>
        /// Ensures a child Checkbox is checked before allowing the containing form to submit.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;

        /// <summary>
        /// Disables the Checkbox group and all child radios.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;
        #endregion

        #region Computed  Properties
        string SizeString
        {
            get
            {
                return Size switch
                {
                    CheckboxGroupSize.XSmall => "xs",
                    CheckboxGroupSize.Small => "s",
                    CheckboxGroupSize.Medium => "m",
                    CheckboxGroupSize.Large => "l",
                    CheckboxGroupSize.XLarge => "xl",
                    CheckboxGroupSize.Inherit => "inherit",
                    _ => ""
                };
            }
        }
        string OrientationString
        {
            get
            {
                return (Orientation == CheckboxGroupOrientation.Vertical) ? "vertical" : "horizontal";
            }
        }
        #endregion

    }


}
