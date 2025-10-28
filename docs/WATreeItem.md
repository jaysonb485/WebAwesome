# WATreeItem
## WebAwesomeBlazor.Components.WATreeItem

```HTML+Razor
<WATree >
    <WATreeItem></WATreeItem>
</WATree>
```

### Description
A tree item serves as a hierarchical node that lives inside a [WATree](/docs/WATree.md).

[WebAwesome docs](https://webawesome.com/docs/components/tree-item/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Expanded | bool | false | Expands the tree item. |
| Disabled | bool | false | Disables the tree item. |
| ShowDuration | string | `200ms` | The animation duration when expanding tree items. |
| HideDuration | string | `200ms` | The animation duration when collapsing tree items. |
| Value | string |  |  The value of the tree item. The value will be passed when selection chage is emitted on the WATree |

### Examples

#### Basic Usage
```HTML+Razor
<WATree SelectionChanged="treeSelectionChanged" Selection="TreeSelection.Multiple" >
    <WATreeItem Value="item1">Item 1</WATreeItem>
        <WATreeItem Value="item2">Item 2
            <WATreeItem Value="item2a">Item 2A</WATreeItem>
            <WATreeItem Value="item2b">Item 2B</WATreeItem>
        </WATreeItem>
        <WATreeItem Value="item3" Disabled="true">Item 3</WATreeItem>
        <WATreeItem Value="item4" Expanded="true">Item 4
            <WATreeItem Value="item4a">Item 4a</WATreeItem>
            <WATreeItem Value="item4b">Item 4b</WATreeItem>
        </WATreeItem>
</WATree>

Selected: @String.Join(" ", selectedValues)

@code {
    string[] selectedValues { get; set; } = [];

    void treeSelectionChanged(string[] values)
    {
        selectedValues = values;
    }
}
```

![WATree](https://github.com/user-attachments/assets/688b1c96-1688-41c7-a677-c4d4559e42f8)