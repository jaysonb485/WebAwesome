# ConfirmDialog
## WebAwesomeBlazor.Extended.ConfirmDialog

```HTML+Razor
<ConfirmDialog />
```

### Description
The confirm dialog uses the `WADialog` component to present a modal dialog with customizable title, message, and action buttons. It is typically used to confirm user actions such as deletions or submissions.


### Usage
In your `MainLayout.razor` or the page where you want to use the ConfirmDialog, include the `ConfirmDialog` component:
```HTML+Razor
<ConfirmDialog />
```

On any page or component where you want to trigger the confirm dialog, inject the `ConfirmDialogService` and use it to show the dialog:
```HTML+Razor
@inject IConfirmDialog confirmDialogService
```

Then, you can call the `ShowAsync` method to display the dialog:
```CSharp
bool confirmed = await confirmDialogService.ShowAsync("Confirm Action", "Are you sure you want to proceed?");
if (confirmed)
{
	// User confirmed the action
}
else
{
	// User canceled the action
}
```

Customise the yes and no button texts by passing additional parameters to the `ShowAsync` method:
```CSharp
bool confirmed = await confirmDialogService.ShowAsync("Confirm Action", "Are you sure you want to proceed?", "Ok", "Nah");
```

If a user closes the dialog without making a choice, the `ShowAsync` method will return false.