# Changelog
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