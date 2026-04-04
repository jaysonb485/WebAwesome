export function initialize(elementId, dotnetHelper, setValue) {
    const element = document.getElementById(elementId);
    if (!element) return;

    if (!setValue) element.value = setValue;

    element.addEventListener('wa-clear', function (event) {
        dotnetHelper.invokeMethodAsync('HandleInputClear');
    });

    element.addEventListener('wa-create', function (event) {
        event.preventDefault();

        dotnetHelper.invokeMethodAsync('HandleOptionCreate', event.detail.inputValue);
    });
}

export function setValue(elementId, value) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.value = value;
}

export function getInputValue(elementId) {
    const element = document.getElementById(elementId);
    if (element)
        return element.inputValue;
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