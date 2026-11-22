using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace WebAwesomeBlazor.Components
{
    public partial class WACounter : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The date from which to calculate time from. If not set, the current date and time will be used. Setting a date/time inline may result in restting the countdown on render.
        /// </summary>
        [Parameter]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// Text to show between units, such as :.
        /// </summary>
        [Parameter]
        public string? Delimiter { get; set; } = string.Empty;

        /// <summary>
        /// The direction to count. Use down to count down to the date and up to count up from it.
        /// </summary>
        [Parameter]
        public CounterDirection Direction { get; set; } = CounterDirection.Down;

        /// <summary>
        /// The number of milliseconds to count down from, starting when the counter is added to the page. Changing it starts the countdown over. Ignored when date is set or direction is up.
        /// </summary>
        [Parameter]
        public int? Duration { get; set; }

        /// <summary>
        /// The formatting style of the unit labels.
        /// </summary>
        [Parameter]
        public CounterFormat Format { get; set; } = CounterFormat.Long;

        /// <summary>
        /// A label that describes the counter to assistive devices.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The largest unit to show. Time beyond it rolls up into it, so two days show as 48 hours when this is hours. Units at zero ahead of the first non-zero unit are hidden unless ShowLabels is false. Falls back to the default range when either unit is invalid or the smallest unit is larger than the largest.
        /// </summary>
        [Parameter]
        public CounterUnit LargestUnit { get; set; } = CounterUnit.Days;

        /// <summary>
        /// Pauses the counter. Used PauseAsync and UnpauseAsync to change state.
        /// </summary>
        [Parameter]
        public bool Paused { get; set; } = false;
        /// <summary>
        /// The smallest unit to show. Time below it is dropped. Falls back to the default range when either unit is invalid or the smallest unit is larger than the largest.
        /// </summary>
        [Parameter]
        public CounterUnit SmallestUnit { get; set; } = CounterUnit.Seconds;

        /// <summary>
        /// Shows the unit labels.
        /// </summary>
        [Parameter]
        public bool ShowLabels { get; set; } = true;

        /// <summary>
        /// A custom label for days.
        /// </summary>
        [Parameter]
        public RenderFragment? DaysContent { get; set; }
        /// <summary>
        /// A custom label for minutes.
        /// </summary>
        [Parameter]
        public RenderFragment? MinutesContent { get; set; }
        /// <summary>
        /// A custom label for hours.
        /// </summary>
        [Parameter]
        public RenderFragment? HoursContent { get; set; }
        /// <summary>
        /// A custom label for seconds.
        /// </summary>
        [Parameter]
        public RenderFragment? SecondsContent { get; set; }
        /// <summary>
        /// A custom label for months.
        /// </summary>
        [Parameter]
        public RenderFragment? MonthsContent { get; set; }
        /// <summary>
        /// A custom label for years.
        /// </summary>
        [Parameter]
        public RenderFragment? YearsContent { get; set; }
        /// <summary>
        /// Content to show in place of the units when a countdown is at zero, including one whose date had already passed.
        /// </summary>
        [Parameter]
        public RenderFragment? FinishedContent { get; set; }
        /// <summary>
        /// Emitted when a running countdown reaches zero. Not emitted when the date had already passed.
        /// </summary>
        [Parameter]
        public EventCallback Finished { get; set; }

        #endregion

        #region Computed  Properties
        string DateTimeISOString
        {
            get
            {
                if (DateTimeValue is null) return string.Empty;
                return DateTimeValue.Value.ToString("o", CultureInfo.InvariantCulture);
            }
        }

        #endregion
        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {

                _instance = await SafeInvokeAsync<IJSObjectReference>("initialize", Element, objRef);
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


            AdditionalAttributes ??= new Dictionary<string, object>();

            await base.OnInitializedAsync();
        }
        #endregion

        #region State
        private DotNetObjectReference<WACounter> objRef = default!;
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleCounterFinished()
        {
            await Finished.InvokeAsync();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Pauses the counter
        /// </summary>
        public async Task PauseAsync()
        {
            Paused = true;
        }

        /// <summary>
        /// Resumes the counter
        /// </summary>
        public async Task UnpauseAsync()
        {
            Paused = false;
        }
        #endregion

    }


}
