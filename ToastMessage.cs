using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor
{
    public class ToastMessage
    {
        public string? Message { get; set; }
        /// <summary>
        /// The name of the icon to draw in the prefix slot. The default library will be used. For other libraries or variants, use Icon.
        /// </summary>
        public string? IconName { get; set; }

        /// <summary>
        /// The icon to draw in the prefix slot. Alternatively, use the IconName value.
        /// </summary>
        public Icon? Icon { get; set; }

        /// <summary>
        /// The number of milliseconds to wait before automatically dismissing the toast. A value of 0 will keep the toast open until dismissed.
        /// </summary>
        public int Duration { get; set; } = 5000;
        /// <summary>
        /// Set the size option to small, medium, or large to change the size of the toast item.
        /// </summary>
        public ToastMessageSize Size { get; set; } = ToastMessageSize.Medium;
        /// <summary>
        /// Set the variant option to brand, success, warning, danger, or neutral to change the type of notification.
        /// </summary>
        public ToastMessageVariant Variant { get; set; } = ToastMessageVariant.Brand;

        public RenderFragment? HTMLContent { get; set; }

        internal string Id = IdUtility.GetNextId();

        internal string VariantString
        {
            get
            {
                return Variant switch
                {
                    ToastMessageVariant.Brand => "brand",
                    ToastMessageVariant.Success => "success",
                    ToastMessageVariant.Neutral => "neutral",
                    ToastMessageVariant.Warning => "warning",
                    ToastMessageVariant.Danger => "danger",
                    _ => "brand",
                };
            }
        }

        internal string SizeString
        {
            get
            {
                return Size switch
                {
                    ToastMessageSize.Medium => "medium",
                    ToastMessageSize.Small => "small",
                    ToastMessageSize.Large => "large",
                    _ => "medium",
                };
            }
        }

    }
}
