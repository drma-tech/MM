using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Profile;
using MM.WEB.Core.Models;
using MudBlazor;

namespace MM.WEB.Modules.Profile
{
    public partial class PopupProfilePopup
    {
        [CascadingParameter] private IMudDialogInstance? MudDialog { get; set; }

        [Parameter][EditorRequired] public string? UserId { get; set; }

        [Parameter] public Action? Liked { get; set; }
        [Parameter] public Action? Disliked { get; set; }
        [Parameter] public Action? Matched { get; set; }

        [Parameter] public MM.Shared.Enums.Origin Origin { get; set; }

        [Parameter] public string? IdUserView { get; set; }
        [Parameter] public bool Fake { get; set; }

        [Parameter] public bool OnlyCompatibility { get; set; } = false;

        private ProfileModel? user;
        private FilterModel? filter;
        [Parameter] public ProfileModel? View { get; set; }
        public RenderControlState<ProfileModel?> State { get; set; } = new(null, obj => obj == null);

        private IReadOnlyCollection<AffinityVM> affinities = [];
        private InteractionModel? interaction;
        public RenderControlState<InteractionModel?> EventState { get; set; } = new(null, obj => false);

        private string[] imageDataUriGallery = [];

        private ProfileReportPopup? report;

        protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
        {
            try
            {
                if (string.IsNullOrEmpty(IdUserView)) return;

                await State.StartLoading.Invoke(null);

                if (string.Equals(IdUserView, UserId, StringComparison.Ordinal))
                {
                    await State.ShowError.Invoke("Something wrong happened.");
                    return;
                }

                if (!Fake) interaction = await InteractionApi.GetInteraction(IdUserView, token);

                if (interaction?.Status == InteractionStatus.Blocked)
                {
                    await State.ShowError.Invoke(Translations.Module.Profile.ProfileNotAvailable);
                    return;
                }

                user = await ProfileApi.Get(states: [], token);
                View ??= await ProfileApi.GetView(IdUserView, states: [], token);

                await MudDialog!.SetTitleAsync(View?.NickName);

                if (View == null)
                {
                    await State.ShowError.Invoke(Translations.Module.Profile.PartnerProfileNotAvailable);
                    return;
                }

                if (Fake)
                    imageDataUriGallery = [View.GetPhoto(ImageHelper.PhotoType.Face, live: true, fake: true)];
                else
                    imageDataUriGallery = [View.GetPhoto(ImageHelper.PhotoType.Face, live: true), View.GetPhoto(ImageHelper.PhotoType.Body, live: true)];

                imageDataUriGallery = [.. imageDataUriGallery.Distinct(StringComparer.Ordinal).Where(x => x.NotEmpty())];

                filter = await FilterApi.Get(states: [], token);

                affinities = AffinityCore.GetAffinity(user, filter, View);

                await State.FinishLoading.Invoke(View);
            }
            catch (Exception ex)
            {
                await State.ShowError.Invoke(ex.Message);
            }
        }

        public static Color GetColor(int perc)
        {
            if (perc >= 80)
            {
                return Color.Success;
            }

            if (perc >= 60)
            {
                return Color.Warning;
            }

            return Color.Error;
        }

        private async Task Like()
        {
            try
            {
                await EventState.StartProcessing.Invoke(null);
                interaction = await InteractionApi.Like(Origin, IdUserView, Cts.Token);
                await EventState.FinishProcessing.Invoke(interaction);
                Liked?.Invoke();

                if (interaction?.Status == InteractionStatus.Match)
                {
                    await ShowSuccess("Match");
                    Matched?.Invoke();
                }
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }

        private async Task Dislike()
        {
            try
            {
                await EventState.StartProcessing.Invoke(null);
                interaction = await InteractionApi.Dislike(Origin, IdUserView, Cts.Token);
                await EventState.FinishProcessing.Invoke(interaction);
                Disliked?.Invoke();
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }

        private void GoChat()
        {
            //Navigation.NavigateTo($"/{Culture}/Explore/Chat/{IdUserView}");
        }

        private bool ButtonDisabled(EventType type)
        {
            if (type == EventType.Like)
            {
                var noLike = interaction?.GetMyEvents(UserId).Empty(a => a.Type == EventType.Like) ?? true;
                var validated = (user?.Validated ?? false);

                return !(noLike && validated);
            }

            if (type == EventType.Dislike)
            {
                var noDislike = interaction?.GetMyEvents(UserId).Empty(a => a.Type == EventType.Dislike) ?? true;

                return !noDislike;
            }
            // else if (type == EventType.Dating)
            // {
            //     var noDating = interaction?.GetMyEvents(UserId).Empty(a => a.Type == EventType.Dating) ?? true;

            //     return !(noDating);
            // }
            // else if (type == EventType.Relationship)
            // {
            //     var noRelationship = interaction?.GetMyEvents(UserId).Empty(a => a.Type == EventType.Relationship) ?? true;

            //     return !(noRelationship);
            // }
            // else if (type == EventType.Feedback)
            // {
            //     var noFeedback = interaction?.GetMyEvents(UserId).Empty(a => a.Type == EventType.Feedback) ?? true;

            //     return !(noFeedback);
            // }

            return true;
        }
    }
}