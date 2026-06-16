using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WAAccordion : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Controls how items can be expanded. multiple (the default) allows any number of items to be open at once. single allows only one item to be open at a time; opening a new item collapses the previously open one, and clicking an open item does not collapse it. single-collapsible is the same as single except that clicking the open item collapses it, so zero open items is a valid state.
        /// </summary>
        [Parameter]
        public AccordionMode Mode { get; set; } = AccordionMode.Multiple;

        /// <summary>
        /// The heading level for child item triggers (1–6), or "none" to omit the heading wrapper. Defaults to 3.
        /// </summary>
        [Parameter]
        public AccordionHeadingLevel HeadingLevel { get; set; } = AccordionHeadingLevel.H3;

        /// <summary>
        /// The accordion's visual appearance.
        /// </summary>
        [Parameter]
        public AccordionAppearance Appearance { get; set; } = AccordionAppearance.Outlined;

        /// <summary>
        /// The location of the expand/collapse icon in child items.
        /// </summary>
        [Parameter]
        public AccordionIconPlacement IconPlacement { get; set; } = AccordionIconPlacement.End;

        #endregion

        #region Computed  Properties
        private string ModeString
        {
            get
            {
                return Mode switch
                {
                    AccordionMode.Single => "single",
                    AccordionMode.Multiple => "multiple",
                    AccordionMode.SingleCollapsible => "single-collapsible",
                    _ => "multiple"
                };
            }
        }

        private string HeadingLevelString
        {
            get
            {
                return HeadingLevel switch
                {
                    AccordionHeadingLevel.H1 => "1",
                    AccordionHeadingLevel.H2 => "2",
                    AccordionHeadingLevel.H3 => "3",
                    AccordionHeadingLevel.H4 => "4",
                    AccordionHeadingLevel.H5 => "5",
                    AccordionHeadingLevel.H6 => "6",
                    AccordionHeadingLevel.None => "none",
                    _ => "3"
                };
            }
        }

        private string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    AccordionAppearance.Outlined => "outlined",
                    AccordionAppearance.Filled => "filled",
                    AccordionAppearance.Plain => "plain",
                    AccordionAppearance.FilledOutlined => "filled-outlined",
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
                    AccordionIconPlacement.Start => "start",
                    AccordionIconPlacement.End => "end",
                    _ => "end"
                };
            }
        }
        #endregion
        #region Lifecycle
        protected override void OnInitialized()
        {
            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= [];

            base.OnInitialized();
        }

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

        #endregion

        #region State
        private DotNetObjectReference<WAAccordion> objRef = default!;
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleSelectionChanged(string[] selectedIds)
        {
            //if (SelectionChanged.HasDelegate) await SelectionChanged.InvokeAsync(selectedIds);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Expands all accordion items.
        /// </summary>
        public async Task ExpandAllAsync()
        {
            await SafeInvokeVoidAsync("expandAll", Id!);
        }

        public void ExpandAll() => _ = ExpandAllAsync();

        public async Task CollapseAllAsync()
        {
            await SafeInvokeVoidAsync("collapseAll", Id!);
        }

        public void CollapseAll() => _ = CollapseAllAsync();
        #endregion
    }


}
