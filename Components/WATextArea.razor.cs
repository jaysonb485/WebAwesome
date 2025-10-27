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
    public partial class WATextArea : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The current value of the input
        /// </summary>
        [Parameter]
        public string? Value { get; set; }
        [Parameter] public Expression<Func<string>> ValueExpression { get; set; } = default!;
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;

        [Parameter]
        public EventCallback<string?> ValueChanged { get; set; } = default!;

        /// <summary>
        /// The number of rows to display by default.
        /// </summary>
        [Parameter]
        public int? Rows { get; set; } = 4;

        /// <summary>
        /// The textarea's visual appearance.
        /// </summary>
        [Parameter]
        public TextAreaAppearance Appearance { get; set; } = TextAreaAppearance.Outlined;
        /// <summary>
        /// The textarea's size.
        /// </summary>
        [Parameter]
        public TextAreaSize Size { get; set; } = TextAreaSize.Inherit;
        /// <summary>
        /// The textarea's label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The textarea's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }

        /// <summary>
        /// Placeholder text to show as a hint when the textarea is empty.
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// Makes the textarea readonly.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Disables the textarea.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;


        /// <summary>
        /// Makes the textarea a required field.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;

        /// <summary>
        /// Controls how the textarea can be resized. Defaults to vertical.
        /// </summary>
        [Parameter]
        public TextAreaResize ResizeMode { get; set; } = TextAreaResize.Vertical;

        /// <summary>
        /// Indicates whether the browser's autocorrect feature is on or off.
        /// </summary>
        [Parameter]
        public bool AutoCorrectEnabled { get; set; } = true;

        /// <summary>
        /// Enables spell checking on the textarea.
        /// </summary>
        [Parameter]
        public bool Spellcheck { get; set; } = true;

        /// <summary>
        /// Controls whether and how text input is automatically capitalized as it is entered by the user.
        /// </summary>
        [Parameter]
        public TextAreaAutoCapitalize? AutoCapitalize { get; set; }
        #endregion

        #region Computed  Properties
        private string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    TextAreaAppearance.Filled => "filled",
                    TextAreaAppearance.Outlined => "outlined",
                    _ => "outlined"
                    //Only filled and outlined are valid for inputs
                };
            }
        }

        private string SizeString
        {
            get
            {
                return Size switch
                {
                    TextAreaSize.Small => "small",
                    TextAreaSize.Medium => "medium",
                    TextAreaSize.Large => "large",
                    TextAreaSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }


        private string ResizeString
        {
            get
            {
                return ResizeMode switch
                {
                    TextAreaResize.None => "none",
                    TextAreaResize.Vertical => "vertical",
                    TextAreaResize.Horizontal => "horizontal",
                    TextAreaResize.Both => "both",
                    TextAreaResize.Auto => "auto",
                    _ => "vertical"
                };
            }
        }

        private string AutoCapitalizeString
        {
            get
            {
                return AutoCapitalize switch
                {
                     TextAreaAutoCapitalize.Off => "off",
                     TextAreaAutoCapitalize.On => "on",
                     TextAreaAutoCapitalize.None => "none",
                     TextAreaAutoCapitalize.Sentences => "sentences",
                     TextAreaAutoCapitalize.Words => "words",
                     TextAreaAutoCapitalize.Characters => "characters",
                     _ => ""
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
        public async Task HandleInputChange(string value)
        {
            await ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }
        #endregion

        #region State
        private DotNetObjectReference<WATextArea> objRef = default!;
        private FieldIdentifier fieldIdentifier = default!;
        private string previousValue = string.Empty;
        #endregion

        #region Private Methods

        private async Task OnValueChanged(ChangeEventArgs e)
        {

            //await JSRuntime.InvokeVoidAsync("window.vengage.input.setValue", Id, e.Value);

            //await ValueChanged.InvokeAsync((string?)e.Value ?? string.Empty);
            //EditContext?.NotifyFieldChanged(fieldIdentifier);
            await SetValueAsync((string)(e.Value ?? string.Empty));
        }
        #endregion

        #region Public Methods
        public async Task SetValueAsync(string value)
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.input.setValue", Id, value);
            await ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }
        #endregion

    }


}
