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

    // const onTagCreating = (event) => {
    //     event.detail.promise = dotnetHelper.invokeMethodAsync('HandleTagCreating', event.detail.inputValue)
    //         .then(result => {
    //             if (result) {
    //                 console.log('preventing');
    //                 event.preventDefault();
    //             }
    //         });
    // };

    // Register listeners
    element.addEventListener('wa-clear', onClear);
    element.addEventListener('change', onChange);
    element.addEventListener('focus', onFocus);
    element.addEventListener('blur', onBlur);
    //element.addEventListener('wa-create', onTagCreating);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-clear', onClear);
            element.removeEventListener('change', onChange);
            element.removeEventListener('focus', onFocus);
            element.removeEventListener('blur', onBlur);
            //element.removeEventListener('wa-create', onTagCreating);
        }
    };
}


export function setFocus(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.focus();
}
