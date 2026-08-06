using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Profile;
using MM.Shared.Requests;
using MudBlazor;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.WEB.Modules.Profile
{
    public partial class ProfileGallery
    {
        private ProfileModel? _profile = new(AppStateStatic.UserId);
        public RenderControlState<ProfileModel> ProfileActions { get; set; } = new(obj => obj == null);

        private MudDialog? MudDialog { get; set; }

        protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
        {
            _profile = await ProfileApi.Get(ProfileActions, token);
        }

        private async Task SelectPicture(PhotoType photoType)
        {
            await DialogService.SelectPicturePopup(photoType,
                new EventCallbackFactory().Create(this, async ((PhotoType, byte[]) result) => await CroppedPictureChanged(result.Item1, result.Item2)));
        }

        private async Task DeletePhotoGallery(PhotoType type)
        {
            try
            {
                _profile = await StorageApi.DeletePhotoGallery(type, Cts.Token);
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }

        private async Task CroppedPictureChanged(PhotoType type, byte[] buffer)
        {
            try
            {
                var request = new PhotoRequest { PhotoType = type, Buffer = buffer };

                _profile = await StorageApi.UploadPhoto(request, Cts.Token);

                StateHasChanged();
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }
    }
}
