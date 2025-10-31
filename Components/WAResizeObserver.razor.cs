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
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.resizeObserver.initialize", Id, objRef);
            }
        }

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

        #endregion

        #region State
        private DotNetObjectReference<WAResizeObserver> objRef = default!;
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleResize(decimal? height, decimal? width)
        {
            if (Resized.HasDelegate) await Resized.InvokeAsync(new() { Height = height, Width = width});
        }
        #endregion

        public class ResizeEventArgs
        {
            public decimal? Height { get; set; }
            public decimal? Width { get; set; }
        }
    }


}
