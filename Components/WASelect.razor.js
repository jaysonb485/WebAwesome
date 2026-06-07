export function initialize(elementId, dotnetHelper, setValue) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Only set the value if explicitly provided
    if (setValue !== undefined && setValue !== null) {
        element.value = setValue;
    }

    // Capture handler so it can be removed later
    const onClear = () => {
        dotnetHelper.invokeMethodAsync('HandleInputClear');
    };

    const onBlur = () => {
        dotnetHelper.invokeMethodAsync('HandleInputBlur');
    };

    // Register listener
    element.addEventListener('wa-clear', onClear);
    element.addEventListener('blur', onBlur);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-clear', onClear);
            element.removeEventListener('blur', onBlur);
        }
    };
}


export function setValue(elementId, value) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.value = value;
}

export function setFocus(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.focus();
}
