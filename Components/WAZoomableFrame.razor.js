export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handlers so they can be removed later
    const onLoad = () => {
        dotnetHelper.invokeMethodAsync('HandleZoomableLoaded');
    };

    const onError = (event) => {
        console.log('error', event.detail);
        dotnetHelper.invokeMethodAsync('HandleZoomableError', event.detail?.status);
    };

    // Register listeners
    element.addEventListener('load', onLoad);
    element.addEventListener('error', onError);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('load', onLoad);
            element.removeEventListener('error', onError);
        }
    };
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