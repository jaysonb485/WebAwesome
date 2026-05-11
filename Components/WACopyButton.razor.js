export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handlers so they can be removed later
    const onCopy = () => {
        dotnetHelper.invokeMethodAsync('HandleCopy');
    };

    const onError = () => {
        dotnetHelper.invokeMethodAsync('HandleCopyError');
    };

    // Register listeners
    element.addEventListener('wa-copy', onCopy);
    element.addEventListener('wa-error', onError);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-copy', onCopy);
            element.removeEventListener('wa-error', onError);
        }
    };
}
