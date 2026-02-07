# Changelog

## Version 1.2.0 - 2026-02-07
- Upgraded to [WebAwesome 3.2.1](https://webawesome.com/docs/resources/changelog#wa_321)
- Added new components:
  * (Pro) [WASparkline](/docs/WASparkline.md): Sparklines display inline data trends as compact, visual charts.
  * (Pro) [WAFileInput](/docs/WAFileInput.md): A file input component that allows users to select files for upload, with support for multiple file selection and drag-and-drop.
  * [WANumberInput](/docs/WANumberInput.md): An input component specifically for numeric values, with support for min/max values, step increments, and formatting options. This is a separate implementation to the [WAInputNumber](/docs/WAInputNumber.md) component.
- [Icon](/docs/WAIcon.md):
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
