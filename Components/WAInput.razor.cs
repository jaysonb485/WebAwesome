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
    public partial class WAInput : WAComponentBase
    {
        #region Parameters
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;
        /// <summary>
        /// The type of input.
        /// </summary>
        [Parameter]
        public InputType Type { get; set; } = InputType.Text;
        [Parameter]
        public string Value { get; set; } = default!;
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; } 

        [Parameter] public Expression<Func<string>> ValueExpression { get; set; } = default!;
        /// <summary>
        /// The input's visual appearance.
        /// </summary>
        [Parameter]
        public InputAppearance Appearance { get; set; } = InputAppearance.Outlined;
        /// <summary>
        /// The input's size.
        /// </summary>
        [Parameter]
        public InputSize Size { get; set; } = InputSize.Inherit;
        /// <summary>
        /// Draws a pill-style input with rounded edges.
        /// </summary>
        [Parameter]
        public bool Pill { get; set; } = false;

        /// <summary>
        /// The input's label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The input's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }

        /// <summary>
        /// Placeholder text to show as a hint when the input is empty.
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// Adds a clear button (with-clear) when the input is not empty.
        /// </summary>
        [Parameter]
        public bool Clearable { get; set; } = false;

        /// <summary>
        /// Makes the input readonly.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Makes the input disabled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Adds a button to toggle the password's visibility. Only applies to password types.
        /// </summary>
        [Parameter]
        public bool PasswordToggle { get; set; } = false;
        /// <summary>
        /// Makes the input a required field.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;

        /// <summary>
        /// An icon placed at the start of the input control.
        /// </summary>
        [Parameter]
        public string? StartIconName { get; set; }
        /// <summary>
        /// An icon placed at the start of the input control.
        /// </summary>
        [Parameter]
        public Icon? StartIcon { get; set; }
        /// <summary>
        /// An icon placed at the end of the input control.
        /// </summary>
        [Parameter]
        public string? EndIconName { get; set; }
        /// <summary>
        /// An icon placed at the end of the input control.
        /// </summary>
        [Parameter]
        public Icon? EndIcon { get; set; }

        /// <summary>
        /// Hides the browser's built-in increment/decrement spin buttons for number inputs. Defaults to false.
        /// </summary>
        [Parameter]
        public bool WithoutSpinButtons { get; set; } = false;
        #endregion

        #region Computed  Properties
        string InputTypeString
        {
            get
            {
                return Type switch
                {
                    InputType.Date => "date",
                    InputType.DateTimeLocal => "datetime-local",
                    InputType.Time => "time",
                    InputType.Telephone => "tel",
                    InputType.Number => "number",
                    InputType.Text => "text",
                    InputType.Url => "url",
                    InputType.Email => "email",
                    InputType.Search => "search",
                    InputType.Password => "password",
                    _ => "text"
                };
            }
        }
        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    InputAppearance.Filled => "filled",
                    InputAppearance.Outlined => "outlined",
                    _ => "outlined"
                    //Only filled and outlined are valid for inputs
                };
            }
        }

        string SizeString
        {
            get
            {
                return Size switch
                {
                    InputSize.Small => "small",
                    InputSize.Medium => "medium",
                    InputSize.Large => "large",
                    InputSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }
        #endregion

        #region Lifecycle
        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    // if (IsRenderComplete)
                    // await JSRuntime.InvokeVoidAsync("window.blazorBootstrap.modal.dispose", Id);
                }
                catch (JSDisconnectedException)
                {
                    // do nothing
                }

                objRef?.Dispose();


            }

            await base.DisposeAsyncCore(disposing);
        }

        protected override void OnInitialized()
        {
            objRef ??= DotNetObjectReference.Create(this);
            AdditionalAttributes ??= new Dictionary<string, object>();
    
            if (ValueExpression != null)
                fieldIdentifier = FieldIdentifier.Create(ValueExpression);

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool FirstRender)
        {
            if (FirstRender)
                await JSRuntime.InvokeVoidAsync("window.vengage.input.initialize", Id, objRef, Value);
        }

        protected override async Task OnParametersSetAsync()
        {
            if (!previousValue!.Equals(Value ?? string.Empty))
            {
                previousValue = Value ?? string.Empty;

                // Run your JS update logic here
                await JSRuntime.InvokeVoidAsync("window.vengage.input.setValue", Id, Value);
            }
        }

        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleInputClear()
        {
            await ValueChanged.InvokeAsync(string.Empty);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        [JSInvokable]
        public async Task HandleInputChange(string value)
        {
            await ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }
        #endregion

        #region State
        private DotNetObjectReference<WAInput> objRef = default!;
        private FieldIdentifier fieldIdentifier = default!;
           private string previousValue = string.Empty;
        #endregion

        #region Private Methods

        private async Task OnValueChanged(ChangeEventArgs e)
        {

            //await JSRuntime.InvokeVoidAsync("window.vengage.input.setValue", Id, e.Value);

            //await ValueChanged.InvokeAsync((string?)e.Value ?? string.Empty);
            //EditContext?.NotifyFieldChanged(fieldIdentifier);
            await SetValue((string)(e.Value ?? string.Empty));
        }
        #endregion
        #region Public Methods
        public async Task SetValue(string value)
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.input.setValue", Id, value);
            await ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }
        #endregion

    }


}
