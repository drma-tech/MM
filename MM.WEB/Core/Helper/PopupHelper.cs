using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Profile;
using MM.WEB.Modules.Auth;
using MM.WEB.Modules.Help;
using MM.WEB.Modules.Profile;
using MM.WEB.Modules.Subscription;
using MudBlazor;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.WEB.Core.Helper;

public static class PopupHelper
{
    public static readonly EventCallbackFactory Factory = new();

    public static async Task SelectPicturePopup(this IDialogService service, PhotoType photoType, EventCallback<(PhotoType, byte[])> pictureChanged)
    {
        var parameters = new DialogParameters<SelectPicturePopup>
        {
            { x => x.PhotoType, photoType },
            { x => x.CroppedPictureChanged, pictureChanged },
        };

        await service.ShowAsync<SelectPicturePopup>("Picture", parameters, Options(MaxWidth.Medium));
    }

    public static async Task AccountPopup(this IDialogService service)
    {
        var parameters = new DialogParameters<AccountPopup> { };

        await service.ShowAsync<AccountPopup>(Translations.Module.Auth.MyAccount, parameters, Options(MaxWidth.Small));
    }

    public static async Task OpenPopupProfile(this IDialogService service, MM.Shared.Enums.Origin origin, string? userId, string? idUserView,
        ProfileModel? fakeView = null, bool onlyCompatibility = false)
    {
        var parameters = new DialogParameters<PopupProfilePopup>
        {
            { x => x.Origin, origin },
            { x => x.UserId, userId },
            { x => x.IdUserView, idUserView },
            { x => x.View, fakeView },
            { x => x.Fake, fakeView != null },
            { x => x.OnlyCompatibility, onlyCompatibility },
            //{ x => x.Liked, await LoadLikes(true) },
            //{ x => x.Matched, await LoadMatches(true) }
        };

        await service.ShowAsync<PopupProfilePopup>(fakeView?.NickName, parameters, Options(MaxWidth.Large));
    }

    public static async Task SettingsPopup(this IDialogService service)
    {
        await service.ShowAsync<SettingsPopup>(Translations.Module.Help.Settings, Options(MaxWidth.Small));
    }

    public static async Task SubscriptionPopup(this IDialogService service)
    {
        var parameters = new DialogParameters<SubscriptionPopup> { };

        await service.ShowAsync<SubscriptionPopup>("My Sparks", parameters, Options(MaxWidth.Small));
    }

    public static async Task OnboardingPopup(this IDialogService service, string culture)
    {
        var parameters = new DialogParameters<OnboardingPopup>
        {
            { x => x.Culture, culture },
        };

        await service.ShowAsync<OnboardingPopup>(Translations.Module.Help.WelcomeTo.CustomFormat(AppInfo.Title), parameters, Options(MaxWidth.Medium));
    }

    public static async Task AskReviewPopup(this IDialogService service)
    {
        await service.ShowAsync<AskReviewPopup>(Translations.Module.Help.WriteReviewTitle.CustomFormat(AppInfo.Title), Options(MaxWidth.Small, allowClose: false, showHeader: false));
    }

    public static DialogOptions Options(MaxWidth width, bool allowClose = true, bool showHeader = true)
    {
        return new DialogOptions
        {
            CloseOnEscapeKey = allowClose,
            CloseButton = allowClose,
            BackdropClick = allowClose,
            NoHeader = !showHeader,
            Position = DialogPosition.Center,
            MaxWidth = width,
        };
    }
}