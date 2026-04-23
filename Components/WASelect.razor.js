export function initialize(elementId, dotnetHelper, setValue) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.value = setValue;

    element.addEventListener('wa-clear', function (event) {
        dotnetHelper.invokeMethodAsync('HandleInputClear');
    });
}
export function setValue(elementId, value) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.value = value;
}
