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

        #endregion

        #region Lifecycle

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {

                if (ToastService is not null)
                {
                    ToastService.OnCreate -= async toast => { await OnCreate(toast); };
                    ToastService.OnHideToast -= async toastId => { await OnToastHide(toastId); };
                    ToastService.OnDismiss -= async toast => { await OnToastHide(toast.Id); };
                }

            }

            await base.DisposeAsyncCore(disposing);
        }

        protected override void OnInitialized()
        {
            if (ToastService is not null)
            {
                ToastService.OnCreate += async toast => { await OnCreate(toast); };
                ToastService.OnHideToast += async toastId => { await OnToastHide(toastId); };
                ToastService.OnDismiss += async toast => { await OnToastHide(toast.Id); };
            }


            base.OnInitialized();
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

                StateHasChanged();
            });

            await InvokeVoidAsync("prepend", Id!, toastMessage.Id);
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
