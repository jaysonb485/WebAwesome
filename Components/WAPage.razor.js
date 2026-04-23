export function initialize(elementId, dotnetHelper, resizeObserverId) {
    const resizeelement = document.getElementById(resizeObserverId);
    if (!resizeelement) return;
    resizeelement.addEventListener('wa-resize', function (event) {
        let pageelement = document.getElementById(elementId);
        if (pageelement) {
            dotnetHelper.invokeMethodAsync('HandleResize', pageelement.view);
        }
    });
}

export function shownav(elementId) {
    const element = document.getElementById(elementId);
    if (element)
        element.showNavigation();
}

export function hidenav(elementId) {
    const element = document.getElementById(elementId);
    if (element)
        element.hideNavigation();
}

export function togglenav(elementId) {
    const element = document.getElementById(elementId);
    if (element)
        element.toggleNavigation();
}

export function view(elementId) {
    let element = document.getElementById(elementId);
    if (element)
        return element.view;
}

