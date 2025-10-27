using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebAwesomeBlazor.Extended.ToastMessages;

namespace WebAwesomeBlazor.Extended
{
    public partial class Toast : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public ToastMessages.ToastMessage ToastMessage { get; set; } = default!;
        [Parameter]
        public EventCallback ToastDismissed { get; set; }
        #endregion

        #region Computed  Properties
        protected override string ClassNames => BuildClassNames(Class,
            ($"wa-brand", ToastMessage.Variant == ToastMessageVariant.Brand),
            ($"wa-neutral", ToastMessage.Variant == ToastMessageVariant.Neutral),
            ($"wa-success", ToastMessage.Variant == ToastMessageVariant.Success),
            ($"wa-warning", ToastMessage.Variant == ToastMessageVariant.Warning),
            ($"wa-danger", ToastMessage.Variant == ToastMessageVariant.Danger)
);
        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender && ToastMessage.Timeout > 0)
            {

                TimeoutRemaning = ToastMessage.Timeout * 1000;
                ProgressBarValue = 100;

                using var periodicTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(100));

                while (await periodicTimer.WaitForNextTickAsync())
                {
                    if (ProgressBarValue == 0)
                    {
                        await OnDismissToast();
                        break;
                    }

                    TimeoutRemaning -= 100;

                    if (TimeoutRemaning < 0)
                    {
                        ProgressBarValue = 0;
                    }
                    else
                    {
                        ProgressBarValue = (TimeoutRemaning / (ToastMessage.Timeout * 1000)) * 100;
                    }

                    StateHasChanged();
                }
            }

            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Event Handlers
        private async Task OnDismissToast()
        {
            await ToastDismissed.InvokeAsync();
        }
        #endregion

        #region State
        private decimal ProgressBarValue { get; set; } = -1;
        private decimal TimeoutRemaning { get; set; } = 0;
        #endregion


    }


}
