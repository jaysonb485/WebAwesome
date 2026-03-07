# WAToast
## WebAwesomeBlazor.Components.WAToast
## WebAwesomeBlazor.ToastService

```HTML+Razor
<WAToast />
```

### Description
Toasts display brief, non-blocking notifications that appear temporarily above the page content.

[WebAwesome docs](https://webawesome.com/docs/components/toast/)

### Toast Service
Use the global toast service to display toasts where needed.

Ensure WebAwesome is registered in your `Program.cs`:

```CSharp
builder.Services.AddWebAwesome();
```

Add the `WAToast` element in your page layout (i.e. `MainLayout.razor`):

```HTML+Razor
@inherits LayoutComponentBase

@* ...
 MainLayout content here
... *@

<WAToasts Placement="ToastPlacement.TopEnd" />
```

Inject `ToastService` on pages where a toast notification would be called and call `CreateAsync(ToastMessage)`:
```HTML+Razor
@inject ToastService ToastService

@* ...
 Page content here
... *@

@code 
{
	private async Task DataActionCompletedAsync()
	{
		await toastService.CreateAsync(new ToastMessage
		{
            Message = "Data was successfully saved",
            Variant = ToastMessageVariant.Success
		});
	}
}
````


### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Placement | ToastPlacement | `ToastPlacement.TopEnd` | The placement of the toast stack on the screen.  |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| CreateAsync  | toastMessage: ToastMessage   | The toast message to display. See below.      |
| DismissAsync | toastMessage: ToastMessage   | The toast message to dismiss. |

### ToastMessage Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Message | string |  | The message to display for a simple toast. If HTMLContent is populated, this property is ignored. |
| Icon | [Icon](/docs/IconClass.md) || The icon to draw on the toast. Alternatively, use IconName to specify the name of the icon. |
| IconName | string | | The name of the icon to draw on the toast. Available names depend on the icon library being used. |
| Duration | int | 5000 | The length of time in milliseconds before the toast item is automatically dismissed. Set to 0 to keep the toast item open until the user dismisses it. |
| Size | ToastMessageSize | `ToastMessageSize.Medium` | The toast item's size. |
| Variant | ToastMessageVariant | `ToastMessageVariant.Brand` | The toast item's variant. |
| HTMLContent | RenderFragment |  | The content to display for a rich toast. If left blank, message will be used instead. |


### Examples

#### Basic Usage
```HTML+Razor
@inject ToastService ToastService

<WAButton Text="ShowSimpleToast" OnClick="ShowSimpleToast" />

@code
{
	private async Task ShowSimpleToast()
	{
		// Show a simple toast message.
		// Toast will automatically dismiss after 5 seconds by default.
		// Toast will have the 'brand' variant by default.

		await ToastService.CreateAsync(new ToastMessage
		{
			Message = "This is a simple toast message."
		});
	}
}

```

#### Rich content
```HTML+Razor
@inject ToastService ToastService

<WAButton Text="ShowSimpleToast" OnClick="ShowRichToast" />

@code
{
    ToastMessage toastMessage = default!;

    private async Task ShowRichToast()
    {
        // Show a rich toast message.
        // Toast will require the user to dismiss.
        // Toast will have the 'success' variant.
        // The toast will be dismissable when the user presses the 'Go to record' button.

		toastMessage = new ToastMessage
        {
            IconName = "user",
            Duration = 0,
            Variant = ToastMessageVariant.Success,
            HTMLContent = @<div class="wa-stack wa-gap-xs"><strong>Successs</strong><span>Update was successful.</span><div style="margin-block-start: var(--wa-space-xs);"><WAButton Size="ButtonSize.Small" Text="Go to record" OnClick="GoToRecord" /> </div></div>
        };

        await ToastService.CreateAsync(toastMessage);
    }

    private async Task GoToRecord()
    {
        // Dismiss the toast
        await ToastService.DismissAsync(toastMessage);
        
        // Navigate to the record
        // ...
    }
}

```