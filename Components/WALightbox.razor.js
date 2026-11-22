var showHandled = false;
var hideHandled = false;

export async function initialize(element, dotnetHelper) {

    if (!element) return null;

    // Capture the handler so we can remove it later
    const onShowing = async (event) => {
        if (showHandled) {
            showHandled = false;
            return;
        }
        event.preventDefault();
        var showcancel = await dotnetHelper.invokeMethodAsync('HandleLightboxShow');

        if (!showcancel) {
            showHandled = true;
            element.open = true;
        }
    };

    const onItemChange = (event) => {
        console.log('itemChange', event);
        dotnetHelper.invokeMethodAsync('HandleItemChange', event.detail.index, event.detail.previousIndex)
    };

    const onHiding = async (event) => {
        if (hideHandled) {
            hideHandled = false;
            return;
        }
        event.preventDefault();

        var hidecancel = await dotnetHelper.invokeMethodAsync('HandleLightboxHide');

        if (!hidecancel) {
            hideHandled = true;
            element.open = false;
        }
    };

    const onHide = () => {
        dotnetHelper.invokeMethodAsync('HandleLightboxHidden');
    }

    const onShow = () => {
        dotnetHelper.invokeMethodAsync('HandleLightboxShown');
    }

    // Register the event listener
    element.addEventListener('wa-show', onShowing);
    element.addEventListener('wa-hide', onHiding);
    element.addEventListener('wa-item-change', onItemChange);
    element.addEventListener('wa-after-hide', onHide);
    element.addEventListener('wa-after-show', onShow);

    // Return a cleanup object for Blazor to call
    return {
        dispose: () => {
            element.removeEventListener('wa-show', onShowing);
            element.removeEventListener('wa-hide', onHiding);
            element.removeEventListener('wa-item-change', onItemChange);
            element.removeEventListener('wa-after-hide', onHide);
            element.removeEventListener('wa-after-show', onShow);
        }
    };
}


