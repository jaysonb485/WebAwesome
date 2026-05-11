export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onRemove = () => {
        dotnetHelper.invokeMethodAsync('HandleTagRemove');
    };

    // Register listener
    element.addEventListener('wa-remove', onRemove);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-remove', onRemove);
        }
    };
}

export function removeTag(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (element) {
        element.style.opacity = '0';
        setTimeout(() => (element.style.display = 'none'), 1000);
        dotnetHelper.invokeMethodAsync('HandleTagRemoved');
    }
}