export function updateContent(elementId, markdown) {
    const element = document.getElementById(elementId);
    if (!element) return;

    const script = element.querySelector('script[type="text/markdown"]');
    script.textContent = markdown;
    element.renderMarkdown();
}
