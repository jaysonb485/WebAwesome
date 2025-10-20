using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WARelativeTime : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public DateTime? DateTimeValue { get; set; }

        [Parameter]
        public bool AutoRefresh { get; set; } = false;

        [Parameter]
        public RelativeTimeFormat Format { get; set; } = RelativeTimeFormat.Long;
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
