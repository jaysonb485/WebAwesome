using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Extended
{
    public partial class WANavTreeItem : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// If NavigateOnClick is true, the URL to navigate to when the item is clicked.
        /// This route will be matched against the current URL to determine if the item is active.
        /// </summary>
        [Parameter]
        public string? Href { get; set; }

        [Parameter]
        public EventCallback<string> TreeItemClicked { get; set; }

        [Parameter]
        public NavLinkMatch? Match { get; set; } = NavLinkMatch.All;

        /// <summary>
        /// Expands the tree item.
        /// </summary>
        [Parameter]
        public bool Expanded { get; set; } = false;

        /// <summary>
        /// Disables the tree item.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Enables lazy loading behavior.
        /// </summary>
        [Parameter]
        public bool LazyLoading { get; set; } = false;

        /// <summary>
        /// Uses navigation manager to navigate to the URL specified in the Href property when the item is clicked.
        /// Otherwise, only raises the TreeItemClicked event.
        /// </summary>
        [Parameter]
        public bool NavigateOnClick { get; set; } = true;
        #endregion


        #region Private Methods
        private async Task ItemClicked()
        {
            if (string.IsNullOrEmpty(Href))
            {
                return;
            }
            // Navigate to the URL specified in the Href property
            if (NavigateOnClick)
                navigationManager.NavigateTo(Href);

            if (TreeItemClicked.HasDelegate)
            {
                await TreeItemClicked.InvokeAsync(Href);
            }

        }

        private bool IsActive(string? href, NavLinkMatch? navLinkMatch = NavLinkMatch.Prefix)
        {
            if (string.IsNullOrEmpty(href))
            {
                return false;
            }

            var relativePath = navigationManager.ToBaseRelativePath(navigationManager.Uri).ToLower();
            return navLinkMatch == NavLinkMatch.All ? relativePath == href.ToLower().TrimStart('/') : relativePath.StartsWith(href.ToLower().TrimStart('/'));
        }
        #endregion
    }


}
