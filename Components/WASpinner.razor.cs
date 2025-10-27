using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WASpinner : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// A custom label for assistive devices.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// Size of the spinner in CSS font-size units. If not defined, the parent element's font size will be used.
        /// </summary>
        [Parameter]
        public string? Size { get; set; }

        /// <summary>
        /// The width of the track  in CSS units.
        /// </summary>
        [Parameter]
        public string? TrackWidth { get; set; }

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

        /// <summary>
        /// The time it takes for the spinner to complete one animation cycle. Default is two seconds.
        /// </summary>
        [Parameter]
        public string? Speed { get; set; } = "2s";
        #endregion

        #region Computed  Properties
        protected override string StyleNames => BuildStyleNames(Style,
    ($"font-size: {Size}", !String.IsNullOrEmpty(Size)),
    ($"--track-width: {TrackWidth}", !String.IsNullOrEmpty(TrackWidth)),
    ($"--track-color: {TrackColor}", !String.IsNullOrEmpty(TrackColor)),
    ($"--indicator-color: {IndicatorColor}", !String.IsNullOrEmpty(IndicatorColor)),
    ($"--speed: {Speed}", !String.IsNullOrEmpty(Speed))
);
        #endregion


    }


}
