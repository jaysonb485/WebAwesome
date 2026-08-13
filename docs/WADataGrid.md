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
| OnDataRequest | EventCallback<DataRequestEventArgs> | `null` | An event that is triggered when the grid needs data in server-side mode. The consumer should handle this event and return the requested data. |

#### DataGridRequesArgs Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Sort | IEnumerable<DataGridColumnSort> | `null` | The sort state of the grid. |
| Filters | string[] | `null` | The filter state of the grid. |
| Search | string | `null` | The search state of the grid. |
| Page | int | `0` | The page index (0-based). |
| PageSize | int | `20` | The page size. |

#### DataGridColumn Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Field | string | `null` | The field name in the data source that this column displays. |
| Id | string | `null` | The unique identifier for this column. If not provided, the field name is used. |
| Label | string | `null` | The column header label. If not provided, the field name is used. |
| Sortable | bool | `true` | Whether this column can be sorted. |
| SortMethod | DataGridColumnSortMethod | `null` | The sort method for this column. |
| Searchable | bool | `true` | Whether this column can be searched. |
| Filterable | bool | `false` | Whether this column can be filtered. |
| Hidden | bool | `false` | Whether this column is hidden. |
| Hideable | bool | `true` | Whether this column can be hidden. |
| Resizable | bool | `true` | Whether this column can be resized. |
| Movable | bool | `false` | Whether this column can be moved. |
| Pinnable | bool | `false` | Whether this column can be pinned. |
| PinDirection | DataGridColumnPinDirection | `null` | The pin direction for this column. |
| Flex | int | `null` | The flex grow factor for this column. |
| Width | int | `null` | The width of this column in pixels. |
| MinWidth | int | `null` | The minimum width of this column in pixels. |
| Align | string | `null` | The text alignment for this column. Can be "left", "center", or "right". |
| Template | RenderFragment<TItem> | `null` | A custom template for rendering the cell content of this column. Set Context to access row data. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| GetPageCountAsync |  | Returns the total number of pages based on the current data and page size. (always 1 when paginate is off) |
| SetPageSizeOptions | int[] | Sets the available page size options for the grid. |
| GetSelectedRowKeysAsync | string columnId, bool descending | Sorts the grid by the specified column. |
| SetDataAsync | IEnumerable<TItem> items | Provide the grid data. When ServerSideMode is false. Enables sorting, filtering, and pagination on the client side. |

### Examples

#### Load data
```HTML+Razor
<WADataGrid TItem="PullRequest" RowKey="Id" @ref="PRDataGrid"
    ShowPagination="true" >
    <Columns>
        <DataGridColumn TItem="PullRequest" Field="title" Label="Title" Sortable="true" Flex="3" MinWidth="180" Filterable="true" />
        <DataGridColumn TItem="PullRequest" Field="author" Label="Author" Flex="1" MinWidth="130" Filterable="true" />
        <DataGridColumn TItem="PullRequest" Field="state" Label="State" Width="120">
            <Template Context="pr">
                <wa-badge variant="@GetStateVariant(pr.State)" appearance="filled">
                    @pr.Author
                </wa-badge>
            </Template>
        </DataGridColumn>
        <DataGridColumn TItem="PullRequest" Id="actions" Label="Actions" Align="right" Width="140">
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

#### Server-side data.
```HTML+Razor
<WADataGrid TItem="PullRequest" RowKey="Id" @ref="PRDataGrid"
    ShowPagination="true" ServerSideMode="true" OnDataRequest="DataRequested" >
    <Columns>
        <DataGridColumn TItem="PullRequest" Field="title" Label="Title" Sortable="true" Flex="3" MinWidth="180" Filterable="true" />
        <DataGridColumn TItem="PullRequest" Field="author" Label="Author" Flex="1" MinWidth="130" Filterable="true" />
        <DataGridColumn TItem="PullRequest" Field="state" Label="State" Width="120">
            <Template Context="pr">
                <wa-badge variant="@GetStateVariant(pr.State)" appearance="filled">
                    @pr.Author
                </wa-badge>
            </Template>
        </DataGridColumn>

        <DataGridColumn TItem="PullRequest" Id="actions" Label="Actions" Align="right" Width="140">
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

@code 
{
    WADataGrid<PullRequest> PRDataGrid = default!;

    public class PullRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string State { get; set; } = "";
    }

        private async Task<GridDataResult<PullRequest>> LoadGridDataAsync(DataGridDataRequestArgs args)
    {
        await Task.Delay(1000); // Simulate network latency

        var prData = await GetPRData();
        var pagedItems = prData
            .Skip((args.Page) * args.PageSize)
            .Take(args.PageSize)
            .ToList();

        // Apply other filters and sorting per event args.

        return new GridDataResult<PullRequest>
        {
            Items = pagedItems,
            TotalCount = prData.Count
        };
    }
}
```