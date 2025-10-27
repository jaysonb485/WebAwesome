using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor
{
    #region Button Enums
    public enum ButtonVariant
    {
        Brand,
        Success,
        Neutral,
        Warning,
        Danger,
        Inherit
    }

    public enum ButtonAppearance
    {
        Accent,
        Filled,
        Outlined,
        OutlinedFilled,
        Plain
    }

    public enum ButtonSize
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
    #endregion
    #region Toast Enums

    public enum ToastMessageVariant
    {
        Brand,
        Success,
        Neutral,
        Warning,
        Danger,
        Inherit,
        Default
    }
    #endregion
    #region Animation Enums
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
    #endregion
    #region Avatar Enums
    public enum AvatarShape
    {
        Circle,
        Square,
        Rounded
    }
    #endregion
    #region Badge Enums
    public enum BadgeVariant
    {
        Brand,
        Success,
        Neutral,
        Warning,
        Danger,
        Inherit,
        Default
    }

    public enum BadgeAppearance
    {
        Accent,
        AccentOutlined,
        Filled,
        FilledOutlined,
        Outlined,
        Plain
    }

    public enum BadgePulse
    {
        None,
        Pulse,
        Bounce
    }

    #endregion
    #region Button Group Enums

    public enum ButtonGroupOrientation
    {
        Horizontal,
        Vertical
    }

    public enum ButtonGroupVariant
    {
        Brand,
        Success,
        Neutral,
        Warning,
        Danger,
        Inherit
    }
    #endregion
    #region Callout Enums
    public enum CalloutVariant
    {
        Brand,
        Success,
        Neutral,
        Warning,
        Danger,
        Inherit,
        Default
    }

    public enum CalloutAppearance
    {
        Accent,
        Filled,
        OutlinedFilled,
        Outlined,
        Plain
    }
    public enum CalloutSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }

    #endregion
    #region Card Enums
    public enum CardAppearance
    {
        Accent,
        Filled,
        FilledOutlined,
        Outlined,
        Plain
    }

    public enum CardOrientation
    {
        Horizontal,
        Vertical
    }
    #endregion
    #region Carousel Enums

    public enum CarouselOrientation
    {
        Horizontal,
        Vertical
    }
    #endregion
    #region Checkbox Enums
    public enum CheckboxSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }
    #endregion
    #region Colour Picker Enums
    public enum PickerColorFormat
    {
        Hex,
        RGB,
        HSL,
        HSV
    }

    public enum PickerColorExtendedFormat
    {
        Hex,
        RGB,
        HSL,
        HSV,
        Hexa,
        RGBA,
        HSLA,
        HSVA
    }


    public enum PickerSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }

    #endregion
    #region Copy button Enums
    public enum CopyButtonTooltipPlacement
    {
        Top,
        Bottom,
        Right,
        Left,
    }
    #endregion
    #region Details Enums
    public enum DetailsAppearance
    {
        Filled,
        FilledOutlined,
        Outlined,
        Plain
    }

    public enum DetailsIconPlacement
    {
        End,
        Start
    }
    #endregion
    #region Divider Enums
    public enum DividerOrientation
    {
        Horizontal,
        Vertical
    }
    #endregion
    #region Drawer Enums

    public enum DrawerPlacement
    {
        Top,
        Bottom,
        End,
        Start
    }
    #endregion
    #region Dropdown Enums
    public enum DropdownPlacement
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
    #endregion
    #region Dropdown Item Enums
    public enum DropdownItemVariant
    {
        Danger,
        Default
    }
    #endregion
    #region Input Enums
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

    public enum InputSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }

    public enum InputAppearance
    {
        Filled,
        Outlined,
    }
    #endregion
    #region Input Date Time  Enums
    public enum DateTimeInputType
    {
        Date,
        DateTimeLocal,
        Text,
        Time,
    }
    #endregion
    #region Layout Content Enums
    public enum LayoutSlots
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
    #endregion
    #region NavTree Enums
    public enum NavTreeSelection
    {
        Single,
        Multiple,
        Leaf
    }
    #endregion
    #region Page Enums
    public enum PageNavigationPlacement
    {
        Start,
        End
    }
    #endregion
    #region Popover Enums

    public enum PopoverPlacement
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
        End,
        Start
    }
    #endregion
    #region Radio Group Enums
    public enum RadioGroupSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }

    public enum RadioGroupOrientation
    {
        Horizontal,
        Vertical
    }
    #endregion
    #region Radio Option Enums

    public enum RadioSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }

    public enum RadioAppearance
    {
        Default,
        Button
    }

    #endregion
    #region Rating Enums
    public enum RatingSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }
    #endregion
    #region Relative Time Enums
    public enum RelativeTimeFormat
    {
        Long,
        Short,
        Narrow
    }
    #endregion
    #region Scroller Enums
    public enum ScrollerOrientation
    {
        Horizontal,
        Vertical
    }
    #endregion
    #region Select Enums

    public enum SelectAppearance
    {
        Filled,
        Outlined,
    }

    public enum SelectSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }
    #endregion
    #region Skeleton Enums
    public enum SkeletonEffect
    {
        None,
        Sheen,
        Pulse
    }
    #endregion
    #region Slider Enums

    public enum SliderSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }

    public enum SliderOrientation
    {
        Horizontal,
        Vertical
    }

    public enum SliderTooltipPlacement
    {
        Top,
        Bottom
    }

    #endregion
    #region Split Panel Enums
    public enum SplitPanelOrientation
    {
        Horizontal,
        Vertical
    }

    public enum SplitPanelPrimaryPanel
    {
        Start,
        End
    }
    #endregion
    #region Switch Enums
    public enum SwitchSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }
    #endregion
    #region Tab Group Enums
    public enum TabGroupTabPlacement
    {
        Top,
        Bottom,
        End,
        Start
    }
    #endregion
    #region Tag Enums
    public enum TagVariant
    {
        Brand,
        Success,
        Neutral,
        Warning,
        Danger,
        Inherit,
        Default
    }

    public enum TagAppearance
    {
        Accent,
        Filled,
        FilledOutlined,
        Outlined
    }


    public enum TagSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }
    #endregion
    #region Text Area Enums
    public enum TextAreaAutoCapitalize
    {
        Off,
        None,
        On,
        Sentences,
        Words,
        Characters
    }


    public enum TextAreaResize
    {
        None,
        Vertical,
        Horizontal,
        Both,
        Auto
    }

    public enum TextAreaAppearance
    {
        Filled,
        Outlined,
    }


    public enum TextAreaSize
    {
        Small,
        Medium,
        Large,
        Inherit
    }
    #endregion
    #region Tooltip Enums
    [Flags]
    public enum TooltipTrigger
    {
        Manual,
        Click = 1 << 0, // 1
        Hover = 1 << 1, // 2
        Focus = 1 << 2, // 4
    }

    public enum TooltipPlacement
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
        End,
        Start
    }
    #endregion

}
