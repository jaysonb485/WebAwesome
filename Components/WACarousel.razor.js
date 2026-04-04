export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.addEventListener('wa-slide-change', function (event) {
        dotnetHelper.invokeMethodAsync('HandleSlideChange', event.detail.index);
    });
}
export function goToSlide(elementId, slideIndex) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.goToSlide({ index: slideIndex });
}

export function nextSlide(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.next();
}
export function previousSlide(elementId) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.previous();
}