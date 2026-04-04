// WAAnimation.razor.js (ES module)

export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.addEventListener('wa-cancel', () => {
        dotnetHelper.invokeMethodAsync('HandleAnimationCancel');
    });

    element.addEventListener('wa-finish', () => {
        dotnetHelper.invokeMethodAsync('HandleAnimationFinish');
    });

    element.addEventListener('wa-start', () => {
        dotnetHelper.invokeMethodAsync('HandleAnimationStart');
    });
}

export function cancel(elementId) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.cancel();
}

export function finish(elementId) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.finish();
}
