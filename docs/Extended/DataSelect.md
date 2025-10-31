# DataSelect<TValue>
## WebAwesomeBlazor.Extended.DataSelect

```HTML+Razor
<DataSelect TValue="" Value="" OptionKey="" OptionLabel="" SelectOptions="">
```

### Description
The DataSelect extends the [<WASelect>](/docs/WASelect.md) component by introducing a data-bound option list.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value | TValue |  | The select's value.  |
| Label | string |  | The select's label.  |
| SelectOptions | IEnumerable<TValue> |  | The list of options to populate in the select |
| OptionKey | Func<TValue, object?> |  | The function for the value from the options |
| OptionText | Func<TValue, string?> |  | The function for the text to display for each option |
| Size | SelectSize | SelectSize.Inherit | The select's size. |
| Hint | string |  | The select's hint. |
| Placeholder | string |  | Placeholder text to show as a hint when the select is empty. |
| Clearable | bool | false | Adds a clear button (with-clear) when the select is not empty. |
| Required | bool | false | The select's required attribute. |
| Appearance | SelectAppearance | SelectAppearance.Outlined | The select's visual appearance. |
| Disabled | bool | false | Disables the select control. |
| Pill | bool | false | Draws a pill-style select with rounded edges. |
| StartIconName | string |  | The name of the icon to draw in the start slot. Available names depend on the icon library being used. |
| StartIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the start slot. |
| EndIconName | string |  | The name of the icon to draw in the end slot. Available names depend on the icon library being used. |
| EndIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the end slot. |
| ClearIconName | string |  | The name of the icon to draw in the clear slot. Available names depend on the icon library being used. |
| ClearIcon | [Icon](/docs/IconClass.md) |  | The icon to draw in the clear slot. |
| ExpandIconName | string |  | The name of the icon to draw in the when the control is expanded and collapsed. Rotates on open and close. Available names depend on the icon library being used. |
| ExpandIcon | [Icon](/docs/IconClass.md) |  | The name of the icon to draw in the when the control is expanded and collapsed. Rotates on open and close. |
| ShowDuration | string | `100ms` | The duration of the show animation. |
| HideDuration | string | `100ms` | The duration of the hide animation. |

### Examples

#### Basic Usage
```HTML+Razor
<DataSelect TValue="User" Required="true" @bind-Value="@selectedUser" SelectOptions="userList" OptionKey="@(o => o.userId)" OptionText="@(o => o.userName)" />

@code 
{
    User selectedUser { get; set; } = new();

    IList<User> userList { get; set; } = new List<User>
        {
            new User{ userId = 1, userName = "Shannon Smith"},
            new User{ userId = 2, userName = "Alex Citizen"},
            new User{ userId = 3, userName = "Blair Wang"},
            new User{ userId = 4, userName = "Jesse Garcia"}
        };

    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
    }
}
```