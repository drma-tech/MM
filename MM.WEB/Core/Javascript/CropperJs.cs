using Microsoft.JSInterop;

namespace MM.WEB.Core.Javascript
{
    public class CropperJs(IJSRuntime js) : JsModuleBase(js, "./js/crop-helper.js")
    {
        public Task InitCropper(string imageId, int aspectRatio, CancellationToken cancellationToken) => InvokeVoid("crop.initCropper", cancellationToken, imageId, aspectRatio);

        public Task<string> GetCroppedImage(int width, int height, CancellationToken cancellationToken) => Invoke<string>("crop.getCroppedImage", cancellationToken, width, height);

        public Task<Modules.Profile.Components.SelectPicturePopup.ImageDimensions> GetImageSize(string imageUrl, CancellationToken cancellationToken) => Invoke<Modules.Profile.Components.SelectPicturePopup.ImageDimensions>("crop.getImageSize", cancellationToken, imageUrl);
    }
}