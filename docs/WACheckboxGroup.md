# WACheckboxGroup
## WebAwesomeBlazor.Components.WACheckboxGroup

```HTML+Razor
<WACheckboxGroup>
	<WACheckbox />
	<WACheckbox/>
</WACheckboxGroup>
```

### Description
Checkbox groups wrap a set of related [WACheckbox](/docs/WACheckbox.md) or [WASwitch](/docs/WASwitch.md) so they share a label, hint, and grouping semantics.

[WebAwesome docs](https://webawesome.com/docs/components/checkbox-group/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Label | string? |  |  The checkbox group's label. |
| Size | CheckboxGroupSize | CheckboxGroupSize.Medium | The checkbox group's size. This size will be applied to all child checkboxes, except when explicitly overridden. |
| Hint | string |  | The checkbox groups's hint. |
| Orientation | ChecboxGroupOrientation | CheckboxGroupOrientation.Vertical | The orientation in which to show items. |
| Required | bool | false | Ensures a checkbox radio is checked before allowing the containing form to submit. |
| Disabled | bool | false | Disables the checkbox group and all child radios. |

### Examples

#### Basic Usage
```HTML+Razor
<WACheckboxGroup Label="Select items">
    <WACheckbox Label="Tick me"  />
    <WACheckbox Label="Indeterminate" />
    <WACheckbox Label="Large green tick" CheckIconColor="lightgreen" CheckIconScale="(decimal)1.5" />
</WACheckboxGroup>
```