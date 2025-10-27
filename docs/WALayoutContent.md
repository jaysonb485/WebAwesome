# WALayoutContent
## WebAwesomeBlazor.Components.WALayoutContent

```HTML+Razor
<WAPage>
	<WALayoutContent Slot="" >
		@ChildContent
	</WALayoutContent>
</WAPage>
```

### Description
A WALayoutContent is used to define a section of a [WAPage](/docs/WAPage.md)

> [!IMPORTANT]
> WAPage and WALayoutContent requires access to WebAwesome Pro.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| LayoutSlot | LayoutSlots |  | The section of the WAPage the element references. |

**Layout slots**
- LayoutSlots.Banner
- LayoutSlots.Header
- LayoutSlots.SubHeader
- LayoutSlots.Menu
- LayoutSlots.NavigationHeader
- LayoutSlots.Navigation
- LayoutSlots.NavigationFooter
- LayoutSlots.NavigationToggle
- LayoutSlots.NavigationToggleIcon
- LayoutSlots.MainHeader
- LayoutSlots.MainContent
- LayoutSlots.MainFooter
- LayoutSlots.Aside
- LayoutSlots.SkipToContent
- LayoutSlots.Footer

### Examples

#### Basic Usage
```HTML+Razor
<WAPage>
	<WALayoutContent LayoutSlot="LayoutSlots.Header">
		<h4>My App</h4>
	</WALayoutContent>
	<WALayoutContent LayoutSlot="LayoutSlots.MainContent">
		@Body
	</WALayoutContent>
	<WALayoutContent LayoutSlot="LayoutSlots.Footer">
		&copy; 2025 My Company
	</WALayoutComponent>
</WAPage>
```

![WALayoutContent](https://github.com/user-attachments/assets/5b31ae7e-1b50-403f-b3c7-a7bf12ec4c8d)
