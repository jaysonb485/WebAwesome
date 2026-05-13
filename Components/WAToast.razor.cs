using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor.Components
{
    public partial class WAToast : WAComponentBase
    {

        #region Parameters
        /// <summary>
        /// The placement of the toast stack on the screen.
        /// </summary>
        [Parameter]
        public ToastPlacement Placement { get; set; } = ToastPlacement.TopEnd;
        #endregion

        #region Computed  Properties

        private string PlacementString
        {
            get
            {
                return Placement switch
                {
                    ToastPlacement.TopStart => "top-start",
                    ToastPlacement.TopEnd => "top-end",
                    ToastPlacement.TopCenter => "top-center",
                    ToastPlacement.BottomStart => "bottom-start",
                    ToastPlacement.BottomEnd => "bottom-end",
                    ToastPlacement.BottomCenter => "bottom-center",
                    _ => "top-end",
                };
            }
        }

        #endregion

        #region State
        private List<DynamicToast>? Toasts = default!;

        private Func<ToastMessage, Task>? _createHandler;
        private Func<string, Task>? _hideHandler;
        private Func<ToastMessage, Task>? _dismissHandler;
        private string? _pendingPrependId;
        #endregion

        #region Lifecycle

        protected override void OnInitialized()
        {
            if (ToastService is not null)
            {
                _createHandler = toast => OnCreate(toast);
                _hideHandler = id => OnToastHide(id);
                _dismissHandler = toast => OnToastHide(toast.Id);

                ToastService.RegisterCreate(_createHandler);
                ToastService.RegisterHide(_hideHandler);
                ToastService.RegisterDismiss(_dismissHandler);
            }

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (_pendingPrependId != null)
            {
                var idToMove = _pendingPrependId;
                _pendingPrependId = null; // Clear it so it doesn't run again on next render

                await SafeInvokeVoidAsync("prepend", Id!, idToMove);
            }
        }

        protected override ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {

            }
            return base.DisposeAsyncCore(disposing);
        }

        #endregion

        #region Event Handlers
        private async Task OnToastHide(string toastId)
        {
            await InvokeAsync(() =>
            {
                Toasts?.RemoveAll(d => d.Id == toastId);
                StateHasChanged();
            });
        }

        private async Task OnCreate(ToastMessage toastMessage)
        {
            if (toastMessage is null)
                return;

            Toasts ??= [];
            await InvokeAsync(() =>
            {
                var toastParameters = new Dictionary<string, object>() { { "ToastMessage", toastMessage } };

                Toasts.Add(new DynamicToast() { Id = toastMessage.Id, ToastType = typeof(ToastItem), Parameters = toastParameters });

                // Store the ID we need to move
                _pendingPrependId = toastMessage.Id;

                StateHasChanged();
            });

        }

        #endregion

        internal class DynamicToast
        {
            public string Id { get; set; } = default!;
            public Type ToastType { get; set; } = default!;
            public Dictionary<string, object>? Parameters { get; set; }

        }

    }
}
