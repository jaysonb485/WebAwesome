using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WAComparison : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The content to show in the before panel, usually an img or svg
        /// </summary>
        [Parameter, EditorRequired]
        public RenderFragment BeforeContent { get; set; }

        /// <summary>
        /// The content to show in the after panel, usually an img or svg
        /// </summary>
        [Parameter, EditorRequired]
        public RenderFragment AfterContent { get; set; }

        /// <summary>
        /// The position of the divider as a percentage.
        /// </summary>
        [Parameter]
        public double? DividerPosition { get; set; } = 50;

        /// <summary>
        /// The icon used inside the handle. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? HandleIconName { get; set; }

        /// <summary>
        /// The icon used inside the handle. Alternatively use HandleIconName
        /// </summary>
        [Parameter]
        public Icon? HandleIcon { get; set; }

        /// <summary>
        /// The width of the dividing line in CSS width units.
        /// </summary>
        [Parameter]
        public string? DividerWidth { get; set; }

        /// <summary>
        /// The size of the compare handle in CSS units.
        /// </summary>
        [Parameter]
        public string? HandleSize { get; set; }
        /// <summary>
        /// Triggered when the position of the divider changes. Provides the new position.
        /// </summary>
        [Parameter]
        public EventCallback<double> PositionChanged { get; set; }

        #endregion

        #region Computed Properties
        protected override string? StyleNames => BuildStyleNames(Style,
             ($"--divider-width: {DividerWidth}", !String.IsNullOrEmpty(DividerWidth)),
             ($"--handle-size: {HandleSize}", !String.IsNullOrEmpty(HandleSize))
            );
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
                await JSRuntime.InvokeVoidAsync("window.vengage.comparison.initialize", Id, objRef);
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

        #endregion

        #region State
        private DotNetObjectReference<WAComparison> objRef = default!;
        #endregion

        #region Private Methods
        [JSInvokable]
        public async Task HandleDividerChange(double newPosition)
        {
            DividerPosition = newPosition;

            if (PositionChanged.HasDelegate)
                await PositionChanged.InvokeAsync(newPosition);
        }

        #endregion
    }
}
