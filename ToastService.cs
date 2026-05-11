namespace WebAwesomeBlazor
{
    public class ToastService
    {
        private readonly List<WeakReference<Func<ToastMessage, Task>>> _onCreate = new();
        private readonly List<WeakReference<Func<string, Task>>> _onHide = new();
        private readonly List<WeakReference<Func<ToastMessage, Task>>> _onDismiss = new();

        public void RegisterCreate(Func<ToastMessage, Task> handler)
            => _onCreate.Add(new WeakReference<Func<ToastMessage, Task>>(handler));

        public void RegisterHide(Func<string, Task> handler)
            => _onHide.Add(new WeakReference<Func<string, Task>>(handler));

        public void RegisterDismiss(Func<ToastMessage, Task> handler)
            => _onDismiss.Add(new WeakReference<Func<ToastMessage, Task>>(handler));

        public async Task CreateAsync(ToastMessage message)
        {
            foreach (var weak in _onCreate.ToList())
            {
                if (weak.TryGetTarget(out var handler))
                    await handler(message);
                else
                    _onCreate.Remove(weak);
            }
        }

        public async Task HideToastAsync(string id)
        {
            foreach (var weak in _onHide.ToList())
            {
                if (weak.TryGetTarget(out var handler))
                    await handler(id);
                else
                    _onHide.Remove(weak);
            }
        }

        public async Task DismissAsync(ToastMessage message)
        {
            foreach (var weak in _onDismiss.ToList())
            {
                if (weak.TryGetTarget(out var handler))
                    await handler(message);
                else
                    _onDismiss.Remove(weak);
            }
        }
    }



}
