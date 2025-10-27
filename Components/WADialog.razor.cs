using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return (String.IsNullOrEmpty(Title) && (HeaderActions == null));
            }
        }

        private bool WithoutFooter { get { return DialogFooter == null; } }
        protected override string? StyleNames => BuildStyleNames(Style, ($"--width:{PreferredWidth}", !String.IsNullOrEmpty(PreferredWidth)));

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
                await JSRuntime.InvokeVoidAsync("window.vengage.dialog.initialize", Id, objRef);
            }
        }

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    // if (IsRenderComplete)
                    // await JSRuntime.InvokeVoidAsync("window.vengage.dialog.dispose", Id);
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
        private DotNetObjectReference<WADialog> objRef = default!;

        private bool IsVisible { get; set; } = false;

        #endregion

        #region Public Methods
        /// <summary>
        /// Hides the dialog.
        /// </summary>
        public void Hide()
        {
            Task.Run(() => JSRuntime.InvokeVoidAsync("window.vengage.dialog.change", Id, false));
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        public void Show()
        {
            IsVisible = true;
            StateHasChanged();

        }
        #endregion

    }
}
