using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WAResizeObserver : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Disables the observer.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        [Parameter]
        public EventCallback<ResizeEventArgs> Resized { get; set; }
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
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {

                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Id!, objRef);
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

        #endregion

        #region State
        private DotNetObjectReference<WAResizeObserver> objRef = default!;
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleResize(decimal? height, decimal? width)
        {
            if (Resized.HasDelegate) await Resized.InvokeAsync(new() { Height = height, Width = width });
        }
        #endregion

        public class ResizeEventArgs
        {
            public decimal? Height { get; set; }
            public decimal? Width { get; set; }
        }
    }


}
