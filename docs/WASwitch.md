# WASwitch
## WebAwesomeBlazor.Components.WASwitch

```HTML+Razor
<WASwitch Label="Switch" />
```

### Description
Switches allow the user to toggle an option on or off.

[WebAwesome docs](https://webawesome.com/docs/components/switch/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string |  | The label for the switch. |
| Value | bool | false | The value of the switch. |
| Size | SwitchSize | SwitchSize.Inherit | The switch's size. |
| Disabled | bool | false | Disables the switch. |
| Hint | string |  | The switch's hint. If you need to display HTML, use the hint slot instead. |

### Examples

#### Basic Usage
```HTML+Razor
<WASwitch Label="Toggle me" Hint="You can switch it on or off" @bind-Value="switchValue" />
```

![WASwitch](https://github.com/user-attachments/assets/f4d71153-ec00-4987-b623-fc798513f50b)