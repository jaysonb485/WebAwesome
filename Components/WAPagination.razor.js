export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onPageChanged = (event) => {
        dotnetHelper.invokeMethodAsync('HandlePageChanged', event.detail.pageSize, event.detail.page);
    };

    // Register listener
    element.addEventListener('wa-page-change', onPageChanged);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-page-change', onPageChanged);
        }
    };
}

