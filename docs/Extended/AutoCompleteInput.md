# AutoCompleteInput<TValue>
## WebAwesomeBlazor.Extended.AutoCompleteInput

```HTML+Razor
<AutoCompleteInput TValue="string" Value="" SearchFunction="" AddNewItemFunction="" /> 
```

### Description
AutoCompleteInput combines a text input with a dropdown list of suggestions that appear as the user types. It allows users to quickly find and select from a list of options, improving the user experience in forms and search fields.
Define the search function to look up and present options to the user and optionally the add new item function to customize the behavior of the component.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| TValue | type |  | The type of the selected value |
| SearchFunction | Func |  | The function that will be called to return a `List<TValue>` to present to the user in the drop down |
| MinimumSearchLength | int  | 3 | The minimum number of characters required before the search function is called |
| AddNewItemFunction | Func  |  | The function that will be called when the user adds a new item |
| LoadingText | string  | "Loading..." | The text to display while loading search results |
| EmptyText | string  | "Nothing found" | The text to display when no search results are found |
| Label | string  |  | The label for the autocomplete input |
| Placeholder | string  | "Search..."  | The placeholder text for the autocomplete input |
| Hint | string  |  | The hint text for the autocomplete input |
| ItemNameProperty | string  |  | The name of the property on TItem to use as the display text in the dropdown |
| ItemValueProperty | string  |  | The name of the property on TItem to use as the value |
| AllowNewItems | bool  | false | Whether to allow users to add new items that are not in the search results |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetFocus |  | Sets focus to the input element. |
| SetFocusAsync |  | Sets focus to the input element. |

### Examples

#### Basic Usage
```HTML+Razor
<AutoCompleteInput TValue="Fruit"
            Label="Select a fruit"
            @bind-Value="selectedFruit"
            MinimumSearchLength="3"
            ItemNameProperty="Name"
            ItemValueProperty="Id"
            SearchFunction="SearchFruit"
            AddNewItemFunction="NewFruitSelected"
            AllowNewItems="true" />


@code {
    Fruit selectedFruit { get; set; }
    IList<Fruit> AllFruits = new List<Fruit>
    {
        new Fruit { Id = 1, Name = "Apple" },
        new Fruit { Id = 2, Name = "Banana" },
        new Fruit { Id = 3, Name = "Orange" },
        new Fruit { Id = 4, Name = "Mango" },
        new Fruit { Id = 5, Name = "Pineapple" },
        new Fruit { Id = 6, Name = "Grapes" },
        new Fruit { Id = 7, Name = "Strawberry" },
        new Fruit { Id = 8, Name = "Watermelon" },
        new Fruit { Id = 9, Name = "Peach" },
        new Fruit { Id = 10, Name = "Cherry" }
    };

    Task<List<Fruit>> SearchFruit(string searchText)
    {
        var results = AllFruits
            .Where(f => f.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            .ToList();
        return Task.FromResult(results);
    }

    Task<Fruit> NewFruitSelected(string newItemText)
    {
        var newFruit = new Fruit
        {
            Id = AllFruits.Max(f => f.Id) + 1,
            Name = newItemText
        };
        AllFruits.Add(newFruit);
        return Task.FromResult(newFruit);
    }


    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
```