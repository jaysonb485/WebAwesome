export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (element) {
        element.addEventListener('wa-remove', function (event) {
            dotnetHelper.invokeMethodAsync('HandleTagRemove');
        });
    }
}
export function removeTag(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (element) {
        element.style.opacity = '0';
        setTimeout(() => (element.style.display = 'none'), 1000);
        dotnetHelper.invokeMethodAsync('HandleTagRemoved');
    }
}