# WAStepper
## WebAwesomeBlazor.Components.WAStepper

```HTML+Razor
<WAStepper>
    <WAStep name="step1">Step 1</WAStep>
    <WAStep name="step2">Step 2</WAStep>
</WAStepper
```

### Description
Steppers visually guide users through a process step by step, breaking content into clear, logical stages. 

[Web Awesome docs](https://webawesome.com/docs/components/stepper/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| ActiveStep | string |  | The name of the active step. Falls back to the first step if unset, or if it doesn't match any step's name. |
| Clickable | bool | `false` | Allows clicking a step, or focusing it and pressing Enter/Space, to jump straight to it |
| Label | string |  | A label that describes the stepper to assistive devices. Especially useful when more than one is on the page. |
| Linear | bool | `false` | Requires steps to be completed in order. |
| Orientation | StepperOrientation | `StepperOrientation.Horizontal` | The stepper's layout direction. auto lays steps out in a row and stacks them when the stepper is too narrow to give each step about 6em of width, so labels stay legible on small screens; use it for anything shown on a phone.

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| StepperChanging (StepperChangingEventArgs) | Triggered when the stepper is changing. Prevent the change with `e.Cancel = true` | 
| StepperChanged (StepperChangedEventArgs) | Triggered when the stepper has changed. |

#### StepperChangingEventArgs
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Step | string | | The name of the step to be changed to  |
| PreviousStep | string | | The name of the previous step |
| Cancel | bool | `false` | Set to `true` to cancel the step change in the StepperChanging event |

#### StepperChangedEventArgs
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Step | string | | The name of the new step |
| PreviousStep | string | | The name of the previous step |


### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| GoToStepAsync  | Step: string   | Requests a change to the named step. If the step is not reachable (disabled, non-linear, etc), the step change will not proceed.      |
| NextStepAsync | | Advances to the step after the active one, if any. |
| PreviousStepAsync | | Goes back to the step before the active one, if any. | 


### Examples

#### Basic Usage
```HTML+Razor
<WAStepper ActiveStep="shipping">
    <WAStep Name="cart" Completed="true">Cart</WAStep>
    <WAStep Name="shipping">Shipping</WAStep>
    <WAStep Name="payment" Disabled="true">Payment</WAStep>
</WAStepper>
```

#### Advanced Usage, Clickable with StepperChanging event prevented by Switch.
```HTML+Razor
<WAStepper Clickable="true" StepperChanging="StepChanging" ActiveStep="shipping">
    <WAStep Name="cart" Completed="true" >Cart</WAStep>
    <WAStep Name="shipping" Description="Tell us where to send it.">Shipping</WAStep>
    <WAStep Name="payment" Disabled="true" IconName="credit-card">Payment</WAStep>
</WAStepper>

<WASwitch @bind-Value="shouldPrevent" Label="Prevent change" />

@code 
{
    bool shouldPrevent { get; set; } = false;

    async Task StepChanging(StepperChangingEventArgs e)
    {
        /// Prevent changing step if shouldPrevent is true.
        e.Cancel = shouldPrevent;
    }
}
```