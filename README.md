I'm a hobbyist developer. This is an open source project to provide Blazor components for the Web Awesome UI framework. Feedback and contributions are welcome!
# WebAwesomeBlazor

Currently supports Web Awesome 3.5.0. 

# Changelog
[Version 1.5.0](/docs/CHANGELOG.md)

# Installation
Get the latest package from [NuGet](https://www.nuget.org/packages/WebAwesomeBlazor/)
```
dotnet add package WebAwesomeBlazor
```

# Usage

## 1. Add Web Awesome style and javascript code
### Free components
Add the project code to your `App.razor` or `wwwroot/index.html` file in the `<head>` section along with the extra utility files for this package:
```HTML
<link rel="stylesheet" href="https://ka-f.webawesome.com/webawesome@3.5.0/styles/webawesome.css">
<script type="module" src="https://ka-f.webawesome.com/webawesome@3.5.0/webawesome.loader.js"></script>
```

### Web Awesome Pro components
To use the Web Awesome Pro components, you'll need to register a [Web Awesome](https://webawesome.com/) project. 
Once registered, copy the project code from the CDN tab in your project settings page into the `<head>` tag on `App.razor` or `wwwroot/index.html` file instead of the free component code above.
Don't forget to also follow the instructions to add any relevant CSS classes to your `<html>` tag mentioned on the CDN page.

## 2. Add Web Awesome Blazor components
Initialize the Web Awesome Blazor services in your `Program.cs` file adding in your kit code:
```CSharp
builder.Services.AddWebAwesome();
```

Add the following to your `_Imports.razor` file:
```HTML+Razor
@using WebAwesomeBlazor
@using WebAwesomeBlazor.Components
@using WebAwesomeBlazor.Extended
```


You can then use the components in your Blazor pages, for example:
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
- (Pro) [WACombobox](/docs/WACombobox.md)
  - [WAComboboxOption](/docs/WAComboboxOption.md)
- [WACopyButton](/docs/WACopyButton.md)
- [WADetails](/docs/WADetails.md)
- [WADialog](/docs/WADialog.md)
- [WADivider](/docs/WADivider.md)
- [WADrawer](/docs/WADrawer.md)
- [WADropdown](/docs/WADropdown.md)
  - [WADropdownItem](/docs/WADropdownItem.md)
- (Pro) [WAFileInput](/docs/WAFileInput.md)
- [WAFormatBytes](/docs/WAFormatBytes.md)
- [WAIcon](/docs/WAIcon.md)
- [WAInclude](/docs/WAInclude.md)
- [WAInput](/docs/WAInput.md)
- [WAInputDateTime](/docs/WAInputDateTime.md)
- [WAInputNumber](/docs/WAInputNumber.md)
- [WAIntersectionObserver](/docs/WAIntersectionObserver.md)
- [WAMarkdown](/docs/WAMarkdown.md)
- [WANumberInput](/docs/WANumberInput.md)
- (Pro) [WAPage](/docs/WAPage.md)
  - (Pro) [WALayoutContent](/docs/WALayoutContent.md)
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
- (Pro) [WAToast](/docs/WAToast.md)
- [WATooltip](/docs/WATooltip.md)
- [WATree](/docs/WATree.md)
  - [WATreeItem](/docs/WATreeItem.md)
- [WAZoomableFrame](/docs/WAZoomableFrame.md)

## Data visualisation
- (Pro) [WABarChart](/docs/WABarChart.md)
- (Pro) [WABubbleChart](/docs/WABubbleChart.md)
- (Pro) [WADoughnutChart](/docs/WADoughnutChart.md)
- (Pro) [WALineChart](/docs/WALineChart.md)
- (Pro) [WAPieChart](/docs/WAPieChart.md)
- (Pro) [WAPolarAreaChart](/docs/WAPolarAreaChart.md)
- (Pro) [WARadarChart](/docs/WARadarChart.md)
- (Pro) [WAScaatterChart](/docs/WAScatterChart.md)
- (Pro) [WASparkline](/docs/WASparkline.md)

Some Web Awesome components have not been included as there are suitable .NET functions available:
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
