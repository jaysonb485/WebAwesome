export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onContentChanged = (event) => {
        const visibleIds = event?.detail?.items?.map(item => String(item.id)) || [];
        dotnetHelper.invokeMethodAsync('HandleContentChanged', visibleIds);
    };

    // Register listener
    element.addEventListener('wa-content-change', onContentChanged);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-content-change', onContentChanged);
        }
    };
}

export function randomize(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        var result = element.randomize();
        return result?.detail?.items?.map(item => String(item.id)) || [];;
    }   
}

