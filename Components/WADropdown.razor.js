
export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.addEventListener('wa-select', function (event) {
        if (event.target.id == elementId) {
            dotnetHelper.invokeMethodAsync('HandleItemSelected', event.detail.item.value);
        };
    });
}