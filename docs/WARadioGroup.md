# WARadioGroup
## Vengage.WebAwesome.Components.WARadioGroup

```HTML+Razor
<WARadioGroup>
	<WARadioOption />
	<WARadioOption />
</WARadioGroup>
```

### Description
Radio groups are used to group multiple [WARadioOption](/docs/WARadioOption) components so they function as a single form control.

[WebAwesome docs](https://webawesome.com/docs/components/radio-group/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| TValue | type |  |  |
| Value | TValue |  | The current value of the radio group, submitted as a name/value pair with form data. |
| Label | string? |  |  A custom label for assistive devices. |
| Size | RadioGroupSize | RadioGroupSize.Inherit | The radio group's size. This size will be applied to all child radios and radio buttons, except when explicitly overridden. |
| Hint | string |  | The radio groups's hint. |
| Orientation | RadioGroupOrientation | RadioGroupOrientation.Vertical | The orientation in which to show radio items. |
| Required | bool | false | Ensures a child radio is checked before allowing the containing form to submit. |
| Disabled | bool | false | Disables the radio group and all child radios. |

### Examples

#### Basic Usage
```HTML+Razor
<WARadioGroup TValue="string" @bind-Value="selectedOption" Label="Select a bird" Hint="It can be any.">
    <WARadioOption TItem="string" Value="@("Goose")">Goose</WARadioOption>
    <WARadioOption TItem="string" Value="@("Turkey")">Turkey</WARadioOption>
    <WARadioOption TItem="string" Value="@("Magpie")">Magpie</WARadioOption>
</WARadioGroup>
```

#### Horizontal layout
```HTML+Razor
<WARadioGroup TValue="string" @bind-Value="selectedOption" Orientation="RadioGroupOrientation.Horizontal" Label="Select a bird" Hint="It can be any.">
    <WARadioOption TItem="string" Value="@("Goose")">Goose</WARadioOption>
    <WARadioOption TItem="string" Value="@("Turkey")">Turkey</WARadioOption>
    <WARadioOption TItem="string" Value="@("Magpie")">Magpie</WARadioOption>
</WARadioGroup>
```

![WARadioGroup](https://github.com/user-attachments/assets/3a9b941a-6e21-4b23-934d-38eb3c0e18e2)