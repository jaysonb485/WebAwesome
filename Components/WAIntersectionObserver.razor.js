export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onIntersect = (event) => {
        const entry = event.detail.entry;

        if (entry.isIntersecting) {
            dotnetHelper.invokeMethodAsync('HandleIntersecting');
        } else {
            dotnetHelper.invokeMethodAsync('HandleLeaving');
        }
    };

    // Register listener
    element.addEventListener('wa-intersect', onIntersect);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-intersect', onIntersect);
        }
    };
}
