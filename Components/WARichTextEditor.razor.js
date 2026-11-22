export async function setValue(elementId, newValue) {
    let element = document.getElementById(elementId);
    if (!element) return;

    console.log('setting new value', newValue);
    element.value = newValue;

    await customElements.whenDefined('wa-rich-text-editor');
    await element.updateComplete;
    console.log(element.textValue);
    return element.textValue;
}

export function initialize(elementId, dotnetHelper, setValue) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    
    // Only set the value if explicitly provided
    if (setValue !== undefined && setValue !== null) {
        element.value = setValue;
    }

    // Capture handlers so they can be removed later

    const onChange = () => {
        dotnetHelper.invokeMethodAsync('HandleInputChange', element.value, element.textValue);
    };

    const onFocus = () => {
        dotnetHelper.invokeMethodAsync('HandleInputFocus');
    };

    const onBlur = () => {
        dotnetHelper.invokeMethodAsync('HandleInputBlur');
    };

    const onInput = () => {
        dotnetHelper.invokeMethodAsync('HandleInputInput', element.value, element.textValue);
    };

    const onSuggestionError = (event) => {
        
        var errorDetails = {
            errorMessage: event.detail.error.message,
            query: event.detail.request.query,
            trigger: event.detail.request.trigger
        }
        dotnetHelper.invokeMethodAsync('HandleSuggestionError', errorDetails);
    };

    const onSelectionChanged = () => {
        dotnetHelper.invokeMethodAsync('HandleSelectionChange')
    };

    // Register listeners
    element.addEventListener('change', onChange);
    element.addEventListener('focus', onFocus);
    element.addEventListener('blur', onBlur);
    element.addEventListener('input', onInput);
    element.addEventListener('wa-suggestions-error', onSuggestionError);
    element.addEventListener('selectionchange', onSelectionChanged);
    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('change', onChange);
            element.removeEventListener('focus', onFocus);
            element.removeEventListener('blur', onBlur);
            element.removeEventListener('input', onInput);
            element.removeEventListener('wa-suggestions-error', onSuggestionError);
            element.removeEventListener('selectionchange', onSelectionChanged);
        }
    };
}


export function setFocus(element) {
    if (!element) return;
    element.focus();
}

export async function addSuggestion(element, dotnetHelper, suggestion) {
    if (!element) return;

    element.suggestions ??= [];

    element.suggestions.push({
        trigger: suggestion.trigger,
        dataSource: ({ query }) =>
        dotnetHelper.invokeMethodAsync(
            'GetSuggestions',
            suggestion.trigger,
            query
        )
    });

}

export function insertText(element, text) {
    if (!element) return;
    element.insertText(text);
}

export function insertHtml(element, html) {
    if (!element) return;
    element.insertHtml(html);
}

export function undo(element) {
    if (!element) return;
    return element.undo();
}

export function redo(element) {
    if (!element) return;
    return element.redo();
}

export function selectAll(element) {
    if (!element) return;
    element.selectAll();
}

export function selectedText(element) {
    if (!element) return;
    return element.selectedText();
}

export function deleteSelection(element) {
    if (!element) return;
    element.deleteSelection();
}

export function canRedo(element) {
    if (!element) return;
    return element.canRedo;
}

export function canUndo(element) {
    if (!element) return;
    return element.canUndo;
}

export function updateColors(element, textColor, highlightColor) {
    element.textColors = textColor;
    element.highlightColors = highlightColor;
}




