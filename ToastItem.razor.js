export function initItem(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.addEventListener('wa-hide', function (event) {
        event.preventDefault();
        dotnetHelper.invokeMethodAsync('HideToast', elementId);
    });
}