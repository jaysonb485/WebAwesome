export function render (elementId, categoryLabels, data, options = null) {
    let element = document.getElementById(elementId);
    if (!element) return;

    element.config = {
        data: {
            labels: categoryLabels,
            datasets: data,
        }
    };
    if (options != null) {
        element.config.options = options
    };
}