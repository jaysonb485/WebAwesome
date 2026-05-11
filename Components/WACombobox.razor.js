export function initialize(elementId, dotnetHelper, setValue) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    if (setValue !== undefined && setValue !== null) {
        element.value = setValue;
    }

    // Capture handlers so they can be removed later
    const onClear = () => {
        dotnetHelper.invokeMethodAsync('HandleInputClear');
    };

    const onCreate = (event) => {
        event.preventDefault();
        dotnetHelper.invokeMethodAsync('HandleOptionCreate', event.detail.inputValue);
    };

    // Register listeners
    element.addEventListener('wa-clear', onClear);
    element.addEventListener('wa-create', onCreate);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-clear', onClear);
            element.removeEventListener('wa-create', onCreate);
        }
    };
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