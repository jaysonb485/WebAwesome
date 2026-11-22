// JavaScript for WACounter component
// JavaScript for WACodeHighlighter component
export function initialize(element, dotnetHelper) {
    if (!element) return null;


    // Capture handler so it can be removed later
    const onFinished = () => {
        dotnetHelper.invokeMethodAsync('HandleCounterFinished');
    };

  
    // Register listener
    element.addEventListener('wa-finish', onFinished);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-finish', onFinished);
        }
    };
}