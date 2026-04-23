export function initialize (elementId, dotnetHelper) {
    let element = document.getElementById(elementId);
    if (!element) return;
    element.addEventListener('wa-selection-change', function (event) {
        dotnetHelper.invokeMethodAsync('HandleSelectionChanged', event.detail.selection.map(obj => obj.attributes.getNamedItem('value').value));
    });

}