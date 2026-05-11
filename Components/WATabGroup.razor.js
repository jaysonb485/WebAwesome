export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onTabShow = (event) => {
        dotnetHelper.invokeMethodAsync('HandleTabShowing', event.detail.name);
    };

    // Register listener
    element.addEventListener('wa-tab-show', onTabShow);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-tab-show', onTabShow);
        }
    };
}
