using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WARelativeTime : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The date from which to calculate time from. If not set, the current date and time will be used. 
        /// </summary>
        [Parameter]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// Keep the displayed value up to date as time passes.
        /// </summary>
        [Parameter]
        public bool AutoRefresh { get; set; } = false;

        /// <summary>
        /// The formatting style to use.
        /// </summary>
        [Parameter]
        public RelativeTimeFormat Format { get; set; } = RelativeTimeFormat.Long;
        /// <summary>
        /// Always show numeric values ('1 day ago') instead of 'yesterday'
        /// </summary>
        [Parameter]
        public bool AlwaysNumeric { get; set; } = false;

        [Parameter]
        public CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;
        #endregion

        #region Computed  Properties
        string DateTimeISOString
        {
            get
            {

                return DateTimeValue == null ? String.Empty : DateTimeValue.Value.ToString("o", CultureInfo.InvariantCulture);
            }
        }
        string FormatString
        {
            get
            {
                return Format switch
                {
                    RelativeTimeFormat.Long => "long",
                    RelativeTimeFormat.Narrow => "narrow",
                    RelativeTimeFormat.Short => "short",
                    _ => "long"
                };
            }
        }
        #endregion

    }


}
