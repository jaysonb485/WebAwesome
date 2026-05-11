
export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;

    const onChange = (event) => {
        dotentHelper.invokeMethodAsync('HandleDividerChange', element.position);
    };

    element.addEventListener('change', onChange);

    return {
        dispose: () => {
            element.removeEventListener('change', onChange);
        }
    };
}