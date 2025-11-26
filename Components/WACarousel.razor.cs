using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

        /// <summary>
        /// The aspect ratio of each slide. Default is 16/9
        /// </summary>
        [Parameter]
        public string? AspectRatio { get; set; }
        /// <summary>
        /// The amount of padding to apply to the scroll area, allowing adjacent slides to become partially visible as a scroll hint.
        /// </summary>
        [Parameter]
        public string? ScrollHint { get; set; }
        /// <summary>
        /// The space between each slide. Default var(--wa-space-m)
        /// </summary>
        [Parameter]
        public string? SlideGap { get; set; }
        [Parameter]
        public EventCallback<int> SlideChanged { get; set; }
        #endregion

        #region Computed Properties
        string OrientationString
        {
            get
            {
                return (Orientation == CarouselOrientation.Horizontal) ? "horizontal" : "vertical";
            }
        }

        protected override string? StyleNames => BuildStyleNames(Style,
            ($"--aspect-ratio: {AspectRatio}", !String.IsNullOrEmpty(AspectRatio)),
            ($"--scroll-hint: {ScrollHint}", !String.IsNullOrEmpty(ScrollHint)),
            ($"--slide-gap: {SlideGap}", !String.IsNullOrEmpty(SlideGap))
        );
        #endregion
        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.carousel.initialize", Id, objRef);
            }
        }

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                try
                {
                }
                catch (JSDisconnectedException)
                {
                    // do nothing
                }

                objRef?.Dispose();

            }

            await base.DisposeAsyncCore(disposing);
        }

        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);

            await base.OnInitializedAsync();
        }
        #endregion

        #region Public Methods
        [JSInvokable]
        public async Task HandleSlideChange(int currentIndex)
        {
            if (SlideChanged.HasDelegate)
            {
                await SlideChanged.InvokeAsync(currentIndex);
            }
        }

        /// <summary>
        /// Scrolls the carousel to the slide specified by index.
        /// </summary>
        /// <param name="index">The index to scroll to</param>
        public async Task GoToSlideAsync(int index)
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.carousel.goToSlide", Id, index);
        }

        public void GoToSlide(int index) => _ = GoToSlideAsync((int)index);

        /// <summary>
        /// Move the carousel forward by SlidesPerMove slides.
        /// </summary>
        public async Task NextSlideAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.carousel.nextSlide", Id);
        }

        public void NextSlide() => _ = NextSlideAsync();
        /// <summary>
        /// Move the carousel backward by SlidesPerMove slides.
        /// </summary>
        /// <returns></returns>
        public async Task PreviousSlideAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.carousel.previousSlide", Id);
        }

        public void PreviousSlide() => _ = PreviousSlideAsync();

        #endregion
        #region State
        private DotNetObjectReference<WACarousel> objRef = default!;
        #endregion

    }
}
