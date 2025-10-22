# WACopyButton
## Vengage.WebAwesome.Components.WACopyButton

```HTML+Razor
<WACopyButton Value="Text to copy" />
```

### Description
Copies text data to the clipboard when the user clicks the trigger.

[WebAwesome docs](https://webawesome.com/docs/components/copy-button/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value    | string |  | The text value to copy.                     |
| FromElementId | string |  | An id that references an element in the same document from which data will be copied. If both this and value are present, this value will take precedence. <br /> By default, the target element's textContent will be copied. Specify an alternate attribute using FromElementAttribute. |
| FromElementAttribute | string |  | The attribute name of the element referenced by FromElementId from which to copy data. If not specified, the target element's textContent will be copied. |
| HoverLabel | string | "Copy" | A custom label to show in the tooltip. |
| SuccessLabel | string | "Copied" | A custom label to show in the tooltip after copying. |
| ErrorLabel | string | "Not supported" | A custom label to show in the tooltip when a copy error occurs. |
| Icon | Icon | Icons.Copy | The icon to show in the default copy state. Defaults to FontAwesome copy icon. |
| SuccessIcon | Icon | Icons.Check | The icon to show when the content is copied. Defaults to FontAwesome check icon. |
| ErrorIcon | Icon | Icons.XMark | The icon to show when a copy error occurs. Defaults to FontAwesome xmark icon. |
| IconName | string |  | The icon to show in the default copy state. |
| SuccessIconName | string | | The icon to show when the content is copied. |
| ErrorIconName | string |   | The icon to show when a copy error occurs  |
| Disabled | bool  | false  | Disables the copy button.  |
| FeedbackDuration  | int  | 1000 | The length of time to show feedback before restoring the default trigger.  |
| TooltipPlacement  | CopyButtonTooltipPlacement  |  CopyButtonTooltipPlacement.Top | The preferred placement of the tooltip.  |


### Examples

#### Basic Usage
```HTML+Razor
<WACopyButton Value="Text to copy" />
```

#### Copy from text value ofanother element.
```HTML+Razor
<div class="wa-cluster wa-gap-0">
    <WAInput Id="TextToCopyInputBox" />
    <WACopyButton FromElementId="TextToCopyInputBox" FromElementAttribute="value" HoverLabel="Copy from the text box" />
</div>
```
<img width="337" height="128" alt="image" src="https://github.com/user-attachments/assets/1c4b645e-ffc1-4a97-af82-6f4bd29d2a48" />
