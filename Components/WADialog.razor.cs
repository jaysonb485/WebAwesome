using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WADialog : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The dialog's title as displayed in the header. You should always include a relevant title, as it is required for proper accessibility.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }
        /// <summary>
        /// The dialog's footer, usually one or more buttons representing various options.
        /// </summary>
        [Parameter]
        public RenderFragment? DialogFooter { get; set; }
        /// <summary>
        /// The dialog's main content.
        /// </summary>
        [Parameter]
        public RenderFragment? DialogBody { get; set; }

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
        /// The preferred width of the dialog in CSS units. Note that the dialog will shrink to accommodate smaller screens.
        /// </summary>
        [Parameter]
        public string? PreferredWidth { get; set; }

        /// <summary>
        /// A CSS filter to apply to the backdrop behind the dialog. e.g. "blur(5px)". 
        /// </summary>
        [Parameter]
        public string? BackdropFilter { get; set; }

        /// <summary>
        /// The animation duration when hiding the dialog.Default `200ms`
        /// </summary>
        [Parameter]
        public string? HideDuration { get; set; }

        /// <summary>
        /// The animation duration when showing the dialog. Default `200ms`
        /// </summary>
        [Parameter]
        public string? ShowDuration { get; set; }

        /// <summary>
        /// The amount of space around and between the dialog's content.
        /// </summary>
        [Parameter]
        public string? Spacing { get; set; }

        /// <summary>
        /// Triggered when the dialog is closed.
        /// </summary>
        [Parameter]
        public EventCallback<string> DialogClosed { get; set; } = default!;


        #endregion

        #region Computed  Properties
        private bool WithoutHeader
        {
            get
            {
                return String.IsNullOrEmpty(Title) && (HeaderActions == null);
            }
        }

        private bool WithoutFooter { get { return DialogFooter == null; } }
        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--width:{PreferredWidth}", !String.IsNullOrEmpty(PreferredWidth)),
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
            await InvokeAsync(StateHasChanged);
            if (DialogClosed.HasDelegate)
                await DialogClosed.InvokeAsync(TargetElementId);
        }
        #endregion
        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Id!, objRef);
            }
        }

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
        #endregion

        #region State
        private DotNetObjectReference<WADialog> objRef = default!;

        private bool IsVisible { get; set; } = false;

        #endregion

        #region Public Methods
        /// <summary>
        /// Hides the dialog.
        /// </summary>
        public void Hide() => _ = HideAsync();
        /// <summary>
        /// Hides the dialog.
        /// </summary>
        public async Task HideAsync()
        {
            await SafeInvokeVoidAsync("change", Id!, false);
            IsVisible = false;
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        public void Show() => _ = ShowAsync();

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        public async Task ShowAsync()
        {
            IsVisible = true;
            await InvokeAsync(StateHasChanged);
        }
        #endregion

    }
}
