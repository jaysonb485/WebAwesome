export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onVideoChanged = (event) => {
        const eventArgs = {
            previousIndex: event.detail.previousIndex,
            currentIndex: event.detail.currentIndex,
            video: event.detail.video
        };
        dotnetHelper.invokeMethodAsync('HandleVideoChanged', eventArgs);
    };

    // Register listener
    element.addEventListener('wa-video-change', onVideoChanged);

    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('wa-video-change', onVideoChanged);
        }
    };
}

export function goToVideo(elementId, videoIndex) {
    const element = document.getElementById(elementId);
    if (element) element.goTo(videoIndex);
}

export function nextVideo(elementId) {
    const element = document.getElementById(elementId);
    if (element) element.next();
}

export function previousVideo(elementId) {
    const element = document.getElementById(elementId);
    if (element) element.previous();
}