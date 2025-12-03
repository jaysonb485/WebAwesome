using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WATag : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The text to display in the tag.
        /// </summary>
        [Parameter]
        public string? Text { get; set; }


        /// <summary>
        /// The tag's theme variant. Defaults to neutral if not within another element with a variant.
        /// </summary>
        [Parameter]
        public TagVariant? Variant { get; set; }

        /// <summary>
        /// The tag's visual appearance. Valid options for tag are: Accent, AccentOutlined, Filled, FilledOutlined, Outlined.
        /// </summary>
        [Parameter]
        public TagAppearance Appearance { get; set; } = TagAppearance.FilledOutlined;

        /// <summary>
        /// Draws a pill-style tag with rounded edges.
        /// </summary>
        [Parameter]
        public bool Pill { get; set; } = false;
        /// <summary>
        /// Makes the tag removable (with-remove) and shows a remove button.
        /// </summary>
        [Parameter]
        public bool Removable { get; set; } = false;

        /// <summary>
        /// The tag's size.
        /// </summary>
        [Parameter]
        public TagSize Size { get; set; } = TagSize.Inherit;
        /// <summary>
        /// Emitted when the tag is removed.
        /// </summary>
        [Parameter]
        public EventCallback TagRemoved { get; set; }
        /// <summary>
        /// Emitted when the remove button is clicked. Set Cancel = true to prevent the tag from being removed.
        /// </summary>
        [Parameter]
        public EventCallback<TagRemovingEventArgs> TagRemoving { get; set; }
        #endregion

        #region Computed  Properties
        string VariantString
        {
            get
            {
                return Variant switch
                {
                    TagVariant.Brand => "brand",
                    TagVariant.Success => "success",
                    TagVariant.Neutral => "neutral",
                    TagVariant.Warning => "warning",
                    TagVariant.Danger => "danger",
                    _ => "neutral"
                };
            }
        }
        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    TagAppearance.Accent => "accent",
                    TagAppearance.Filled => "filled",
                    TagAppearance.FilledOutlined => "filled-outlined",
                    TagAppearance.Outlined => "outlined",
                    _ => "filled outlined"
                };
            }
        }

        string SizeString
        {
            get
            {
                return Size switch
                {
                    TagSize.Small => "small",
                    TagSize.Medium => "medium",
                    TagSize.Large => "large",
                    TagSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }

        protected override string? ClassNames => BuildClassNames(Class, 
            ("wa-tag-removeable", Removable));

        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                objRef = DotNetObjectReference.Create(this);
                await JSRuntime.InvokeVoidAsync("window.vengage.tag.initialize", Id, objRef);
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

        #region Event Handlers
        /// <summary>
        /// Captures when the remove button is pressed
        /// </summary>
        [JSInvokable]
        public async Task HandleTagRemove()
        {
            var args = new TagRemovingEventArgs();
            await TagRemoving.InvokeAsync(args);

            if(!args.Cancel)
            {
                await this.RemoveAsync();
            }
        }

        /// <summary>
        /// Captures when the tag has been removed
        /// </summary>
        [JSInvokable]
        public async Task HandleTagRemoved()
        {
            await TagRemoved.InvokeAsync();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Remove (hide the tag).
        /// </summary>
        public async Task RemoveAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.tag.removeTag", Id, objRef);
        }

        public void Remove() => _ = RemoveAsync();
        #endregion

        #region State
        private DotNetObjectReference<WATag> objRef = default!;
        #endregion



    }


}
