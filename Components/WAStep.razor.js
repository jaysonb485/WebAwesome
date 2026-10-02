export function collapse(elementId) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.collapse();
}

export function expand(elementId) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.expand();
}

export function toggle(elementId) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.toggle();
}

export function focus(elementId, focusOptions) {
    const element = document.getElementById(elementId);
    if (!element) return;
    element.focus(focusOptions);
}