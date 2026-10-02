# WAStep
## WebAwesomeBlazor.Components.WAStep

```HTML+Razor
<WAStepper>
    <WAStep name="step1">Step 1</WAStep>
    <WAStep name="step2">Step 2</WAStep>
</WAStepper
```

### Description
Steps represent a single stage inside a [WAStepper](/docs/WAStepper.md), showing its position, label, and status.

[Web Awesome docs](https://webawesome.com/docs/components/step)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Attention | StepAttention | StepAttention.None | Adds an animation to the step's marker to draw attention to it, e.g. the step the user should do next. |
| Completed | bool | `false` | Marks the step done. Shows a checkmark instead of the step number. |\
| Description | string | | Optional text shown under the label. Use `DescriptionContent` RenderFragment for formatted descriptions. |
| DescriptionContent | RenderFragment | | Optional text shown under the label. Use `Description` for simple text descriptions. |
| Disabled | bool | `false` | Makes the step non-interactive. It can't be clicked or reached with NextStepAsync or GoToAsync, and it renders as a disabled button when the stepper is clickable. |
| Icon | [Icon](/docs/IconClass.md) | | The name of the icon to draw for the step replacing the step number, checkmark, or loading indicator. Alternatively used IconName. 
| IconName | string | | The name of the icon to draw for the step replacing the step number, checkmark, or loading indicator. Available names depend on the icon library being used. |
| Loading | bool | `false` | Shows a loading indicator instead of the step number, e.g. while an async transition is in progress. | 
| Name | string | | Identifies the step. Matched against the stepper's active attribute and used in events |
| Variant | StepVariant | `StepVariant.Brand` | Colors the step's marker with a semantic color. Upcoming brand steps keep a neutral outline so a default stepper reads quietly. The color is cosmetic; pair it with an icon in the icon slot and a clear label when a step needs to read as failed or flagged. |



### Examples

#### Basic Usage
```HTML+Razor
<WAStepper ActiveStep="shipping">
    <WAStep Name="cart" Completed="true">Cart</WAStep>
    <WAStep Name="shipping" Description="Tell us where to send it" IconName="boxes-packing">Shipping</WAStep>
    <WAStep Name="payment" Disabled="true">Payment</WAStep>
</WAStepper>
```
