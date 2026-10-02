export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    let isInternalChange = false;

    // Capture handler so it can be removed later
    const onStepChanging = async (event) => {
        if (isInternalChange) return;

        event.preventDefault();

        const targetStep = event.detail.name;

        var eventArgs = {
            "step": event.detail.name,
            "previousStep": event.detail.previousName,
            "cancel": false
        }

        var result = await dotnetHelper.invokeMethodAsync('HandleStepChanging', eventArgs);
        
        if (!result.cancel) {
            isInternalChange = true;

            element.goTo(targetStep);

            setTimeout(() => { isInternalChange = false; }, 0);
        }
            
    };

    const onStepChanged = (event) => {
        var eventArgs = {
            "step": event.detail.name,
            "previousStep": event.detail.previousName
        }

        dotnetHelper.invokeMethodAsync('HandleStepChanged', eventArgs);
    }

    // Register listener
    element.addEventListener('wa-before-step-change', onStepChanging);
    element.addEventListener('wa-step-change', onStepChanged);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-before-step-change', onStepChanging);
            element.removeEventListener('wa-step-change', onStepChanged)
        }
    };
}

export function goTo(element, step) {
    element.goTo(step);
}

export function next(element) {
    element.next();
}

export function previous(element) {
    element.previous();
}