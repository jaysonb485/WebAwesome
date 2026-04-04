export function setValue(elementId, newValue) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.value = newValue;
}

export function initialize(elementId, dotnetHelper, setValue) {
    let element = document.getElementById(elementId);
    if (!element) return;

    element.value = setValue;

    element.addEventListener('wa-clear', function (event) {
        dotnetHelper.invokeMethodAsync('HandleInputClear');
    });

    element.addEventListener('change', function (event) {
        dotnetHelper.invokeMethodAsync('HandleInputChange', element.value);
    });
}
export function dispose(elementRef) {
    if (elementRef != null)
        vengage?.Input?.getOrCreateInstance(elementRef)?.dispose();
}
export function setFocus(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.focus();
}

export function numberInputStepUp(elementId, dotnetHelper) {
    let element = document.getElementById(elementId);
    if (!element) return;

    element.stepUp();
    dotnetHelper.invokeMethodAsync('HandleInputChange', element.value);
}
export function numberInputStepDown(elementId, dotnetHelper) {
    let element = document.getElementById(elementId);
    if (!element) return;

    element.stepDown();
    dotnetHelper.invokeMethodAsync('HandleInputChange', element.value);
}