using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesome
{
    public class Enums
    {
        public enum Variant
        {
            Brand,
            Success,
            Neutral,
            Warning,
            Danger,
            Inherit
        }

        public enum Appearance
        {
            Accent,
            AccentOutlined,
            Filled,
            FilledOutlined,
            Outlined,
            Plain
        }

        public enum Size
        {
            Small,
            Medium,
            Large,
            Inherit
        }

        public enum ButtonType
        {
            Button,
            Submit,
            Reset
        }

        public enum InputType
        {

            Date,
            DateTimeLocal,
            Email,
            Number,
            Password,
            Search,
            Telephone,
            Text,
            Time,
            Url,
        }

        public enum AnimationName
        {
            bounce,
            flash,
            pulse,
            rubberBand,
            shakeX,
            shakeY,
            headShake,
            swing,
            tada,
            wobble,
            jello,
            heartBeat,
            backInDown,
            backInLeft,
            backInRight,
            backInUp,
            backOutDown,
            backOutLeft,
            backOutRight,
            backOutUp,
            bounceIn,
            bounceInDown,
            bounceInLeft,
            bounceInRight,
            bounceInUp,
            bounceOut,
            bounceOutDown,
            bounceOutLeft,
            bounceOutRight,
            bounceOutUp,
            fadeIn,
            fadeInDown,
            fadeInDownBig,
            fadeInLeft,
            fadeInLeftBig,
            fadeInRight,
            fadeInRightBig,
            fadeInUp,
            fadeInUpBig,
            fadeInTopLeft,
            fadeInTopRight,
            fadeInBottomLeft,
            fadeInBottomRight,
            fadeOut,
            fadeOutDown,
            fadeOutDownBig,
            fadeOutLeft,
            fadeOutLeftBig,
            fadeOutRight,
            fadeOutRightBig,
            fadeOutUp,
            fadeOutUpBig,
            fadeOutTopLeft,
            fadeOutTopRight,
            fadeOutBottomRight,
            fadeOutBottomLeft,
            flip,
            flipInX,
            flipInY,
            flipOutX,
            flipOutY,
            lightSpeedInRight,
            lightSpeedInLeft,
            lightSpeedOutRight,
            lightSpeedOutLeft,
            rotateIn,
            rotateInDownLeft,
            rotateInDownRight,
            rotateInUpLeft,
            rotateInUpRight,
            rotateOut,
            rotateOutDownLeft,
            rotateOutDownRight,
            rotateOutUpLeft,
            rotateOutUpRight,
            hinge,
            jackInTheBox,
            rollIn,
            rollOut,
            zoomIn,
            zoomInDown,
            zoomInLeft,
            zoomInRight,
            zoomInUp,
            zoomOut,
            zoomOutDown,
            zoomOutLeft,
            zoomOutRight,
            zoomOutUp,
            slideInDown,
            slideInLeft,
            slideInRight,
            slideInUp,
            slideOutDown,
            slideOutLeft,
            slideOutRight,
            slideOutUp
        }

        public enum AnimationDirection
        {
            Normal,
            Reverse,
            Alternate,
            AlternateReverse
        }

        public enum AvatarShape
        {
            Circle,
            Square,
            Rounded
        }

        public enum Orientation
        {
            Horizontal,
            Vertical
        }
        public enum ColorFormat
        {
            Hex,
            RGB,
            HSL,
            HSV
        }

        public enum Position
        {
            Top,
            Right,
            Bottom,
            Left
        }

        public enum Placement
        {
             Top,
            TopStart,
            TopEnd,
            Bottom,
            BottomStart,
            BottomEnd,
            Right,
            RightStart,
            RightEnd,
            Left,
            LeftStart,
            LeftEnd,

        }

        public enum RelativeTimeFormat
        {
            Long,
            Short,
            Narrow
        }

        public enum SkeletonEffect
        {
            None,
            Sheen,
            Pulse
        }

        public enum PrimaryPanel
        {
            Start,
            End
        }

        public enum TabPlacement
        {
            Top,
            Bottom,
            Start,
            End
        }

        public enum TextAreaResize
        {
            None,
            Vertical,
            Horizontal,
            Both,
            Auto
        }

        public enum TooltipTrigger
        {
            Any,
            HoverFocus,
            Click,
            Hover,
            Focus,
            Manual,
        }

        public enum NavigationPlacement
        {
            Start,
            End
        }

        public enum LayoutSlot
        {
            Banner,
            Header,
            SubHeader,
            Menu,
            NavigationHeader,
            Navigation,
            NavigationFooter,
            NavigationToggle,
            NavigationToggleIcon,
            MainHeader,
            MainContent,
            MainFooter,
            Aside,
            SkipToContent,
            Footer,

        }
    }
}
