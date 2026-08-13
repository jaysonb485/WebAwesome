using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace WebAwesomeBlazor.Components
{
    public partial class WADataGrid<TItem> : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Keeps a sorted column always sorted, alternating between ascending and descending. By default, a sorted column's third click clears its sort (the asc → desc → unsorted cycle).
        /// </summary>
        [Parameter]
        public bool AllowSortRemoval { get; set; } = false;

        /// <summary>
        /// The grid's visual appearance. Outlined or plain.
        /// </summary>
        [Parameter] public DataGridAppearance Appearance { get; set; } = DataGridAppearance.Outlined;

        /// <summary>
        /// The current page index (0-based).
        /// </summary>
        [Parameter] public int CurrentPage { get; set; } = 0;
        /// <summary>
        /// How long (in milliseconds) to wait after a search or filter keystroke before requesting data in server mode. Client-side filtering is always immediate. Sort and page changes are never debounced.
        /// </summary>
        [Parameter] public int FilterDebounce { get; set; } = 250;
        /// <summary>
        /// An accessible label for the grid.
        /// </summary>
        [Parameter] public string? Label { get; set; }

        /// <summary>
        /// The maximum number of columns that can participate in a multi-column sort. 0 (default) means no limit.
        /// </summary>
        [Parameter] public int MaxMultiSort { get; set; } = 0;

        /// <summary>
        /// The number of rows per page.
        /// </summary>
        [Parameter] public int PageSize { get; set; } = 20;
        /// <summary>
        /// Enables column pinning (and the pin actions in the column menu). Can be overridden per column with pinnable.
        /// </summary>
        [Parameter] public bool Pinnable { get; set; } = false;
        /// <summary>
        /// The field used as a stable row id for selection. 
        /// </summary>
        [Parameter, EditorRequired] public string RowKey { get; set; } = "id";
        /// <summary>
        /// Sets the data grid to server-side mode, filters, sorts, and pagination will be handled by the consumer via the OnDataRequest callback. If false (default), all data is loaded into the grid and filtering, sorting, and pagination are handled client-side.
        /// </summary>
        [Parameter] public bool ServerSideData { get; set; } = false;

        /// <summary>
        /// Enables client-side pagination and the pager footer.
        /// </summary>
        [Parameter] public bool ShowPagination { get; set; } = false;

        /// <summary>
        /// Enables drag-to-reorder for columns (can be overridden per column with movable).
        /// </summary>
        [Parameter] public bool Reorderable { get; set; } = false;
        /// <summary>
        /// Enables drag-to-resize for columns (can be overridden per column).
        /// </summary>
        [Parameter] public bool Resizable { get; set; } = false;
        /// <summary>
        /// Enables row selection.
        /// </summary>
        [Parameter] public DataGridRowSelection RowSelectionMode { get; set; } = DataGridRowSelection.None;
        /// <summary>
        /// Shows a global search box that filters across all columns.
        /// </summary>
        [Parameter] public bool Searchable { get; set; } = false;
        /// <summary>
        /// Shows a per-column header menu (kebab button) with pin, sort, hide, and autosize actions.
        /// </summary>
        [Parameter] public bool ShowColumnMenus { get; set; } = false;
        /// <summary>
        /// Shows a toolbar menu for toggling column visibility.
        /// </summary>
        [Parameter] public bool ShowColumnVisibilityMenu { get; set; } = false;

        /// <summary>
        /// The grid's size. Controls the font scale of grid text and form controls, plus row height and cell padding.
        /// </summary>
        [Parameter]
        public DataGridSize Size { get; set; } = DataGridSize.Medium;
        /// <summary>
        /// When true, a column's first sort click sorts descending instead of ascending
        /// </summary>
        [Parameter] public bool SortDescendingFirst { get; set; } = false;
        /// <summary>
        /// Renders alternating row background colors.
        /// </summary>
        [Parameter] public bool Striped { get; set; } = false;


        /// <summary>
        /// Content shown in the loading overlay (server mode).
        /// </summary>
        [Parameter] public RenderFragment? LoadingTemplate { get; set; }
        /// <summary>
        /// Content shown when there are no rows to display.
        /// </summary>
        [Parameter] public RenderFragment? EmptyDataTemplate { get; set; }

        /// <summary>
        /// Content shown when an active search or filter matches no rows (falls back to a localized message).
        /// </summary>
        [Parameter] public RenderFragment? NoResultsTemplate { get; set; }

        [Parameter] public RenderFragment? Columns { get; set; }

        /// <summary>
        /// Event driven data provider callback.
        /// </summary>
        [Parameter]
        public Func<DataGridDataRequestArgs, Task<GridDataResult<TItem>>> OnDataRequest { get; set; } = null!;


        #endregion
        #region State

        private DotNetObjectReference<WADataGrid<TItem>>? objRef;
        private readonly List<DataGridColumn<TItem>> _columns = new();
        private IEnumerable<TItem> _currentPageItems = Enumerable.Empty<TItem>();

        #endregion

        #region Computed Properties

        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    DataGridAppearance.Outlined => "outlined",
                    DataGridAppearance.Plain => "plain",
                    _ => "outlined"
                };
            }
        }

        string RowSelectionModeString
        {
            get
            {
                return RowSelectionMode switch
                {
                    DataGridRowSelection.None => "none",
                    DataGridRowSelection.Single => "single",
                    DataGridRowSelection.Multiple => "multiple",
                    _ => "none"
                };
            }
        }

        string SizeString
        {
            get
            {
                return Size switch
                {
                    DataGridSize.XSmall => "xs",
                    DataGridSize.Small => "s",
                    DataGridSize.Medium => "m",
                    DataGridSize.Large => "l",
                    DataGridSize.XLarge => "xl",
                    _ => "m"
                };
            }
        }

        #endregion

        internal void AddColumn(DataGridColumn<TItem> column) => _columns.Add(column);

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                objRef = DotNetObjectReference.Create(this);
                await LoadModuleAsync("./_content/WebAwesomeBlazor/Components/WADataGrid.razor.js");

                var columnConfigs = _columns.Select(c => new
                {
                    field = c.Field,
                    id = c.Id ?? c.Field,
                    label = c.Label,
                    sortable = c.Sortable,
                    sortFn = c.SortMethod is not null ? (object)c.SortMethod : null,
                    searchable = c.Searchable,
                    filterable = c.Filterable,
                    hidden = c.Hidden,
                    resizable = c.Resizable,
                    movable = c.Movable,
                    pinnable = c.Pinnable,
                    pinned = c.PinDirection is not null ? c.PinDirection : null,
                    flex = c.Flex,
                    width = c.Width,
                    minWidth = c.MinWidth,
                    align = c.Align,
                    hasTemplate = c.Template is not null
                }).ToList();

                await SafeInvokeVoidAsync("initEventGrid", Element, Id!, JsonNamingPolicy.CamelCase.ConvertName(RowKey), objRef, columnConfigs);
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
        #region Public methods

        /// <summary>
        /// Called by JavaScript when wa-data-request fires
        /// </summary>
        [JSInvokable]
        public async Task<object> HandleDataRequest(DataGridDataRequestArgs args)
        {
            // 1. Fetch data for current view from consumer C# delegate
            var result = await OnDataRequest(args);
            _currentPageItems = result.Items ?? Enumerable.Empty<TItem>();

            // 2. Re-render Blazor portal DOM cache for current page
            StateHasChanged();

            // 3. Return JSON payload matching what wa-data-grid expects
            return new
            {
                items = _currentPageItems,
                total = result.TotalCount
            };
        }

        /// <summary>
        /// Retrieves the number of pages in the current result set.
        /// </summary>
        /// <returns>The number of pages in the current result set (always 1 when paginate is off). </returns>
        public async Task<int> GetPageCountAsync()
        {
            if (ShowPagination)
            {
                return await SafeInvokeAsync<int>("getPageCount", Element);
            }
            return 1;
        }

        /// <summary>
        /// Sets the page sizes offered by the pager's page-size selector.
        /// </summary>
        /// <param name="PageSizeOptions">Array of page sizes available to select</param>
        public async Task SetPageSizeOptions(int[] PageSizeOptions)
        {
            if (ShowPagination)
            {
                await SafeInvokeVoidAsync("setPageSizeOptions", Element, PageSizeOptions);
            }
        }

        /// <summary>
        /// Retrieves the keys of the currently selected rows. The keys are determined by the RowKey property.
        /// </summary>
        /// <returns></returns>
        public async Task<string[]> GetSelectedRowKeysAsync()
        {
            return await SafeInvokeAsync<string[]>("getSelectedRows", Element);
        }

        /// <summary>
        /// Sorts the grid by the specified column.
        /// </summary>
        /// <param name="columnId">The ID of the column to sort</param>
        /// <param name="descending">Indicates whether to sort in descending order</param>
        public async Task SortColumnAsync(string columnId, bool descending)
        {
            await SafeInvokeVoidAsync("sortColumn", Element, columnId, descending);
        }
        /// <summary>
        /// Provide the grid data when ServerSideData is false.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task SetDataAsync(IEnumerable<TItem> items)
        {
            if (ServerSideData)
            {
                throw new InvalidOperationException("SetDataAsync can only be used in client-side mode. In server-side mode, use the OnDataRequest callback to provide data.");
            }
            _currentPageItems = items ?? [];
            await SafeInvokeVoidAsync("setData", Element, _currentPageItems);
            StateHasChanged();
        }

        #endregion
        #region Private Methods

        private string GetRowKeyValue(TItem item)
        {
            if (item is null) return string.Empty;
            var prop = typeof(TItem).GetProperty(RowKey,
                System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            return prop?.GetValue(item)?.ToString() ?? string.Empty;
        }



        #endregion 

    }

    public class GridDataResult<TItem>
    {
        public IEnumerable<TItem> Items { get; set; } = Enumerable.Empty<TItem>();
        public int TotalCount { get; set; }
    }
}
