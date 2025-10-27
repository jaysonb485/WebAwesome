# WARadioOption
## WebAwesomeBlazor.Components.WARadioOption

```HTML+Razor
<WARadioGroup>
	<WARadioOption />
	<WARadioOption />
</WARadioGroup>
```

### Description
Radio option allow the user to select a single option from a [WARadioGroup](/docs/WARadioGroup).

[WebAwesome docs](https://webawesome.com/docs/components/radio/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| TItem | Type |  |  |
| Value | TItem |  | The option's value. When selected, the radio group will receive this value |
| Label | string |  | The option's label |
| Disabled | bool | false | Disables the option |
| Size | RadioSize | RadioSize.Inherit | The options's size. When used inside a radio group, the size will be determined by the radio group's size so this attribute can typically be omitted. |
| Appearance | RadioAppearance | RadioAppearance.Default | The appearance of the option. |


### Examples

#### Basic Usage
```HTML+Razor
<WARadioGroup TValue="string" @bind-Value="selectedOption" Label="Select a bird" Hint="It can be any.">
    <WARadioOption TItem="string" Value="@("Goose")">Goose</WARadioOption>
    <WARadioOption TItem="string" Value="@("Turkey")">Turkey</WARadioOption>
    <WARadioOption TItem="string" Value="@("Magpie")">Magpie</WARadioOption>
</WARadioGroup>
```

#### Buttons and disabled option
```HTML+Razor
<WARadioGroup TValue="string" @bind-Value="selectedOption" Label="Select an option" Hint="It can be any." Orientation="RadioGroupOrientation.Horizontal">
    <WARadioOption TItem="string" Value="@("Disabled")" Appearance="RadioAppearance.Button" Disabled="true">Disabled option</WARadioOption>
    <WARadioOption TItem="string" Value="@("Turkey")" Appearance="RadioAppearance.Button">Appearance: Button</WARadioOption>
    <WARadioOption TItem="string" Value="@("Magpie")" Appearance="RadioAppearance.Button">Also button</WARadioOption>
</WARadioGroup>
```

![WARadioOption](https://github.com/user-attachments/assets/757f28e4-d27a-4691-96e1-02c86850c78d)