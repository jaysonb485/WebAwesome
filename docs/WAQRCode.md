# WAQRCode
## WebAwesomeBlazor.Components.WAQRCode

```HTML+Razor
<WAQRCode Value="" />
```

### Description
Generates a QR code and renders it using the Canvas API.

[WebAwesome docs](https://webawesome.com/docs/components/qr-code/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value | string |  | The QR code's value. |
| Label | string |  | The label for assistive devices to announce. If unspecified, the value will be used instead. |
| Size | int | 128 | The size of the QR code, in pixels. Default is 128. |
| FillColor | string |  | The fill color. This can be any valid CSS color, but not a CSS custom property. |
| BackgroundColor | string |  | The background color. This can be any valid CSS color or transparent. It cannot be a CSS custom property. |
| Radius | double | 0 | The edge radius of each module. Must be between 0 and 0.5. |
| ErrorCorrection | QRCodeErrorCorrection | QRCodeErrorCorrection.H | The level of error correction to use. |

### Examples

#### Basic Usage
```HTML+Razor
<WAQRCode Value="https://webawesome.com/docs/components/qr-code/" />
```

#### Colors, size and radius
```HTML+Razor
<WAQRCode Value="https://webawesome.com/docs/components/qr-code/" ErrorCorrection="QRCodeErrorCorrection.L" FillColor="darkblue" BackgroundColor="skyblue" Radius="0.5" Size="256" />
```

![WAQRCode](https://github.com/user-attachments/assets/df0f17a5-d04f-484f-82a6-62684e1f96a2)