# WABreadcrumb
## WebAwesomeBlazor.Components.WABreadcrumb

```HTML+Razor
<WABreadcrumb>
  <WABreadcrumbItem>Item one</WABreadcrumbItem>
  <WABreadcrumbItem>Item two</WABreadcrumbItem>
</WABreadcrumb>
```

### Description
Breadcrumbs provide a group of links so users can easily navigate a website's hierarchy.

Breadcrumbs are usually placed before a page's main content with the current page shown last to indicate the user's position in the navigation.

[WebAwesome docs](https://webawesome.com/docs/breadcrumb)
[WABreadcrumbItem](/docs/WABreadcrumbItem.md)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label    | string |  | The label to use for the breadcrumb control. This will not be shown on the screen, but it will be announced by screen readers and other assistive devices to provide more context for users.                     |
| Icon    | [Icon](/docs/IconClass) |        | The separator to use between breadcrumb items.                     |
| IconName    | string |    | The separator to use between breadcrumb items. Available names depend on the icon library being used.                     |

### Examples

#### Basic Usage
```HTML+Razor
<WABreadcrumb>
  <WABreadcrumbItem>Item one</WABreadcrumbItem>
  <WABreadcrumbItem>Item two</WABreadcrumbItem>
</WABreadcrumb>
```
<img width="219" height="51" alt="image" src="https://github.com/user-attachments/assets/604d8745-8da7-41b6-9128-927193b20a2d" />
