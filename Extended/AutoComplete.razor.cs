using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Extended
{
    public partial class AutoComplete<TValue, TItem> : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public string? SearchText { get; set; }

        [Parameter]
        public Func<string, Task<List<TItem>>>? SearchFunction { get; set; }

        [Parameter]
        public TValue? Value { get; set; }

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }

        [Parameter]
        public Expression<Func<TValue>> ValueExpression { get; set; } = default!;

        [Parameter]
        public int MinimumSearchLength { get; set; } = 3;

        [Parameter]
        public Func<string, Task<TItem>> AddNewItemFunction { get; set; } = default!;

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
        #endregion

        #region Computed  Properties

        #endregion

        #region Lifecycle
        protected override async Task OnParametersSetAsync()
        {
         if (!Initialised)
            {
                if (Value != null)
                {
                    SearchText = @GetPropertyName((TItem)(object)Value);
                }
                Initialised = true;
            }
            await base.OnParametersSetAsync();
        }
        #endregion

        #region Event Handlers
        private async Task OnSearchChanged(ChangeEventArgs e)
        {

            SearchText = e.Value?.ToString();
            if (SearchText == string.Empty)
            {
                if (ValueChanged.HasDelegate)
                {
                    await ValueChanged.InvokeAsync((TValue?)(object?)null);
                    SearchInProgress = false;
                    return;
                }
            }

            if (SearchText != null && SearchText.Length >= MinimumSearchLength && SearchFunction != null)
            {
                SearchInProgress = true;
                ShowPopup = true;
                await Task.Delay(300); // Debounce delay

                Items = await SearchFunction.Invoke(SearchText);

            }
            else
            {
                ShowPopup = false;
                Items.Clear();
            }

            SearchInProgress = false;

        }

        private async Task OnItemSelected(TItem item)
        {

            if (ValueChanged.HasDelegate)
            {
                await ValueChanged.InvokeAsync((TValue?)(object?)item);
            }

            ShowPopup = false;
            //SearchText = @GetPropertyName(item);
            await SearchInputBox.SetValue(@GetPropertyName(item) ?? string.Empty);
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
        private List<TItem> Items { get; set; } = [];
        private bool ShowPopup { get; set; } = false;
        private bool SearchInProgress { get; set; } = false;

        private Components.WAInput SearchInputBox = default!;

        private bool Initialised { get; set; } = false;
        #endregion

        #region Private Methods
        private string? GetPropertyName(TItem item)
        {
            if (item == null)
                return string.Empty;

            // Handle string and primitive types directly
            var itemType = typeof(TItem);
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

        private string? GetPropertyValue(TItem item)
        {
            if (item == null)
                return string.Empty;

            // Handle string and primitive types directly
            var itemType = typeof(TItem);
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

    }


}
