using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor.Components
{
    public partial class WANumberTicker : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The ISO 4217 currency code to use when formatting.
        /// </summary>
        [Parameter]
        public string CurrencyCode { get; set; } = "USD";
        /// <summary>
        /// How to display the currency.
        /// </summary>
        [Parameter]
        public NumberTickerCurrencyDisplay CurrencyDisplay { get; set; } = NumberTickerCurrencyDisplay.Symbol;
        /// <summary>
        /// The number of milliseconds to wait before counting from the start value. Later value changes aren't delayed.
        /// </summary>
        [Parameter]
        public int Delay { get; set; } = 0;

        /// <summary>
        /// The longest a count can take, in milliseconds. A count ends early once the number shown stops changing. Set to 0 to skip the animation.
        /// </summary>
        [Parameter]
        public int Duration { get; set; } = 2000;
        /// <summary>
        /// Starts counting right away instead of waiting until the ticker scrolls into view.
        /// </summary>
        [Parameter]
        public bool Eager { get; set; } = false;
        /// <summary>
        /// The easing function to use for counting. Accepts any CSS easing function, such as linear, ease-in-out, cubic-bezier(), steps(), or linear(). Invalid values fall back to the default.
        /// </summary>
        [Parameter]
        public string Easing { get; set; } = "cubic-bezier(0.16, 1, 0.3, 1)";
        /// <summary>
        /// The maximum number of fraction digits to use. Possible values are 0-100. If only one fraction digit option is set, it's used for both.
        /// </summary>
        [Parameter]
        public int? MaximumFractionDigits { get; set; }
        /// <summary>
        /// The minimum number of fraction digits to use. Possible values are 0-100. If only one fraction digit option is set, it's used for both.
        /// </summary>
        [Parameter]
        public int? MinimumFractionDigits { get; set; }
        /// <summary>
        /// The maximum number of significant digits to use. Possible values are 1-21.
        /// </summary>
        [Parameter]
        public int? MaximumSignificantDigits { get; set; }
        /// <summary>
        /// The minimum number of integer digits to use. Possible values are 1-21.
        /// </summary>
        [Parameter]
        public int? MinimumSignificantDigits { get; set; }
        /// <summary>
        /// The number to count from on the first run and when RestartAsync() is called.
        /// </summary>
        [Parameter]
        public decimal StartValue { get; set; } = 0;

        /// <summary>
        /// The formatting style to use.
        /// </summary>
        [Parameter]
        public NumberTickerFormatType FormatType { get; set; } = NumberTickerFormatType.Decimal;
        /// <summary>
        /// The number to count to. Once the ticker has started, changing it counts from the number currently displayed to the new value.
        /// </summary>
        [Parameter]
        public decimal Value { get; set; }
        /// <summary>
        /// Shows grouping separators
        /// </summary>
        [Parameter]
        public bool GroupDigits { get; set; } = true;

        /// <summary>
        /// Emitted when a running countdown reaches zero. Not emitted when the date had already passed.
        /// </summary>
        [Parameter]
        public EventCallback Finished { get; set; }

        #endregion

        #region Computed  Properties

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
        private DotNetObjectReference<WANumberTicker> objRef = default!;
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleTickerFinished()
        {
            await Finished.InvokeAsync();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Plays the ticker again from startValue to value.
        /// </summary>
        public async Task RestartAsync()
        {
            await SafeInvokeVoidAsync("restart", Element);
        }

        public void Restart()
        {
            _ = RestartAsync();
        }

        #endregion

    }


}
