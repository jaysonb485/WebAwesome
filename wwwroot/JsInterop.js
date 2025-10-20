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
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.addEventListener('wa-after-hide', function (event) {
                if (event.target.id == elementId) {
                    console.log(event);
                    dotnetHelper.invokeMethodAsync('HandleDialogClosed', event.target.id);
                };
            });

            element.addEventListener('wa-hide', event => {
                console.log(event);
                //if (event.detail.source !== closeButton) {
                //    event.preventDefault();
                //}
            });

        },
        change: (elementId, newState) => {
            let dialog = document.getElementById(elementId);
            if (dialog != null)
                dialog.open = newState;
        }
    },
    input: {
        setValue: (elementId, newValue) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.value = newValue;
        },
        initialize: (elementId, dotnetHelper, setValue) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.value = setValue;

            element.addEventListener('wa-clear', function (event) {
                dotnetHelper.invokeMethodAsync('HandleInputClear');
            });

            element.addEventListener('change', function (event) {
                dotnetHelper.invokeMethodAsync('HandleInputChange', element.value);
            });
        },
        dispose: (elementRef) => {
            if (elementRef != null)
                vengage?.Input?.getOrCreateInstance(elementRef)?.dispose();
        },
        setFocus: (elementId) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.focus();
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
    navtree: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.addEventListener('wa-selection-change', function (event) {
                console.log(event);
                dotnetHelper.invokeMethodAsync('HandleNavTreeSelect', event.detail.item);
            });
        }
    },
    page: {
        initialize: (elementId, dotnetHelper, resizeObserverId) => {
            let resizeelement = document.getElementById(resizeObserverId);
            if (!resizeelement) return;
            resizeelement.addEventListener('wa-resize', function (event) {
                let pageelement = document.getElementById(elementId);
                if (pageelement) {
                    dotnetHelper.invokeMethodAsync('HandleResize', pageelement.view);
                }
            });
        },
        shownav: (elementId) => {
            let element = document.getElementById(elementId);
            if (element)
                element.showNavigation();
        },
        hidenav: (elementId) => {
            let element = document.getElementById(elementId);
            if (element)
                element.hideNavigation();
        },
        togglenav: (elementId) => {
            let element = document.getElementById(elementId);
            if (element)
                element.toggleNavigation();
        },
        view: (elementId) => {
            let element = document.getElementById(elementId);
            if (element)
                console.log(element);
            return element.view;
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
    select: {
        setValue: (elementId, value) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.value = value;
        },
        initialize: (elementId, dotnetHelper, setValue) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.value = setValue;

            element.addEventListener('wa-clear', function (event) {
                dotnetHelper.invokeMethodAsync('HandleInputClear');
            });

            //element.addEventListener('change', function (event) {
            //    dotnetHelper.invokeMethodAsync('HandleInputChange', element.value);
            //});
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
    tab: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.addEventListener('wa-tab-show', function (event) {
                dotnetHelper.invokeMethodAsync('HandleTabShowing', event.detail.name);
            });
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
            document.documentElement.classList.add('wa-theme-' + themeName);
            document.documentElement.classList.add('wa-palette-' + palette);
            document.documentElement.classList.add('wa-brand-' + brandColor);
            document.body.classList.add('initialized');
        },
        setStyleSheet: (url) => {

            link = document.createElement('link');
            link.rel = 'stylesheet';
            link.href = url;
            document.head.appendChild(link);

        },
        setDarkMode: (darkMode) => {
            document.documentElement.classList.toggle('wa-dark', darkMode);
        }
    },

}
