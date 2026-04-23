
export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.addEventListener('change', function (event) {
        dotnetHelper.invokeMethodAsync('HandleDividerChange', element.position);
    });
}