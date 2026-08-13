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

    const onChange = () => {
        dotnetHelper.invokeMethodAsync('HandleInputChange', element.value);
    };

    const onComplete = () => {
        dotnetHelper.invokeMethodAsync('HandleOTPComplete', element.value);
    };
    // Register listeners
    element.addEventListener('change', onChange);
    element.addEventListener('wa-complete', onComplete);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('change', onChange);
            element.removeEventListener('wa-complete', onComplete);
        }
    };
}


export function setFocus(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.focus();
}
