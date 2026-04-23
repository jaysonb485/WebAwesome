using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebAwesomeBlazor
{
    public abstract class WALayoutComponentBase : LayoutComponentBase, IDisposable, IAsyncDisposable
    {
        #region Fields and Constants

        private bool isAsyncDisposed;

        private bool isDisposed;
        private IJSObjectReference? _module;
        private string? _moduleFileName;

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            IsRenderComplete = true;

            await base.OnAfterRenderAsync(firstRender);
        }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            Id ??= IdUtility.GetNextId();

            base.OnInitialized();
        }

        public static string BuildClassNames(params (string? cssClass, bool when)[] cssClassList)
        {
            var list = new HashSet<string>();

            if (cssClassList is not null && cssClassList.Any())
                foreach (var (cssClass, when) in cssClassList)
                    if (!string.IsNullOrWhiteSpace(cssClass) && when)
                        list.Add(cssClass);

            if (list.Any())
                return string.Join(" ", list);

            return string.Empty;
        }

        public static string BuildClassNames(string? userDefinedCssClass, params (string? cssClass, bool when)[] cssClassList)
        {
            var list = new HashSet<string>();

            if (cssClassList is not null && cssClassList.Any())
                foreach (var (cssClass, when) in cssClassList)
                    if (!string.IsNullOrWhiteSpace(cssClass) && when)
                        list.Add(cssClass);

            if (!string.IsNullOrWhiteSpace(userDefinedCssClass))
                list.Add(userDefinedCssClass.Trim());

            if (list.Any())
                return string.Join(" ", list);

            return string.Empty;
        }

        public static string BuildStyleNames(string? userDefinedCssStyle, params (string? cssStyle, bool when)[] cssStyleList)
        {
            var list = new HashSet<string>();

            if (cssStyleList is not null && cssStyleList.Any())
                foreach (var (cssStyle, when) in cssStyleList)
                    if (!string.IsNullOrWhiteSpace(cssStyle) && when)
                        list.Add(cssStyle);

            if (!string.IsNullOrWhiteSpace(userDefinedCssStyle))
                list.Add(userDefinedCssStyle.Trim());

            if (list.Any())
                return string.Join(';', list);

            return string.Empty;
        }

        /// <inheritdoc />
        /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0" />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc />
        /// <see
        ///     href="https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync#implement-both-dispose-and-async-dispose-patterns" />
        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore(true).ConfigureAwait(false);
            if (_module is not null)
            {
                try
                {
                    await _module.DisposeAsync();
                }
                catch
                {
                    // swallow — Blazor may already be shutting down
                }
            }
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // cleanup
                }

                isDisposed = true;
            }
        }

        protected virtual ValueTask DisposeAsyncCore(bool disposing)
        {
            if (!isAsyncDisposed)
            {
                if (disposing)
                {
                    // cleanup
                }

                isAsyncDisposed = true;
            }

            return ValueTask.CompletedTask;
        }

        #endregion

        #region Properties, Indexers

        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> AdditionalAttributes { get; set; } = default!;

        [Parameter] public string? Class { get; set; }

        [Parameter] public RenderFragment? ChildContent { get; set; }

        protected virtual string? ClassNames => Class;

        public ElementReference Element { get; set; }

        [Parameter] public string? Id { get; set; }

        protected bool IsRenderComplete { get; private set; }

        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;

        [Parameter] public string? Style { get; set; }

        protected virtual string? StyleNames => Style;

        [Parameter] public string? Slot { get; set; }

        #endregion

        #region Other

        ~WALayoutComponentBase()
        {
            Dispose(false);
        }

        #endregion

        #region Private Methods
        protected async Task<IJSObjectReference> LoadModuleAsync(string? moduleFileName = "")
        {
            _moduleFileName ??= string.IsNullOrWhiteSpace(moduleFileName) ? $"./_content/WebAwesomeBlazor/Components/{GetType().Name}.razor.js" : moduleFileName;

            if (_module is null)
            {
                _module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", _moduleFileName);
            }

            return _module;
        }

        protected async Task InvokeVoidAsync(string methodName, params object[] args)
        {
            await LoadModuleAsync();
            if (_module is not null)
            {
                await _module.InvokeVoidAsync(methodName, args);
            }
            else
            {
                throw new InvalidOperationException("Module state is invalid. Ensure JS calls are only made after render.");
            }
        }

        protected async Task<T> InvokeAsync<T>(string methodName, params object[] args)
        {
            await LoadModuleAsync();
            if (_module is not null)
            {
                return await _module.InvokeAsync<T>(methodName, args);
            }
            else
            {
                throw new InvalidOperationException("Module state is invalid. Ensure JS calls are only made after render.");
            }
        }
        #endregion
    }
}
