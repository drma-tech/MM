window.getReference = function (element) {
    return element;
};

window.setAttribute = function (element, name, value) {
    element[name] = value;
};

window.captureFrame = async function (videoElement) {
    const video = videoElement;
    const canvas = document.createElement("canvas");
    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;

    const ctx = canvas.getContext("2d");
    ctx.drawImage(video, 0, 0, canvas.width, canvas.height);

    return canvas.toDataURL("image/png");
};
