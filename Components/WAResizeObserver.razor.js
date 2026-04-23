export function initialize (elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.addEventListener('wa-resize', function (event) {
        dotnetHelper.invokeMethodAsync('HandleResize', event.detail.entries[0].contentRect.height, event.detail.entries[0].contentRect.width);
    });
}
