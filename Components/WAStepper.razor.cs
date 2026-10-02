using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WAStepper : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public RenderFragment? Steps { get; set; }

        /// <summary>
        /// The name of the active step. Falls back to the first step if unset, or if it doesn't match any step's name.
        /// </summary>
        [Parameter]
        public string? ActiveStep { get; set; }
        /// <summary>
        /// Allows clicking a step, or focusing it and pressing Enter/Space, to jump straight to it
        /// </summary>
        [Parameter]
        public bool Clickable { get; set; } = false;
        /// <summary>
        /// A label that describes the stepper to assistive devices. Especially useful when more than one is on the page.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// Requires steps to be completed in order.
        /// </summary>
        [Parameter]
        public bool Linear { get; set; } = false;
        /// <summary>
        /// The stepper's layout direction. auto lays steps out in a row and stacks them when the stepper is too narrow to give each step about 6em of width, so labels stay legible on small screens; use it for anything shown on a phone.
        /// </summary>
        [Parameter]
        public StepperOrientation Orientation { get; set; } = StepperOrientation.Horizontal;

        /// <summary>
        /// Triggered when the stepper is changing. Prevent the change with e.Cancel = true
        /// </summary>
        [Parameter]
        public EventCallback<StepperChangingEventArgs> StepperChanging { get; set; }
        /// <summary>
        /// Triggered when the stepper has changed.
        /// </summary>
        [Parameter]
        public EventCallback<StepperChangedEventArgs> StepperChanged { get; set; }

        #endregion

        #region Computed  Properties
        private string OrientationString
        {
            get
            {
                return Orientation switch
                {
                    StepperOrientation.Horizontal => "horizontal",
                    StepperOrientation.Vertical => "vertical",
                    StepperOrientation.Auto => "auto",
                    _ => "horizontal"
                };
            }
        }

        #endregion
        #region Lifecycle
        protected override void OnInitialized()
        {
            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= [];

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Id!, objRef);
            }
        }

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    if (_instance is not null)
                        await _instance.InvokeVoidAsync("dispose");


                }
                catch (JSDisconnectedException)
                {
                }
                objRef?.Dispose();
            }

        }

        #endregion

        #region State
        private DotNetObjectReference<WAStepper> objRef = default!;
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task<StepperChangingEventArgs> HandleStepChanging(StepperChangingEventArgs stepperChangingEventArgs)
        {

            //stepperChangingEventArgs = await StepperChanging(stepperChangingEventArgs);

            //return stepperChangingEventArgs;
            if (StepperChanging.HasDelegate) await StepperChanging.InvokeAsync(stepperChangingEventArgs);

            return stepperChangingEventArgs;
        }

        [JSInvokable]
        public async Task HandleStepChanged(StepperChangedEventArgs stepperChangedEventArgs)
        {
            if (StepperChanged.HasDelegate) await StepperChanged.InvokeAsync(stepperChangedEventArgs);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Requests a change to the named step
        /// </summary>
        /// <param name="Step">Name of the step to move to</param>
        /// <returns></returns>
        public async Task GoToStepAsync(string Step)
        {
            await SafeInvokeVoidAsync("goTo", Element, Step);
        }

        public void GoToStep(string Step) => _ = GoToStepAsync(Step);

        /// <summary>
        /// Advances to the step after the active one, if any.
        /// </summary>
        /// <returns></returns>
        public async Task NextStepAsync()
        {
            await SafeInvokeVoidAsync("next", Element);
        }

        public void NextStep() => _ = NextStepAsync();

        /// <summary>
        /// Goes back to the step before the active one, if any.
        /// </summary>
        /// <returns></returns>
        public async Task PreviousStepAsync()
        {
            await SafeInvokeVoidAsync("previous", Element);
        }

        public void PreviousStep() => _ = PreviousStepAsync();

        #endregion
    }


}
