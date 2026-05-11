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

    // Register listener
    element.addEventListener('wa-clear', onClear);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-clear', onClear);
        }
    };
}


export function setValue(elementId, value) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.value = value;
}
