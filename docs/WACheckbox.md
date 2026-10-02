# WACheckbox
## WebAwesomeBlazor.Components.WACheckbox

```HTML+Razor
<WACheckbox Label="Tick me" />
```

### Description
Checkboxes allow the user to toggle an option on or off.

[Web Awesome docs](https://webawesome.com/docs/components/checkbox/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| CheckIconColor  | string |   |  The color of the checked and indeterminate icons. Use CSS-valid colors. |
| CheckIconScale  | decimal |   | The size of the checked and indeterminate icons relative to the checkbox represented by a decimal. 1 is full size, 0.5 is half size etc.  |
| Disabled    | bool | false   | Disables the checkbox.                     |
| Hint | string  |   | The checkbox's hint text.  |
| Label    | string |        | The checkbox's label.                     |
| Size  | CheckboxSize | CheckboxSize.Inherit  | The checkbox's size. |
| Value    | string |  | The value of the checkbox, submitted as a name/value pair with form data.                     |

### Examples

#### Basic Usage
```HTML+Razor
<WACheckbox Label="Tick me" @bind-Value="tickBox" />
<WACheckbox Label="Indeterminate" indeterminate />
<WACheckbox Label="Large green tick" CheckIconColor="lightgreen" CheckIconScale="(decimal)1.5" />

@code {
    bool tickBox {get; set;} = false;
}
```

<img width="178" height="162" alt="image" src="https://github.com/user-attachments/assets/abb020da-623c-46c0-a7ff-c59d9ac2b8af" />
