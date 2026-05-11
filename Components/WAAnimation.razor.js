// WAAnimation.razor.js (ES module)

export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handlers so they can be removed later
    const onCancel = () => dotnetHelper.invokeMethodAsync('HandleAnimationCancel');
    const onFinish = () => dotnetHelper.invokeMethodAsync('HandleAnimationFinish');
    const onStart = () => dotnetHelper.invokeMethodAsync('HandleAnimationStart');

    // Register listeners
    element.addEventListener('wa-cancel', onCancel);
    element.addEventListener('wa-finish', onFinish);
    element.addEventListener('wa-start', onStart);

    // Return a cleanup object
    return {
        dispose: () => {
            console.log("disposing waanimation");
            element.removeEventListener('wa-cancel', onCancel);
            element.removeEventListener('wa-finish', onFinish);
            element.removeEventListener('wa-start', onStart);
        }
    };
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
