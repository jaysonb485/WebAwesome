# Changelog

## Version 1.1.1 -
- [WASelect](/docs/WASelect.md):
- [WAComboxbox](/docs/WACombobox.md):
  * Enabled multi-select mode to allow users to select multiple options from the dropdown.
	
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
