using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Extended
{
    public interface IConfirmDialog
    {
        Task<bool> ShowAsync(string Title, string Message, string? ConfirmText = "Yes", string? DeclineText = "No");
    }
    public class ConfirmDialogService : IConfirmDialog
    {
        private TaskCompletionSource<bool>? _tcs;
        public event Action<string, string, string?, string?>? OnShow;

        public Task<bool> ShowAsync(string Title, string Message, string? ConfirmText = "Yes", string? DeclineText = "No")
        {
            _tcs = new TaskCompletionSource<bool>();
            OnShow?.Invoke(Title, Message, ConfirmText, DeclineText);
            return _tcs.Task;
        }

        public void SetResult(bool result)
        {
            _tcs?.TrySetResult(result);
        }
    }

}
