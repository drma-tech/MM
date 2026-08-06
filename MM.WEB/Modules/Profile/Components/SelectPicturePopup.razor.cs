using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.WEB.Modules.Profile.Components
{
    public partial class SelectPicturePopup
    {
        [CascadingParameter] private IMudDialogInstance? MudDialog { get; set; }

        [Parameter] public PhotoType PhotoType { get; set; }
        [Parameter] public EventCallback<(PhotoType, byte[])> CroppedPictureChanged { get; set; }

        // const long maxAllowedSize = 2 * 1024 * 1024; // 2 MB
        private bool imageLoaded;

        private async Task<byte[]> GetBuffer(IBrowserFile file)
        {
            var buffer = new byte[file.Size];
            _ = await file.OpenReadStream(file.Size, Cts.Token).ReadAsync(buffer, Cts.Token);
            return buffer;
        }

        public class ImageDimensions
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }

        private async Task OnFileSelected(IBrowserFile? file)
        {
            try
            {
                if (file == null) return;

                var buffer = await GetBuffer(file);
                var base64 = Convert.ToBase64String(buffer);
                var imageUrl = $"data:{file.ContentType};base64,{base64}";

                var dimensions = await JsRuntime.Cropper().GetImageSize(imageUrl, Cts.Token);

                if (dimensions?.Width < 300 || dimensions?.Height < 300)
                {
                    await ShowWarning("The image must be at least 300x300 pixels.");
                    return;
                }

                imageLoaded = true;
                StateHasChanged();

                await JsRuntime.Window().InvokeVoidAsync("eval", $"document.getElementById('cropImage').src = '{imageUrl}'");
                await JsRuntime.Cropper().InitCropper("cropImage", 1, Cts.Token);
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }

        private async Task SavePictureHandle()
        {
            var dataUrl = await JsRuntime.Cropper().GetCroppedImage(512, 512, Cts.Token);

            var base64 = dataUrl.Split(',')[1];
            var buffer = Convert.FromBase64String(base64);
            await CroppedPictureChanged.InvokeAsync((PhotoType, buffer));

            MudDialog?.Close();
        }
    }
}
