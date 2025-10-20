using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WADrawer : WAComponentBase
    {
        #region Parameters

        /// <summary>
        /// The drawer's title as displayed in the header. You should always include a relevant title, as it is required for proper accessibility.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }
        /// <summary>
        /// Renders the drawer with a footer.
        /// </summary>
        [Parameter]
        public RenderFragment? DrawerFooter { get; set; }
        /// <summary>
        /// Optional actions to add to the header. Works best with WAButton.
        /// </summary>
        [Parameter]
        public RenderFragment? HeaderActions { get; set; }
        /// <summary>
        /// When enabled, the drawer will be closed when the user clicks outside of it. Defaults to true.
        /// </summary>
        [Parameter]
        public bool LightDismiss { get; set; } = true;
        /// <summary>
        /// The direction from which the drawer will open. Valid options are top, end, bottom, start. Default is end.
        /// </summary>
        [Parameter]
        public DrawerPlacement Placement { get; set; } = DrawerPlacement.End;
        #endregion

        #region Computed  Properties

        bool WithHeader
        {
            get
            {
                return (!String.IsNullOrEmpty(Title) || (HeaderActions != null));
            }
        }

        bool WithFooter { get { return DrawerFooter != null; } }





        string PlacementString
        {
            get
            {
                return Placement switch
                {
                    DrawerPlacement.Top => "top",
                    DrawerPlacement.End => "end",
                    DrawerPlacement.Start => "start",
                    DrawerPlacement.Bottom => "bottom",
                    _ => "end"
                };
            }
        }
        #endregion

        #region Lifecycle

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

                // if (ModalService is not null && IsServiceModal)
                //     ModalService.OnShow -= OnShowAsync;
            }

            await base.DisposeAsyncCore(disposing);
        }

        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);

            // if (ModalService is not null && IsServiceModal)
            //     ModalService.OnShow += OnShowAsync;

            await base.OnInitializedAsync();
        }
        #endregion

        #region State
        private DotNetObjectReference<WADrawer> objRef = default!;

        private bool IsVisible { get; set; } = false;

        #endregion

        #region Public Methods

        /// <summary>
        /// Hides the drawer.
        /// </summary>
        public async Task HideAsync()
        {
            IsVisible = false;
            await JSRuntime.InvokeVoidAsync("window.changeModal", Id, false);
        }

        /// <summary>
        /// Shows the drawer.
        /// </summary>
        public async Task ShowAsync()
        {
            IsVisible = false;
            await JSRuntime.InvokeVoidAsync("window.changeModal", Id, true);
        }
        #endregion

    }
}
