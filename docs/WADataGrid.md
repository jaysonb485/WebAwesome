# WADataGrid
## WebAwesomeBlazor.Components.WADataGrid

```HTML+Razor
<WADataGrid TItem="" />
```

### Description
Data grids display tabular data with sorting, selection, filtering, pinning, tree data, grouping with aggregation, column footers, expandable rows, pagination, CSV export, full keyboard navigation, and virtualization for large datasets.

[Web Awesome docs](https://webawesome.com/docs/component/datagrid)

> [!IMPORTANT]
> WebAwesome charts require access to WebAwesome Pro.

> [!NOTE]
> Not all features from Web Awesome Data Grid have been implemented. Refer to Web Awesome docs and use JS Interop to access features not yet implemented in this component.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| AllowSortRemoval | bool | `false` | Keeps a sorted column always sorted, alternating between ascending and descending. By default, a sorted column's third click clears its sort (the asc → desc → unsorted cycle). |
| Appearance | DataGridAppearance | `Outlined` | The grid's visual appearance. Outlined or plain. |
| CurrentPage | int | `0` | The current page index (0-based). |
| FilterDebounce | int | `250` | How long (in milliseconds) to wait after a search or filter keystroke before requesting data in server mode. Client-side filtering is always immediate. Sort and page changes are never debounced. |
| GroupBy | string[] | `null` | Array of column id(s) to group on. Use column aggregator functions to define other grouped data (e.g. sum, min, max) |
| Label | string | `null` | An accessible label for the grid. |
| MaxMultiSort | int | `0` | The maximum number of columns that can participate in a multi-column sort. 0 (default) means no limit. |
| PageSize | int | `20` | The number of rows per page. |
| Pinnable | bool | `false` | Enables column pinning (and the pin actions in the column menu). Can be overridden per column with pinnable. |
| RowKey | string | `"id"` | The field used as a stable row id for selection. |
| ServerSideData | bool | `false` | Sets the data grid to server-side mode, filters, sorts, and pagination will be handled by the consumer via the OnDataRequest callback. If false (default), all data is loaded into the grid and filtering, sorting, and pagination are handled client-side. |
| ShowPagination | bool | `false` | Enables client-side pagination and the pager footer. |
| Reorderable | bool | `false` | Enables drag-to-reorder for columns (can be overridden per column with movable). |
| Resizable | bool | `false` | Enables drag-to-resize for columns (can be overridden per column). |
| RowSelectionMode | DataGridRowSelection | `None` | Enables row selection. |
| Searchable | bool | `false` | Shows a global search box that filters across all columns. |
| ShowColumnMenus | bool | `false` | Shows a per-column header menu (kebab button) with pin, sort, hide, and autosize actions. |
| ShowColumnVisibilityMenu | bool | `false` | Shows a toolbar menu for toggling column visibility. |
| Size | DataGridSize | `Medium` | The grid's size. Controls the font scale of grid text and form controls, plus row height and cell padding. |
| SortDescendingFirst | bool | `false` | Changes the default sort order for a column's first click to descending. |
| Striped | bool | `false` | Enables striped rows. |
| LoadingTemplate | RenderFragment | `null` | A custom template to show when the grid is loading. |
| EmptyTemplate | RenderFragment | `null` | A custom template to show when the grid has no data. |
| NoResultsTemplate | RenderFragment | `null` | A custom template to show when the grid has no results after filtering. |
| RowDetailsTemplate | RenderFragment | | A custom template to show when a row is expanded. Set context to access underlying row data |
| OnDataRequest | EventCallback\<DataRequestEventArgs> | `null` | An event that is triggered when the grid needs data in server-side mode. The consumer should handle this event and return the requested data. |

#### DataGridRequesArgs Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Sort | IEnumerable\<DataGridColumnSort> | `null` | The sort state of the grid. |
| Filters | string[] | `null` | The filter state of the grid. |
| Search | string | `null` | The search state of the grid. |
| Page | int | `0` | The page index (0-based). |
| PageSize | int | `20` | The page size. |

#### DataGridColumn Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Align | string | `null` | The text alignment for this column. Can be "left", "center", or "right". |
| Aggregation | DataGridColumnAggregation | `null` | Give columns an aggregation (sum, min, max, mean, median, count, unique, uniqueCount, extent, or a custom function) to summarize the group on its row when another column is grouped. |
| Field | string | `null` | The field name in the data source that this column displays. |
| Filterable | bool | `false` | Whether this column can be filtered. |
| FilterType | DataGridColumnFilterType | `DataGridColumnFilterType.Text` | For client-side data, how the filter panel renders. Refer Web Awesome docs. |
| Flex | int | `null` | The flex grow factor for this column. |
| Hidden | bool | `false` | Whether this column is hidden. |
| Hideable | bool | `true` | Whether this column can be hidden. |
| Id | string | `null` | The unique identifier for this column. If not provided, the field name is used. |
| Label | string | `null` | The column header label. If not provided, the field name is used. |
| MinWidth | int | `null` | The minimum width of this column in pixels. |
| Movable | bool | `false` | Whether this column can be moved. |
| Pinnable | bool | `false` | Whether this column can be pinned. |
| PinDirection | DataGridColumnPinDirection | `null` | The pin direction for this column. |
| Resizable | bool | `true` | Whether this column can be resized. |
| Sortable | bool | `true` | Whether this column can be sorted. |
| SortMethod | DataGridColumnSortMethod | `null` | The sort method for this column. |
| Searchable | bool | `true` | Whether this column can be searched. |
| Template | RenderFragment\<TItem> | `null` | A custom template for rendering the cell content of this column. Set Context to access row data. |
| Width | int | `null` | The width of this column in pixels. |

> [!NOTE]
> CSS page styles RowDetailsTemplate and Column Templates sit in the shadow DOM where Web Awesome's loaded cannot see it. Refer to [Web Awesome docs](https://webawesome.com/docs/components/data-grid/#preloading-rendered-components) for component rendering. 

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| GetPageCountAsync |  | Returns the total number of pages based on the current data and page size. (always 1 when paginate is off) |
| SetPageSizeOptions | int[] | Sets the available page size options for the grid. |
| GetSelectedRowKeysAsync | string columnId, bool descending | Sorts the grid by the specified column. |
| SetDataAsync | IEnumerable\<TItem> items | Provide the grid data. When ServerSideMode is false. Enables sorting, filtering, and pagination on the client side. |
| CopySelectedRowsAsync | columnIds: string[]?, includeHeaders: bool = true, format: DataGridCopyFormat = DataGridCopyFormat.Tsv, escapeFormulas: bool = true | Copies the selected rows (or every processed row when nothing is selected) to the clipboard, honoring the active sort, filters, and column visibility/order. The default tab-separated format pastes into spreadsheet cells; format: 'csv' copies comma-separated text instead.|
| SortColumnAsync | columnId: string, descending, bool | Sorts the grid by the specified column. |
| SetColumnFilterOptionsAsync | columnId: string, filterOptions: IEnumerable\<DataGridFilterOptions> | Set the filter options available for server mode data when column filter type is set, include all, or include any. `DataGridFilterOptions`: Value (columnId) of the column, Count of the items for the specified filter value. |
| ExpandAllRowsAsync | | Expands every row (all detail panels, or every branch of a tree). |
| ExpandRowAsync | rowKey: string | Expands the row tithe the given key (its rowKey value) |
| ExportDataAsCsvAsync | fileName: string, columnIds: string[]?, includeHeaders: bool, delimiter: string, EscapeFormulas: bool | Exports the current rows as a CSV file (browser download). Respects the active sort, filters, search, and column visibility/order, and runs each column's formatter. In server mode, only the currently loaded page is exported. |
| ReloadAsync | | Re-runs the current server request (server mode only), even if its parameters haven't changed. Use this function for first load in Server Mode also. |

### Examples

#### Load data
```HTML+Razor
<WADataGrid TItem="PullRequest" RowKey="Id" @ref="PRDataGrid"
    ShowPagination="true" >
    <Columns>
        <DataGridColumn TItem="PullRequest" Field="Title" Label="Title" Sortable="true" Flex="3" MinWidth="180" Filterable="true" />
        <DataGridColumn TItem="PullRequest" Field="Author" Label="Author" Flex="1" MinWidth="130" Filterable="true" />
        <DataGridColumn TItem="PullRequest" Field="State" Label="State" Width="120">
            <Template Context="pr">
                <wa-badge variant="@GetStateVariant(pr.State)" appearance="filled">
                    @pr.Author
                </wa-badge>
            </Template>
        </DataGridColumn>
        <DataGridColumn TItem="PullRequest" Id="Actions" Label="Actions" Align="right" Width="140">
            <Template Context="pr">
                <button class="btn btn-sm btn-outline-primary" @onclick="() => ApproveRequest(pr)">
                    Approve
                </button>
            </Template>
        </DataGridColumn>
    </Columns>
    <LoadingTemplate>
        <WASpinner Size="4rem;" />
    </LoadingTemplate>
    <EmptyDataTemplate>
        <div class="wa-stack">
            <WAIcon IconName="ghost" />
            <p>No data available</p>
        </div>
    </EmptyDataTemplate>
    <NoResultsTemplate>
        <div class="wa-stack">
            <WAIcon IconName="search" />
            <p>No results found</p>
        </div>
    </NoResultsTemplate>
</WADataGrid>

@code {
    WADataGrid<PullRequest> PRDataGrid = default!;

    public class PullRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string State { get; set; } = "";
    }

    protected override async Task OnParametersSetAsync()
    {
        var data = await GetPRData(); /// Get data from database.

        await PRDataGrid.SetDataAsync(data);
    }
}
```

#### Server-side data, Row Details and filtering example
```HTML+Razor

<WADataGrid TItem="PullRequest" RowKey="Id" @ref="PRDataGrid" Pinnable="true" RowSelectionMode="DataGridRowSelection.Multiple"
            ShowPagination="true" ServerSideData="true" OnDataRequest="LoadGridDataAsync" group-by="Author">
    <Columns>
        <DataGridColumn TItem="PullRequest" Field="Title" Label="Title" Sortable="true" Flex="3" MinWidth="180" Filterable="true" />
        <DataGridColumn TItem="PullRequest" Field="Created" Label="Created" Sortable="true" Filterable="true" FilterType="DataGridColumnFilterType.DateRange" />
        <DataGridColumn TItem="PullRequest" Field="Author" Pinnable="true" PinDirection="DataGridColumnPinDirection.Left" Label="Author" Flex="1" MinWidth="130" Filterable="true" FilterType="DataGridColumnFilterType.Set" />
        <DataGridColumn TItem="PullRequest" Field="State" Label="State" Width="120" Filterable="true" FilterType="DataGridColumnFilterType.Set" FilterOptions="StateOptions">
            <Template Context="pr">
                <wa-badge appearance="filled">
                    @pr.State
                </wa-badge>
            </Template>
        </DataGridColumn>

        <DataGridColumn TItem="PullRequest" Id="Actions" Label="Actions" Align="right" Width="140" Field="">
            <Template Context="pr">
                <WAButton >
                    Approve
                </WAButton>
            </Template>
        </DataGridColumn>
    </Columns>
    <LoadingTemplate>
        <WASpinner Size="4rem;" />
    </LoadingTemplate>
    <EmptyDataTemplate>
        <div class="wa-stack">
            <WAIcon IconName="ghost" />
            <p>No data available</p>
        </div>
    </EmptyDataTemplate>
    <NoResultsTemplate>
        <div class="wa-stack">
            <WAIcon IconName="search" />
            <p>No results found</p>
        </div>
    </NoResultsTemplate>
   <RowDetailTemplate Context="pr">
        <div class="wa-grid" style="--min-column-size: 14ch; gap: var(--wa-space-l);">
            <div>
                <small style="color: var(--wa-color-text-quiet);">Author</small><br />
                <strong>@pr.Author</strong>
            </div>
            <div><small style="color: var(--wa-color-text-quiet);">State</small><br />@pr.State</div>
            <div style="grid-column: 1 / -1;">
                <small style="color: var(--wa-color-text-quiet);">Title</small><br />@pr.Title

            </div>

        </div>
    </RowDetailTemplate>
</WADataGrid>


@code
{
    WADataGrid<PullRequest> PRDataGrid = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await PRDataGrid.ReloadAsync();
        }
    }

    public class PullRequest
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Title { get
            {
                return $"Mock request - {Author} - {State}";
            } 
        }
        public string Author { get; set; } = "";
        public string State { get; set; } = "";
    }

    List<PullRequest> prData { get; set; } = default!;
    IEnumerable<DataGridColumnFilterOptions> StateOptions { get; set; } = default!;

    async Task copyRows()
    {
        var rows = await PRDataGrid.CopySelectedRowsAsync();
        await ToastService.CreateAsync(new ToastMessage { Message = $"Copied {rows} rows." });
    }

    private async Task<GridDataResult<PullRequest>> LoadGridDataAsync(DataGridDataRequestArgs args)
    {
        await Task.Delay(1000); // Simulate network latency

        // Get data if we haven't previously
        prData ??= await GetPRData();

        //Apply any column filters from the data request
        var filteredData = ApplyFilters(prData, args.Filters);

        //Select the items from the page args
        var pagedItems = filteredData
            .Skip((args.Page) * args.PageSize)
            .Take(args.PageSize)
            .ToList();

        return new GridDataResult<PullRequest>
        {
            Items = pagedItems,
            TotalCount = filteredData.Count()
        };
    }

    async Task<List<PullRequest>> GetPRData()
    {
        var rnd = new Random();
        var authors = new[] { "Jay", "Alex", "Morgan", "Sam", "Taylor", "Jordan" };
        var states = new[] { "open", "closed", "merged" };

        List<PullRequest> pullRequests =
            Enumerable.Range(1, 200)
                .Select(i => new PullRequest
                {
                    Id = i,
                    Created = DateTime.UtcNow.AddDays(-rnd.Next(0, 365)),
                    Author = authors[rnd.Next(authors.Length)],
                    State = states[rnd.Next(states.Length)]
                })
                .ToList();

        // Set the values for the State column filter set and their counts
        await PRDataGrid.SetColumnFilterOptionsAsync("State", pullRequests
        .GroupBy(pr => pr.State)
        .Select(g => new DataGridColumnFilterOptions
        {
            Value = g.Key,
            Count = g.Count()
        }));

        return pullRequests;
    }

    public IEnumerable<PullRequest> ApplyFilters(
        IEnumerable<PullRequest> source,
        IEnumerable<DataGridColumnFilter>? filters)
    {
        if (filters is null) return source;

        foreach (var filter in filters)
        {
            var values = filter.Value;

            if (filter.Id == "Author")
            {
                source = source.Where(pr =>
                    values.Contains(pr.Author, StringComparer.OrdinalIgnoreCase));
            }
            else if (filter.Id == "State")
            {
                source = source.Where(pr =>
                    values.Contains(pr.State, StringComparer.OrdinalIgnoreCase));
            }
            else if (filter.Id == "Title")
            {
                source = source.Where(pr =>
                    values.Any(v => pr.Title.Contains(v, StringComparison.OrdinalIgnoreCase)));
            }
            else if (filter.Id == "Created")
            {
                //Ensure valid filter - If a column filter is a dateRange type, there should always be two values in the array.
                if(values.Count() == 2)
                {
                    //Check if the first value (start date) is a valid date and apply the filter
                    if(DateTime.TryParse(values[0], out var start))
                        source = source.Where(pr => pr.Created >= start);

                    //Check if the second value (end date) is a valid date and apply the filter
                    if (DateTime.TryParse(values[1], out var end))
                        source = source.Where(pr => pr.Created <= end);
                }
            }
        }

        return source;
    }

}

```