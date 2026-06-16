using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor.Components
{
    public partial class WAAccordionItem : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Expands the accordion item.
        /// </summary>
        [Parameter]
        public bool Expanded { get; set; } = false;

        /// <summary>
        /// Disables the accordion item so it can't be toggled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The text label shown in the header.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }


        /// <summary>
        /// The name of the icon to draw for the expand/collapse indicator. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? IconName { get; set; }

        /// <summary>
        /// Theicon to draw for the expand/collapse indicator. Alternatively used IconName.
        /// </summary>
        [Parameter]
        public Icon? Icon { get; set; }


        /// <summary>
        /// The duration of the expand animation.
        /// </summary>
        [Parameter]
        public string ShowDuration { get; set; } = "200ms";

        /// <summary>
        /// The duration of the collapse animation.
        /// </summary>
        [Parameter]
        public string HideDuration { get; set; } = "200ms";

        /// <summary>
        /// The amount of space in CSS units around and between the item's header and content. Defaults to var(--wa-space-m)
        /// </summary>
        [Parameter]
        public string? Spacing { get; set; }

        /// <summary>
        /// The easing of the expand / collapse animation.
        /// </summary>
        [Parameter]
        public string Easing { get; set; } = "ease";

        /// <summary>
        /// The color of the divider between accordion items. Defaults to var(--wa-color-surface-border)
        /// </summary>
        [Parameter]
        public string? DividerColor { get; set; }

        #endregion

        #region Computed  Properties
        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--show-duration: {ShowDuration}", !String.IsNullOrWhiteSpace(ShowDuration)),
            ($"--hide-duration: {HideDuration}", !String.IsNullOrWhiteSpace(HideDuration)),
            ($"--easing: {Easing}", !String.IsNullOrWhiteSpace(Easing)),
            ($"--spacing: {Spacing}", !String.IsNullOrWhiteSpace(Spacing)),
            ($"--wa-accordion-divider-color: {DividerColor}", !String.IsNullOrWhiteSpace(DividerColor))
            );
        #endregion

        #region Public Methods
        /// <summary>
        /// Collapses the accordion item with animation.
        /// </summary>
        public async Task CollapseAsync()
        {
            await SafeInvokeVoidAsync("collapse", Id!);
        }
        /// <summary>
        /// Collapses the accordion item with animation.
        /// </summary>
        public void Collapse() => _ = CollapseAsync();

        /// <summary>
        /// Expands the accordion item with animation.
        /// </summary>
        public async Task ExpandAsync()
        {
            await SafeInvokeVoidAsync("expand", Id!);
        }

        /// <summary>
        /// Expands the accordion item with animation.
        /// </summary>
        public void Expand() => _ = ExpandAsync();

        /// <summary>
        /// Focuses the accordion item's trigger button.
        /// </summary>
        /// <param name="focusOptions">The optional focus options.</param>
        public async Task FocusAsync(FocusOptions? focusOptions = null)
        {
            await SafeInvokeVoidAsync("focus", Id!, focusOptions!);
        }
        /// <summary>
        /// Focuses the accordion item's trigger button.
        /// </summary>
        /// <param name="focusOptions">The optional focus options.</param>
        public void Focus(FocusOptions? focusOptions = null) => _ = FocusAsync(focusOptions);

        /// <summary>
        /// Toggles the accordion item's expanded state.
        /// </summary>
        public async Task ToggleAsync()
        {
            await SafeInvokeVoidAsync("toggle", Id!);
        }
        /// <summary>
        /// Toggles the accordion item's expanded state.
        /// </summary>
        public void Toggle() => _ = ToggleAsync();
        #endregion

    }


}
