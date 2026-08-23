using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile
{
    public partial class ProfileSettingPage
    {
        private SettingModel? Setting { get; set; }
        private RenderControlState<SettingModel?> State { get; set; } = new(null, obj => obj == null);

        protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
        {
            await State.StartLoading.Invoke(null);

            Setting = await SettingApi.Get(states: [], token);

            Setting ??= new SettingModel(AppStateStatic.UserId);

            await State.FinishLoading.Invoke(Setting);
        }

        private async Task SaveHandle()
        {
            try
            {
                if (Setting == null) throw new InvalidOperationException("Setting is null");

                await State.StartProcessing.Invoke(null);

                Setting = await SettingApi.Update(Setting, Cts.Token);

                if (Setting!.BlindDate)
                {
                    var profile = await ProfileApi.Get(states: [], Cts.Token);

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
                    var profile = await ProfileApi.Get(states: [], Cts.Token);

                    if (profile?.Gallery?.Type == GalleryType.BlindDate)
                    {
                        profile.Gallery.Type = GalleryType.NoPictures;
                        await ProfileApi.Update(profile, Cts.Token);
                    }
                }

                await State.FinishProcessing.Invoke(Setting);

                Navigation.NavigateTo($"/{Culture}/profile");
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }
    }
}