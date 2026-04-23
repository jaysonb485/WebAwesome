export function initialize (elementId, dotnetHelper) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.addEventListener('wa-tab-show', function (event) {
        dotnetHelper.invokeMethodAsync('HandleTabShowing', event.detail.name);
    });
}
