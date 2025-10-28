using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WAInclude : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The location of the HTML file to include. Be sure you trust the content you are including as it will be executed as code and can result in XSS
        /// </summary>
        [Parameter]
        public string? SourceUrl { get; set; }

        /// <summary>
        /// The fetch mode to use.
        /// </summary>
        [Parameter]
        public IncludeMode Mode { get; set; } = IncludeMode.CORS;

        /// <summary>
        /// Allows included scripts to be executed. Be sure you trust the content you are including as it will be executed as code and can result in XSS
        /// </summary>
        [Parameter]
        public bool AllowScripts { get; set; } = false;

        /// <summary>
        /// Emitted when the included file is loaded.
        /// </summary>
        [Parameter]
        public EventCallback Loaded { get; set; }
        /// <summary>
        /// Emitted when the included file fails to load due to an error.
        /// </summary>
        [Parameter]
        public EventCallback<string> LoadError { get; set; }

        #endregion

        #region Computed  Properties
        private string IncludeModeString
        {
            get
            {
                return Mode switch
                {
                    IncludeMode.CORS => "cors",
                    IncludeMode.NoCORS => "no-cors",
                    IncludeMode.SameOrigin => "same-origin",
                    _ => "cors"
                };
            }
        }
        #endregion
        #region Lifecycle
        protected override void OnInitialized()
        {
            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= [];

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.include.initialize", Id, objRef);
            }
        }

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    
                }
                catch (JSDisconnectedException)
                {
                    // do nothing
                }

                objRef?.Dispose();


            }

            await base.DisposeAsyncCore(disposing);
        }

        #endregion

        #region State
        private DotNetObjectReference<WAInclude> objRef = default!;
        #endregion

        #region Private Methods
        [JSInvokable]
        public async Task HandleIncludeLoaded()
        {
            if (Loaded.HasDelegate)
                await Loaded.InvokeAsync();
        }

        [JSInvokable]
        public async Task HandleIncludeError(int HttpErrorCode)
        {
            if (LoadError.HasDelegate)
                await LoadError.InvokeAsync(HttpErrorCode.ToString());
        }
        #endregion
    }

}
