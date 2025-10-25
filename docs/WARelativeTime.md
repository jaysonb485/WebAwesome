# WARelativeTime
## Vengage.WebAwesome.Components.WARelativeTime

```HTML+Razor
<WARelativeTime DateTimeValue="" />
```

### Description
Outputs a localized time phrase relative to the current date and time.

[WebAwesome docs](https://webawesome.com/docs/components/relative-time/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| DateTimeValue | datetime |  | The date from which to calculate time from. If not set, the current date and time will be used.  |
| AutoRefresh | bool | false | Keep the displayed value up to date as time passes. |
| Format | RelativeTimeFormat | RelativeTimeFormat.Long | The formatting style to use (Long, Short, Narrow) |
| AlwaysNumeric | bool | false | Always show numeric values ('1 day ago') instead of 'yesterday' |
| Culture | CultureInfo | CultureInfo.CurrentCulture | Used to set the desired locale. |

### Examples

#### Basic Usage
```HTML+Razor
    <WARelativeTime DateTimeValue="@(DateTime.Parse("2025-10-01T16:00:00Z"))"/>
```

#### Short format, different languages
```HTML+Razor
    <WARelativeTime DateTimeValue="@(DateTime.Parse("2025-10-01T16:00:00Z"))" Format="RelativeTimeFormat.Short" />
    <WARelativeTime DateTimeValue="@(DateTime.Parse("2025-10-01T16:00:00Z"))" Culture="@(System.Globalization.CultureInfo.GetCultureInfo("zh"))" />
    <WARelativeTime DateTimeValue="@(DateTime.Parse("2025-10-01T16:00:00Z"))" Culture="@(System.Globalization.CultureInfo.GetCultureInfo("nl"))" />
```

![WARelativeTime](https://github.com/user-attachments/assets/418bff72-5dfc-4302-82df-7994011642eb)