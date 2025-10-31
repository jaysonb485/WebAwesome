# WATree
## WebAwesomeBlazor.Components.componentname

```HTML+Razor
<WATree >
    <WATreeItem></WATreeItem>
</WATree>
```

### Description
Trees allow you to display a hierarchical list of selectable [WATreeItem](/docs/WATreeItem.md). Items with children can be expanded and collapsed as desired by the user.

[WebAwesome docs](https://webawesome.com/docs/components/tree/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| SelectionMode | TreeSelection | TreeSelection.Single | The selection behavior of the tree. Single selection allows only one node to be selected at a time. Multiple displays checkboxes and allows more than one node to be selected. Leaf allows only leaf nodes to be selected. |
| IndentSize | string |  | The size of the indentation for nested items. |
| IndentGuideColor | string |  | The color of the indentation line. |
| IndentGuideOffset | string |  | The amount of vertical spacing to leave between the top and bottom of the indentation line's starting position. |
| IndentGuideStyle | TreeIndentStyle | TreeIndentStyle.Solid | The style of the indentation line, e.g. solid, dotted, dashed. |
| IndentGuideWidth | string | `0px` | The width of the indentation line. Defaults to 0px. |
| ExpandIconName | string |  | The icon to show when the tree item is expanded. Available names depend on the icon library being used. |
| ExpandIcon |  | [Icon](/docs/IconClass.md) | The icon to show when the tree item is expanded. |
| CollapseIconName | string |  | The icon to show when the tree item is collapsed. Available names depend on the icon library being used. |
| CollapseIcon | [Icon](/docs/IconClass.md) |  | The icon to show when the tree item is collapsed |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| SelectionChanged   | Emitted when a tree item is selected or deselected. Provides array list of tree item values. Requires value property set on each tree item. |


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