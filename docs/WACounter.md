# WACounter
## WebAwesomeBlazor.Components.WACounter

```HTML+Razor
<WACounter Duration="190800000" Label="Final countdown!"/>
```

### Description
Counters count down to a date or up from one, ticking through years, months, days, and smaller units. Use them for launch countdowns, sale timers, and showing how long something has been running.

[Web Awesome docs](https://webawesome.com/docs/components/counter)

### Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `DateTimeValue` | `DateTime?` | `null` | The date and time from which the counter calculates elapsed or remaining time. When not specified, the current date and time are used. Setting this value during rendering may reset the counter. |
| `Delimiter` | `string?` | `""` | Text displayed between units, such as `:`. |
| `Direction` | `CounterDirection` | `Down` | Determines whether the counter counts down to a date or counts up from it. |
| `Duration` | `int?` | `null` | The duration, in milliseconds, to count down from when the component is first rendered. Ignored when `DateTimeValue` is set or when `Direction` is `Up`. |
| `Format` | `CounterFormat` | `Long` | Controls the display format of unit labels. |
| `Label` | `string?` | `null` | Accessible label used to describe the counter to assistive technologies. |
| `LargestUnit` | `CounterUnit` | `Days` | The largest time unit displayed by the counter. Time exceeding this unit is rolled into it. |
| `Paused` | `bool` | `false` | Indicates whether the counter is paused. Use `PauseAsync()` and `UnpauseAsync()` to change the running state programmatically. |
| `SmallestUnit` | `CounterUnit` | `Seconds` | The smallest time unit displayed by the counter. Any time below this unit is discarded. |
| `ShowLabels` | `bool` | `true` | Shows or hides the unit labels. |
| `DaysContent` | `RenderFragment?` | `null` | Custom content used for the days label. |
| `HoursContent` | `RenderFragment?` | `null` | Custom content used for the hours label. |
| `MinutesContent` | `RenderFragment?` | `null` | Custom content used for the minutes label. |
| `SecondsContent` | `RenderFragment?` | `null` | Custom content used for the seconds label. |
| `MonthsContent` | `RenderFragment?` | `null` | Custom content used for the months label. |
| `YearsContent` | `RenderFragment?` | `null` | Custom content used for the years label. |
| `FinishedContent` | `RenderFragment?` | `null` | Content displayed when a countdown reaches zero or when the target date has already passed. |
| `Finished` | `EventCallback` | - | Invoked when an active countdown reaches zero. Not raised when the target date has already passed before rendering. |

### Methods

| Method | Parameters | Description |
|----------|----------|-------------|
| `PauseAsync` | None | Pauses the counter, preventing it from advancing until resumed. |
| `UnpauseAsync` | None | Resumes a paused counter. |

### Examples

#### Basic Usage
```HTML+Razor
<WACounter Duration="190800000" Label="Final countdown!"/>
```

#### Customer labels and finish content
```HTML+Razor
<WACounter Duration="100000" Label="Finalise the booking!" LargestUnit="CounterUnit.Minutes" SmallestUnit="CounterUnit.Minutes">
	<MinutesContent>
		<WABadge>Minutes</WABadge>
	</MinutesContent>
	<SecondsContent>
		<WABadge>Seconds</WABadge>
	<SecondsContent>
	<FinishedContent>
		<WACallout>Times up!</WACallout>
	</FinishedContent>
</WACounter>

```