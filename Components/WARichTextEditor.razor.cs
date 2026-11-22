using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Linq.Expressions;

namespace WebAwesomeBlazor.Components
{
    public partial class WARichTextEditor : WAComponentBase
    {
        #region Parameters
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;
        /// <summary>
        /// The value of the editor
        /// </summary>
        [Parameter]
        public string Value { get; set; } = default!;
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        [Parameter] public Expression<Func<string>> ValueExpression { get; set; } = default!;

        /// <summary>
        /// The plain text value of the editor
        /// </summary>
        [Parameter]
        public string PlainTextValue { get; set; } = default!;
        [Parameter]
        public EventCallback<string> PlainTextValueChanged { get; set; }
        [Parameter]
        public Expression<Func<string>> PlainTextValueExpression { get; set; } = default!;

        /// <summary>
        /// Invoked when the editor value has changed and committed.
        /// </summary>
        [Parameter]
        public EventCallback<string> Changed { get; set; }

        /// <summary>
        /// The editor's visual appearance.
        /// </summary>
        [Parameter]
        public InputAppearance Appearance { get; set; } = InputAppearance.Outlined;


        /// <summary>
        /// Controls whether and how text input is automatically capitalized as it is entered/edited by the user.
        /// </summary>
        [Parameter]
        public InputAutoCapitalize? AutoCapitalize { get; set; }

        /// <summary>
        /// Indicates whether the browser's autocorrect feature is on or off. 
        /// </summary>
        [Parameter]
        public bool AutoCorrect { get; set; } = true;

        /// <summary>
        /// Makes the editor disabled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Used to customize the label or icon of the Enter key on virtual keyboards.
        /// </summary>
        [Parameter]
        public InputEnterKeyHint? EnterKeyHint { get; set; } = InputEnterKeyHint.Enter;

        /// <summary>
        /// The editor's size.
        /// </summary>
        [Parameter]
        public InputSize Size { get; set; } = InputSize.Inherit;

        /// <summary>
        /// The editor's label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The editor's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }

        /// <summary>
        /// Placeholder text to show as a hint when the editor is empty.
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }


        /// <summary>
        /// Makes the editor readonly.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Makes the editor a required field.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;

        /// <summary>
        /// Tells the browser what type of data will be entered by the user, allowing it to display the appropriate virtual keyboard on supportive devices.
        /// </summary>
        [Parameter]
        public InputInputMode InputMode { get; set; } = InputInputMode.Text;

        /// <summary>
        /// Enables spell checking on the editor.
        /// </summary>
        [Parameter]
        public bool Spellcheck { get; set; } = false;
        /// <summary>
        /// Invoked when the editor receives focus.
        /// </summary>
        [Parameter]
        public EventCallback Focused { get; set; }
        /// <summary>
        /// Invoked when the editor loses focus.
        /// </summary>
        [Parameter]
        public EventCallback Blurred { get; set; }

        /// <summary>
        /// Invoked when there is an error retrieving a suggestion list.
        /// </summary>
        [Parameter]
        public EventCallback<RichTextEditorSuggestionError> SuggestionError { get; set; }

        /// <summary>
        /// Invoked when the selected text in the editor has changed.
        /// </summary>
        [Parameter]
        public EventCallback SelectionChanged { get; set; }


        #endregion

        #region Computed  Properties

        string AppearanceString => Appearance switch
        {
            InputAppearance.Filled => "filled",
            InputAppearance.Outlined => "outlined",
            InputAppearance.FilledOutlined => "filled-outlined",
            _ => "outlined"
            //Only filled and outlined are valid for inputs
        };

        string SizeString => Size switch
        {
            InputSize.XSmall => "xs",
            InputSize.Small => "s",
            InputSize.Medium => "m",
            InputSize.Large => "l",
            InputSize.XLarge => "xl",
            InputSize.Inherit => "inherit",
            _ => "m"
        };


        string AutoCapitaliseString => AutoCapitalize switch
        {
            InputAutoCapitalize.Off => "off",
            InputAutoCapitalize.None => "none",
            InputAutoCapitalize.On => "on",
            InputAutoCapitalize.Sentences => "sentences",
            InputAutoCapitalize.Words => "words",
            InputAutoCapitalize.Characters => "characters",
            _ => ""
        };

        string EnterKeyHintString => EnterKeyHint switch
        {
            InputEnterKeyHint.Next => "next",
            InputEnterKeyHint.Done => "done",
            InputEnterKeyHint.Enter => "enter",
            InputEnterKeyHint.Go => "go",
            InputEnterKeyHint.Previous => "previous",
            InputEnterKeyHint.Search => "search",
            InputEnterKeyHint.Send => "send",
            null => "",
            _ => "",
        };

        string InputModeString => InputMode switch
        {
            InputInputMode.None => "none",
            InputInputMode.Text => "text",
            InputInputMode.Decimal => "decimal",
            InputInputMode.Numeric => "numeric",
            InputInputMode.Telephone => "tel",
            InputInputMode.Search => "search",
            InputInputMode.Email => "email",
            InputInputMode.Url => "url",
            _ => "text"
        };
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
                //await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WAInput.razor.js");
                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Id!, objRef, Value);

            }



        }

        protected override async Task OnParametersSetAsync()
        {
            if (!previousValue!.Equals(Value ?? string.Empty))
            {
                previousValue = Value ?? string.Empty;

                //set the formatted value and update the plaintext
                var plainTextValue = await SafeInvokeAsync<string>("setValue", Id!, Value!);
                await PlainTextValueChanged.InvokeAsync(plainTextValue);
            }

        }

        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleInputClear()
        {
            await ValueChanged.InvokeAsync(string.Empty);
            await PlainTextValueChanged.InvokeAsync(string.Empty);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        [JSInvokable]
        public async Task HandleInputInput(string value, string plainTextValue)
        {
            Console.WriteLine($"HandleInputInput. value: {value}, plaintext: {plainTextValue}");

            await ValueChanged.InvokeAsync(value);
            await PlainTextValueChanged.InvokeAsync(plainTextValue);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        [JSInvokable]
        public async Task HandleInputChange(string value, string plainTextValue)
        {
            Console.WriteLine($"HandleInputChange. value: {value}, plaintext: {plainTextValue}");
            await Changed.InvokeAsync(value);
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

        [JSInvokable]
        public async Task<List<RichTextEditorSuggestionItem>> GetSuggestions(string trigger, string query)
        {
            var suggestion = suggestions.SingleOrDefault(s => s.Trigger == trigger) ?? throw new("Suggestion trigger not found");
            var suggestionList = await suggestion.InvokeAsync(query);
            return suggestionList;
        }

        [JSInvokable]
        public async Task HandleSuggestionError(RichTextEditorSuggestionError error)
        {
            Console.WriteLine($"Suggestion error: {error.ErrorMessage}. Request: {error.Trigger} : {error.Query}");
        }

        [JSInvokable]
        public async Task HandleSelectionChange()
        {
            await SelectionChanged.InvokeAsync();
        }

        #endregion

        #region State
        private DotNetObjectReference<WARichTextEditor> objRef = default!;
        private FieldIdentifier fieldIdentifier = default!;
        private string previousValue = string.Empty;

        private List<RichTextEditorSuggestion> suggestions { get; set; } = new();

        private bool ColorUpdateRequired { get; set; } = false;
        private object? textColor;
        private object? highlightColor;
        private RichTextEditorOptions Options { get; set; } = new RichTextEditorOptions();

        #endregion

        #region Private Methods

        private async Task OnValueChanged(ChangeEventArgs e)
        {

            await SetValueAsync((string)(e.Value ?? string.Empty));
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Set the value of the editor
        /// </summary>
        /// <param name="value">The value to set</param>
        public async Task SetValueAsync(string value)
        {
            var plainText = await SafeInvokeAsync<string>("setValue", Element, value);
            await ValueChanged.InvokeAsync(value);
            await PlainTextValueChanged.InvokeAsync(plainText);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        public void SetValue(string value)
        {
            _ = SetValueAsync(value);
        }

        /// <summary>
        /// Sets focus to the editor
        /// </summary>
        public async Task SetFocusAsync()
        {
            await SafeInvokeVoidAsync("setFocus", Id!);
        }

        public void SetFocus()
        {
            _ = SetFocusAsync();
        }

        /// <summary>
        /// Registers a new suggestion trigger and callback source for features such as mentions, tags, or custom autocomplete providers.
        /// </summary>
        /// <param name="suggestion">The suggestion configuration</param>
        public async Task AddSuggestionAsync(RichTextEditorSuggestion suggestion)
        {
            suggestions ??= [];

            if (suggestions.SingleOrDefault(s => s.Trigger == suggestion.Trigger) is not null) return;


            suggestions.Add(suggestion);
            await SafeInvokeVoidAsync("addSuggestion", Element, objRef, suggestion);

        }
        /// <summary>
        /// Replaces the selection with plain text
        /// </summary>
        /// <param name="text">The text to insert</param>
        public async Task InsertTextAsync(string text)
        {
            await SafeInvokeVoidAsync("insertText", Element, text);
        }

        public void InsertText(string text)
        {
            _ = InsertTextAsync(text);
        }

        /// <summary>
        /// Replaces the selection with HTML. Markup the editor doesn't support is stripped
        /// </summary>
        /// <param name="html">The HTML string to insert</param>
        public async Task InsertHtmlAsync(string html)
        {
            await SafeInvokeVoidAsync("insertHtml", Element, html);
        }

        public void InsertHtml(string html)
        {
            _ = InsertHtmlAsync(html);
        }
        /// <summary>
        /// Undoes the last edit and returns whether there was one
        /// </summary>
        /// <returns>True, if the undo was successful</returns>
        public async Task<bool> UndoAsync()
        {
            return await SafeInvokeAsync<bool>("undo", Element);
        }

        /// <summary>
        /// Redoes the last edit and returns whether there was one
        /// </summary>
        /// <returns>True, if the redo was successful</returns>
        public async Task<bool> RedoAsync()
        {
            return await SafeInvokeAsync<bool>("redo", Element);
        }

        /// <summary>
        /// Selects all of the content. Does nothing while the editor is disabled
        /// </summary>
        public async Task SelectAllAsync()
        {
            await SafeInvokeVoidAsync("selectAll", Element);
        }

        public void SelectAll()
        {
            _ = SelectAllAsync();
        }

        /// <summary>
        /// Gets the selected text
        /// </summary>
        /// <returns>The selected text</returns>
        public async Task<string> GetSelectedTextAsync()
        {
            return await SafeInvokeAsync<string>("selectedText", Element);
        }

        /// <summary>
        /// Deletes the selected text
        /// </summary>
        public async Task DeleteSelectedTextAsync()
        {
            await SafeInvokeVoidAsync("deleteSelection", Element);
        }

        public void DeleteSelectedText()
        {
            _ = DeleteSelectedTextAsync();
        }

        /// <summary>
        /// Checks whether there's an edit to redo
        /// </summary>
        /// <returns>True, if there is an edit to redo</returns>
        public async Task<bool> CanRedoAsync()
        {
            return await SafeInvokeAsync<bool>("canRedo", Element);
        }

        /// <summary>
        /// Checks whether there's an edit to undo
        /// </summary>
        /// <returns>True, if there is an edit to undo</returns>
        public async Task<bool> CanUndoAsync()
        {
            return await SafeInvokeAsync<bool>("canUndo", Element);
        }

        public async Task SetOptionsAsync(RichTextEditorOptions options)
        {
            Options = options;

            await SafeInvokeVoidAsync("updateColors", Element, options.TextColors!.GetValue(), options.HighlightColors!.GetValue());

            await InvokeAsync(StateHasChanged);
        }
        #endregion

    }



}
