using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WACopyButton : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The text value to copy.
        /// </summary>
        [Parameter]
        public string? Value { get; set; }

        /// <summary>
        /// An id that references an element in the same document from which data will be copied. If both this and value are present, this value will take precedence.
        /// By default, the target element's textContent will be copied. Specify an alternate attribute using FromElementAttribute.
        /// </summary>
        [Parameter]
        public string? FromElementId { get; set; }

        /// <summary>
        /// The attribute name of the element referenced by FromElementId from which to copy data. If not specified, the target element's textContent will be copied.
        /// </summary>
        [Parameter]
        public string? FromElementAttribute { get; set; }

        /// <summary>
        /// A custom label to show in the tooltip.
        /// </summary>
        [Parameter]
        public string HoverLabel { get; set; } = "Copy";

        /// <summary>
        /// A custom label to show in the tooltip after copying.
        /// </summary>
        [Parameter]
        public string? SuccessLabel { get; set; } = "Copied";

        /// <summary>
        /// A custom label to show in the tooltip when a copy error occurs.
        /// </summary>
        [Parameter]
        public string? ErrorLabel { get; set; } = "Not supported";

        /// <summary>
        /// The icon to show in the default copy state. Defaults to FontAwesome copy icon.
        /// </summary>
        [Parameter]
        public Icon? Icon { get; set; } = Icons.Copy;

        /// <summary>
        /// The icon to show when the content is copied. Defaults to FontAwesome check icon.
        /// </summary>
        [Parameter]
        public Icon? SuccessIcon { get; set; } = Icons.Check;

        /// <summary>
        /// The icon to show when a copy error occurs. Defaults to FontAwesome xmark icon.
        /// </summary>
        [Parameter]
        public Icon? ErrorIcon { get; set; } = Icons.XMark;
        /// <summary>
        /// The icon to show in the default copy state.
        /// </summary>
        [Parameter]
        public string? IconName { get; set; }

        /// <summary>
        /// The icon to show when the content is copied. 
        /// </summary>
        [Parameter]
        public string? SuccessIconName { get; set; }

        /// <summary>
        /// The icon to show when a copy error occurs
        /// </summary>
        [Parameter]
        public string? ErrorIconName { get; set; }

        /// <summary>
        /// Disables the copy button.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The length of time to show feedback before restoring the default trigger.
        /// </summary>
        [Parameter]
        public int FeedbackDuration { get; set; } = 1000;

        /// <summary>
        /// The preferred placement of the tooltip.
        /// </summary>
        [Parameter]
        public CopyButtonTooltipPlacement TooltipPlacement { get; set; } = CopyButtonTooltipPlacement.Top;
        /// <summary>
        /// Emitted when the data has been copied.
        /// </summary>
        [Parameter]
        public EventCallback Copied { get; set; }
        /// <summary>
        /// Emitted when the data could not be copied.
        /// </summary>
        [Parameter]
        public EventCallback CopyFailed { get; set; }
        #endregion

        #region Computed  Properties
        private string TooltipPlacementString
        {
            get
            {
                return TooltipPlacement switch
                {
                    CopyButtonTooltipPlacement.Top => "top",
                    CopyButtonTooltipPlacement.Left => "left",
                    CopyButtonTooltipPlacement.Right => "right",
                    CopyButtonTooltipPlacement.Bottom => "bottom",
                    _ => "top"
                };
            }
        }

        private string FromElementIdAndAttribute
        { get
            {
                if (!string.IsNullOrWhiteSpace(FromElementId))
                {
                    if (!string.IsNullOrWhiteSpace(FromElementAttribute))
                    {
                        return $"{FromElementId}[{FromElementAttribute}]";
                    }
                    else
                    {
                        return FromElementId;
                    }
                }
                return string.Empty;
            }
        }
        #endregion

        #region Lifecycle
        protected override void OnInitialized()
        {
            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= new Dictionary<string, object>();

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.copybutton.initialize", Id, objRef);
            }
        }

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {

                objRef?.Dispose();

            }

            await base.DisposeAsyncCore(disposing);
        }

        #endregion

        #region State
        private DotNetObjectReference<WACopyButton> objRef = default!;
        #endregion

        #region Public Methods
        [JSInvokable]
        public async Task HandleCopy()
        {
            if(Copied.HasDelegate)
                await Copied.InvokeAsync();
        }
        [JSInvokable]
        public async Task HandleCopyError()
        {
            if(CopyFailed.HasDelegate)
                await CopyFailed.InvokeAsync();
        }
        #endregion

    }
}
