// WAAnimatedImage.razor.js (ES module)

export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Store handlers so we can remove them later
    const onError = () => dotnetHelper.invokeMethodAsync('HandleLoadError');
    const onLoad = () => dotnetHelper.invokeMethodAsync('HandleImageLoaded');

    element.addEventListener('wa-error', onError);
    element.addEventListener('wa-load', onLoad);

    // Return a cleanup function to be called by .NET
    return {
        dispose: () => {
            element.removeEventListener('wa-error', onError);
            element.removeEventListener('wa-load', onLoad);
        }
    };
}