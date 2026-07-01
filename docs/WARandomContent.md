# WARandomContent
## WebAwesomeBlazor.Components.WARandomContent

```HTML+Razor
<WARandomContent>
	<p>Random element 1</p>
	<p>Random element 2</p>
</WARandomContent>
```

### Description
Selects one or more child elements at random and displays them, hiding the rest.

[Web Awesome docs](https://webawesome.com/docs/components/random-content)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| ChildContent | RenderFragment |  | The content to display randomly. Only direct children will be randomized. Set ID attribute to identify each child on ContentChanged event. |
| Animation | RandomContentAnimation | RandomContentAnimation.None | Entrance animation for newly shown children. |
| AutoPlay | bool | `false` | Rotate the content automatically. Set the cadence with `AutoPlayInterval`. |
| AutoPlayInterval | int | `3000` | Autoplay cadence in milliseconds. |
| DisplayItems | int | `1` | Number of child elements to display at once. Minimum is 1, maximum is the number of elements in the pool. |
| Mode | RandomContentMode | RandomContentMode.Unique | The mode of randomization. `Unique` never repeats the previous selection. `Random` will select elements randomly, while `Sequential` will display them in order. |
| ContentChanged | EventCallback<string[]> |  | Event triggered when the displayed content changes. Provides an array of ID strings of the elements displayed. |
| AnimationDuration | int | `300` | Duration of the entrance animation in milliseconds. |
| AnimationEasing | string | `ease` | CSS easing function for the entrance animation. |
| AnimationTranslate | string | `0.5em` | CSS translate value for the entrance animation. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| RandomizeAsync()  |  | Selects a new set of children using the current mode. Returns an array of ID strings of the elements now shown. Note: ContentChanged event will also be fired as a result.  |

### Examples

#### Basic Usage
```HTML+Razor
<WARandomContent @ref="RandomContent>
	<p id="paragraph1">Random element 1</p>
	<p id="paragraph2">Random element 2</p>
	<p id="paragraph3">Random element 3</p>
	<p id="paragraph4">Random element 4</p>
</WARandomContent>

<WAButton OnClick="randomizeContent">Randomize</WAButton>

@code {
	private WARandomContent RandomContent;
	private async Task randomizeContent()
	{
		var displayedIds = await RandomContent.RandomizeAsync();
		Console.WriteLine($"Displayed content IDs: {string.Join(", ", displayedIds)}");
	}
}
```
