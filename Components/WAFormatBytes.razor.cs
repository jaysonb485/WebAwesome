using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WAFormatBytes : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The number to format in bytes.
        /// </summary>
        [Parameter]
        public int Value { get; set; }
        /// <summary>
        /// Determines how to display the result, e.g. "100 bytes", "100 b", or "100b".
        /// </summary>
        [Parameter]
        public FormatBytesDisplay Display { get; set; } = FormatBytesDisplay.Short;
        /// <summary>
        /// The type of unit to display.
        /// </summary>
        [Parameter]
        public FormatBytesUnit Unit { get; set; } = FormatBytesUnit.Byte;

        /// <summary>
        /// Set the number formatting locale.
        /// </summary>
        [Parameter]
        public CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;
        #endregion

        #region Computed Properties
        private string UnitString
        {
            get
            {
                return Unit switch
                {
                    FormatBytesUnit.Byte => "byte",
                    FormatBytesUnit.Bit => "bit",
                    _ => "byte"
                };
            }
        }

        private string DisplayString
        {
            get
            {
                return Display switch
                {
                    FormatBytesDisplay.Short => "short",
                    FormatBytesDisplay.Long => "long",
                    FormatBytesDisplay.Narrow => "narrow",
                    _ => "short"
                };
            }
        }
        #endregion
    }
}
