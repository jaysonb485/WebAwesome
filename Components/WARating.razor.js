export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.onchange = function (event) {
        dotnetHelper.invokeMethodAsync('OnValueChanged', element.value);
    };
}