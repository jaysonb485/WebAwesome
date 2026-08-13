using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Linq.Expressions;

namespace WebAwesomeBlazor.Components
{
    public partial class WAOTPInput : WAComponentBase
    {
        #region Parameters
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;
        [Parameter]
        public string Value { get; set; } = default!;
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        [Parameter] public Expression<Func<string>> ValueExpression { get; set; } = default!;
        /// <summary>
        /// Allowed character class.
        /// </summary>
        [Parameter]
        public OtpAllowedCharacters AllowedCharacters { get; set; } = OtpAllowedCharacters.Numeric;

        /// <summary>
        /// Visual appearance of the segments.
        /// </summary>
        [Parameter]
        public OtpAppearance Appearance { get; set; } = OtpAppearance.Outlined;
        /// <summary>
        /// Indicates that the input should receive focus on page load.
        /// </summary>
        [Parameter]
        public bool Autofocus { get; set; } = false;

        /// <summary>
        /// Specifies what permission the browser has to provide assistance in filling out form field values. Refer to this page on MDN for available values.
        /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete"/>
        /// </summary>
        [Parameter]
        public string? Autocomplete { get; set; }

        /// <summary>
        /// When true, the form is submitted automatically once all segments are filled.
        /// </summary>
        [Parameter]
        public bool AutoSubmit { get; set; } = false;

        /// <summary>
        /// Case transformation applied to entered characters.
        /// </summary>
        [Parameter]
        public OtpCaseTransformation CaseTransformation { get; set; } = OtpCaseTransformation.Preserve;
        /// <summary>
        /// Makes the input disabled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Segment format string using # as a segment placeholder and any other character as a literal separator. Setting format overrides length (the segment count is derived from the number of # characters).
        /// </summary>
        [Parameter]
        public string? SegmentFormat { get; set; }

        /// <summary>
        /// The input's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }
        /// <summary>
        /// The input's label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// Number of character segments to display. Overridden by SegmentFormat when set.
        /// </summary>
        [Parameter]
        public int Length { get; set; } = 6;
        /// <summary>
        /// When true, entered characters are displayed as MaskCharacter instead of their real value.
        /// </summary>
        [Parameter]
        public bool Mask { get; set; } = false;
        /// <summary>
        /// Makes the input readonly.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;
        /// <summary>
        /// Makes the input a required field.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;

        /// <summary>
        /// The input's size.
        /// </summary>
        [Parameter]
        public OtpSize Size { get; set; } = OtpSize.Medium;

        /// <summary>
        /// Character shown in place of entered values when mask is set, and as a hint in empty segments when ShowEmptyMask is set.
        /// </summary>
        [Parameter]
        public string MaskCharacter { get; set; } = "•";

        /// <summary>
        /// When true, empty segments show MaskCharacter as a hint instead of appearing blank, similar to how a password field communicates its expected length before anything is typed.
        /// </summary>
        [Parameter]
        public bool ShowEmptyMask { get; set; } = false;

        /// <summary>
        /// Triggered when the input is completed (all segments filled). The value is the concatenated string of all segments.
        /// </summary>
        [Parameter]
        public EventCallback<string> OTPCompleted { get; set; }

        #endregion

        #region Computed  Properties

        string AllowedCharactersString
        {
            get
            {
                return AllowedCharacters switch
                {
                    OtpAllowedCharacters.Numeric => "numeric",
                    OtpAllowedCharacters.Alpha => "alpha",
                    OtpAllowedCharacters.Alphanumeric => "alphanumeric",
                    _ => "numeric"
                };
            }
        }

        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    OtpAppearance.Filled => "filled",
                    OtpAppearance.Outlined => "outlined",
                    OtpAppearance.FilledOutlined => "filled-outlined",
                    OtpAppearance.Contained => "contained",
                    _ => "outlined"
                };
            }
        }

        string CaseTransformationString
        {
            get
            {
                return CaseTransformation switch
                {
                    OtpCaseTransformation.Upper => "upper",
                    OtpCaseTransformation.Lower => "lower",
                    OtpCaseTransformation.Preserve => "preserve",
                    _ => "preserve"
                };
            }
        }

        string SizeString
        {
            get
            {
                return Size switch
                {
                    OtpSize.XSmall => "xs",
                    OtpSize.Small => "s",
                    OtpSize.Medium => "m",
                    OtpSize.Large => "l",
                    OtpSize.XLarge => "xl",
                    _ => "m"
                };
            }
        }

        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--mask-char: '{MaskCharacter}'", !String.IsNullOrEmpty(MaskCharacter.ToString())));

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
                }
                catch (JSDisconnectedException)
                {
                }

                objRef?.Dispose();

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
                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Id!, objRef, Value);

            }
        }

        protected override async Task OnParametersSetAsync()
        {
            if (!previousValue!.Equals(Value ?? string.Empty))
            {
                previousValue = Value ?? string.Empty;

                // Run your JS update logic here
                await SafeInvokeVoidAsync("setValue", Id!, Value!);
            }
        }

        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleOTPComplete(string value)
        {
            if (OTPCompleted.HasDelegate)
                await OTPCompleted.InvokeAsync(value);
        }

        [JSInvokable]
        public async Task HandleInputChange(string value)
        {
            await ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }
        #endregion

        #region State
        private DotNetObjectReference<WAOTPInput> objRef = default!;
        private FieldIdentifier fieldIdentifier = default!;
        private string previousValue = string.Empty;
        #endregion

        #region Private Methods

        private async Task OnValueChanged(ChangeEventArgs e)
        {

            await SetValueAsync((string)(e.Value ?? string.Empty));
        }
        #endregion
        #region Public Methods
        public async Task SetValueAsync(string value)
        {
            await SafeInvokeVoidAsync("setValue", Id!, value);
            await ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        public void SetValue(string value) => _ = SetValueAsync(value);

        public async Task SetFocusAsync()
        {
            await SafeInvokeVoidAsync("setFocus", Id!);
        }

        public void SetFocus() => _ = SetFocusAsync();

        #endregion

    }


}
