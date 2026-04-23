export function getFormattedValue(elementId, colorFormat) {
    const element = document.getElementById(elementId);
    if (!element) return;
    return element.getFormattedValue(colorFormat);
}

export function setSwatches(elementId, swatches) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.swatches = swatches;
}