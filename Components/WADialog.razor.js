export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.addEventListener('wa-after-hide', function (event) {
        if (event.target.id == elementId) {
            dotnetHelper.invokeMethodAsync('HandleDialogClosed', event.target.id);
        };
    });
}

export function change(elementId, newState) {
    let dialog = document.getElementById(elementId);
    if (dialog != null)
        dialog.open = newState;
}