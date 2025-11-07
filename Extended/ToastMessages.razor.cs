using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Extended
{
    public partial class ToastMessages : WAComponentBase
    {
        #region Parameters
        public List<ToastMessage>? Toasts { get; set; }
        #endregion

        #region Lifecycle
        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                Toasts = null;

                if (toastService is not null)
                    toastService.OnNotify -= OnNotify;
            }

            await base.DisposeAsyncCore(disposing);
        }

        protected override void OnInitialized()
        {
            if (toastService is not null)
                toastService.OnNotify += OnNotify;

            base.OnInitialized();
        }

        #endregion
        #region Event Handlers
        private void OnNotify(ToastMessage toastMessage)
        {
            if (toastMessage is null)
                return;

            Toasts ??= new List<ToastMessage>();

            Toasts.Add(toastMessage);

            StateHasChanged();
        }

        private void OnToastDismissed(ToastMessage toastMessage)
        {
            Toasts?.Remove(toastMessage);
            StateHasChanged();
        }


        #endregion

        public class ToastMessage
        {
            public string? Title { get; set; }
            public string? Message { get; set; }
            /// <summary>
            /// The name of the icon to draw in the prefix slot. Available names depend on the icon library being used.
            /// </summary>
            public string? IconName { get; set; }
            /// <summary>
            /// The family of icons to choose from for the prefix slot icon. For Font Awesome Free (default), valid options include classic and brands. For Font Awesome Pro subscribers, valid options include, classic, sharp, duotone, and brands. Custom icon libraries may or may not use this property.
            /// </summary>
            public string? IconFamily { get; set; }
            /// <summary>
            /// The name of the prefix slot icon's variant. For Font Awesome, valid options include thin, light, regular, and solid for the classic and sharp families. Some variants require a Font Awesome Pro subscription. Custom icon libraries may or may not use this property.
            /// </summary>
            public string? IconVariant { get; set; }

            /// <summary>
            /// Shows a close button to manually dismiss the toast. If timeout is set to a value greater than 0, the toast will automatically dismiss after the timeout period even if this property is false.
            /// </summary>
            public bool Dismissable { get; set; } = true;

            /// <summary>
            /// The number of milliseconds to wait before automatically dismissing the toast.
            /// </summary>
            public int Timeout { get; set; } = 0;
            public ToastMessageVariant Variant { get; set; } = ToastMessageVariant.Brand;

        }
    }


}
