using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WARadioOption<TItem> : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The option's value. When selected, the radio group will receive this value.
        /// </summary>
        [Parameter]
        public TItem Value { get; set; } = default!;

        /// <summary>
        /// The option's label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// Disables the option
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

         /// <summary>
        /// The options's size. When used inside a radio group, the size will be determined by the radio group's size so this attribute can typically be omitted.
        /// </summary>
        [Parameter]
        public RadioSize Size { get; set; } = RadioSize.Inherit;
        /// <summary>
        /// The appearance of the option.
        /// </summary>
        [Parameter]
        public RadioAppearance Appearance { get; set; } = RadioAppearance.Default;
        #endregion

        #region Computed  Properties
        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    RadioAppearance.Button => "button",
                    _ => "default"
                };
            }
        }

        string SizeString
        {
            get
            {
                return Size switch
                {
                    RadioSize.Small => "small",
                    RadioSize.Medium => "medium",
                    RadioSize.Large => "large",
                    RadioSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }
        #endregion


    }


}
