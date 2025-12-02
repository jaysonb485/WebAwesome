using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WATooltip : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Size of the tooltip arrow. Set to 0 to hide the arrow.
        /// </summary>
        [Parameter]
        public int? ArrowSize { get; set; }

        /// <summary>
        /// Maximum width the tooltip can grow to before wrapping.
        /// </summary>
        [Parameter]
        public int? MaxWidth { get; set; }

        /// <summary>
        /// ID of the component to attach the tooltip to
        /// </summary>
        [Parameter, EditorRequired]
        public string? TargetId { get; set; }

        /// <summary>
        /// The preferred placement of the tooltip. Note that the actual placement may vary as needed to keep the tooltip inside of the viewport.
        /// </summary>
        [Parameter]
        public TooltipPlacement Placement { get; set; } = TooltipPlacement.Top;
        /// <summary>
        /// Disables the tooltip so it won't show when triggered.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The distance in pixels from which to offset the tooltip away from its target.
        /// </summary>
        [Parameter]
        public int Distance { get; set; } = 8;

        /// <summary>
        /// The distance in pixels from which to offset the tooltip along its target. (Skidding)
        /// </summary>
        [Parameter]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// The amount of time to wait before showing the tooltip when the user mouses in.
        /// </summary>
        [Parameter]
        public int ShowDelay { get; set; } = 150;

        /// <summary>
        /// The amount of time to wait before hiding the tooltip when the user mouses out.
        /// </summary>
        [Parameter]
        public int HideDelay { get; set; } = 0;

        /// <summary>
        /// Removes the arrow from the tooltip.
        /// </summary>
        [Parameter]
        public bool WithoutArrow { get; set; } = false;

        /// <summary>
        /// Indicates whether or not the tooltip is open. 
        /// </summary>
        [Parameter]
        public bool Open { get; set; } = false;

        /// <summary>
        /// Controls how the tooltip is activated. Possible options include click, hover, focus, and manual. Multiple options can be passed by separating them with a space. When manual is used, the tooltip must be activated programmatically.
        /// </summary>
        [Parameter]
        public TooltipTrigger Trigger { get; set; } = TooltipTrigger.Hover | TooltipTrigger.Focus;
        #endregion

        #region Computed  Properties

        private string PlacementString
        {
            get
            {
                return Placement switch
                {
                    TooltipPlacement.Top => "top",
                    TooltipPlacement.TopStart => "top-start",
                    TooltipPlacement.TopEnd => "top-end",
                    TooltipPlacement.Bottom => "bottom",
                    TooltipPlacement.BottomStart => "bottom-start",
                    TooltipPlacement.BottomEnd => "bottom-end",
                    TooltipPlacement.Right => "right",
                    TooltipPlacement.RightStart => "right-start",
                    TooltipPlacement.RightEnd => "right-end",
                    TooltipPlacement.Left => "left",
                    TooltipPlacement.LeftStart => "left-start",
                    TooltipPlacement.LeftEnd => "left-end",
                    _ => "top"
                };
            }
        }

        private string TriggerString
        {
            get
            {
                var result =  string.Join(" ",
                    Enum.GetValues<TooltipTrigger>()
                        .Cast<TooltipTrigger>()
                        .Where(t => t != TooltipTrigger.Manual && Trigger.HasFlag(t))
                        .Select(t => t.ToString().ToLower())
                );
                return string.IsNullOrWhiteSpace(result) ? "manual" : result;

            }
        }

        protected override string StyleNames => BuildStyleNames(Style,
            ($"--max-width: {MaxWidth}", MaxWidth != null),
            ($"--wa-tooltip-arrow-size: {ArrowSize}", ArrowSize != null)
);
        #endregion

        #region Public Methods
        
        public async Task ShowAsync()
        {
            Open = true;
            await InvokeAsync(StateHasChanged);
        }
        public void Show() => _ = ShowAsync();


        public async Task HideAsync()
        {
            Open = false;
            StateHasChanged();
        }

        public void Hide() => _ = HideAsync();
        #endregion


    }


}
