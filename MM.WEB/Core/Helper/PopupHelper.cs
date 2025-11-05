using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Profile;
using MM.WEB.Modules.Auth;
using MM.WEB.Modules.Profile.Components;
using MM.WEB.Modules.Subscription.Components;
using MM.WEB.Modules.Support;
using MM.WEB.Shared;
using MudBlazor;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.WEB.Core.Helper;

public static class PopupHelper
{
    public static readonly EventCallbackFactory Factory = new();

    public static async Task InvitePerEmail(this IDialogService service, AuthPrincipal? principal,
        EventCallback<string> inviteSent)
    {
        var parameters = new DialogParameters<InvitePerEmail>
        {
            { x => x.principal, principal },
            { x => x.InviteSent, inviteSent }
        };

        await service.ShowAsync<InvitePerEmail>(CardHeader.InvitePartner, parameters, Options(MaxWidth.Small));
    }

    public static async Task SelectPicturePopup(this IDialogService service, PhotoType photoType, EventCallback<(PhotoType, byte[])> pictureChanged)
    {
        var parameters = new DialogParameters<SelectPicturePopup>
        {
            { x => x.PhotoType, photoType },
            { x => x.CroppedPictureChanged, pictureChanged }
        };

        await service.ShowAsync<SelectPicturePopup>("Picture", parameters, Options(MaxWidth.Medium));
    }

    public static async Task OpenAccountPopup(this IDialogService service, bool isAuthenticated)
    {
        var parameters = new DialogParameters<ProfilePopup>
        {
            { x => x.IsAuthenticated, isAuthenticated }
        };

        await service.ShowAsync<ProfilePopup>(Modules.Profile.Resources.Translations.MyProfile, parameters, Options(MaxWidth.ExtraSmall));
    }

    public static async Task OpenPopupProfile(this IDialogService service, bool isAuthenticated, MM.Shared.Enums.Origin origin, string? userId, string? idUserView,
        ProfileModel? fakeView = null)
    {
        var parameters = new DialogParameters<PopupProfile>
        {
            { x => x.IsAuthenticated, isAuthenticated },
            { x => x.Origin, origin },
            { x => x.UserId, userId },
            { x => x.IdUserView, idUserView },
            { x => x.View, fakeView },
            { x => x.Fake, fakeView != null },
            //{ x => x.Liked, await LoadLikes(true) },
            //{ x => x.Matched, await LoadMatches(true) }
        };

        await service.ShowAsync<PopupProfile>(fakeView?.NickName, parameters, Options(MaxWidth.Large));
    }

    public static async Task SettingsPopup(this IDialogService service)
    {
        await service.ShowAsync<SettingsPopup>(GlobalTranslations.Settings, Options(MaxWidth.Small));
    }

    public static async Task SubscriptionPopup(this IDialogService service, bool isAuthenticated)
    {
        var parameters = new DialogParameters<NewSubscriptionPopup>
        {
            { x => x.IsAuthenticated, isAuthenticated }
        };

        await service.ShowAsync<NewSubscriptionPopup>(Modules.Subscription.Resources.Translations.MySubscription, parameters, Options(MaxWidth.Medium));
    }

    public static async Task OnboardingPopup(this IDialogService service)
    {
        await service.ShowAsync<Onboarding>(string.Format(GlobalTranslations.WelcomeTo, SeoTranslations.AppName), Options(MaxWidth.Medium));
    }

    public static async Task AskReviewPopup(this IDialogService service)
    {
        await service.ShowAsync<AskReview>(string.Format("Want to help {0} grow?", SeoTranslations.AppName), Options(MaxWidth.Small));
    }

    public static DialogOptions Options(MaxWidth width)
    {
        return new DialogOptions
        {
            CloseOnEscapeKey = true,
            CloseButton = true,
            Position = DialogPosition.Center,
            MaxWidth = width
        };
    }
}
