# WATag
## WebAwesomeBlazor.Components.WATag

```HTML+Razor
<WATag Text="Label" />
```

### Description
Tags are used as labels to organize things or to indicate a selection.

[WebAwesome docs](https://webawesome.com/docs/components/tag/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Text | string |  | The text to display in the tag. |
| Variant | TagVariant |  | The tag's theme variant. Defaults to neutral if not within another element with a variant. |
| Appearance | TagAppearance | TagAppearance.FilledOutlined | The tag's visual appearance. Valid options for tag are: Accent, AccentOutlined, Filled, FilledOutlined, Outlined. |
| Pill | bool | false | Draws a pill-style tag with rounded edges |
| Removable | bool | false | Makes the tag removable (with-remove) and shows a remove button. |
| Size | TagSize | TagSize.Inherit | The tag's size |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| TagRemoving<TagRemovingEventArgs> | When Removable, triggered when the tag's remove button is clicked, before the tag is removed. To cancel removal set `TagRemovingEventArgs.Cancel = true`. See example below. |
| TagRemoved | Triggered when the tag is removed. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| Remove  |   | Removes the tag. Opacity is set to 0 and Display is `none`.      |
| RemoveAsync  |   | Removes the tag. Opacity is set to 0 and Display is `none`.      |

### Examples

#### Basic Usage
```HTML+Razor
<WATag Text="Label" />

```

#### Display properties and removable
```HTML+Razor
<WATag @ref="tag" Text="Label" Size="TagSize.Large" Variant="TagVariant.Success" Appearance="TagAppearance.Accent" Removable="true" TagRemoved="TagRemoved" TagRemoving="TagRemoving" />

@code 
{
	WATag tag;
	void TagRemoved()
	{
	
	}

	async Task TagRemoving(TagRemovingEventArgs e)
	{
		// Add logic here to determine if the tag should be removed.
		// Tag to be removed:
		e.Cancel = true;

		// Manually remove the tag:
		await tag.RemoveAsync();
	}
}
```

![WATag](https://github.com/user-attachments/assets/bd4da2d9-f73f-4631-bbb0-b3f8de39466b)