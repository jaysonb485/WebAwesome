# WAComparison
## WebAwesomeBlazor.Components.WAComparison

```HTML+Razor
    <WAComparison>
        <BeforeContent>

        </BeforeContent>
        <AfterContent>

        </AfterContent>
    </WAComparison>
```

### Description
Compare visual differences between similar content with a sliding panel.

[WebAwesome docs](https://webawesome.com/docs/components/comparison/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| BeforeContent | RenderFragment |  | The content to show in the before panel, usually an img or svg |
| AfterContent | RenderFragment |  | The content to show in the after panel, usually an img or svg |
| DividerPosition | double | 50 | The position of the divider as a percentage. |
| HandleIconName | string |  | The icon used inside the handle. Available names depend on the icon library being used. |
| HandleIcon | [Icon](/docs/IconClass.md) |  | The icon used inside the handle. Alternatively use HandleIconName |
| DividerWidth | string |  | The width of the dividing line in CSS width units. |
| HandleSize | string |  | The size of the compare handle in CSS units. |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| PositionChanged   | Triggered when the position of the divider changes. Provides the new position. |

### Examples

#### Basic Usage with PositionChanged tracking.
```HTML+Razor
<WAComparison PositionChanged="ComparisionChanged">
    <BeforeContent>
        <img src="https://picsum.photos/seed/picsum/200?grayscale" />
    </BeforeContent>
    <AfterContent>
        <img src="https://picsum.photos/seed/picsum/200" />
    </AfterContent>
</WAComparison>

@code {
    void ComparisionChanged(double newPosition)
    {
        Console.WriteLine($"Comparision Changed {newPosition}");
    }
}
```

#### Default dividier posiiton, modified divider and handle.
```HTML+Razor
    <WAComparison DividerPosition="75" DividerWidth="15px" HandleSize="50px" HandleIconName="grip-lines-vertical">
        <BeforeContent>
            <img src="https://picsum.photos/seed/picsum/200?grayscale" />
        </BeforeContent>
        <AfterContent>
            <img src="https://picsum.photos/seed/picsum/200" />
        </AfterContent>
    </WAComparison>
```

![WAComparison](https://github.com/user-attachments/assets/276a61a8-b0c1-4abb-a44b-4789815434dc)