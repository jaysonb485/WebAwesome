using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WATabGroup : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Enables the scroll arrows that appear when tabs overflow. Defaults to true.
        /// </summary>
        [Parameter]
        public bool ShowScrollControls { get; set; } = true;

        /// <summary>
        /// Sets the active tab.
        /// </summary>
        [Parameter]
        public string? ActiveTab { get; set; }

        /// <summary>
        /// The placement of the tabs.
        /// </summary>
        [Parameter]
        public TabGroupTabPlacement TabPlacement { get; set; } = TabGroupTabPlacement.Top;

        /// <summary>
        /// Triggered when the active tab has changed.
        /// </summary>
        [Parameter]
        public EventCallback<string> ActiveTabChanged { get; set; } = default!;
        /// <summary>
        /// The color of the active tab indicator.
        /// </summary>
        [Parameter]
        public string? IndicatorColor { get; set; }
        /// <summary>
        /// The color of the indicator's track (the line that separates tabs from panels).
        /// </summary>
        [Parameter]
        public string? TrackColor { get; set; }
        /// <summary>
        /// The width of the indicator's track (the line that separates tabs from panels).
        /// </summary>
        [Parameter]
        public string? TrackWidth { get; set; }
        #endregion

        #region Computed  Properties
        string TabPlacementString
        {
            get
            {
                return TabPlacement switch
                {
                    TabGroupTabPlacement.Top => "top",
                    TabGroupTabPlacement.Bottom => "bottom",
                    TabGroupTabPlacement.Start => "start",
                    TabGroupTabPlacement.End => "end",
                    _ => "top"
                };
            }
        }

        protected override string? StyleNames => BuildStyleNames(Style,
     ($"--indicator-color: {IndicatorColor}", !String.IsNullOrEmpty(IndicatorColor)),
     ($"--track-color: {TrackColor}", !String.IsNullOrEmpty(TrackColor)),
     ($"--track-width: {TrackWidth}", !String.IsNullOrEmpty(TrackWidth))
    );
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleTabShowing(string tabId)
        {
            ActiveTab = tabId;
            if(ActiveTabChanged.HasDelegate)
                await ActiveTabChanged.InvokeAsync(tabId);
        }
        #endregion

        #region Lifecycle Methods
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.tab.initialize", Id, objRef);
            }
        }

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


            }

            await base.DisposeAsyncCore(disposing);
        }

        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);


            AdditionalAttributes ??= new Dictionary<string, object>();

            await base.OnInitializedAsync();
        }

        #endregion
        #region state
        private DotNetObjectReference<WATabGroup> objRef = default!;
        #endregion
    }


}
