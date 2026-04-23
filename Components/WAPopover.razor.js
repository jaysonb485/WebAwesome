
export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (element) {
        element.addEventListener('wa-show', function (event) {
            dotnetHelper.invokeMethodAsync('HandlePopoverShow', event.type, event);
        });
        element.addEventListener('wa-hide', function (event) {
            dotnetHelper.invokeMethodAsync('HandlePopoverHide', event.type, event);
        });
    }
}

export function show(elementId) {
    const element = document.getElementById(elementId);
    if (element)
        element.show();
}

export function hide(elementId) {
    const element = document.getElementById(elementId);
    if (element)
        element.hide();
}