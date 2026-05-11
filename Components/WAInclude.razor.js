export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handlers so they can be removed later
    const onLoad = () => {
        dotnetHelper.invokeMethodAsync('HandleIncludeLoaded');
    };

    const onError = (event) => {
        console.log('error ' + event.detail.status);
        dotnetHelper.invokeMethodAsync('HandleIncludeError', event.detail.status);
    };

    // Register listeners
    element.addEventListener('wa-load', onLoad);
    element.addEventListener('wa-include-error', onError);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-load', onLoad);
            element.removeEventListener('wa-include-error', onError);
        }
    };
}
