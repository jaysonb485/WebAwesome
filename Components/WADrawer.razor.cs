using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
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
        /// The drawer's footer, usually one or more buttons representing various options.
        /// </summary>
        [Parameter]
        public RenderFragment? DrawerFooter { get; set; }
        /// <summary>
        /// The drawer's main content.
        /// </summary>
        [Parameter]
        public RenderFragment? DrawerBody { get; set; }
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

        /// <summary>
        /// Triggered when the drawer is closed.
        /// </summary>
        [Parameter]
        public EventCallback<string> DrawerClosed { get; set; } = default!;

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


        #region Event Handlers
        [JSInvokable]
        public async Task HandleDialogClosed(string TargetElementId)
        {
            IsVisible = false;
            if (DrawerClosed.HasDelegate)
                await DrawerClosed.InvokeAsync(TargetElementId);
        }
        #endregion

        #region Lifecycle

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                
                objRef?.Dispose();

            }

            await base.DisposeAsyncCore(disposing);
        }

        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);

            await base.OnInitializedAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.drawer.initialize", Id, objRef);
            }
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
            await JSRuntime.InvokeVoidAsync("window.vengage.drawer.change", Id, false);
        }

        /// <summary>
        /// Shows the drawer.
        /// </summary>
        public async Task ShowAsync()
        {
            
            await JSRuntime.InvokeVoidAsync("window.vengage.drawer.change", Id, true);
            IsVisible = true;
            await InvokeAsync(StateHasChanged);

        }
        #endregion

    }
}
