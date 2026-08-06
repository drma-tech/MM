using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile
{
    public partial class ProfileSetting
    {
        private SettingModel? Setting { get; set; }
        private RenderControlState<SettingModel> Actions { get; set; } = new(obj => obj == null);

        protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
        {
            await Actions.StartLoading.Invoke(null);

            Setting = await SettingApi.Get(actions: null, token);

            Setting ??= new SettingModel(AppStateStatic.UserId);

            await Actions.FinishLoading.Invoke(Setting);
        }

        private async Task SaveHandle()
        {
            try
            {
                if (Setting == null) throw new InvalidOperationException("Setting is null");

                await Actions.StartProcessing.Invoke(null);

                Setting = await SettingApi.Update(Setting, Cts.Token);

                if (Setting!.BlindDate)
                {
                    var profile = await ProfileApi.Get(actions: null, Cts.Token);

                    if (profile != null && profile.Gallery != null)
                    {
                        if (profile.Gallery.FaceId != null) profile = await StorageApi.DeletePhotoGallery(ImageHelper.PhotoType.Face, Cts.Token);
                        if (profile!.Gallery!.BodyId != null) profile = await StorageApi.DeletePhotoGallery(ImageHelper.PhotoType.Body, Cts.Token);

                        if (profile!.Gallery!.Type != GalleryType.BlindDate)
                        {
                            profile.Gallery.Type = GalleryType.BlindDate;
                            await ProfileApi.Update(profile, Cts.Token);
                        }
                    }
                }
                else
                {
                    var profile = await ProfileApi.Get(actions: null, Cts.Token);

                    if (profile?.Gallery?.Type == GalleryType.BlindDate)
                    {
                        profile.Gallery.Type = GalleryType.NoPictures;
                        await ProfileApi.Update(profile, Cts.Token);
                    }
                }

                await Actions.FinishProcessing.Invoke(Setting);

                Navigation.NavigateTo($"/{Culture}/profile");
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }
    }
}
