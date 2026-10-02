using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor.Components
{
    public partial class WAStep : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Adds an animation to the step's marker to draw attention to it, e.g. the step the user should do next.
        /// </summary>
        [Parameter]
        public StepAttention Attention { get; set; } = StepAttention.None;

        /// <summary>
        /// Marks the step done. Shows a checkmark instead of the step number.
        /// </summary>
        [Parameter]
        public bool Completed { get; set; } = false;

        /// <summary>
        /// Optional text shown under the label.
        /// </summary>
        [Parameter]
        public RenderFragment? DescriptionContent { get; set; }

        /// <summary>
        /// /// Optional text shown under the label.
        /// </summary>
        [Parameter]
        public string? Description { get; set; }

        /// <summary>
        /// Makes the step non-interactive. It can't be clicked or reached with NextStepAsync or GoToAsync, and it renders as a disabled button when the stepper is clickable.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;



        /// <summary>
        /// The name of the icon to draw for the step replacing the step number, checkmark, or loading indicator. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? IconName { get; set; }

        /// <summary>
        /// The name of the icon to draw for the step replacing the step number, checkmark, or loading indicator. Alternatively used IconName.
        /// </summary>
        [Parameter]
        public Icon? Icon { get; set; }

        /// <summary>
        /// Shows a loading indicator instead of the step number, e.g. while an async transition is in progress.
        /// </summary>
        [Parameter]
        public bool Loading { get; set; } = false;

        /// <summary>
        /// Identifies the step. Matched against the stepper's active attribute and used in events.
        /// </summary>
        [Parameter]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Colors the step's marker with a semantic color. Upcoming brand steps keep a neutral outline so a default stepper reads quietly. The color is cosmetic; pair it with an icon in the icon slot and a clear label when a step needs to read as failed or flagged.
        /// </summary>
        [Parameter]
        public StepVariant Variant { get; set; } = StepVariant.Brand;

        #endregion

        #region Computed  Properties
        private string AttentionString
        {
            get
            {
                return Attention switch
                {
                    StepAttention.None => "none",
                    StepAttention.Pulse => "pulse",
                    StepAttention.Bounce => "bounce",
                    _ => "none"
                };
            }
        }

        private string VariantString
        {
            get
            {
                return Variant switch
                {
                    StepVariant.Brand => "brand",
                    StepVariant.Neutral => "neutral",
                    StepVariant.Danger => "danger",
                    StepVariant.Success => "success",
                    StepVariant.Warning => "warning",
                    _ => "brand"
                };
            }
        }
        #endregion



    }


}
