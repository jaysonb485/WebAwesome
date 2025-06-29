// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

//export function showPrompt(message) {
//  return prompt(message, 'Type anything here');
//}

//export function executeDotNetMethod(objRef, methodName) {
//    return objRef.invokeMethodAsync(methodName);
//}

window.changeModal = (objRef, newState) => {
    var modal = document.getElementById(objRef);
    modal.open = newState;
}

function interceptChangeEvent(elementId, dotNetObject) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.onchange = function (event) {
        dotNetObject.invokeMethodAsync('OnValueChanged', element.value);
    };
}

function addTagRemovedListener(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (element) {
        element.addEventListener('wa-remove', function (event) {
            dotnetHelper.invokeMethodAsync('HandleRemove', event.type, event);
        });
    }
}

window.updateComponentValue = (elementId, newValue) => {
    const element = document.getElementById(elementId);
    if (element)
        element.value = newValue;
}

window.toggleDarkMode = (darkMode) => {
    document.documentElement.classList.toggle('wa-dark', darkMode);
}

window.showNavigation = (elementId) => {
    const element = document.getElementById(elementId);
    if (element)
        element.showNavigation();
}

window.hideNavigation = (elementId) => {
    const element = document.getElementById(elementId);
    if (element)
        element.hideNavigation();
}

window.toggleNavigation = (elementId) => {
    const element = document.getElementById(elementId);
    if (element)
        element.toggleNavigation();
}

