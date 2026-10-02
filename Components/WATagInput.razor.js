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

    let isInternalChange = false;

    // Capture handler so it can be removed later
    const onTagCreating = async (event) => {
        if (isInternalChange) return;

        event.preventDefault();

        const newTag = event.detail.inputValue;

        var result = await dotnetHelper.invokeMethodAsync('HandleTagCreating', event.detail.inputValue);

        if (!result.cancel) {
            isInternalChange = true;

            element.value = [...element.value, newTag];
            element.inputValue = '';

            setTimeout(() => { isInternalChange = false; }, 0);
        }

    };


    // Register listeners
    element.addEventListener('wa-clear', onClear);
    element.addEventListener('change', onChange);
    element.addEventListener('focus', onFocus);
    element.addEventListener('blur', onBlur);
    element.addEventListener('wa-create', onTagCreating);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-clear', onClear);
            element.removeEventListener('change', onChange);
            element.removeEventListener('focus', onFocus);
            element.removeEventListener('blur', onBlur);
            element.removeEventListener('wa-create', onTagCreating);
        }
    };
}


export function setFocus(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.focus();
}
