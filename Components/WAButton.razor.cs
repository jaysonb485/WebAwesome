using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WAButton : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The button's label.
        /// </summary>
        [Parameter]
        public string? Text { get; set; }

        /// <summary>
        /// The button's theme variant. Defaults to neutral if not within another element with a variant.
        /// </summary>
        [Parameter]
        public ButtonVariant Variant { get; set; } = ButtonVariant.Inherit;

        /// <summary>
        /// The button's visual appearance.
        /// </summary>
        [Parameter]
        public ButtonAppearance Appearance { get; set; } = ButtonAppearance.Accent;
        /// <summary>
        /// The button's size.
        /// </summary>
        [Parameter]
        public ButtonSize Size { get; set; } = ButtonSize.Medium;
        /// <summary>
        /// Draws the button with a caret (with-caret). Used to indicate that the button triggers a dropdown menu or similar behavior.
        /// </summary>
        [Parameter]
        public bool Caret { get; set; } = false;

        /// <summary>
        /// Disables the button. Does not apply to link buttons.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Draws the button in a loading state.
        /// </summary>
        [Parameter]
        public bool Loading { get; set; } = false;

        /// <summary>
        /// Draws a pill-style button with rounded edges.
        /// </summary>
        [Parameter]
        public bool Pill { get; set; } = false;

        /// <summary>
        /// The type of button. When the type is submit, the button will submit the surrounding form.
        /// </summary>
        [Parameter]
        public ButtonType Type { get; set; } = ButtonType.Button;


        [Parameter]
        public EventCallback<MouseEventArgs?> OnClick { get; set; }

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

        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    ButtonAppearance.Accent => "accent",
                    ButtonAppearance.Filled => "filled",
                    ButtonAppearance.Outlined => "outlined",
                    ButtonAppearance.OutlinedFilled => "outlined filled",
                    ButtonAppearance.Plain => "plain",
                    _ => "accent"
                };
            }
        }

        string SizeString
        {
            get
            {
                return Size switch
                {
                    ButtonSize.Small => "small",
                    ButtonSize.Medium => "medium",
                    ButtonSize.Large => "large",
                    ButtonSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }


        string ButtonTypeString
        {
            get
            {
                return Type switch
                {
                    ButtonType.Button => "button",
                    ButtonType.Submit => "submit",
                    ButtonType.Reset => "reset",
                    _ => "button"
                };
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Turn off or on the loading indicator.
        /// </summary>
        /// <param name="LoadingState">Set to true to show the loading indicator.</param>
        public void SetLoading(bool LoadingState)
        {
            Loading = LoadingState;
            StateHasChanged();
        }

        /// <summary>
        /// Turn off or on the loading indicator.
        /// </summary>
        /// <param name="LoadingState">Set to true to show the loading indicator.</param>
        public async Task SetLoadingAsync(bool LoadingState)
        {
            Loading = LoadingState;
            await InvokeAsync(StateHasChanged);
        }
        #endregion


    }

}
