I'm a hobbyist developer. This is an open source project to provide Blazor components for the Web Awesome UI framework. Feedback and contributions are welcome!
# WebAwesomeBlazor

Currently supports Web Awesome 3.0.0-beta 6.

# Installation
Add as a project dependency, or build from source.

Nuget coming soon.

# Usage
Add the following to your `_Imports.razor` file:
```csharp
@using WebAwesomeBlazor
@using WebAwesomeBlazor.Components
@using WebAwesomeBlazor.Extended
```

Add the following to your App.razor or wwwroot/index.html file:
```csharp
    <link rel="stylesheet" href="https://early.webawesome.com/webawesome@3.0.0-beta.6/dist/styles/webawesome.css" />
    <script type="module" src="https://early.webawesome.com/webawesome@3.0.0-beta.6/dist/webawesome.loader.js"></script>
    <link rel="stylesheet" href="@Assets["/_content/WebAwesomeBlazor/WebAwesome.css"]" />
    <script type="text/javascript" src="@Assets["/_content/WebAwesomeBlazor/JsInterop.js"]"></script>
```

Then you can use the components in your Blazor pages, for example:
```csharp
<WAButton OnClick="ButtonClicked" Appearance="ButtonAppearance.Outlined" Variant="ButtonVariant.Brand">Change value</WAButton>
```
# Using Icons
Throughout the library, many components use icons.
Refer to [IconClass](/docs/IconClass.md) for usage.


# Web Awesome components
- WAAnimatedImage (coming soon)
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
- WAComparison (coming soon)
- [WACheckbox](/docs/WACheckbox.md)
- [WAColorPicker](/docs/WAColorPicker.md)
- [WACopyButton](/docs/WACopyButton.md)
- [WADetails](/docs/WADetails.md)
- [WADialog](/docs/WADialog.md)
- [WADivider](/docs/WADivider.md)
- [WADrawer](/docs/WADrawer.md)
- [WADropdown](/docs/WADropdown.md)
  - [WADropdownItem](/docs/WADropdownItem.md)
- WAFormatBytes (coming soon)
- WAFormatDate (coming soon)
- WAFormatNumber (coming soon)
- [WAIcon](/docs/WAIcon.md)
- WAInclude (coming soon)
- [WAInput](/docs/WAInput.md)
- [WAInputDateTime](/docs/WAInputDateTime.md)
- [WAInputNumber](/docs/WAInputNumber.md)
- [WAIntersectionObserver](/docs/WAIntersectionObserver.md)
- WAMutationObserver (coming soon)
- [WAPage](/docs/WAPage.md)
  - [WALayoutContent](/docs/WALayoutContent.md)
- [WAPopover](/docs/WAPopover.md)
- [WAProgressBar](/docs/WAProgressBar.md)
- [WAProgressRing](/docs/WAProgressRing.md)
- WAQRCode (coming soon)
- [WARadioGroup](/docs/WARadioGroup.md)
  - [WARadioOption](/docs/WARadioOption.md)
- [WARating](/docs/WARating.md)
- [WARelativeTime](/docs/WARelativeTime.md)
- WAResizeObserver (coming soon)
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
- WATree (coming soon)
  - WATreeItem (coming soon)
- [WAZoomableFrame](/docs/WAZoomableFrame.md)

# Extended components (Coming soon)
New components built on top of the Web Awesome library for additional functionality:
- NavTree
- AutoComplete
- ConfirmDialog
- DataSelect
- ThemeManager
- Toast


# Credits
This project contains inspiration of elements from:
* Vikram - [Blazor Bootstrap Component Library](https://github.com/vikramlearning/blazorbootstrap)
