# WAAccordionItem
## WebAwesomeBlazor.Components.WAAccordionItem

```HTML+Razor
<WAAccordion>
	<WAAccordionItem Label="Accordion Item 1">
		<p>This is the content of Accordion Item 1.</p>
	</WAAccordionItem>
</WAAccordion>
```

### Description
Accordion items are used inside [WAAccordion](/docs/WAAccordion.md) to create expandable sections with accessible headers.

[Web Awesome docs](https://webawesome.com/docs/components/accordion-item)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Disabled | bool | `false` | Disabled the accordion item so it can't be toggled.  |
| DividerColor | string | | The color of the divider between accordion items. Defaults to `var(--wa-color-surface-border)`.|
| Easing | string | `ease` | The easing of the expand / collapse animation. |
| Expanded | bool | `false` | Expands the accordion item. |
| HideDuration | string | `200ms` | The duration of the collpase animation. |
| Icon | WAIcon | | The icon to draw for the expand/collapse indicator.  Alternatively used IconName. |
| IconName | string | | The name of the icon to draw for the expand/collapse indicator. Available names depend on the icon library being used. |
| Label | string |  | The text label shown in the header. |
| ShowDuration | string | `200ms` | The duration of the expand animation. |
| Spacing | string | | The amount of space in CSS units around and between the item's header and content. Defaults to `var(--wa-space-m)`. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| CollapseAsync  | | Collapses the accordion item with animation. |
| ExpandAsync | | Expands the accordion item with animation. |
| FocusAsync | FocusOptions: focusOptions | Focuses the accordion item's trigger button. |
| ToggleAsync | | Toggles the accordion item's expanded state with animation. |


### Examples

#### Basic Usage
```HTML+Razor
<WAAccordion>
	<WAAccordionItem Label="Accordion Item 1">
		<p>This is the content of Accordion Item 1.</p>
	</WAAccordionItem>
	<WAAccordionItem Label="Accordion Item 2 Disabled" Disabled="true">
		<p>This is the content of Accordion Item 2.</p>
	</WAAccordionItem>
	<WAAccordionItem Label="Accordion Item 3" Expanded="true" IconName="plus-square">
		<p>This is the content of Accordion Item 3.</p>
	</WAAccordionItem>
</WAAccordion>
```
