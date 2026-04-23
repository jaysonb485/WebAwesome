export function create(elementId, toastMessage, toastOptions) {
    const element = document.getElementById(elementId);
    if (!element) return;

    console.log(toastOptions);
    element.create(toastMessage, toastOptions);
}
export function prepend(elementId, toastItemId) {

    const element = document.getElementById(elementId);
    if (!element) return;

    const toastItem = document.getElementById(toastItemId);
    if (!toastItem) return;

    element.prepend(toastItem);
}
