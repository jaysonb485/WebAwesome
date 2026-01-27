using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Linq.Expressions;

namespace WebAwesomeBlazor.Extended
{
    public partial class AutoCompleteInput<TValue> : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public Func<string, Task<List<TValue>>>? SearchFunction { get; set; }

        [Parameter]
        public TValue? Value { get; set; }

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }

        [Parameter]
        public Expression<Func<TValue>> ValueExpression { get; set; } = default!;

        [Parameter]
        public int MinimumSearchLength { get; set; } = 3;

        [Parameter]
        public Func<string, Task<TValue>> AddNewItemFunction { get; set; } = default!;

        [Parameter]
        public string? LoadingText { get; set; } = "Loading...";

        [Parameter]
        public string? EmptyText { get; set; } = "Nothing found";

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public string? ItemNameProperty { get; set; }

        [Parameter]
        public string? ItemValueProperty { get; set; }

        [Parameter]
        public bool AllowNewItems { get; set; } = false;

        [Parameter]
        public string? Placeholder { get; set; }
        [Parameter]
        public string? Hint { get; set; }
        [Parameter]
        public int DebounceDelay { get; set; } = 300;
        #endregion

        #region Computed  Properties

        #endregion

        #region Lifecycle
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (!Initialised)
            {
                if (Value != null)
                {
                    SearchText = @GetPropertyName((TValue)(object)Value);
                }
                Initialised = true;
            }

        }
        #endregion

        #region Event Handlers
        private async Task OnSearchChanged(ChangeEventArgs e)
        {

            SearchText = e.Value?.ToString();
            if (string.IsNullOrWhiteSpace(SearchText))

            {
                ShowPopup = false;
                SearchInProgress = false;
                Items.Clear();

                if (ValueChanged.HasDelegate)
                {
                    await ValueChanged.InvokeAsync((TValue?)(object?)null);
                    return;
                }
            }

            // Cancel any previous debounce
            _debounceCts?.Cancel();
            _debounceCts = new CancellationTokenSource();
            var token = _debounceCts.Token;

            try
            {
                SearchInProgress = true;
                // Debounce delay
                await Task.Delay(DebounceDelay, token);

                // Only search if still valid
                if (SearchText!.Length >= MinimumSearchLength && SearchFunction != null)
                {
                    ShowPopup = true;

                    Items = await SearchFunction.Invoke(SearchText);
                }
                else
                {
                    ShowPopup = false;
                    Items.Clear();
                }
            }
            catch (TaskCanceledException)
            {
                // Expected when user types again before debounce finishes
            }
            finally
            {
                SearchInProgress = false;
            }


        }

        private async Task OnItemSelected(TValue item)
        {

            if (ValueChanged.HasDelegate)
            {
                await ValueChanged.InvokeAsync((TValue?)(object?)item);
            }

            ShowPopup = false;
            //SearchText = @GetPropertyName(item);
            await SearchInputBox.SetValueAsync(@GetPropertyName(item) ?? string.Empty);
            Items.Clear();
        }

        private async Task OnNewItemSelected()
        {
            if (AddNewItemFunction == null || string.IsNullOrWhiteSpace(SearchText))
                return;

            var newItem = await AddNewItemFunction.Invoke(SearchText);
            await OnItemSelected(newItem);

            ShowPopup = false;
            Items.Clear();
        }

        #endregion

        #region State
        private List<TValue> Items { get; set; } = [];
        private bool ShowPopup { get; set; } = false;
        private bool SearchInProgress { get; set; } = false;
        private Components.WAInput SearchInputBox = default!;
        private bool Initialised { get; set; } = false;
        private string? SearchText { get; set; }
        private CancellationTokenSource? _debounceCts;
        #endregion

        #region Private Methods
        private string? GetPropertyName(TValue item)
        {
            if (item == null)
                return string.Empty;

            // Handle string and primitive types directly
            var itemType = typeof(TValue);
            if (itemType == typeof(string) || itemType.IsPrimitive || itemType.IsValueType)
            {
                return item.ToString();
            }

            // If no property name is provided, fallback to ToString
            if (string.IsNullOrWhiteSpace(ItemNameProperty))
                return item.ToString();

            // Use reflection for complex types
            var propertyInfo = itemType.GetProperty(ItemNameProperty);
            if (propertyInfo == null)
                return $"[Missing property: {ItemNameProperty}]";

            var value = propertyInfo.GetValue(item);
            return value?.ToString();

        }

        private string? GetPropertyValue(TValue item)
        {
            if (item == null)
                return string.Empty;

            // Handle string and primitive types directly
            var itemType = typeof(TValue);
            if (itemType == typeof(string) || itemType.IsPrimitive || itemType.IsValueType)
            {
                return item.ToString();
            }

            // If no property name is provided, fallback to ToString
            if (string.IsNullOrWhiteSpace(ItemValueProperty))
                return item.ToString();

            // Use reflection for complex types
            var propertyInfo = itemType.GetProperty(ItemValueProperty);
            if (propertyInfo == null)
                return $"[Missing property: {ItemValueProperty}]";

            var value = propertyInfo.GetValue(item);
            return value?.ToString();

        }
        #endregion

        #region Public Methods
        public async Task SetFocusAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.input.setFocus", SearchInputBox.Id);
        }

        public void SetFocus() => _ = SetFocusAsync();
        #endregion

    }


}
