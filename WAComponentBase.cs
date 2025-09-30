using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome
{
    public abstract class WAComponentBase : ComponentBase, IDisposable, IAsyncDisposable
    {

        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> AdditionalAttributes { get; set; } = default!;

        [Parameter] public string? Class { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected virtual string? ClassNames => Class;

        public ElementReference Element { get; set; }

        [Parameter] public string? Id { get; set; }
        [Parameter] public string? Slot { get; set; }

        protected bool IsRenderComplete { get; private set; }

        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;

        [Parameter] public string? Style { get; set; }

        protected virtual string? StyleNames => Style;
        protected override void OnAfterRender(bool firstRender)
        {
            // process queued tasks
            //while (queuedTasks.TryDequeue(out var taskToExecute))
            //    await taskToExecute.Invoke();

            IsRenderComplete = true;
        }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            Id ??= IdUtility.GetNextId();
        }

        public static string BuildClassNames(params (string? cssClass, bool when)[] cssClassList)
        {
            var list = new HashSet<string>();

            if (cssClassList is not null && cssClassList.Any())
                foreach (var (cssClass, when) in cssClassList)
                {
                    if (!string.IsNullOrWhiteSpace(cssClass) && when)
                        list.Add(cssClass);
                }

            if (list.Any())
                return string.Join(" ", list);
            else
                return string.Empty;
        }

        public static string BuildClassNames(string? userDefinedCssClass, params (string? cssClass, bool when)[] cssClassList)
        {
            var list = new HashSet<string>();

            if (cssClassList is not null && cssClassList.Any())
                foreach (var (cssClass, when) in cssClassList)
                {
                    if (!string.IsNullOrWhiteSpace(cssClass) && when)
                        list.Add(cssClass);
                }

            if (!string.IsNullOrWhiteSpace(userDefinedCssClass))
                list.Add(userDefinedCssClass.Trim());

            if (list.Any())
                return string.Join(" ", list);
            else
                return string.Empty;
        }

        public static string BuildStyleNames(string? userDefinedCssStyle, params (string? cssStyle, bool when)[] cssStyleList)
        {
            var list = new HashSet<string>();

            if (cssStyleList is not null && cssStyleList.Any())
                foreach (var (cssStyle, when) in cssStyleList)
                {
                    if (!string.IsNullOrWhiteSpace(cssStyle) && when)
                        list.Add(cssStyle);
                }

            if (!string.IsNullOrWhiteSpace(userDefinedCssStyle))
                list.Add(userDefinedCssStyle.Trim());

            if (list.Any())
                return string.Join(';', list);
            else
                return string.Empty;
        }

        private bool disposed = false;
        private bool asyncDisposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc />
        /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync#implement-both-dispose-and-async-dispose-patterns" />
        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore(true).ConfigureAwait(false);

            Dispose(false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // cleanup
                }

                disposed = true;
            }
        }

        protected virtual ValueTask DisposeAsyncCore(bool disposing)
        {
            if (!asyncDisposed)
            {
                if (disposing)
                {
                    // cleanup
                }

                asyncDisposed = true;
            }

            return ValueTask.CompletedTask;
        }
        ~WAComponentBase()
        {
            Dispose(false);
        }


    }
}
