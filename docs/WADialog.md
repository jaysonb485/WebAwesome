# WADialog
## WebAwesomeBlazor.Components.WADialog

```HTML+Razor
    <WADialog Title="">
        <HeaderActions></HeaderActions>
        <DialogBody></DialogBody>
        <DialogFooter></DialogFooter>
    </WADialog>
```

### Description
Dialogs (modals) appear above the page and require the user's immediate attention.

[Web Awesome docs](https://webawesome.com/docs/components/dialog/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| BackdropFilter | string | | A CSS filter to apply to the backdrop behind the dialog. e.g. "blur(5px)" |
| DialogBody | RenderFragment |   | The dialog's main content. |
| DialogFooter | RenderFragment |   | The dialog's footer, usually one or more buttons representing various options.  |
| HeaderActions  | RenderFragment |   | Optional actions to add to the header. Works best with WAButton.  |
| HideDuration | string | 200ms | The animation duration when hiding the dialog.Default `200ms` |
| LightDismiss | bool | true  | When enabled, the drawer will be closed when the user clicks outside of it. Defaults to true.  |
| PreferredWidth  | string  |   | The preferred width of the dialog in CSS units. Note that the dialog will shrink to accommodate smaller screens.  |
| ShowDuration | string | 200ms | The animation duration when showing the dialog. Default `200ms` |
| Spacing | string | | The amount of space around and between the dialog's content. |
| Title | string  |   | The dialog's title as displayed in the header. You should always include a relevant title, as it is required for proper accessibility.  |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| DialogClosed (string)  | Triggered when the dialog is closed. Argument provides ID of the triggering component  |


### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| Show  | | Shows the dialog.      |
| ShowAsync  | | Shows the dialog.      |
| Hide |  |  Hides the dialog. |
| HideAsync |  |  Hides the dialog. |

### Examples

#### Basic Usage
```HTML+Razor
     <WADialog @ref="infoDialog" Title="Dialog title">
        <DialogBody>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit.
        </DialogBody>
        <DialogFooter>
            <WAButton OnClick="infoDialog.Hide">Close Dialog</WAButton>
        </DialogFooter>        
    </WADialog>

     <WAButton OnClick="@(() => infoDialog.ShowAsync())">Open Dialog</WAButton>
  
@code {
    WADialog infoDialog { get; set; } = default!;
}

```
<img width="525" height="229" alt="image" src="https://github.com/user-attachments/assets/733199b1-935d-45fb-bf79-f6d74f8ee081" />
