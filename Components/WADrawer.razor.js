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
    const element = document.getElementById(elementId);
    if (element != null)
        element.open = newState;
}