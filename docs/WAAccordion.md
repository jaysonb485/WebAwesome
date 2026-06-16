# WAAccordion
## WebAwesomeBlazor.Components.WAAccordion

```HTML+Razor
<WAAccordion>
	<WAAccordionItem Label="Accordion Item 1">
		<p>This is the content of Accordion Item 1.</p>
	</WAAccordionItem>
</WAAccordion>
```

### Description
Accordions are a vertically stacked set of interactive headings that each contain a title, representing a section of content.

[WebAwesome docs](https://webawesome.com/docs/components/accordion/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Mode | AccordionMode | `AccordionMode.Multiple` | Controls how items can be expanded. multiple (the default) allows any number of items to be open at once. single allows only one item to be open at a time; opening a new item collapses the previously open one, and clicking an open item does not collapse it. single-collapsible is the same as single except that clicking the open item collapses it, so zero open items is a valid state. |
| HeadingLevel | AccordionHeadingLevel | `AccordionHeadingLevel.H3` | The heading level for child item triggers (1–6), or "none" to omit the heading wrapper. Defaults to 3. |
| Appearance | AccordionAppearance | `AccordionAppearance.Outlined` | The accordion's visual appearance. |
| IconPlacement | AccordionIconPlacement | `AccordionIconPlacement.End` | The position of the expand/collapse icon. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| ExpandAllAsync  | | Expands all accordion items.      |
| CollapseAllAsync | | Collapses all accordion items.      |


### Examples

#### Basic Usage
```HTML+Razor
<WAAccordion Mode="AccordionMode.Single" Appearance="AccordionAppearance.Plain">
	<WAAccordionItem Label="Accordion Item 1">
		<p>This is the content of Accordion Item 1.</p>
	</WAAccordionItem>
	<WAAccordionItem Label="Accordion Item 2">
		<p>This is the content of Accordion Item 2.</p>
	</WAAccordionItem>
		<WAAccordionItem Label="Accordion Item 3">
		<p>This is the content of Accordion Item 3.</p>
	</WAAccordionItem>
</WAAccordion>
```

