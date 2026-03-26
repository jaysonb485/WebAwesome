# WAColorPicker
## WebAwesomeBlazor.Components.WAColorPicker

```HTML+Razor
<WAComponoentName prop1="value1" prop2="value2" />
```

### Description
Color pickers allow the user to select a color.

[WebAwesome docs](https://webawesome.com/docs/components/color-picker/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value    | string |  | The current value of the color picker. The value's format will vary based the format attribute. To get the value in a specific format, use the GetFormattedValueAsync() method.                     |
| Label    | string |        | The color picker's label.                     |
| Hint    | string |    | The color picker's hint                 |
| ColorFormat | PickerColorFormat | PickerColorFormat.Hex | The format to use. If opacity is enabled, these will translate to HEXA, RGBA, HSLA, and HSVA respectively. The color picker will accept user input in any format (including CSS color names) and convert it to the desired format.
| Size | PickerSize | PickerSize.Inherit | Determines the size of the color picker's trigger |
| AllowFormatSelector | bool | true | Shows the button that lets users toggle between formats. Default is true. |
| Disabled | bool | false | Disables the color picker. | 
| ShowOpacitySlider | bool | false | Shows the opacity slider. Enabling this will cause the formatted value to be HEXA, RGBA, or HSLA. |
| UppercaseValues | bool | false | By default, values are lowercase. With this attribute, values will be uppercase instead. |
| Swatches | string | | One or more predefined color swatches to display as presets in the color picker. Can include any format the color picker can parse, including HEX(A), RGB(A), HSL(A), HSV(A), and CSS color names. Each color must be separated by a semicolon (;). <br/> For accessibility, use `SetSwatchesAsync` instead and provide labels for the swatches. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| GetFormattedValueAsync  | colorFormat: PickerColorExtendedFormat   | Returns the value as a string in the specified format.      |
| SetSwatchesAsync | swatches: SwatchColor | Sets color swatches with accessible labels to display as presets in the color picker. |

### Examples

#### Basic Usage
```HTML+Razor
<WAColorPicker @bind-Value="pickerValue" ColorFormat="PickerColorFormat.RGB" Label="Pick a color" />
```

#### Advanced Usage
```HTML+Razor
<WAColorPicker @bind-Value="pickerValue"
    ColorFormat="PickerColorFormat.HSL"
    AllowFormatSelector="false"
    Label="Pick an HSL color with opacity"
    ShowOpacitySlider="true" />
```
<img width="616" height="407" alt="image" src="https://github.com/user-attachments/assets/ff28ecf8-21e0-4bc4-9cf6-4d15259241eb" />

### Set color swatches
```HTML+Razor
<WAColorPicker @ref="ColorPicker" Label="Choose a color" />

@code
{
    WAColorPicker ColorPicker = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await ColorPicker.SetSwatchesAsync(new SwatchColor[]
                {
                     new SwatchColor{ Color = "#ff0000", Label = "Red"},
                     new SwatchColor{ Color = "#00ff00", Label = "Green"},
                     new SwatchColor{ Color = "#0000ff", Label = "Blue"},
                     new SwatchColor{ Color = "#ffffff", Label = "White"}
                });
        }
    }
}
