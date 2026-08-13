# WAPagination
## WebAwesomeBlazor.Components.WAPagination

```HTML+Razor
<WAPagination TotalItems="99" />
```

### Description
Pagination splits long lists of content into pages, letting users navigate between them.

[WebAwesome docs](https://webawesome.com/docs/components/pagination/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Appearance | PaginationAppearance | PaginationAppearance.Outlined | The pagination's visual appearance. Valid options are: Filled, Outlined, Plain. |
| BoundaryCount | int | 3 | The number of boundary pages to display at the beginning and end of the pagination. |
| Disabled | bool | false | Whether the pagination is disabled. |
| Format | PaginationFormat | PaginationFormat.Standard | The pagination's layout format. Valid options are: Standard, Compact. |
| HideSinglePage | bool | false | Whether to hide the pagination when there is only one page. |
| LinkTemplate | string | | A URL template used to render page items as links instead of buttons. When set, items render as <a> elements. Provide a string with {page} as a placeholder for the page number, e.g. /products?page={page}. 
| Label | string |  | The label for the pagination component, used for accessibility. |
| Page | int | 1 | The current page number. |
| PageSize | int | 10 | The number of items to display per page. |
| SiblingCount | int | 1 | The number of sibling pages to display on each side of the current page. |
| TotalItems | int | 0 | The total number of items across all pages. |
| ShowEdgeButtons | bool | false | Whether to show the first and last page buttons. |
| ShowNavButtons | bool | true | Whether to show the previous and next page buttons. |
| ShowSummary | bool | false | Whether to display a summary of the current page and total items. |
| FirstIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the first slot. Alternatively, use FirstIconName to specify the name of the icon. |
| FirstIconName    | string  |       |The name of the icon to draw in the first slot. Available names depend on the icon library being used.  |
| LastIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the last slot. Alternatively, use LastIconName to specify the name of the icon. |
| LastIconName    | string  |       |The name of the icon to draw in the last slot. Available names depend on the icon library being used.  |
| NextIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the next slot. Alternatively, use NextIconName to specify the name of the icon. |
| NextIconName    | string  |       |The name of the icon to draw in the next slot. Available names depend on the icon library being used.  |
| PreviousIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the previous slot. Alternatively, use PreviousIconName to specify the name of the icon. |
| PreviousIconName    | string  |       |The name of the icon to draw in the previous slot. Available names depend on the icon library being used.  |
| PageChanged | EventCallback<PaginationPageChangedEventArgs> |  | Triggered when the page number changes. Provides page number and page size |

### Examples

#### Basic Usage
```HTML+Razor
<WAPagination TotalItems="99" />

```
#### Detect page changes
```HTML+Razor
<WAPagination TotalItems="99" PageChanged="@OnPageChanged" />

@code {
	private void OnPageChanged(PaginationPageChangedEventArgs args)
	{
		Console.WriteLine($"Page changed to {args.Page}, Page size: {args.PageSize}");
		// You can use args.Page and args.PageSize to fetch new data for the selected page.
	}
}
```