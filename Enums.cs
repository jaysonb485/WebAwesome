using System.ComponentModel;
using System.Text.Json.Serialization;

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
        FilledOutlined,
        Plain
    }

    public enum ButtonSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
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
    public enum ToastPlacement
    {
        TopStart,
        TopEnd,
        TopCenter,
        BottomStart,
        BottomEnd,
        BottomCenter,
    }
    public enum ToastMessageSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge
    }
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
    #region Accordion Enums
    public enum AccordionMode
    {
        Multiple,
        Single,
        SingleCollapsible
    }

    public enum AccordionHeadingLevel
    {
        H1,
        H2,
        H3,
        H4,
        H5,
        H6,
        None
    }

    public enum AccordionAppearance
    {
        Filled,
        Outlined,
        FilledOutlined,
        Plain
    }

    public enum AccordionIconPlacement
    {
        Start,
        End
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
        FilledOutlined,
        Outlined,
        Plain
    }
    public enum CalloutSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
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
    #region Chart Enums
    public enum ChartLegendPosition
    {
        Top,
        Bottom,
        Left,
        Right,
        Start,
        End
    }

    public enum ChartGridLines
    {
        Both,
        HorizontalOnly,
        VerticalOnly,
        None
    }
    #endregion
    #region Checkbox Enums
    public enum CheckboxSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
        Inherit
    }
    #endregion
    #region Checkbox Group Enums
    public enum CheckboxGroupSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
        Inherit
    }

    public enum CheckboxGroupOrientation
    {
        Horizontal,
        Vertical
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
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
        Inherit
    }

    public enum PickerPlacement
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
        LeftEnd
    }

    #endregion
    #region Combobox Enums

    public enum ComboboxAppearance
    {
        Filled,
        Outlined,
        FilledOutlined
    }


    public enum ComboboxPlacement
    {
        Top,
        Bottom
    }

    public enum ComboboxSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
        Inherit
    }

    public enum ComboboxAutoCapitalize
    {
        Off,
        None,
        On,
        Sentences,
        Words,
        Characters
    }

    public enum ComboboxEnterKeyHint
    {
        Enter,
        Done,
        Go,
        Next,
        Previous,
        Search,
        Send
    }

    public enum ComboboxInputMode
    {
        None,
        Text,
        Decimal,
        Numeric,
        Telephone,
        Search,
        Email,
        Url
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
    public enum CopyButtonTooltipMode
    {
        Full,
        Copy,
        None
    }
    #endregion
    #region Counter Enums
    public enum CounterDirection
    {
        [Description("up")]
        Up,
        [Description("down")]
        Down
    }
    public enum CounterFormat
    {
        [Description("long")]
        Long,
        [Description("short")]
        Short,
        [Description("narrow")]
        Narrow
    }

    public enum CounterUnit
    {
        [Description("seconds")]
        Seconds,
        [Description("minutes")]
        Minutes,
        [Description("hours")]
        Hours,
        [Description("days")]
        Days,
        [Description("months")]
        Months,
        [Description("years")]
        Years
    }
    #endregion
    #region DataGrid Enums
    public enum DataGridAppearance
    {
        Outlined,
        Plain
    }
    public enum DataGridRowSelection
    {
        Single,
        Multiple,
        None
    }

    public enum DataGridSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DataGridCopyFormat
    {
        Tsv,
        Csv
    }
    public enum DataGridColumnSortMethod
    {
        Alphanumeric,
        AlphanumericCaseSensitive,
        Text,
        TextCaseSensitive,
        Datetime,
        Basic
    }
    public enum DataGridColumnPinDirection
    {
        Left,
        Right
    }

    public enum DataGridColumnFilterType
    {
        Text,
        Equals,
        NumberRange,
        DateRange,
        Set,
        IncludesAny,
        IncludesAll
    }

    public enum DataGridColumnAggregation
    {
        Sum,
        Min,
        Max,
        Mean,
        Median,
        Count,
        Unique,
        UniqueCount,
        Extent
    }
    #endregion
    #region DatePicker Enums
    public enum DatePickerDayOfTheWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public enum DatePickerSelectionMode
    {
        Single,
        Range
    }

    public enum DatePickerWeekdayFormat
    {
        Short,
        Narrow,
        Long
    }

    #endregion
    #region DateInput Enums
    public enum DateInputPlacement
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
        LeftEnd
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

    public enum DividerLabelPlacement
    {
        Center,
        Start,
        End
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
    #region FileInput Enums
    public enum FileInputSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
        Inherit
    }

    public enum FileInputCapture
    {
        User,
        Environment
    }
    #endregion
    #region FormatBytes Enums
    public enum FormatBytesUnit
    {
        Byte,
        Bit
    }

    public enum FormatBytesDisplay
    {
        Long,
        Short,
        Narrow
    }
    #endregion
    #region Icon Enums
    public enum IconAnimation
    {
        None,
        Beat,
        Fade,
        BeatFade,
        Bounce,
        Flip,
        Flip360,
        Shake,
        Spin,
        SpinSnap,
        SpinSnap4,
        SpinSnap8,
        Buzz,
        Float,
        Jello,
        Swing,
        Wag
    }

    public enum IconCanvas
    {
        Fixed,
        Auto,
        Square,
        Roomy
    }

    public enum IconFlip
    {
        None,
        Horizontal,
        Vertical,
        Both
    }
    #endregion
    #region Include Enums
    public enum IncludeMode
    {
        CORS,
        NoCORS,
        SameOrigin
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
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
        Inherit
    }

    public enum InputAppearance
    {
        Filled,
        Outlined,
        FilledOutlined
    }

    public enum InputAutoCapitalize
    {
        Off,
        None,
        On,
        Sentences,
        Words,
        Characters
    }

    public enum InputEnterKeyHint
    {
        Enter,
        Done,
        Go,
        Next,
        Previous,
        Search,
        Send
    }

    public enum InputInputMode
    {
        None,
        Text,
        Decimal,
        Numeric,
        Telephone,
        Search,
        Email,
        Url
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
    #region LightboxItem Enums
    public enum LightboxItemMediaType
    {
        [Description("image")]
        Image,
        [Description("video")]
        Video
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
    #region NumberInput Enums

    public enum NumberInputSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
        Inherit
    }

    public enum NumberInputAppearance
    {
        Filled,
        Outlined,
        FilledOutlined
    }

    public enum NumberInputEnterKeyHint
    {
        Enter,
        Done,
        Go,
        Next,
        Previous,
        Search,
        Send
    }
    #endregion
    #region NumberTicker Enums
    public enum NumberTickerFormatType
    {
        [Description("currency")]
        Currency,
        [Description("decimal")]
        Decimal,
        [Description("percent")]
        Percent
    }

    public enum NumberTickerCurrencyDisplay
    {
        [Description("symbol")]
        Symbol,
        [Description("narrowSymbol")]
        NarrowSymbol,
        [Description("code")]
        Code,
        [Description("name")]
        Name
    }
    #endregion
    #region OtpInput Enums
    public enum OtpAllowedCharacters
    {
        Numeric,
        Alpha,
        Alphanumeric
    }
    public enum OtpAppearance
    {
        Filled,
        Outlined,
        FilledOutlined,
        Contained
    }

    public enum OtpCaseTransformation
    {
        Preserve,
        Upper,
        Lower
    }
    public enum OtpSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge
    }
    #endregion
    #region Page Enums
    public enum PageNavigationPlacement
    {
        Start,
        End
    }
    #endregion
    #region Pagionation Enums
    public enum PaginationFormat
    {
        Standard,
        Compact
    }

    public enum PaginationAppearance
    {
        Outlined,
        Filled,
        Plain
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
    #region QRCode Enums
    public enum QRCodeErrorCorrection
    {
        L,
        M,
        Q,
        H
    }
    #endregion
    #region Radio Group Enums
    public enum RadioGroupSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
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
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
        Inherit
    }

    public enum RadioAppearance
    {
        Default,
        Button
    }

    #endregion
    #region Random Content Enums
    public enum RandomContentAnimation
    {
        None,
        Fade,
        FadeUp,
        FadeDown,
        FadeLeft,
        FadeRight
    }

    public enum RandomContentMode
    {
        Unique,
        Random,
        Sequence
    }
    #endregion
    #region Rating Enums
    public enum RatingSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
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
    #region RichTextEditor Enums
    public enum RichTextEditorToolbarItem
    {
        [Description("block")]
        Block,
        [Description("bold")]
        Bold,
        [Description("italic")]
        Italic,
        [Description("underline")]
        Underline,
        [Description("strikethrough")]
        Strikethrough,
        [Description("highlight")]
        Highlight,
        [Description("code")]
        Code,
        [Description("subscript")]
        Subscript,
        [Description("superscript")]
        Superscript,
        [Description("color")]
        Color,
        [Description("format-menu")]
        FormatMenu,
        [Description("align")]
        Align,
        [Description("lists")]
        Lists,
        [Description("bullet-list")]
        BulletList,
        [Description("ordered-list")]
        OrderedList,
        [Description("indent")]
        Indent,
        [Description("outdent")]
        Outdent,
        [Description("block-quote")]
        BlockQuote,
        [Description("code-block")]
        CodeBlock,
        [Description("link")]
        Link,
        [Description("image")]
        Image,
        [Description("embed")]
        Embed,
        [Description("table")]
        Table,
        [Description("horizontal-rule")]
        HorizontalRule,
        [Description("clear-formatting")]
        ClearFormatting,
        [Description("paste-plain-text")]
        PasteAsPlainText,
        [Description("undo")]
        Undo,
        [Description("redo")]
        Redo,
        [Description("actions")]
        CustomActions,
        [Description("|")]
        Divider
    }
    public enum RichTextEditorToolbarPlacement
    {
        [Description("top")]
        Top,
        [Description("bottom")]
        Bottom
    }
    public enum RichTextEditorFeatureOption
    {
        [Description("bold")]
        Bold,
        [Description("italic")]
        Italic,
        [Description("underline")]
        Underline,
        [Description("strikethrough")]
        Strikethrough,
        [Description("highlight")]
        Highlight,
        [Description("code")]
        Code,
        [Description("subscript")]
        Subscript,
        [Description("superscript")]
        Superscript,
        [Description("color")]
        Color,
        [Description("link")]
        Link,
        [Description("image")]
        Image,
        [Description("embed")]
        Embed,
        [Description("table")]
        Table,
        [Description("blockquote")]
        BlockQuote,
        [Description("code-block")]
        CodeBlock,
        [Description("bullet-list")]
        BulletList,
        [Description("ordered-list")]
        OrderedList,
        [Description("horizontal-rule")]
        HorizontalRule,
        [Description("align")]
        Align,
        [Description("lists")]
        Lists
    }

    public enum RichTextEditorHeadingLevel
    {
        [Description("1")]
        H1,
        [Description("2")]
        H2,
        [Description("3")]
        H3,
        [Description("4")]
        H4,
        [Description("5")]
        H5,
        [Description("6")]
        H6
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
        FilledOutlined
    }

    public enum SelectSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
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
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
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
    #region Sparkline Enums
    public enum SparklineAppearance
    {
        Solid,
        Gradient,
        Line
    }
    public enum SparklineCurve
    {
        Linear,
        Natural,
        Step
    }
    public enum SparklineTrend
    {
        Positive,
        Negative,
        Neutral
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
    #region Step Enums
    public enum StepAttention
    {
        None,
        Pulse,
        Bounce
    }

    public enum StepVariant
    {
        Brand,
        Neutral,
        Success,
        Warning,
        Danger
    }
    #endregion
    #region Stepper Enums
    public enum StepperOrientation
    {
        Horizontal,
        Vertical,
        Auto
    }
    #endregion
    #region Switch Enums
    public enum SwitchSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
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
    #region Tag Input Enums
    public enum TagInputAppearance
    {
        Filled,
        Outlined,
        FilledOutlined,
    }

    public enum TagInputAutoCapitalize
    {
        Off,
        None,
        On,
        Sentences,
        Words,
        Characters
    }

    public enum TagInputSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
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
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
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
        FilledOutlined,
    }


    public enum TextAreaSize
    {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge,
        Inherit
    }
    #endregion
    #region Time Input enums
    public enum TimeInputHourFormat
    {
        Auto,
        Twelve,
        TwentyFour
    }

    public enum TimeInputPlacement
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
        LeftEnd
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
    #region Tree Enums
    public enum TreeSelection
    {
        Single,
        Multiple,
        Leaf,
        LeafMultiple
    }
    public enum TreeIndentStyle
    {
        Solid,
        Dashed,
        Dotted
    }
    #endregion
    #region Video Enums
    public enum VideoControls
    {
        None,
        Standard,
        Full
    }

    public enum VideoPreload
    {
        None,
        Metadata,
        Auto
    }
    #endregion


    internal static class EnumExtensions
    {
        extension(Enum e)
        {
            internal string GetDescription()
            {
                var field = e.GetType().GetField(e.ToString());
                if (field == null)
                    return e.ToString();

                var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    return attribute.Description;
                }

                return e.ToString();
            }
        }
    }

}
