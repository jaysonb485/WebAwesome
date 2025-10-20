using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WAProgressBar : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The current progress as a percentage, 0 to 100.
        /// </summary>
        [Parameter]
        public decimal Value { get; set; } = 0;

        /// <summary>
        /// When true, percentage is ignored, the label is hidden, and the progress bar is drawn in an indeterminate state.
        /// </summary>
        [Parameter]
        public bool Indeterminate { get; set; } = false;

        /// <summary>
        /// A custom label for assistive devices.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// Text to display over the progress bar
        /// </summary>
        [Parameter]
        public string? Text { get; set; }

        /// <summary>
        /// Height of the progress bar in CSS units.
        /// </summary>
        [Parameter]
        public string? TrackHeight { get; set; }

        /// <summary>
        /// The color of the track.
        /// </summary>
        [Parameter]
        public string? TrackColor { get; set; }

        /// <summary>
        /// The color of the indicator.
        /// </summary>
        [Parameter]
        public string? IndicatorColor { get; set; }
        #endregion

        #region Computed  Properties
        protected override string? StyleNames => BuildStyleNames(Style,
    ($"--track-height: {TrackHeight}", !String.IsNullOrEmpty(TrackHeight)),
    ($"--track-color: {TrackColor}", !String.IsNullOrEmpty(TrackColor)),
    ($"--indicator-color: {IndicatorColor}", !String.IsNullOrEmpty(IndicatorColor))
);
        #endregion

    }


}
