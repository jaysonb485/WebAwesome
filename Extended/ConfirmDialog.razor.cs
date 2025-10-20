using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Extended
{
    public partial class ConfirmDialog : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The drawer's title as displayed in the header. You should always include a relevant title, as it is required for proper accessibility.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool LightDismiss { get; set; } = false;
        #endregion

        #region Computed  Properties
        protected override string? ClassNames =>
            BuildClassNames(Class,
                ("dialog-deny-close", true));


        #endregion

        #region State

        private string? Message { get; set; } = null;
        private string? ConfirmButtonText { get; set; } = "Ok";
        private string? CancelButtonText { get; set; } = "Cancel";
        private bool IsVisible { get; set; } = false;
        private TaskCompletionSource<ConfirmationDialogResult>? taskCompletionSource;

        private Components.WADialog DialogReference = default!;
        #endregion

        #region Private Methods
        /// <summary>
        /// Hides confirm dialog.
        /// </summary>
        private void Hide()
        {
            DialogReference.Hide();
//            StateHasChanged();

            //Task.Run(() => JSRuntime.InvokeVoidAsync("window.vengage.dialog.change", Id, false));
        }

        private void OnNoClick()
        {
            Hide();
            taskCompletionSource?.SetResult(new(false, false));
        }

        private void OnYesClick()
        {
            Hide();
            taskCompletionSource?.SetResult(new(false, true));
        }
        private Task<ConfirmationDialogResult> Show(string title, string? message1, string? confirmButtonText = "Ok", string? cancelButtonText = "Cancel")
        {
            taskCompletionSource = new TaskCompletionSource<ConfirmationDialogResult>();
            var task = taskCompletionSource.Task;

            this.Title = title;
            this.Message = message1;
            this.ConfirmButtonText = confirmButtonText;
            this.CancelButtonText = cancelButtonText;

            //IsVisible = true;

            StateHasChanged();
            DialogReference.Show();

            //Task.Run(() => JSRuntime.InvokeVoidAsync("window.vengage.dialog.change", Id, true));

            return task;
        }

        private void OnDialogClosed(string result)
        {
            if(taskCompletionSource == null || taskCompletionSource.Task.IsCompleted)
                return;

            taskCompletionSource.SetResult(new(true, false));
        }

        #endregion

        #region Public Methods
        public Task<ConfirmationDialogResult> ShowAsync(string Title, string Message) => Show(Title, Message);
        public Task<ConfirmationDialogResult> ShowAsync(string Title, string Message, string ConfirmButtonText, string CancelButtonText) => Show(Title, Message, ConfirmButtonText, CancelButtonText);


        #endregion

    
    }

    public class ConfirmationDialogResult()
    {
        public ConfirmationDialogResult(bool IsCancelled, bool Confirmed) : this()
        {
            this.IsCancelled = IsCancelled;
            this.Confirmed = Confirmed;
        }

        public bool IsCancelled { get; set; }
        public bool Confirmed { get; set; }
    }
}
