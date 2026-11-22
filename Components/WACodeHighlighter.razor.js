// JavaScript for WACodeHighlighter component
export function initialize(element, dotnetHelper) {
    if (!element) return null;


    // Capture handler so it can be removed later
    const onGrammarError = () => {
        dotnetHelper.invokeMethodAsync('HandleGrammarError');
    };

    const onLoad = () => {
        dotnetHelper.invokeMethodAsync('HandleLoaded');
    };

    // Register listener
    element.addEventListener('wa-error', onGrammarError);
    element.addEventListener('wa-load', onLoad);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-error', onGrammarError);
            element.removeEventListener('wa-load', onLoad);
        }
    };
}