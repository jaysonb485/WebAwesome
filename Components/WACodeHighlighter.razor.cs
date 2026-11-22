using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WACodeHighlighter : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The code to display. It takes precedence over ChildContent and renders verbatim, without dedenting. Use it when the code is dynamic or when escaping ChildContent is impractical.
        /// </summary>
        [Parameter]
        public string? Code { get; set; }

        /// <summary>
        /// An accessible label for the code region. When omitted, a localized "Code" label is used.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The language of the code, e.g. html, css, js, or python. Common languages are bundled and the rest load on demand. Leave it empty to display plain text.
        /// </summary>
        [Parameter]
        public string? CodeLanguage { get; set; }

        /// <summary>
        /// Shows the copy button.
        /// </summary>
        [Parameter]
        public bool ShowCopyButton { get; set; } = true;

        /// <summary>
        /// Code is dedented by default. Disable to preserve ChildContent code exactly as written instead of dedenting
        /// </summary>
        [Parameter]
        public bool Dedent { get; set; } = true;

        /// <summary>
        /// Wraps long lines instead of scrolling horizontally.
        /// </summary>
        [Parameter]
        public bool Wrap { get; set; } = false;

        /// <summary>
        /// Emitted when no grammar exists for the current language. The code renders as plain text.
        /// </summary>
        [Parameter]
        public EventCallback GrammarError { get; set; }

        /// <summary>
        /// Emitted when the grammar for the current language has loaded and the code has been highlighted.
        /// </summary>
        [Parameter]
        public EventCallback Loaded { get; set; }

        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {

                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Element, objRef);
            }
        }

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
        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);


            AdditionalAttributes ??= new Dictionary<string, object>();

            await base.OnInitializedAsync();
        }
        #endregion

        #region State
        private DotNetObjectReference<WACodeHighlighter> objRef = default!;
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleGrammarError()
        {
            await GrammarError.InvokeAsync();
        }

        [JSInvokable]
        public async Task HandleLoaded()
        {
            await Loaded.InvokeAsync();
        }

        #endregion

    }


}
