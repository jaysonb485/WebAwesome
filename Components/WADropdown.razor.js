export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onSelect = (event) => {
        if (event.target.id === elementId) {
            dotnetHelper.invokeMethodAsync(
                'HandleItemSelected',
                event.detail.item.value
            );
        }
    };

    // Register listener
    element.addEventListener('wa-select', onSelect);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-select', onSelect);
        }
    };
}
