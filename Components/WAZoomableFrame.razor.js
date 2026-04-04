export function initialize(elementId, dotnetHelper) {
    let element = document.getElementById(elementId);
    if (!element) return;

    element.addEventListener('load', function (event) {
        dotnetHelper.invokeMethodAsync('HandleZoomableLoaded');
    });

    element.addEventListener('error', function (event) {
        console.log('error' + event.detail);
        dotnetHelper.invokeMethodAsync('HandleZoomableError', event.detail.status);
    });
}
export function zoomIn(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.zoomIn();
}
export function zoomOut(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.zoomOut();
}