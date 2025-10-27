using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WACarousel : WAComponentBase
    {
        #region Parameters

        /// <summary>
        /// When true, show the carousel's pagination indicators.
        /// </summary>
        [Parameter]
        public bool ShowPagination { get; set; } = false;

        /// <summary>
        /// When true, allows the user to navigate the carousel in the same direction indefinitely.
        /// </summary>
        [Parameter]
        public bool AllowLooping { get; set; } = false;

        /// <summary>
        /// When true, show the carousel's navigation.
        /// </summary>
        [Parameter]
        public bool ShowNavigation { get; set; } = false;

        /// <summary>
        /// When true, the slides will scroll automatically when the user is not interacting with them.
        /// </summary>
        [Parameter]
        public bool Autoplay { get; set; } = false;

        /// <summary>
        /// Specifies the amount of time, in milliseconds, between each automatic scroll when Autoplay is true.
        /// </summary>
        [Parameter]
        public int AutoplayInterval { get; set; } = 3000;

        /// <summary>
        /// Specifies how many slides should be shown at a given time.
        /// </summary>
        [Parameter]
        public int SlidesPerPage { get; set; } = 1;

        /// <summary>
        /// Specifies the number of slides the carousel will advance when scrolling, useful when specifying a slides-per-page greater than one. It can't be higher than slides-per-page.
        /// </summary>
        [Parameter]
        public int SlidesPerMove { get; set; } = 1;

        /// <summary>
        /// Specifies the orientation in which the carousel will lay out.
        /// </summary>
        [Parameter]
        public CarouselOrientation Orientation { get; set; } = CarouselOrientation.Horizontal;

        /// <summary>
        /// When true, it is possible to scroll through the slides by dragging them with the mouse.
        /// </summary>
        [Parameter]
        public bool MouseDraggingEnabled { get; set; } = false;
        #endregion

        #region Computed Properties
        string OrientationString
        {
            get
            {
                return (Orientation == CarouselOrientation.Horizontal) ? "horizontal" : "vertical";
            }
        }
        #endregion

    }
}
