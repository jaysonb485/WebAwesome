export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.addEventListener('wa-copy', function (event) {
        dotnetHelper.invokeMethodAsync('HandleCopy');
    });
    element.addEventListener('wa-error', function (event) {
        dotnetHelper.invokeMethodAsync('HandleCopyError');
    });
}