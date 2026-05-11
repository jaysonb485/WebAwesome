export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onResize = (event) => {
        const entry = event.detail.entries[0];
        const rect = entry.contentRect;

        dotnetHelper.invokeMethodAsync(
            'HandleResize',
            rect.height,
            rect.width
        );
    };

    // Register listener
    element.addEventListener('wa-resize', onResize);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-resize', onResize);
        }
    };
}
