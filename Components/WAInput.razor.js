export function setValue(elementId, newValue) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.value = newValue;
}

export function initialize(elementId, dotnetHelper, setValue) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    
    // Only set the value if explicitly provided
    if (setValue !== undefined && setValue !== null) {
        element.value = setValue;
    }

    // Capture handlers so they can be removed later
    const onClear = () => {
        dotnetHelper.invokeMethodAsync('HandleInputClear');
    };

    const onChange = () => {
        dotnetHelper.invokeMethodAsync('HandleInputChange', element.value);
    };

    const onFocus = () => {
        dotnetHelper.invokeMethodAsync('HandleInputFocus');
    };

    const onBlur = () => {
        dotnetHelper.invokeMethodAsync('HandleInputBlur');
    };

    // Register listeners
    element.addEventListener('wa-clear', onClear);
    element.addEventListener('change', onChange);
    element.addEventListener('focus', onFocus);
    element.addEventListener('blur', onBlur);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-clear', onClear);
            element.removeEventListener('change', onChange);
            element.removeEventListener('focus', onFocus);
            element.removeEventListener('blur', onBlur);
        }
    };
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

export function pickerGoToDate(elementId, date) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.goToDate(date);
}

export function pickerGoToToday(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.goToToday();
}

export function datetimeInputShowPicker(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.show();
}

export function datetimeInputHidePicker(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.hide();
}