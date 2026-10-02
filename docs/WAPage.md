# WAPage
## WebAwesomeBlazor.Components.WAPage

```HTML+Razor
<WAPage>
	<WALayoutContent LayoutSlot="LayoutSlots.MainContent">
		@Body
	</WALayoutContent>
</WAPage>
```

### Description
Pages offer an easy way to scaffold entire page layouts using minimal markup.

[Web Awesome docs](https://webawesome.com/docs/components/page/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| IsMobilePageView | bool |  | Reflects. Indicates if the current view is mobile or desktop. This is determined by the MobileBreakpoint parameter. The value is updated after the component has rendered or when the browser is resized (when `ObserveResize` is `true`).|
| IsStickyAside | bool | true | Indicates if the aside should be sticky. Default is true. |
| IsStickyBanner | bool | true | Indicates if the banner should be sticky. |
| IsStickyHeader | bool | true | Indicates if the header should be sticky. Default is true.  |
| IsStickyMenu | bool | true | Indicates if the menu should be sticky. Default is true. |
| IsStickySubHeader | bool | true | Indicates if the subheader should be sticky. Default is true. |
| LayoutContent | RenderFragment |  | Refer [WALayoutContent](/docs/WALayoutContent.md)  |
| LoadingContent | RenderFragment |  | An optional custom loading content to show while the component is initializing. Prevents showing layout content until the component has fully rendered. |
| MobileBreakpoint | string | 768px | At what page width to hide the "navigation" slot and collapse into a hamburger button. Accepts both numbers (interpreted as px) and CSS lengths (e.g. 50em), which are resolved based on the root element. |
| NavigationPlacement | PageNavigationPlacement | PageNavigationPlacement.Start | Where to place the navigation when in the mobile viewport. |
| NavOpen | bool |  | Whether or not the navigation drawer is open. Note, the navigation drawer is only "open" on mobile views. |
| ObserveResize | bool | true | Enables page resize monitoring and triggers Resized when the page resizes |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| Resized   | Event callback when the page is resized. Only invoked if ObserveResize is true. Provides bool IsMobilePageView.  |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| HideNavigationAsync  |    |Hides the mobile navigation drawer      |
| ShowNavigationAsync  |    |Shows the mobile navigation drawer      |
| ToggleNavigationAsync  |    |Toggles the mobile navigation drawer      |


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
