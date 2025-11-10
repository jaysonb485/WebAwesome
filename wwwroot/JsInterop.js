// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.


window.vengage = {
    animation: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.addEventListener('wa-cancel', function (event) {
                dotnetHelper.invokeMethodAsync('HandleAnimationCancel');
            });
            element.addEventListener('wa-finish', function (event) {
                dotnetHelper.invokeMethodAsync('HandleAnimationFinish');
            });
            element.addEventListener('wa-start', function (event) {
                dotnetHelper.invokeMethodAsync('HandleAnimationStart');
            });
        },
        cancel: (elementId) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.cancel();
        },
        finish: (elementId) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.finish();
        }
    },
    carousel: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.addEventListener('wa-slide-change', function (event) {
                dotnetHelper.invokeMethodAsync('HandleSlideChange', event.detail.index);
            });
        },
        goToSlide: (elementId, slideIndex) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.goToSlide({ index: slideIndex });
        },
        nextSlide: (elementId) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.next();
        },
        previousSlide: (elementId) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.previous();
        }
    },
    colorPicker: {
        getFormattedValue: (elementId, colorFormat) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            return element.getFormattedValue(colorFormat);
        }
    },
    comparison: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.addEventListener('change', function (event) {
                dotnetHelper.invokeMethodAsync('HandleDividerChange', element.position);
            });
        }
    },
    copybutton: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.addEventListener('wa-copy', function (event) {
                dotnetHelper.invokeMethodAsync('HandleCopy');
            });
            element.addEventListener('wa-error', function (event) {
                dotnetHelper.invokeMethodAsync('HandleCopyError');
            });
        }
    },
    details: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.addEventListener('wa-show', function (event) {
                dotnetHelper.invokeMethodAsync('HandleDetailsShow');
            });
            element.addEventListener('wa-hide', function (event) {
                dotnetHelper.invokeMethodAsync('HandleDetailsHide');
            });
        },
        hide: (elementId) => {
            let element = document.getElementById(elementId);
            if (element)
                element.hide();
        },
        show: (elementId) => {
            let element = document.getElementById(elementId);
            if (element)
                element.show();
        }
    },
    dialog: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.addEventListener('wa-after-hide', function (event) {
                if (event.target.id == elementId) {
                    dotnetHelper.invokeMethodAsync('HandleDialogClosed', event.target.id);
                };
            });
        },
        change: (elementId, newState) => {
            let dialog = document.getElementById(elementId);
            if (dialog != null)
                dialog.open = newState;
        }
    },
    drawer: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.addEventListener('wa-after-hide', function (event) {
                if (event.target.id == elementId) {
                    dotnetHelper.invokeMethodAsync('HandleDialogClosed', event.target.id);
                };
            });
        },
        change: (elementId, newState) => {
            let dialog = document.getElementById(elementId);
            if (dialog != null)
                dialog.open = newState;
        }
    },
    dropdown: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.addEventListener('wa-select', function (event) {
                if (event.target.id == elementId) {
                    dotnetHelper.invokeMethodAsync('HandleItemSelected', event.detail.item.value);
                };
            });
        }
    },
    include: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.addEventListener('wa-load', function (event) {
                dotnetHelper.invokeMethodAsync('HandleIncludeLoaded');
            });

            element.addEventListener('wa-include-error', function (event) {
                console.log('error' + event.detail.status);
                dotnetHelper.invokeMethodAsync('HandleIncludeError', event.detail.status);
            });
        },
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
    rating: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.onchange = function (event) {
                dotnetHelper.invokeMethodAsync('OnValueChanged', element.value);
            };
        }
    },
    resizeObserver: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.addEventListener('wa-resize', function (event) {
                dotnetHelper.invokeMethodAsync('HandleResize', event.detail.entries[0].contentRect.height, event.detail.entries[0].contentRect.width);
            });
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
        }
    },
    slider: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.onchange = function (event) {
                dotnetHelper.invokeMethodAsync('OnValueChanged', element.value);
            };
        },
        setValue: (elementId, newValue) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.value = newValue;
        }
    },
    splitPanel: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.addEventListener('wa-reposition', function (event) {
                dotnetHelper.invokeMethodAsync('HandleDividerChange', element.position);
            });
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
                    dotnetHelper.invokeMethodAsync('HandleTagRemove');
                });
            }
        },
        removeTag: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (element) {
                element.style.opacity = '0';
                setTimeout(() => (element.style.display = 'none'), 1000);
                dotnetHelper.invokeMethodAsync('HandleTagRemoved');
            }
        }

    },
    themeManager: {
        setDarkMode: (darkMode) => {
            document.documentElement.classList.toggle('wa-dark', darkMode);
        }
    },
    tree: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.addEventListener('wa-selection-change', function (event) {
                dotnetHelper.invokeMethodAsync('HandleSelectionChanged', event.detail.selection.map(obj => obj.attributes.getNamedItem('value').value));
            });

        }
    },
    zoomable: {
        initialize: (elementId, dotnetHelper) => {
            let element = document.getElementById(elementId);
            if (!element) return;

            element.addEventListener('load', function (event) {
                dotnetHelper.invokeMethodAsync('HandleZoomableLoaded');
            });

            element.addEventListener('error', function (event) {
                console.log('error' + event.detail);
                dotnetHelper.invokeMethodAsync('HandleZoomableError', event.detail.status);
            });
        },
        zoomIn: (elementId) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.zoomIn();
        },
        zoomOut: (elementId) => {
            let element = document.getElementById(elementId);
            if (!element) return;
            element.zoomOut();
        }
    }

}
