using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WAPage : WALayoutComponentBase
    {
        #region Parameters
        /// <summary>
        /// Raised events when the page is resized.
        /// </summary>
        [Parameter]
        public bool ObserveResize { get; set; } = false;

        /// <summary>
        /// Event callback when the page is resized. Only invoked if ObserveResize is true. 
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnResize { get; set; }

        /// <summary>
        /// Use WALayoutContent components to render the page layout.
        /// </summary>
        [Parameter]
        public RenderFragment? LayoutContent { get; set; }

        /// <summary>
        /// Indicates if the current view is mobile or desktop. This is determined by the MobileBreakpoint parameter.
        /// The value is updated after the component has rendered or when the browser is resized (when ObserveResize is true).
        /// </summary>
        public bool IsMobilePageView { get; private set; } = false;

        /// <summary>
        /// Whether or not the navigation drawer is open. Note, the navigation drawer is only "open" on mobile views.
        /// </summary>
        [Parameter]
        public bool NavOpen { get; set; } = false;

        /// <summary>
        /// Where to place the navigation when in the mobile viewport.
        /// </summary>
        [Parameter]
        public PageNavigationPlacement NavigationPlacement { get; set; } = PageNavigationPlacement.Start;

        /// <summary>
        /// At what page width to hide the "navigation" slot and collapse into a hamburger button. Accepts both numbers (interpreted as px) and CSS lengths (e.g. 50em), which are resolved based on the root element.
        /// </summary>
        [Parameter]
        public string? MobileBreakpoint { get; set; } = "768px";

        /// <summary>
        /// Indicates if the banner should be sticky. Default is true.
        /// </summary>
        [Parameter]
        public bool IsStickyBanner { get; set; } = true;
        /// <summary>
        /// Indicates if the header should be sticky. Default is true.
        /// </summary>
        [Parameter]
        public bool IsStickyHeader { get; set; } = true;
        /// <summary>
        /// Indicates if the subheader should be sticky. Default is true.
        /// </summary>
        [Parameter]
        public bool IsStickySubHeader { get; set; } = true;
        /// <summary>
        /// Indicates if the menu should be sticky. Default is true.
        /// </summary>
        [Parameter]
        public bool IsStickyMenu { get; set; } = true;
        /// <summary>
        /// Indicates if the aside should be sticky. Default is true.
        /// </summary>
        [Parameter]
        public bool IsStickyAside { get; set; } = true;

        /// <summary>
        /// A custom loading content to show while the component is initializing. Prevents showing layout content until the component has fully rendered.
        /// </summary>
        [Parameter]
        public RenderFragment LoadingContent { get; set; } = default!;
        #endregion

        #region Computed  Properties
        string NavigationPlacementString
        {
            get
            {
                return NavigationPlacement switch
                {
                    PageNavigationPlacement.Start => "start",
                    PageNavigationPlacement.End => "end",
                    _ => "start"
                };
            }
        }

        private string? DisableSticky
        {
            get
            {
                (string? cssClass, bool when)[] cssClassList = { ($"banner", !IsStickyBanner),
                ($"header", !IsStickyHeader),
                ($"sub-header", !IsStickySubHeader),
                ($"menu", !IsStickyMenu),
                ($"aside", !IsStickyAside)};

                var list = new HashSet<string>();

                if (cssClassList is not null && cssClassList.Any())
                    foreach (var (cssClass, when) in cssClassList)
                        if (!string.IsNullOrWhiteSpace(cssClass) && when)
                            list.Add(cssClass);

                if (list.Any())
                    return string.Join(" ", list);

                return string.Empty;
            }
        }
        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.page.initialize", Id, objRef, ObserveResize ? _resizeId : null);

                await Task.Delay(1);

                await GetPageViewAsync();

                _hasRendered = true;

                StateHasChanged();
            }

        }


        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    // if (IsRenderComplete)
                    // await JSRuntime.InvokeVoidAsync("window.blazorBootstrap.modal.dispose", Id);
                }
                catch (JSDisconnectedException)
                {
                    // do nothing
                }

                objRef?.Dispose();

                // if (ModalService is not null && IsServiceModal)
                //     ModalService.OnShow -= OnShowAsync;
            }

            await base.DisposeAsyncCore(disposing);
        }

        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= new Dictionary<string, object>();

            _hasRendered = false;

            await base.OnInitializedAsync();
        }
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleResize(string view)
        {
            IsMobilePageView = view == "mobile";
            await InvokeAsync(StateHasChanged);
            if (ObserveResize && OnResize.HasDelegate)
                await OnResize.InvokeAsync(IsMobilePageView);
        }
        #endregion

        #region State

        private DotNetObjectReference<WAPage> objRef = default!;

        private string _resizeId = IdUtility.GetNextId();

        private bool _hasRendered = false;
        #endregion

        #region Private Methods
        private async Task GetPageViewAsync()
        {
            IsMobilePageView = await JSRuntime.InvokeAsync<string>("window.vengage.page.view", Id) == "mobile";
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Shows the mobile navigation drawer
        /// </summary>
        public async Task ShowNavigationAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.page.shownav", Id);
        }

        public void ShowNavigation() => _ = ShowNavigationAsync();

        /// <summary>
        /// Hides the mobile navigation drawer
        /// </summary>
        public async Task HideNavigationAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.page.hidenav", Id);
        }

        public void HideNavigation() => _ = HideNavigationAsync();


        /// <summary>
        /// Toggles the mobile navigation drawer
        /// </summary>
        public async Task ToggleNavigationAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.page.togglenav", Id);
        }

        public void ToggleNavigation() => _ = ToggleNavigationAsync();
        #endregion

     }
	
	
}
