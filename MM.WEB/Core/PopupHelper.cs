using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Auth;
using MM.WEB.Modules.Auth;
using MM.WEB.Modules.Profile.Components;
using MM.WEB.Modules.Subscription.Components;
using MM.WEB.Shared;
using MudBlazor;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.WEB.Core;

public static class PopupHelper
{
    public static readonly EventCallbackFactory Factory = new();

    public static async Task InvitePerEmail(this IDialogService service, ClientePrincipal? principal,
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

    public static async Task SettingsPopup(this IDialogService service)
    {
        await service.ShowAsync<SettingsPopup>(GlobalTranslations.Settings, Options(MaxWidth.Small));
    }

    public static async Task SubscriptionPopup(this IDialogService service, bool isAuthenticated)
    {
        var parameters = new DialogParameters<SubscriptionPopup>
        {
            { x => x.IsAuthenticated, isAuthenticated }
        };

        await service.ShowAsync<SubscriptionPopup>(Modules.Subscription.Resources.Translations.MySubscription, parameters, Options(MaxWidth.Medium));
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