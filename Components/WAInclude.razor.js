
export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.addEventListener('wa-load', function (event) {
        dotnetHelper.invokeMethodAsync('HandleIncludeLoaded');
    });

    element.addEventListener('wa-include-error', function (event) {
        console.log('error' + event.detail.status);
        dotnetHelper.invokeMethodAsync('HandleIncludeError', event.detail.status);
    });
}