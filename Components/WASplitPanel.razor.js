export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onReposition = () => {
        dotnetHelper.invokeMethodAsync('HandleDividerChange', element.position);
    };

    // Register listener
    element.addEventListener('wa-reposition', onReposition);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-reposition', onReposition);
        }
    };
}
