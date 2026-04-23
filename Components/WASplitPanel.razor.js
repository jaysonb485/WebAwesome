export function initialize (elementId, dotnetHelper) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.addEventListener('wa-reposition', function (event) {
        dotnetHelper.invokeMethodAsync('HandleDividerChange', element.position);
    });
}