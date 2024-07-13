﻿"use strict";

function getWindowDimensions() {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};

function share(url) {
    if (!("share" in navigator)) {
        alert('Web Share API not supported.');
        return;
    }

    navigator.share({ url: url })
        .then(() => console.log('Successful share'))
        .catch(error => console.log('Error sharing:', error));
}

function GetLocalStorage(key) {
    return window.localStorage.getItem(key);
}

function SetLocalStorage(key, value) {
    return window.localStorage.setItem(key, value);
}

function TryDetectPlatform() {
    if (GetLocalStorage('platform')) return; //if populate before, cancel, cause detection (windows) only works for first call

    let isWindows = document.referrer == "app-info://platform/microsoft-store";
    let isAndroid = /(android)/i.test(navigator.userAgent);

    if (isWindows)
        SetLocalStorage('platform', 'windows');
    else if (isAndroid)
        SetLocalStorage('platform', 'play');
    else
        SetLocalStorage('platform', 'webapp');
}