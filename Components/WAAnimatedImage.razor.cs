using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WAAnimatedImage : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The path to the image to load.
        /// </summary>
        [Parameter]
        public string? AnimationUrl { get; set; }
        /// <summary>
        /// A description of the image used by assistive devices.
        /// </summary>
        [Parameter]
        public string? AltText { get; set; }
        /// <summary>
        /// Optional play icon to use instead of the default.
        /// </summary>
        [Parameter]
        public Icon? PlayIcon { get; set; }
        /// <summary>
        /// Optional pause icon to use instead of the default
        /// </summary>
        [Parameter]
        public Icon? PauseIcon { get; set; }
        /// <summary>
        /// Optional play icon name to use instead of the default.  Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? PlayIconName { get; set; }
        /// <summary>
        /// Optional pause icon name to use instead of the default.  Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? PauseIconName { get; set; }
        /// <summary>
        /// The size of the icon box in CSS size units.
        /// </summary>
        [Parameter]
        public string? ControlBoxSize { get; set; }
        /// <summary>
        /// The size of the play/pause icons in CSS size units.
        /// </summary>
        [Parameter]
        public string? IconSize { get; set; }
        #endregion

        #region Computed  Properties
        protected override string StyleNames => BuildStyleNames(Style,
            ($"--control-box-size: {ControlBoxSize}", !String.IsNullOrEmpty(ControlBoxSize)),
            ($"--icon-size: {IconSize}", !String.IsNullOrEmpty(IconSize))
        );
        #endregion

        #region State
        private bool IsPlaying { get; set; } = false;
        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        public void TogglePlay()
        {
            IsPlaying = !IsPlaying;
            StateHasChanged();
        }

        public void Play()
        {
            IsPlaying = true;
            StateHasChanged();
        }

        public void Pause()
        {
            IsPlaying = false;
            StateHasChanged();
        }
        #endregion

    }


}
