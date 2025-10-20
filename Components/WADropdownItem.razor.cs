using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WADropdownItem : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Additional content or details to display after the label.
        /// </summary>
        [Parameter]
        public RenderFragment? DetailsContent { get; set; }
        /// <summary>
        /// If true, the menu item is rendered as a submenu item.
        /// </summary>
        [Parameter]
        public bool IsSubMenu { get; set; } = false;
        /// <summary>
        /// An optional value for the menu item. 
        /// </summary>
        [Parameter]
        public string? Value { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Parameter]
        public DropdownItemVariant Variant { get; set; } = DropdownItemVariant.Default;

        /// <summary>
        /// Adds the disabled attribute to disable the menu item so it cannot be selected.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The text to display on the menu item
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// Adds a loading spinner to indicate that a menu item is busy. Like a disabled menu item, clicks will be suppressed until the loading state is removed.
        /// </summary>
        [Parameter]
        public bool Loading { get; set; } = false;

        /// <summary>
        /// Indicates the menu item can be checked. To use Checked, this value must be true.
        /// </summary>
        [Parameter]
        public bool IsCheckbox { get; set; } = false;

        /// <summary>
        /// Draws the item in a checked state.
        /// </summary>
        [Parameter]
        public bool Checked { get; set; } = false;

        [Parameter]
        public EventCallback<bool> CheckedChanged { get; set; } = default!;

        [Parameter]
        public EventCallback<MouseEventArgs?> OnClick { get; set; }

        /// <summary>
        /// Whether the submenu is currently open.
        /// </summary>
        [Parameter]
        public bool SubmenuOpen { get; set; } = false;

        /// <summary>
        /// An optional icon to display before the label.
        /// </summary>
        [Parameter]
        public string? IconName { get; set; }
        /// <summary>
        /// An optional icon to display before the label.
        /// </summary>
        [Parameter]
        public Icon? Icon { get; set; }
        #endregion

        #region Computed  Properties
        string VariantString
        {
            get
            {
                return Variant switch
                {
                    DropdownItemVariant.Default => "default",
                    DropdownItemVariant.Danger => "danger",
                    _ => "default"
                };
            }
        }
        #endregion
        
        #region Private Methods
        private async Task Clicked(MouseEventArgs e)
        {
            if (IsCheckbox)
            {
                await CheckedChanged.InvokeAsync(!Checked);
                return;
            }
            await OnClick.InvokeAsync();
            //EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        private async Task OnChange(ChangeEventArgs e)
        {
            var oldValue = Checked;
            var newValue = e.Value is not null && (bool)e.Value;

            await CheckedChanged.InvokeAsync(newValue);

            //EditContext?.NotifyFieldChanged(fieldIdentifier);
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
