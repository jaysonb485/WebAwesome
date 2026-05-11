using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

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

        /// <summary>
        /// The preferred size of the drawer in CSS units. This will be applied to the drawer's width or height depending on its placement.
        /// </summary>
        [Parameter]
        public string? PreferredSize { get; set; }

        /// <summary>
        /// A CSS filter to apply to the backdrop behind the drawer. e.g. "blur(5px)". 
        /// </summary>
        [Parameter]
        public string? BackdropFilter { get; set; }

        /// <summary>
        /// The animation duration when hiding the drawer.Default `200ms`
        /// </summary>
        [Parameter]
        public string? HideDuration { get; set; }

        /// <summary>
        /// The animation duration when showing the drawer. Default `200ms`
        /// </summary>
        [Parameter]
        public string? ShowDuration { get; set; }

        /// <summary>
        /// The amount of space around and between the dialog's content.
        /// </summary>
        [Parameter]
        public string? Spacing { get; set; }

        #endregion

        #region Computed  Properties

        bool WithHeader
        {
            get
            {
                return !String.IsNullOrEmpty(Title) || (HeaderActions != null);
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

        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--size:{PreferredSize}", !String.IsNullOrEmpty(PreferredSize)),
            ($"--spacing:{Spacing}", !String.IsNullOrEmpty(Spacing)),
            ($"--show-duration:{ShowDuration}", !String.IsNullOrEmpty(ShowDuration)),
            ($"--hide-duration:{HideDuration}", !String.IsNullOrEmpty(HideDuration)),
            ($"--backdrop-filter:{BackdropFilter}", !String.IsNullOrEmpty(BackdropFilter)));

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
        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);

            await base.OnInitializedAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Id!, objRef);
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
            await SafeInvokeVoidAsync("change", Id!, false);
        }

        public void Hide() => _ = HideAsync();

        /// <summary>
        /// Shows the drawer.
        /// </summary>
        public async Task ShowAsync()
        {
            IsVisible = true;
            await SafeInvokeVoidAsync("change", Id!, true);

        }

        public void Show() => _ = ShowAsync();


        #endregion

    }
}
