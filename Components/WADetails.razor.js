export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.addEventListener('wa-show', function (event) {
        dotnetHelper.invokeMethodAsync('HandleDetailsShow');
    });
    element.addEventListener('wa-hide', function (event) {
        dotnetHelper.invokeMethodAsync('HandleDetailsHide');
    });
}

export function hide(elementId) {
    const element = document.getElementById(elementId);
    if (element)
        element.hide();
}

export function show(elementId) {
    const element = document.getElementById(elementId);
    if (element)
        element.show();
}