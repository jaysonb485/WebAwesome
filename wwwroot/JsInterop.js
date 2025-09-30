// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

//export function showPrompt(message) {
//  return prompt(message, 'Type anything here');
//}

//export function executeDotNetMethod(objRef, methodName) {
//    return objRef.invokeMethodAsync(methodName);
//}

window.vengage = {
    dialog: {
        change: (elementId, newState) => {
            let dialog = document.getElementById(elementId);
            if (dialog != null)
                dialog.open = newState;
        }
    },
    //dropdown: {
    //    initialize: (elementId, dotnetHelper) => {
    //        let element = document.getElementById(elementId);
    //        if (!element) return;
    //        element.addEventListener('wa-select', function (event) {
    //            console.log('dropdown selected');
    //            console.log(event);
    //            dotnetHelper.invokeMethodAsync('OnDropdownItemSelected', event.detail.item.value);
    //        });
    //    },
    //    dispose: (elementRef) => {
    //        if (elementRef != null)
    //            vengage?.Dropdown?.getOrCreateInstance(elementRef)?.dispose();
    //    }
    //},
    input: {
        setValue: (elementId, newValue) => {
            let element = document.getElementById(elementId);
            if (element)
                element.value = newValue;
        },
        initialize: (elementId, dotnetHelper, setValue) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.value = setValue;

            element.addEventListener('wa-clear', function (event) {
                console.log('inputcleared');
                console.log(event);
                dotnetHelper.invokeMethodAsync('HandleInputClear');
            });
        },
        dispose: (elementRef) => {
            if (elementRef != null)
                vengage?.Input?.getOrCreateInstance(elementRef)?.dispose();
        }
    },
    interceptObserver: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.addEventListener('wa-intersect', function (event) {
                const entry = event.detail.entry;
                if (entry.isIntersecting) {
                    dotnetHelper.invokeMethodAsync('HandleIntersecting');
                } else {
                    dotnetHelper.invokeMethodAsync('HandleLeaving');
                }
            });
        }
    },
    navigation: {
        show: (elementId) => {
            let element = document.getElementById(elementId);
            if (element)
                element.showNavigation();
        },
        hide: (elementId) => {
            let element = document.getElementById(elementId);
            if (element)
                element.hideNavigation();
        },
        toggle: (elementId) => {
            let element = document.getElementById(elementId);
            if (element)
                element.toggleNavigation();
        }
    },
    popover: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (element) {
                element.addEventListener('wa-show', function (event) {
                    dotnetHelper.invokeMethodAsync('HandlePopoverShow', event.type, event);
                });
                element.addEventListener('wa-hide', function (event) {
                    dotnetHelper.invokeMethodAsync('HandlePopoverHide', event.type, event);
                });
            }
        },
        show: (elementId) => {
            let element = document.getElementById(elementId);
            if (element)
                element.show();
        },
        hide: (elementId) => {
            let element = document.getElementById(elementId);
            if (element)
                element.hide();
        }
    },
    slider: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.onchange = function (event) {
                dotnetHelper.invokeMethodAsync('OnValueChanged', element.value);
            };
        }
    },
    tag: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (element) {
                element.addEventListener('wa-remove', function (event) {
                    dotnetHelper.invokeMethodAsync('HandleTagRemove', event.type, event);
                });
            }
        }
    },
    themeManager: {
        initialize: (themeName, palette, brandColor) => {
            document.body.classList.add('wa-theme-' + themeName);
            document.body.classList.add('wa-palette-' + palette);
            document.body.classList.add('wa-brand-' + brandColor);
            document.body.classList.add('initialized');
        },
        setDarkMode: (darkMode) => {
            document.documentElement.classList.toggle('wa-dark', darkMode);
        }
    },

}

//function interceptChangeEvent(elementId, dotNetObject) {
//    const element = document.getElementById(elementId);
//    if (!element) return;

//    element.onchange = function (event) {
//        dotNetObject.invokeMethodAsync('OnValueChanged', element.value);
//    };
//}

//function addTagRemovedListener(elementId, dotnetHelper) {
//    const element = document.getElementById(elementId);
//    if (element) {
//        element.addEventListener('wa-remove', function (event) {
//            dotnetHelper.invokeMethodAsync('HandleRemove', event.type, event);
//        });
//    }
//}

//function addPopoverEventListeners(elementId, dotnetHelper) {
//    const element = document.getElementById(elementId);
//    if (element) {
//        element.addEventListener('wa-show', function (event) {
//            dotnetHelper.invokeMethodAsync('HandleShow', event.type, event);
//        });
//        element.addEventListener('wa-hide', function (event) {
//            dotnetHelper.invokeMethodAsync('HandleHide', event.type, event);
//        });
//    }
//}

//window.updateComponentValue = (elementId, newValue) => {
//    const element = document.getElementById(elementId);
//    if (element)
//        element.value = newValue;
//}

//window.toggleDarkMode = (darkMode) => {
//    document.documentElement.classList.toggle('wa-dark', darkMode);
//}

//window.showNavigation = (elementId) => {
//    const element = document.getElementById(elementId);
//    if (element)
//        element.showNavigation();
//}

//window.hideNavigation = (elementId) => {
//    const element = document.getElementById(elementId);
//    if (element)
//        element.hideNavigation();
//}

//window.toggleNavigation = (elementId) => {
//    const element = document.getElementById(elementId);
//    if (element)
//        element.toggleNavigation();
//}

//window.showPopover = (elementId) => {
//    const element = document.getElementById(elementId);
//    if (element)
//        element.show();
//}

//window.hidePopover = (elementId) => {
//    const element = document.getElementById(elementId);
//    if (element)
//        element.hide();
//}

//window.initTheme = (themeName, palette, brandColor) => {
//    document.body.classList.add('wa-theme-'+themeName);
//    document.body.classList.add('wa-palette-'+palette);
//    document.body.classList.add('wa-brand-' + brandColor);
//    document.body.classList.add('initialized');

//}
