using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WASkeleton : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// Determines which effect the skeleton will use.
        /// </summary>
        [Parameter]
        public SkeletonEffect Effect { get; set; } = SkeletonEffect.None;

        /// <summary>
        /// The height of the skeleton.
        /// </summary>
        [Parameter]
        public string? Height { get; set; }

        /// <summary>
        /// The width of the skeleton.
        /// </summary>
        [Parameter]
        public string? Width { get; set; }
        /// <summary>
        /// The color of the skeleton.
        /// </summary>
        [Parameter]
        public string? Color { get; set; }
        /// <summary>
        /// The sheen color when the skeleton is in its loading state.
        /// </summary>
        [Parameter]
        public string? SheenColor { get; set; }

        /// <summary>
        /// The border radius of the skeleton.
        /// </summary>
        [Parameter]
        public string? BorderRadius { get; set; }
        #endregion

        #region Computed  Properties
        string EffectString
        {
            get
            {
                return Effect switch
                {
                    SkeletonEffect.None => "none",
                    SkeletonEffect.Sheen => "sheen",
                    SkeletonEffect.Pulse => "pulse",
                    _ => "none"
                };
            }
        }


        protected override string StyleNames => BuildStyleNames(Style,
            ($"height: {Height}", !String.IsNullOrEmpty(Height)),
            ($"width: {Width}", !String.IsNullOrEmpty(Width)),
            ($"--color: {Color}", !String.IsNullOrEmpty(Color)),
            ($"--sheen-color: {SheenColor}", !String.IsNullOrEmpty(SheenColor)),
            ($"--border-radius: {BorderRadius}", !String.IsNullOrEmpty(BorderRadius))
        );
        #endregion




    }


}
