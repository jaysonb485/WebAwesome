# WAFormatBytes
## WebAwesomeBlazor.Components.WAFormatBytes

```HTML+Razor
<WAFormatBytes Value="" />
```

### Description
Formats a number as a human readable bytes value.

[WebAwesome docs](https://webawesome.com/docs/components/format-bytes/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value | int | 0 | The number to format in bytes. |
| Display | FormatBytesDisplay | FormatBytesDisplay.Short |  Determines how to display the result, e.g. "100 bytes", "100 b", or "100b". |
| Unit | FormatBytesUnit | FormatBytesUnit.Byte | The type of unit to display (Byte or Bit). |
| Culture | CultureInfo | CultureInfo.CurrentCulture | Used to set the desired locale. |

### Examples

#### Basic Usage
```HTML+Razor
<WAFormatBytes Value="1000" />
```

#### Bits, long display
```HTML+Razor
<WAFormatBytes Value="1000" Unit="" Display="" />
```

![WAFormatBytes](https://github.com/user-attachments/assets/98bdc4e6-b524-4148-95b0-65b2cdad360e)