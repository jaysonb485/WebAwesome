I'm a hobbyist developer. This is an open source project to provide Blazor components for the Web Awesome UI framework. Feedback and contributions are welcome!
# WebAwesomeBlazor

Currently supports Web Awesome 3.0.0.

# Changelog
[Version 1.0.5](/docs/CHANGELOG.md)

# Installation
Get the latest package from [NuGet](https://www.nuget.org/packages/WebAwesomeBlazor/)
```
dotnet add package WebAwesomeBlazor
```

# Usage
Register your [Web Awesome](https://webawesome.com) account.
Create your project and obtain your unique project code.

Add the project code to your `App.razor` or `wwwroot/index.html` file in the `<HEAD>` section along with the extra utility files for this package:
```HTML
    <script src="https://kit.webawesome.com/---YOUR KIT CODE---.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="@Assets["/_content/WebAwesomeBlazor/WebAwesome.css"]" />
    <script type="text/javascript" src="@Assets["/_content/WebAwesomeBlazor/JsInterop.js"]"></script>
```

Alternatively, if hosting the Web Awesome yourself, reference the relevant files and add:
```HTML
    -- YOUR WEB AWESOME FILES HERE --
    <link rel="stylesheet" href="@Assets["/_content/WebAwesomeBlazor/WebAwesome.css"]" />
    <script type="text/javascript" src="@Assets["/_content/WebAwesomeBlazor/JsInterop.js"]"></script>
```

Add the following to your `_Imports.razor` file:
```HTML+Razor
@using WebAwesomeBlazor
@using WebAwesomeBlazor.Components
@using WebAwesomeBlazor.Extended
```

If you plan to use `ConfirmDialog`, add the following to your `Program.cs`:
```CSharp
builder.Services.AddWebAwesome();
```

Then you can use the components in your Blazor pages, for example:
```HTML+Razor
<WAButton OnClick="ButtonClicked" Appearance="ButtonAppearance.Outlined" Variant="ButtonVariant.Brand">Change value</WAButton>
```
# Using Icons
Throughout the library, many components use icons.
Refer to [IconClass](/docs/IconClass.md) for usage.


# Web Awesome components
- [WAAnimatedImage](/docs/WAAnimatedImage.md)
- [WAAnimation](/docs/WAAnimation.md)
- [WAAvatar](/docs/WAAvatar.md)
- [WABadge](/docs/WABadge.md)
- [WABreadcrumb](/docs/WABreadcrumb.md)
  - [WABreadcrumbItem](/docs/WABreadcrumbItem.md)
- [WAButton](/docs/WAButton.md)
- [WAButtonGroup](/docs/WAButtonGroup.md)
- [WACallout](/docs/WACallout.md)
- [WACard](/docs/WACard.md)
- [WACarousel](/docs/WACarousel.md)
- [WAComparison](/docs/WAComparison.md)
- [WACheckbox](/docs/WACheckbox.md)
- [WAColorPicker](/docs/WAColorPicker.md)
- [WACopyButton](/docs/WACopyButton.md)
- [WADetails](/docs/WADetails.md)
- [WADialog](/docs/WADialog.md)
- [WADivider](/docs/WADivider.md)
- [WADrawer](/docs/WADrawer.md)
- [WADropdown](/docs/WADropdown.md)
  - [WADropdownItem](/docs/WADropdownItem.md)
- [WAFormatBytes](/docs/WAFormatBytes.md)
- [WAIcon](/docs/WAIcon.md)
- [WAInclude](/docs/WAInclude.md)
- [WAInput](/docs/WAInput.md)
- [WAInputDateTime](/docs/WAInputDateTime.md)
- [WAInputNumber](/docs/WAInputNumber.md)
- [WAIntersectionObserver](/docs/WAIntersectionObserver.md)
- [WAPage](/docs/WAPage.md)
  - [WALayoutContent](/docs/WALayoutContent.md)
- [WAPopover](/docs/WAPopover.md)
- [WAProgressBar](/docs/WAProgressBar.md)
- [WAProgressRing](/docs/WAProgressRing.md)
- [WAQRCode](/docs/WAQRCode.md)
- [WARadioGroup](/docs/WARadioGroup.md)
  - [WARadioOption](/docs/WARadioOption.md)
- [WARating](/docs/WARating.md)
- [WARelativeTime](/docs/WARelativeTime.md)
- [WAResizeObserver](/docs/WAResizeObserver.md)
- [WAScroller](/docs/WAScroller.md)
- [WASelect](/docs/WASelect.md)
  - [WASelectOption](/docs/WASelectOption.md)
- [WASkeleton](/docs/WASkeleton.md)
- [WASlider](/docs/WASlider.md)
- [WASplitPanel](/docs/WASplitPanel.md)
- [WASwitch](/docs/WASwitch.md)
- [WATabGroup](/docs/WATabGroup.md)
  - [WATabPanel](/docs/WATabPanel.md)
- [WATag](/docs/WATag.md)
- [WATextArea](/docs/WATextArea.md)
- [WATooltip](/docs/WATooltip.md)
- [WATree](/docs/WATree.md)
  - [WATreeItem](/docs/WATreeItem.md)
- [WAZoomableFrame](/docs/WAZoomableFrame.md)

Some functions have not been included as there are suitable .NET functions available:
- [FormatNumber](https://webawesome.com/docs/components/format-number/)
- [FormatDate](https://webawesome.com/docs/components/format-date/) 
- [MutationObserver](https://webawesome.com/docs/components/mutation-observer/)

# Extended components 
Additional components built on top of the Web Awesome library for additional functionality:
- [DataSelect](/docs/Extended/DataSelect.md)
- [AutoCompleteInput](/docs/Extended/AutoComplete.md)
- [DarkModeToggle](/docs/Extended/DarkModeToggle.md)
- [ConfirmDialog](/docs/Extended/ConfirmDialog.md)

## Coming soon:
- NavTree


# Credits
This project contains inspiration of elements from:
* Vikram - [Blazor Bootstrap Component Library](https://github.com/vikramlearning/blazorbootstrap)
