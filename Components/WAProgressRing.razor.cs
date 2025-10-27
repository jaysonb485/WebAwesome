using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WAProgressRing : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The current progress as a percentage, 0 to 100.
        /// </summary>
        [Parameter]
        public int Value { get; set; } = 0;

        /// <summary>
        /// A custom label for assistive devices.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// Text to show inside the ring.
        /// </summary>
        [Parameter]
        public string? Text { get; set; }

        /// <summary>
        /// Size of the progress ring in CSS units.
        /// </summary>
        [Parameter]
        public string? Size { get; set; }

        /// <summary>
        /// The width of the track  in CSS units.
        /// </summary>
        [Parameter]
        public string? TrackWidth { get; set; }

        /// <summary>
        /// The width of the indicator. Defaults to the track width.
        /// </summary>
        [Parameter]
        public string? IndicatorWidth { get; set; }

        /// <summary>
        /// The colour of the track  in CSS units.
        /// </summary>
        [Parameter]
        public string? TrackColor { get; set; }

        /// <summary>
        /// The colour of the indicator. Defaults to the track width.
        /// </summary>
        [Parameter]
        public string? IndicatorColor { get; set; }
        #endregion

        #region Computed  Properties
        protected override string StyleNames => BuildStyleNames(Style,
    ($"--size: {Size}", !String.IsNullOrEmpty(Size)),
    ($"--track-width: {TrackWidth}", !String.IsNullOrEmpty(TrackWidth)),
    ($"--indicator-width: {IndicatorWidth}", !String.IsNullOrEmpty(IndicatorWidth)),
    ($"--track-color: {TrackColor}", !String.IsNullOrEmpty(TrackColor)),
    ($"--indicator-color: {IndicatorColor}", !String.IsNullOrEmpty(IndicatorColor))
);
        #endregion


    }


}
