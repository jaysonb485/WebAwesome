using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WADetails : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The element's visual appearance.
        /// </summary>
        [Parameter]
        public DetailsAppearance Appearance { get; set; } = DetailsAppearance.Outlined;

        /// <summary>
        /// Disables the details so it can't be toggled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The summary to show in the header.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// The details' summary. Alternatively, you can use the Title property.
        /// </summary>
        [Parameter]
        public RenderFragment? DetailsTitle { get; set; }

        /// <summary>
        /// The details' main content.
        /// </summary>
        [Parameter]
        public RenderFragment? DetailsBody { get; set; }

        /// <summary>
        /// Indicates whether or not the details is open.
        /// </summary>
        [Parameter]
        public bool IsOpen { get; set; } = false;

        /// <summary>
        /// The name of the icon to draw for the expand indicator. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ExpandIconName { get; set; }

        /// <summary>
        /// The name of the icon to draw for the expand indicator.
        /// </summary>
        [Parameter]
        public Icon? ExpandIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw on for the collapse indicator. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? CollapseIconName { get; set; }

        /// <summary>
        /// The name of the icon to draw for the collapse indicator.
        /// </summary>
        [Parameter]
        public Icon? CollapseIcon { get; set; }

        /// <summary>
        /// Groups related details elements. When one opens, others with the same name will close.
        /// </summary>
        [Parameter]
        public string? GroupName { get; set; }

        /// <summary>
        /// The location of the expand/collapse icon.
        /// </summary>
        [Parameter]
        public DetailsIconPlacement IconPlacement { get; set; } = DetailsIconPlacement.End;
        #endregion

        #region Computed  Properties
        private string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    DetailsAppearance.Filled => "filled",
                    DetailsAppearance.FilledOutlined => "filled-outlined",
                    DetailsAppearance.Outlined => "outlined",
                    DetailsAppearance.Plain => "plain",
                    _ => "outlined"
                };
            }
        }

        private string IconPlacementString
        {
            get
            {
                return IconPlacement switch
                {
                    DetailsIconPlacement.End => "end",
                    DetailsIconPlacement.Start => "start",
                    _ => "end"
                };
            }
        }
        #endregion


        #region Lifecycle
        protected override void OnInitialized()
        {
            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= new Dictionary<string, object>();

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.details.initialize", Id, objRef);
            }
        }

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {

                objRef?.Dispose();

            }

            await base.DisposeAsyncCore(disposing);
        }

        #endregion

        #region State
        private DotNetObjectReference<WADetails> objRef = default!;
        #endregion

        #region Public Methods
        /// <summary>
        /// Shows the details.
        /// </summary>
        public async Task ShowAsync()
        {
                await JSRuntime.InvokeVoidAsync("window.vengage.details.show", Id);
        }

        public void Show() => _ = ShowAsync();
        /// <summary>
        /// Hides the details.
        /// </summary>
        public async Task HideAsync()
        {
                await JSRuntime.InvokeVoidAsync("window.vengage.details.hide", Id);
        }

        public void Hide() => _ = HideAsync();  

        [JSInvokable]
        public void HandleDetailsShow()
        {
            IsOpen = true;
        }

        [JSInvokable]
        public void HandleDetailsHide()
        {
            IsOpen = false;
        }
        #endregion

    }
}
