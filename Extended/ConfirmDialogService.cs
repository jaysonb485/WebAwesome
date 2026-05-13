namespace WebAwesomeBlazor.Extended
{
    public class ConfirmDialogService
    {
        private readonly List<WeakReference<Func<DialogRequest, Task>>> _handlers = new();
        private TaskCompletionSource<bool>? _tcs;

        public IDisposable RegisterHandler(Func<DialogRequest, Task> handler)
        {
            var weak = new WeakReference<Func<DialogRequest, Task>>(handler);
            _handlers.Add(weak);

            return new HandlerSubscription(_handlers, weak);
        }

        public Task<bool> ShowAsync(
            string title,
            string message,
            string? confirmText = "Yes",
            string? declineText = "No")
        {
            _tcs = new TaskCompletionSource<bool>();

            var request = new DialogRequest(title, message, confirmText, declineText);

            // Fire all live handlers
            foreach (var weak in _handlers.ToList())
            {
                if (weak.TryGetTarget(out var handler))
                {
                    _ = handler(request);
                }
                else
                {
                    _handlers.Remove(weak);
                }
            }

            return _tcs.Task;
        }

        public void SetResult(bool result)
        {
            _tcs?.TrySetResult(result);
        }

        private sealed class HandlerSubscription : IDisposable
        {
            private readonly List<WeakReference<Func<DialogRequest, Task>>> _list;
            private readonly WeakReference<Func<DialogRequest, Task>> _reference;

            public HandlerSubscription(
                List<WeakReference<Func<DialogRequest, Task>>> list,
                WeakReference<Func<DialogRequest, Task>> reference)
            {
                _list = list;
                _reference = reference;
            }

            public void Dispose()
            {
                _list.Remove(_reference);
            }
        }
    }

    public record DialogRequest(
        string Title,
        string Message,
        string? ConfirmText,
        string? DeclineText);

}
