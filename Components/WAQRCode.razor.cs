using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor.Components
{
    public partial class WAQRCode : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The QR code's value.
        /// </summary>
        [Parameter, EditorRequired]
        public string Value { get; set; }

        /// <summary>
        /// The label for assistive devices to announce. If unspecified, the value will be used instead.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The size of the QR code, in pixels. Default is 128.
        /// </summary>
        [Parameter]
        public int Size { get; set; } = 128;

        /// <summary>
        /// The fill color. This can be any valid CSS color, but not a CSS custom property.
        /// </summary>
        [Parameter]
        public string? FillColor { get; set; }

        /// <summary>
        /// The background color. This can be any valid CSS color or transparent. It cannot be a CSS custom property.
        /// </summary>
        [Parameter]
        public string? BackgroundColor { get; set; }

        /// <summary>
        /// The edge radius of each module. Must be between 0 and 0.5.
        /// </summary>
        [Parameter]
        public double Radius { get; set; } = 0;

        /// <summary>
        /// The level of error correction to use.
        /// </summary>
        [Parameter]
        public QRCodeErrorCorrection ErrorCorrection { get; set; } = QRCodeErrorCorrection.H;

        /// <summary>
        /// Add a logo or image to the center of the QR code. Error correction will be set to H.
        /// </summary>
        [Parameter]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Control how much of the QR code the image is allowed to cover, from 0 to 1. The default is 0.5
        /// The higher the image-coverage value, the harder it will be for QR readers to scan. For example, 1.0 usually makes the QR code unreadable.
        /// </summary>
        [Parameter]
        public decimal? ImageCoverage { get; set; } = 0.5m;

        #endregion

        #region Computed  Properties
        private string ErrorCorrectionString
        {
            get
            {
                return ErrorCorrection.ToString();
            }
        }
        #endregion
    }


}
