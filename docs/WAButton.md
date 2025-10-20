# WAButton
## Vengage.WebAwesome.Components.WAButton

```HTML+Razor
<WAButton>Click me</WAButton>
```

### Description
Buttons represent actions that are available to the user.

[WebAwesome docs](https://webawesome.com/docs/components/button/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Apppearance | ButtonAppearance | ButtonAppearance.Accent | The button's visual appearance. |
| Caret | bool | false | Draws the button with a caret (with-caret). Used to indicate that the button triggers a dropdown menu or similar behavior. |
| Disabled | bool | false | Disables the button. Does not apply to link buttons. | 
| EndIcon    | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. Alternatively, use EndIconName to specify the name of the icon. |
| EndIconName    | string  |       |The name of the icon to draw in the end slot. Available names depend on the icon library being used.  |
| Loading | bool | false | Draws the button in a loading state. |
| OnClick | EventCallback<MouseEventArgs?> | | Triggered when the button is clicked |
| Pill | bool | false | Draws a pill-style button with rounded edges. |
| Size | ButtonSize | ButtonSize.Medium | The button's size (Small, medium, large). |
| StartIcon | [Icon](/docs/IconClass.md) || The icon to draw in the start slot. Altneratively, use StartIconName to specify the name of the icon. |
| StartIconName | string | | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| Text    | string |  | The button's label. Alternatively, use ChildContent to populate the button's content.                   |
| Type | ButtonType | ButtonType.Button | The type of button (Button, Submit, Reset). When the type is submit, the button will submit the surrounding form. |
| Variant | ButtonVariant | Inherit | The button's theme variant. Defaults to neutral if not within another element with a variant. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetLoading  | LoadingState: bool   | Turn off or on the loading indicator.      |
| SetLoadingAsync | LoadingState: bool   | Turn off or on the loading indicator.      |

### Examples

#### Basic Usage
```HTML+Razor
<WAButton OnClick="ButtonClick">Click me</WAButton>
@code {
    void ButtonClick()
    {
        /// Do something here
    }
}
```

#### Set loading on click
```HTML+Razor
<WAButton @ref="LoadingButton"
  Appearance="ButtonAppearance.Accent"
  Variant="ButtonVariant.Success"
  OnClick="@(() => LoadingButton.SetLoading(true))"
  Text="Click me" />
@code {
    WAButton LoadingButton;
}
```
![WAButtonLoading](https://github.com/user-attachments/assets/31069859-e330-40f3-9772-f169d4f9dd44)

