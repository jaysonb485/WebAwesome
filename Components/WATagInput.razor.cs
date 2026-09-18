using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Linq.Expressions;

namespace WebAwesomeBlazor.Components
{
    public partial class WATagInput : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The current value of the input
        /// </summary>
        [Parameter]
        public string[]? Value { get; set; }
        [Parameter] public Expression<Func<string[]?>> ValueExpression { get; set; } = default!;
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;

        [Parameter]
        public EventCallback<string[]?> ValueChanged { get; set; } = default!;

        /// <summary>
        /// Allows the same tag to be added more than once. By default, duplicates are ignored.
        /// </summary>
        [Parameter]
        public bool AllowDuplicates { get; set; } = false;

        /// <summary>
        /// The tag input's visual appearance.
        /// </summary>
        [Parameter]
        public TagInputAppearance Appearance { get; set; } = TagInputAppearance.Outlined;

        /// <summary>
        /// Controls whether and how text input is automatically capitalized as it is entered by the user.
        /// </summary>
        [Parameter]
        public TagInputAutoCapitalize? AutoCapitalize { get; set; }

        /// <summary>
        /// Specifies what permission the browser has to provide assistance in filling out form field values. Refer to this page on MDN for available values.
        /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete"/>
        /// </summary>
        [Parameter]
        public string? Autocomplete { get; set; }
        /// <summary>
        /// Indicates whether the browser's autocorrect feature is on or off.
        /// </summary>
        [Parameter]
        public bool AutoCorrectEnabled { get; set; } = true;
        /// <summary>
        /// Adds a clear button (with-clear) when the input is not empty.
        /// </summary>
        [Parameter]
        public bool Clearable { get; set; } = false;

        /// <summary>
        /// The characters that turn typed text into a tag. Each character is a separate delimiter, so ",;" accepts both commas and semicolons. Empty string for enter.
        /// </summary>
        [Parameter]
        public string? Delimiter { get; set; } = "";

        /// <summary>
        /// Disables the tag input.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The tag input's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }

        /// <summary>
        /// The tag input's label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// The maximum number of tags that can be added. Once reached, no more tags can be added until one is removed.
        /// </summary>
        [Parameter]
        public int? MaxTags { get; set; }
        /// <summary>
        /// The minimum number of tags required for the control to be valid. Has no effect when there are no tags.
        /// </summary>
        [Parameter]
        public int? MinTags { get; set; }

        /// <summary>
        /// Draws a pill-style tag input, and pill-style tags, with rounded edges.
        /// </summary>
        [Parameter]
        public bool Pill { get; set; } = false;

        /// <summary>
        /// Placeholder text to show as a hint when the tag input is empty. Hidden once the maximum number of tags is reached.
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// Makes the tag input readonly.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Makes the tag input a required field.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;


        /// <summary>
        /// The tag input's size.
        /// </summary>
        [Parameter]
        public TagInputSize Size { get; set; } = TagInputSize.Medium;

        /// <summary>
        /// Enables spell checking on the tag input.
        /// </summary>
        [Parameter]
        public bool Spellcheck { get; set; } = true;

        //[Parameter]
        //public EventCallback<InputTagCreatingEventArgs> TagCreating { get; set; } = default!;
        //[Parameter]
        //public Func<string, Task<bool>>? TagCreatingFunc { get; set; } = null;


        [Parameter]
        public EventCallback Focused { get; set; }
        [Parameter]
        public EventCallback Blurred { get; set; }
        #endregion

        #region Computed  Properties
        private string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    TagInputAppearance.Filled => "filled",
                    TagInputAppearance.Outlined => "outlined",
                    TagInputAppearance.FilledOutlined => "filled-outlined",
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
                    TagInputSize.XSmall => "xs",
                    TagInputSize.Small => "s",
                    TagInputSize.Medium => "m",
                    TagInputSize.Large => "l",
                    TagInputSize.XLarge => "xl",
                    _ => "m"
                };
            }
        }


        private string AutoCapitalizeString
        {
            get
            {
                return AutoCapitalize switch
                {
                    TagInputAutoCapitalize.Off => "off",
                    TagInputAutoCapitalize.On => "on",
                    TagInputAutoCapitalize.None => "none",
                    TagInputAutoCapitalize.Sentences => "sentences",
                    TagInputAutoCapitalize.Words => "words",
                    TagInputAutoCapitalize.Characters => "characters",
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
                    if (_instance is not null)
                        await _instance.InvokeVoidAsync("dispose");

                    objRef?.Dispose();
                }
                catch (JSDisconnectedException)
                {
                }
            }

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
            {
                await LoadModuleAsync();
                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Id!, objRef, Value!);
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            if (!previousValue!.Equals(Value ?? []))
            {
                previousValue = Value ?? [];

                // Run your JS update logic here
                await LoadModuleAsync();
                await SafeInvokeVoidAsync("setValue", Id!, Value!);
            }
        }

        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleInputChange(string[] value)
        {
            await ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }
        [JSInvokable]
        public async Task HandleInputFocus()
        {
            await Focused.InvokeAsync();
        }

        [JSInvokable]
        public async Task HandleInputBlur()
        {
            await Blurred.InvokeAsync();
        }

        ///// <summary>
        ///// Captures when the remove button is pressed
        ///// </summary>
        //[JSInvokable]
        //public async Task<bool> HandleTagCreating(string tag)
        //{
        //    if (TagCreatingFunc != null)
        //    {
        //        return await TagCreatingFunc(tag);
        //    }

        //    return false;

        //    //var args = new InputTagCreatingEventArgs
        //    //{
        //    //    Tag = tag
        //    //};
        //    //await TagCreating.InvokeAsync(args);

        //    //return args.Cancel;
        //}
        #endregion

        #region State
        private DotNetObjectReference<WATagInput> objRef = default!;
        private FieldIdentifier fieldIdentifier = default!;
        private string[] previousValue = [];
        #endregion

        #region Private Methods

        private async Task OnValueChanged(ChangeEventArgs e)
        {
            await SetValueAsync((string[]?)e.Value ?? []);
        }
        #endregion

        #region Public Methods
        public async Task SetValueAsync(string[] value)
        {
            await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
            await SafeInvokeVoidAsync("setValue", Id!, value!);
            await ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        public void SetValue(string[] value) => _ = SetValueAsync(value);
        #endregion

    }


}
