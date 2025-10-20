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
    public partial class WASelect : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public Expression<Func<string>> ValueExpression { get; set; } = default!;

        [CascadingParameter] private EditContext EditContext { get; set; } = default!;
        /// <summary>
        /// A custom label for assistive devices.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// The select's size.
        /// </summary>
        [Parameter]
        public SelectSize Size { get; set; } = SelectSize.Inherit;

        /// <summary>
        /// The input's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }
        /// <summary>
        /// Placeholder text to show as a hint when the select is empty.
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// Adds a clear button (with-clear) when the select is not empty.
        /// </summary>
        [Parameter]
        public bool Clearable { get; set; } = false;

        /// <summary>
        /// Ensures a child radio is checked before allowing the containing form to submit.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;
        /// <summary>
        /// The select's visual appearance.
        /// </summary>
        [Parameter]
        public SelectAppearance Appearance { get; set; } = SelectAppearance.Outlined;
        /// <summary>
        /// Disables the select control.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Draws a pill-style input with rounded edges.
        /// </summary>
        [Parameter]
        public bool Pill { get; set; } = false;

        /// <summary>
        /// The name of the icon to draw in the start slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? StartIconName { get; set; }

        /// <summary>
        /// The icon to draw in the start slot.
        /// </summary>
        [Parameter]
        public Icon? StartIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw in the end slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? EndIconName { get; set; }
        /// <summary>
        /// The icon to draw in the end slot.
        /// </summary>
        [Parameter]
        public Icon? EndIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw for the clear icon. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ClearIconName { get; set; }
        /// <summary>
        /// The icon to draw in the clear slot.
        /// </summary>
        [Parameter]
        public Icon? ClearIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw in the when the control is expanded and collapsed. Rotates on open and close. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ExpandIconName { get; set; }
        /// <summary>
        /// The icon to draw in the expand slot.
        /// </summary>
        [Parameter]
        public Icon? ExpandIcon { get; set; }

        /// <summary>
        /// The duration of the show animation.
        /// </summary>
        [Parameter]
        public string? ShowDuration { get; set; }

        /// <summary>
        /// The duration of the hide animation.
        /// </summary>
        [Parameter]
        public string? HideDuration { get; set; }
        #endregion

        #region Computed  Properties
        protected override string? StyleNames => BuildStyleNames(Style,
    ($"--show-duration: {ShowDuration}", !String.IsNullOrEmpty(ShowDuration)),
    ($"--hide-duration: {HideDuration}", !String.IsNullOrEmpty(HideDuration))
);

        string SizeString
        {
            get
            {
                return Size switch
                {
                    SelectSize.Small => "small",
                    SelectSize.Medium => "medium",
                    SelectSize.Large => "large",
                    SelectSize.Inherit => "inherit",
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
                    SelectAppearance.Filled => "filled",
                    SelectAppearance.Outlined => "outlined",
                    _ => "outlined"
                    //Only filled and outlined are valid for inputs
                };
            }
        }
        #endregion

        #region Lifecycle
        protected override void OnInitialized()
        {
            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= new Dictionary<string, object>();

            if(ValueExpression != null)
            {
                try
                {
                    fieldIdentifier = FieldIdentifier.Create(ValueExpression);
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine($"Invalid ValueExpression: {ex.Message}");
                }

            }

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && Value is not null)
                await JSRuntime.InvokeVoidAsync("window.vengage.select.initialize", Id, objRef, Value);
        }
        protected override async Task OnParametersSetAsync()
        {
            if (previousValue is null || !previousValue!.Equals(Value ?? default!))
            {
                previousValue = Value ?? default!;

                // Run your JS update logic here
                await JSRuntime.InvokeVoidAsync("window.vengage.select.setValue", Id, Value ?? default!);
            }
        }
        #endregion

        #region Event Handlers
        private async Task OnValueChanged(ChangeEventArgs e)
        {
            var value = e.Value != null ? e.Value!.ConvertTo<string>() : string.Empty;
            await ValueChanged.InvokeAsync(value);
            try
            {
                EditContext?.NotifyFieldChanged(fieldIdentifier);
            }
            catch (ArgumentException ex)
            {
                Console.Error.WriteLine($"Notify field error: {ex.Message}");
            }
            
        }

        [JSInvokable]
        public async Task HandleInputClear()
        {
            await ValueChanged.InvokeAsync(default!);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }



        #endregion

        #region State
        private FieldIdentifier fieldIdentifier = default!;
        private DotNetObjectReference<WASelect> objRef = default!;
        private string previousValue = default!;
        #endregion


    }


}
