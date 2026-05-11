export function setValue(elementId, newValue) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.value = newValue;
}

export function initialize(elementId, dotnetHelper, setValue) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    console.log('init input ' + elementId + ' with value: ' + setValue);

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

    // Register listeners
    element.addEventListener('wa-clear', onClear);
    element.addEventListener('change', onChange);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-clear', onClear);
            element.removeEventListener('change', onChange);
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