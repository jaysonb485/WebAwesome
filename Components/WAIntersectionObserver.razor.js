export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.addEventListener('wa-intersect', function (event) {
        const entry = event.detail.entry;
        if (entry.isIntersecting) {
            dotnetHelper.invokeMethodAsync('HandleIntersecting');
        } else {
            dotnetHelper.invokeMethodAsync('HandleLeaving');
        }
    });
}