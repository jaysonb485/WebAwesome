export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onAfterHide = (event) => {
        if (event.target.id === elementId) {
            dotnetHelper.invokeMethodAsync('HandleDialogClosed', event.target.id);
        }
    };

    // Register listener
    element.addEventListener('wa-after-hide', onAfterHide);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-after-hide', onAfterHide);
        }
    };
}


export function change(elementId, newState) {
    let dialog = document.getElementById(elementId);
    if (dialog != null)
        dialog.open = newState;
}