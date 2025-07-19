let cropper;

window.initCropper = (imageId, aspectRatio) => {
    const image = document.getElementById(imageId);
    if (!image) return;

    if (cropper) cropper.destroy();

    cropper = new Cropper(image, {
        aspectRatio: aspectRatio,
        viewMode: 1,
        autoCropArea: 1,
        minCropBoxWidth: 300,
        minCropBoxHeight: 300,
        responsive: true,
        background: false,
        ready() {
            const data = cropper.getImageData();

            if (data.naturalWidth < 300 || data.naturalHeight < 300) {
                alert("A imagem deve ter pelo menos 300x300 pixels.");
                cropper.destroy(); // remove cropper
            }

            const containerData = cropper.getContainerData();
            const cropBoxData = {
                width: 300,
                height: 300,
                left: (containerData.width - 300) / 2,
                top: (containerData.height - 300) / 2
            };
            cropper.setCropBoxData(cropBoxData);
        }
    });
};

window.getCroppedImage = (width, height) => {
    return cropper.getCroppedCanvas({
        width,
        height
    }).toDataURL("image/jpeg");
};

window.getImageSize = (imageUrl) => {
    return new Promise((resolve, reject) => {
        const img = new Image();
        img.onload = () => {
            resolve({
                width: img.naturalWidth,
                height: img.naturalHeight
            });
        };
        img.onerror = reject;
        img.src = imageUrl;
    });
};