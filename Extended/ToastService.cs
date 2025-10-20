using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vengage.WebAwesome.Extended.ToastMessages;

namespace Vengage.WebAwesome.Extended
{
    public class ToastService
    {
        #region Events

        internal event Action<ToastMessage> OnNotify = default!;

        #endregion

        #region Methods

        public void Notify(ToastMessage toastMessage) => OnNotify?.Invoke(toastMessage);

        #endregion
    }
}
