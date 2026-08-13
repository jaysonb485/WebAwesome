using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WAPagination : WAComponentBase
    {
        #region Parameters


        /// <summary>
        /// The pagination's visual appearance.
        /// </summary>
        [Parameter]
        public PaginationAppearance Appearance { get; set; } = PaginationAppearance.Outlined;

        /// <summary>
        /// The number of pages to always show at the start and end.
        /// </summary>
        [Parameter]
        public int BoundaryCount { get; set; } = 1;

        /// <summary>
        /// Disables the pagination.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The pagination's layout. The default standard format shows the full page list with ellipses; compact collapses it into a short "1 of 5" label flanked by the previous and next buttons, useful in tight spaces like toolbars and cards.
        /// </summary>
        [Parameter]
        public PaginationFormat Format { get; set; } = PaginationFormat.Standard;

        /// <summary>
        /// Renders nothing when there's only one page.
        /// </summary>
        [Parameter]
        public bool HideSinglePage { get; set; } = false;

        /// <summary>
        /// A URL template used to render page items as links instead of buttons. When set, items render as <a> elements. Provide a string with {page} as a placeholder for the page number, e.g. /products?page={page}. 
        /// </summary>
        [Parameter]
        public string? LinkTemplate { get; set; }

        /// <summary>
        /// A label that describes the pagination to assistive devices. This won't be shown on the screen, but it will be announced by screen readers. Especially useful when more than one pagination control exists on the same page.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The current page, starting at 1.
        /// </summary>
        [Parameter]
        public int Page { get; set; } = 1;

        /// <summary>
        /// The number of items shown per page.
        /// </summary>
        [Parameter]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// The number of pages to show on each side of the current page.
        /// </summary>
        [Parameter]
        public int SiblingCount { get; set; } = 1;

        /// <summary>
        /// The total number of items to paginate.
        /// </summary>
        [Parameter]
        public int TotalItems { get; set; } = 0;

        /// <summary>
        /// Shows buttons that jump to the first and last pages.
        /// </summary>
        [Parameter]
        public bool ShowEdgeButtons { get; set; } = false;

        /// <summary>
        /// Shows the previous and next buttons. Default is true.
        /// </summary>
        [Parameter]
        public bool ShowNavButtons { get; set; } = true;

        /// <summary>
        /// Shows a summary of the items on the current page, e.g. "1–10 of 237".
        /// </summary>
        [Parameter]
        public bool ShowSummary { get; set; } = false;

        /// <summary>
        /// An icon to use in lieu of the default first icon.
        /// </summary>
        [Parameter]
        public string? FirstIconName { get; set; }
        /// <summary>
        /// An icon to use in lieu of the default first icon.
        /// </summary>
        [Parameter]
        public Icon? FirstIcon { get; set; }
        /// <summary>
        /// An icon to use in lieu of the default last icon.
        /// </summary>
        [Parameter]
        public string? LastIconName { get; set; }
        /// <summary>
        /// An icon to use in lieu of the default last icon.
        /// </summary>
        [Parameter]
        public Icon? LastIcon { get; set; }

        /// <summary>
        /// An icon to use in lieu of the default next icon.
        /// </summary>
        [Parameter]
        public string? NextIconName { get; set; }
        /// <summary>
        /// An icon to use in lieu of the default next icon.
        /// </summary>
        [Parameter]
        public Icon? NextIcon { get; set; }
        /// <summary>
        /// An icon to use in lieu of the default previous icon.
        /// </summary>
        [Parameter]
        public string? PreviousIconName { get; set; }
        /// <summary>
        /// An icon to use in lieu of the default previous icon.
        /// </summary>
        [Parameter]
        public Icon? PreviousIcon { get; set; }

        [Parameter]
        public EventCallback<PaginationPageChangedEventArgs> PageChanged { get; set; }

        #endregion

        #region Computed  Properties

        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    PaginationAppearance.Outlined => "outlined",
                    PaginationAppearance.Filled => "filled",
                    PaginationAppearance.Plain => "plain",
                    _ => "outlined"
                };
            }
        }

        string FormatString
        {
            get
            {
                return Format switch
                {
                    PaginationFormat.Standard => "standard",
                    PaginationFormat.Compact => "compact",
                    _ => "standard"
                };
            }
        }


        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
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

        #region Event Handlers
        /// <summary>
        /// Emitted after the page changes.
        /// </summary>
        [JSInvokable]
        public async Task HandlePageChanged(int pageSize, int Page)
        {
            var args = new PaginationPageChangedEventArgs
            {
                PageSize = pageSize,
                Page = Page
            };
            await PageChanged.InvokeAsync(args);

        }



        #endregion

        #region Public Methods
        /// <summary>
        /// Remove (hide the tag).
        /// </summary>
        public async Task ChangePageAsync(int Page)
        {
            await SafeInvokeVoidAsync("removeTag", Id!, objRef);
        }

        public void Remove(int Page) => _ = ChangePageAsync(Page);
        #endregion

        #region State
        private DotNetObjectReference<WAPagination> objRef = default!;
        #endregion



    }


}
