# Changelog

## Version 1.5.0
- Upgraded to [Web Awesome 3.5.0](https://webawesome.com/docs/resources/changelog#wa_350) - Make sure you have updated your project version on [Web Awesome Teams](https://webawesome.com/teams).
- Breaking: Project initialisation has changed. Refer to the Readme for details.
- Removed Pro from [WAPage](/docs/WAPage.md) and [WALayoutContent](/docs/WALayoutContent.md) as they are now available to all users.
- Added new component: [WAMarkdown](/docs/WAMarkdown.md) - The markdown component turns raw markdown into rendered HTML using the Marked library.

## Version 1.4.0
- Upgraded to [Web Awesome 3.4.0](https://webawesome.com/docs/resources/changelog#wa_340) - Make sure you have updated your project version on [Web Awesome Teams](https://webawesome.com/teams).
- [WAColorPicker](/docs/WAColorPicker.md): Added new method `SetSwatchesAsync` to set color swatches with accessible labels to display as presets.
- [WACombobox](/docs/WACombobox.md) and [WAInput](/docs/WAInput.md):
	* New parameter `AutoCapitalize` to control whether and how text input is automatically capitalized as it is entered/edited by the user.
	* New parameter `AutoCorrect` to indicate whether the browser's autocorrect feature is on or off. 
	* New parameter `EnterKeyHint` used to customize the label or icon of the Enter key on virtual keyboards.
	* New parameter `InputMode` to tell the browser what type of data will be entered by the user, allowing it to display the appropriate virtual keyboard on supportive devices.
	* New parameter `Spellcheck` to enable spell checking on the comboxbox.
- [WACombobox](/docs/WACombobox.md)
    * New parameter `AllowCreate` and Event Callback `OptionCreating` to allow the user to create a new option if it doesn't exit.
	* BREAKING - `Autocomplete` parameter has been removed by Web Awesome due to conflicts with native HTML parameter.
- [WAZoomableFrame](/docs/WAZoomableFrame.md) 
	* New parameter `SyncThemes` enables automatic theme syncing (light/dark mode and theme selector classes) from the host document to the iframe.

## Version 1.3.0.2
- Fix: DatSelect - Error when OptionKey is invalid.

## Version 1.3.0.1
- Fix: WAToast would not display if the calling function is not on the dispatcher thread.

## Version 1.3.0 - 2026-03-08
- Upgraded to [Web Awesome 3.3.1](https://webawesome.com/docs/resources/changelog#wa_331) - Make sure you have updated your project version on [Web Awesome Teams](https://webawesome.com/teams).
- Added new components:
	* (Pro) [WABarChart](/docs/WABarChart.md): Bar charts compare quantities across categories using rectangular bars.
	* (Pro) [WABubbleChart](/docs/WABubbleChart.md): Bubble charts add a third dimension to scatter plots by varying the size of each data point. 
	* (Pro) [WADoughnutChart](/docs/WADoughnutChart.md): Doughnut charts show proportional data as slices of a ring with a hollow center.
	* (Pro) [WALineChart](/docs/WALineChart.md): Line charts show trends over time by connecting data points with line segments.
	* (Pro) [WAPieChart](/docs/WAPieChart.md): Pie charts show the proportional composition of a whole as slices of a circle. 
	* (Pro) [WAPolarAreaChart](/docs/WAPolarAreaChart.md): Polar area charts compare values using segments that radiate from a center point with varying radius.
	* (Pro) [WARadarChart](/docs/WARadarChart.md): Radar charts compare multiple variables at once by plotting data on a radial grid.
	* (Pro) [WAScaatterChart](/docs/WAScatterChart.md): Scatter charts reveal relationships between two variables by plotting data points on a grid. 
	* (Pro) [WAToast](/docs/WAToast.md): Toasts display brief, non-blocking notifications that appear temporarily above the page content.


## Version 1.2.1
- Added new parameter 'Tooltip' to [WAIcon](/docs/WAIcon.md) to allow for easy addition of tooltips to icons.

## Version 1.2.0 - 2026-02-07
- Upgraded to [Web Awesome 3.2.1](https://webawesome.com/docs/resources/changelog#wa_321)
- Added new components:
  * (Pro) [WASparkline](/docs/WASparkline.md): Sparklines display inline data trends as compact, visual charts.
  * (Pro) [WAFileInput](/docs/WAFileInput.md): A file input component that allows users to select files for upload, with support for multiple file selection and drag-and-drop.
  * [WANumberInput](/docs/WANumberInput.md): An input component specifically for numeric values, with support for min/max values, step increments, and formatting options. This is a separate implementation to the [WAInputNumber](/docs/WAInputNumber.md) component.
- [Icon](/docs/IconClass.md):
  * New parameter `Rotate` to specify the rotation of the icon in degrees.
  * New parameter `Flip` to specify the flip orientation of the icon (horizontal, vertical, both).
  * New parameter `Animation` to specify a built-in animation for the icon (e.g. beat, fade). 
- Fix for [WATag](/docs/WATag.md): default fallback appearance was missing a hyphen.
- Added parameters to input components [WAInput](/docs/WAInput.md), [WAInputDateTime](/docs/WAInputDateTime.md), [WAInputNumber](/docs/WAInputNumber.md):
  * `Autofocus` to automatically focus the input when it is rendered.
  * `Autocomplete` to specify what permission the browser has to provide assistance in filling out form field values.

## Version 1.1.2 - 2026-01-29
- [AutoCompleteInput](/docs/Extended/AutoCompleteInput.md):
  * New method - SetValue to programmatically set the input value.

## Version 1.1.1 - 2026-01-27
- [WASelect](/docs/WASelect.md):
- [WAComboxbox](/docs/WACombobox.md):
  * Enabled multi-select mode to allow users to select multiple options from the dropdown.
	
- [AutoCompleteInput](/docs/Extended/AutoCompleteInput.md):
  * New parameter `DebounceDelay` to control the delay before the search function is called after user input.

## Version 1.1.0 - 2025-12-19
- [WAComboxbox](/docs/WACombobox.md):
  * New component, Combobox allows users to select from a list of options or enter custom values.

## Version 1.0.6 - 2025-12-03
- Behind-the-scenes enhancements for [WADialog](/docs/WADialog.md)

## Version 1.0.5 - 2025-11-18
- [ConfirmDialog](/docs/Extended/ConfirmDialog.md):
  * New component, ConfirmDialog extends WADialog to provide a simple yes/no prompt to users with feedback to the application.
- WADialog:
  * Small change behind the scenes to accomodate ConfirmDialog.

## Version 1.0.4.1 - 2025-11-12
- WAInputNumber:
  * Step property was not passing through to the resulting input box
  * Changed step property to `decimal` to allow greater precision definition

## Version 1.0.4 - 2025-11-10

- WAAnimation: 
  * Added event callbacks for AnimationCancelled, AnimationFinished and AnimationStarted.
  * Added methods: CancelAnimation and FinishAnimation
- WAAvatar: Added size property
- WACard: Added spacing property
- WACarousel:
  * Added event callback for SlideChanged
  * Added methods: GoToSlide, NextSlide, PreviousSlide
- WADetails - Added methods for Show and Hide
- WADrawer - Code clean up
- WADropdown - Event callback for ItemSelected
- WARadioOption - Added properties:
  * CheckedIconColor
  * CheckedIconScale
- WARadioGroup - Added null check for ValueExpression
- WARating - Added properties:
  * SymbolColor
  * SymbolColorActive
  * SymbolSpacing
- WAScroller - Added properties:
  * ShadowColor
  * ShadowSize
- WASlider:
  * Added event callback for PositionChanged
  * Changed PositionPercent to double (was int)
- WASwitch - Added properties:
  * SwitchWidth
  * SwitchHeight
  * ThumbSize
- WATabGroup - Added properties:
  * IndicatorColor
  * TrackColor
  * TrackWidth
- WATabPanel:
  * Added property: PanelPadding
  * Provided separate style and class properties for the panel vs tab.
- WATag
  * Provided separate TagRemoving event to allow for intercept of removal.
  * Provided Remove method to remove the tag programatically.
- WAZoomableFrame
  * Provided methods for ZoomIn and ZoomOut
  * Provided event callbacks for Loaded and LoadError
