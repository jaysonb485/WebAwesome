export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onSelectionChange = (event) => {
        const selection = event.detail.selection.map(obj =>
            obj.attributes.getNamedItem('value').value
        );

        dotnetHelper.invokeMethodAsync('HandleSelectionChanged', selection);
    };

    // Register listener
    element.addEventListener('wa-selection-change', onSelectionChange);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-selection-change', onSelectionChange);
        }
    };
}
