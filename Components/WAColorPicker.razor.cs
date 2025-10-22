using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WAColorPicker : WAComponentBase
    {
        #region Parameters
        [Parameter] public Expression<Func<string>> ValueExpression { get; set; } = default!;
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;
        [Parameter]
        public string? Value { get; set; }

        [Parameter]
        public EventCallback<string?> ValueChanged { get; set; } = default!;
        /// <summary>
        /// The color picker's label.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// The color picker's hint.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }

        /// <summary>
        /// The format to use. If opacity is enabled, these will translate to HEXA, RGBA, HSLA, and HSVA respectively. The color picker will accept user input in any format (including CSS color names) and convert it to the desired format.
        /// </summary>
        [Parameter]
        public PickerColorFormat ColorFormat { get; set; } = PickerColorFormat.Hex;
        /// <summary>
        /// Determines the size of the color picker's trigger
        /// </summary>
        [Parameter]
        public PickerSize Size { get; set; } = PickerSize.Inherit;

        /// <summary>
        /// Shows the button that lets users toggle between formats. Default is true.
        /// </summary>
        [Parameter]
        public bool AllowFormatSelector { get; set; } = true;

        /// <summary>
        /// Disables the color picker.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Shows the opacity slider. Enabling this will cause the formatted value to be HEXA, RGBA, or HSLA.
        /// </summary>
        [Parameter]
        public bool ShowOpacitySlider { get; set; } = false;

        /// <summary>
        /// By default, values are lowercase. With this attribute, values will be uppercase instead.
        /// </summary>
        [Parameter]
        public bool UppercaseValues { get; set; } = false;

        /// <summary>
        /// One or more predefined color swatches to display as presets in the color picker. Can include any format the color picker can parse, including HEX(A), RGB(A), HSL(A), HSV(A), and CSS color names. Each color must be separated by a semicolon (;).
        /// </summary>
        [Parameter]
        public string? Swatches { get; set; }
        #endregion

        #region Computed Properties
        string ColorFormatString
        {
            get
            {
                return ColorFormat switch
                {
                    PickerColorFormat.Hex => "hex",
                    PickerColorFormat.HSL => "hsl",
                    PickerColorFormat.RGB => "rgb",
                    PickerColorFormat.HSV => "hsv",
                    _ => "hex"
                };
            }
        }

        string SizeString
        {
            get
            {
                return Size switch
                {
                    PickerSize.Small => "small",
                    PickerSize.Medium => "medium",
                    PickerSize.Large => "large",
                    PickerSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }
        #endregion

        #region Lifecycle
        protected override void OnInitialized()
        {
            AdditionalAttributes ??= new Dictionary<string, object>();

            fieldIdentifier = FieldIdentifier.Create(ValueExpression);

            base.OnInitialized();
        }
        #endregion

        #region State
        private FieldIdentifier fieldIdentifier = default!;
        #endregion

        #region Private Methods
        private async Task OnChange(ChangeEventArgs e)
        {
            await ValueChanged.InvokeAsync((string?)e.Value ?? string.Empty);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Returns the current value as a string in the specified format.
        /// </summary>
        /// <param name="colorFormat">The format to convert to</param>
        /// <returns></returns>
        public async Task<string> GetFormattedValueAsync(PickerColorExtendedFormat colorFormat)
        {
            var result =
                await JSRuntime.InvokeAsync<string>("window.vengage.colorPicker.getFormattedValue",
                    Id, colorFormat.ToString().ToLower()
                );

            return result;
        }
        #endregion
    }
}
