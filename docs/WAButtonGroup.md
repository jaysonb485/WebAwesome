# WAButtonGroup
## WebAwesomeBlazor.Components.WAButtonGroup

```HTML+Razor
    <WAButtonGroup Label="Action buttons">
        <WAButton>Action one</WAButton>
        <WAButton>Action two</WAButton>
        <WAButton>Action three</WAButton>
    </WAButtonGroup>
```

### Description
Button groups can be used to group related buttons into sections.

[WebAwesome docs](https://webawesome.com/docs/components/button-group/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label    | string |  | A label to use for the button group. This won't be displayed on the screen, but it will be announced by assistive devices when interacting with the control and is strongly recommended.                     |
| Variant    | ButtonGroupVariant | ButtonGroupVariant.Neutral       | The button group's theme variant. Defaults to neutral if not within another element with a variant.                     |
| Orientation    | ButtonGroupOrientation | ButtonGroupOrientation.Horizontal   | The button group's orientation.                     |

### Examples

#### Basic Usage
```HTML+Razor
    <WAButtonGroup Label="Action buttons">
        <WAButton>Action one</WAButton>
        <WAButton>Action two</WAButton>
        <WAButton>Action three</WAButton>
    </WAButtonGroup>
```

#### Vertical group
```HTML+Razor
    <WAButtonGroup Label="Brand action buttons" 
        Orientation="ButtonGroupOrientation.Vertical" 
        Variant="ButtonGroupVariant.Brand">
        <WAButton>Action one</WAButton>
        <WAButton Disabled="true">Disabled action</WAButton>
        <WAButton Loading="true">Loading action</WAButton>
        <WAButton Variant="ButtonVariant.Success">Success variant</WAButton>
    </WAButtonGroup>
```

<img width="555" height="193" alt="image" src="https://github.com/user-attachments/assets/9b0b1c5e-e8cf-4427-8364-42e83664f25c" />
