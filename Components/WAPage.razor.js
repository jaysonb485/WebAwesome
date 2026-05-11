export function initialize(elementId, dotnetHelper, resizeObserverId) {
    const resizeElement = document.getElementById(resizeObserverId);
    if (!resizeElement) return null;

    // Capture handler so it can be removed later
    const onResize = (event) => {
        const pageElement = document.getElementById(elementId);
        if (pageElement) {
            dotnetHelper.invokeMethodAsync('HandleResize', pageElement.view);
        }
    };

    // Register listener
    resizeElement.addEventListener('wa-resize', onResize);

    // Return cleanup object
    return {
        dispose: () => {
            resizeElement.removeEventListener('wa-resize', onResize);
        }
    };
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

