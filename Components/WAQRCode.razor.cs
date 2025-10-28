using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
