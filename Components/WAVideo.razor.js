export function initialize(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    // Capture handler so it can be removed later
    const onEnded = () => {
        dotnetHelper.invokeMethodAsync('HandleVideoEnded');
    };

    const onError = (event) => {
        dotnetHelper.invokeMethodAsync('HandleVideoError', event.message || 'Unknown error');
    };

    const onLoadedMetadata = () => {
        dotnetHelper.invokeMethodAsync('HandleLoadedMetadata');
    };

    const onPause = () => {
        dotnetHelper.invokeMethodAsync('HandleVideoPaused');
    };

    const onPlay = () => {
        dotnetHelper.invokeMethodAsync('HandleVideoPlayed');
    };

    const onTimeUpdate = () => {
        console.log('Time updated:');
        console.log(element);
        dotnetHelper.invokeMethodAsync('HandleTimeUpdated', element.currentTime);
    };

    const onVolumeChange = () => {
        console.log('Volume changed:');
        console.log(element);
        dotnetHelper.invokeMethodAsync('HandleVolumeChanged', element.volume);
    };

    // Register listener
    element.addEventListener('ended', onEnded);
    element.addEventListener('error', onError);
    element.addEventListener('loadedmetadata', onLoadedMetadata);
    element.addEventListener('pause', onPause);
    element.addEventListener('play', onPlay);
    element.addEventListener('timeupdate', onTimeUpdate);
    element.addEventListener('volumechange', onVolumeChange);


    // Return cleanup object
    return {
        dispose: () => {
            element.removeEventListener('ended', onEnded);
            element.removeEventListener('error', onError);
            element.removeEventListener('loadedmetadata', onLoadedMetadata);
            element.removeEventListener('pause', onPause);
            element.removeEventListener('play', onPlay);
            element.removeEventListener('timeupdate', onTimeUpdate);
            element.removeEventListener('volumechange', onVolumeChange);
        }
    };
}

export function exitFullscreen(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.exitFullscreen();
    }
}

export function getPlaybackState(elementId) {
    const element = document.getElementById(elementId);
    if (!element) return null;

    return element.getState();  
}

export function pauseVideo(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.pause();
    }
}

export function playVideo(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.play();
    }
}

export function requestFullscreen(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.requestFullscreen();
    }
}

export function seekVideo(elementId, time) {
    const element = document.getElementById(elementId);
    if (element) {
        element.seek(time);
    }
}

export function setPlaybackRate(elementId, rate) {
    const element = document.getElementById(elementId);
    if (element) {
        element.setPlaybackRate(rate);
    }
}

export function setVolume(elementId, volume) {
    const element = document.getElementById(elementId);
    if (element) {
        element.setVolume(volume);
    }
}

export function toggleMute(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.toggleMute();
    }
}

export function togglePlay(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.togglePlay();
    }
}
