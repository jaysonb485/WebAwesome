using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WAAnimation : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The name of the built-in animation to use.
        /// </summary>
        [Parameter]
        public AnimationName? Name { get; set; }

        /// <summary>
        /// Sets whether the animation will commence automatically when rendered.
        /// </summary>
        [Parameter]
        public bool AutoStart { get; set; } = true;

        /// <summary>
        /// The number of milliseconds to delay the start of the animation.
        /// </summary>
        [Parameter]
        public int Delay { get; set; } = 0;

        /// <summary>
        /// Determines the direction of playback as well as the behavior when reaching the end of an iteration
        /// </summary>
        [Parameter]
        public AnimationDirection Direction { get; set; } = AnimationDirection.Normal;

        /// <summary>
        /// The number of milliseconds each iteration of the animation takes to complete.
        /// </summary>
        [Parameter]
        public int Duration { get; set; } = 1000;
        /// <summary>
        /// The easing function to use for the animation. This can be a Web Awesome easing function or a custom easing function such as cubic-bezier(0, 1, .76, 1.14).
        /// </summary>
        [Parameter]
        public string Easing { get; set; } = "linear";
        /// <summary>
        /// The number of milliseconds to delay after the active period of an animation sequence.
        /// </summary>
        [Parameter]
        public int EndDelay { get; set; } = 0;

        /// <summary>
        /// The number of iterations to run before the animation completes. Defaults to Infinity, which loops.
        /// </summary>
        [Parameter]
        public int? Iterations { get; set; }


        #endregion

        #region Lifecycle   
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
                if (AutoStart)
                {
                    Play = true;
                    StateHasChanged();
                }
        }

        #endregion

        #region State
        private bool Play { get; set; } = false;
        #endregion

        #region Computed Properties

        /// <summary>
        /// Provides the string representation of the AnimationDirection enum to set the direction attribute.
        /// </summary>
        string DirectionString
        {
            get
            {
                return Direction switch
                {
                    AnimationDirection.Normal => "normal",
                    AnimationDirection.Reverse => "reverse",
                    AnimationDirection.Alternate => "alternate",
                    AnimationDirection.AlternateReverse => "alternate-reverse",
                    _ => "normal"
                };
            }
        }
        /// <summary>
        /// Indicates whether the animation is currently playing.
        /// </summary>
        public bool IsPlaying
        {
            get
            {
                return Play;
            }
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// Starts the animation
        /// </summary>
        public void StartAnimation()
        {
            Play = true;
            StateHasChanged();
        }

        /// <summary>
        /// Stops the animation
        /// </summary>
        public void StopAnimation()
        {
            Play = false;
            StateHasChanged();
        }
        #endregion

    }
}
