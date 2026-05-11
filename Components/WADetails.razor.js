export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handlers so they can be removed later
    const onShow = () => {
        dotnetHelper.invokeMethodAsync('HandleDetailsShow');
    };

    const onHide = () => {
        dotnetHelper.invokeMethodAsync('HandleDetailsHide');
    };

    // Register listeners
    element.addEventListener('wa-show', onShow);
    element.addEventListener('wa-hide', onHide);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-show', onShow);
            element.removeEventListener('wa-hide', onHide);
        }
    };
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