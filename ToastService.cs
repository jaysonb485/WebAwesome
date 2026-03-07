namespace WebAwesomeBlazor
{
    public class ToastService
    {
        #region Events

        internal event Action<ToastMessage> OnCreate = default!;
        internal event Action<string> OnHideToast = default!;
        internal event Action<ToastMessage> OnDismiss = default!;
        #endregion

        #region Methods

        public async Task CreateAsync(ToastMessage toastMessage) => OnCreate?.Invoke(toastMessage);
        public async Task HideToastAsync(string ToastId) => OnHideToast?.Invoke(ToastId);
        public async Task DismissAsync(ToastMessage toastMessage) => OnDismiss?.Invoke(toastMessage);

        #endregion
    }


}
