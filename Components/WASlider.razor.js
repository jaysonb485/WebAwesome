export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onChange = () => {
        dotnetHelper.invokeMethodAsync('OnValueChanged', element.value);
    };

    // Register listener
    element.addEventListener('change', onChange);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('change', onChange);
        }
    };
}

export function setValue(elementId, newValue) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.value = newValue;
}