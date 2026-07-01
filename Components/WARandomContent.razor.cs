using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WARandomContent : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Entrance animation for newly shown children.
        /// </summary>
        [Parameter]
        public RandomContentAnimation Animation { get; set; } = RandomContentAnimation.None;
        /// <summary>
        /// Rotate the content automatically. Set the cadence with `AutoPlayInterval`.
        /// </summary>
        [Parameter]
        public bool AutoPlay { get; set; } = false;
        /// <summary>
        /// Autoplay cadence in milliseconds.
        /// </summary>
        [Parameter]
        public int AutoPlayInterval { get; set; } = 3000;
        /// <summary>
        /// Number of children to show simultaneously. Must be more than 1 and less than or equal to the number of children.
        /// </summary>
        [Parameter]
        public int DisplayItems { get; set; } = 1;
        /// <summary>
        /// Selection strategy: unique (default), random, or sequence.
        /// </summary>
        [Parameter]
        public RandomContentMode Mode { get; set; } = RandomContentMode.Unique;
        /// <summary>
        /// Emitted whenever the displayed selection changes, including on first render, on Randomize(), and on each autoplay tick. Provides the IDs of the newly selected content items.
        /// </summary>
        [Parameter]
        public EventCallback<string[]> ContentChanged { get; set; }

        /// <summary>
        /// Duration of the entrance animation. Default is 300ms.
        /// </summary>
        [Parameter]
        public int AnimationDuration { get; set; } = 300;

        /// <summary>
        /// Easing function for the entrance animation. Default is ease.
        /// </summary>
        [Parameter]
        public string AnimationEasing { get; set; } = "ease";

        /// <summary>
        /// Translation distance for directional animations (fade-up, fade-down, fade-left, fade-right). Default is 0.5em.
        /// </summary>
        [Parameter]
        public string AnimationTranslate { get; set; } = "0.5em";
        #endregion

        #region Computed  Properties
        protected override string? ClassNames => $"wa-cloak {Class}";

        protected override string StyleNames => BuildStyleNames(Style,
            ($"--animation-duration: {AnimationDuration}ms", true),
            ($"--animation-easing: {AnimationEasing}", !String.IsNullOrEmpty(AnimationEasing)),
            ($"--animation-translate: {AnimationTranslate}", !String.IsNullOrEmpty(AnimationTranslate))
        );

        int DisplayItemsComputed => Math.Max(1, DisplayItems);

        string AnimationString => Animation switch
        {
            RandomContentAnimation.None => "none",
            RandomContentAnimation.Fade => "fade",
            RandomContentAnimation.FadeUp => "fade-up",
            RandomContentAnimation.FadeDown => "fade-down",
            RandomContentAnimation.FadeLeft => "fade-left",
            RandomContentAnimation.FadeRight => "fade-right",
            _ => "none",
        };

        string ModeString => Mode switch
        {
            RandomContentMode.Unique => "unique",
            RandomContentMode.Random => "random",
            RandomContentMode.Sequence => "sequence",
            _ => "unique",
        };
        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
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

        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);
            await base.OnInitializedAsync();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// 	Emitted when the content changes.
        /// </summary>
        [JSInvokable]
        public async Task HandleContentChanged(string[] Ids)
        {
            if (ContentChanged.HasDelegate)
                await ContentChanged.InvokeAsync(Ids);
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Selects a new set of children using the current mode. Returns the elements now shown.
        /// </summary>
        /// <returns>The IDs of the newly selected content items.</returns>
        public async Task<string[]> RandomizeAsync()
        {
            return await SafeInvokeAsync<string[]>("randomize", Id!);
        }
        #endregion

        #region State
        private DotNetObjectReference<WARandomContent> objRef = default!;
        #endregion



    }


}
