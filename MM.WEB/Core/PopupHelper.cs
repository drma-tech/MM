using Blazorise;
using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Auth;
using MM.WEB.Modules.Profile.Components;
using MM.WEB.Modules.Subscription.Components;
using MM.WEB.Shared;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.WEB.Core;

public static class PopupHelper
{
    public static readonly EventCallbackFactory Factory = new();

    public static async Task InvitePerEmail(this IModalService service, ClientePrincipal? principal,
        EventCallback<string> inviteSent)
    {
        await service.Show<InvitePerEmail>(null, x =>
        {
            x.Add(x => x.principal, principal);
            x.Add(x => x.InviteSent, inviteSent);
        }, Options(ModalSize.Default));
    }

    public static async Task OpenPopup<TComponent>(this IModalService service,
        Action<ModalProviderParameterBuilder<TComponent>> parameters, ModalSize size)
        where TComponent : IComponent
    {
        await service.Show(null, parameters, Options(size));
    }

    public static async Task SelectPicturePopup(this IModalService service, string? picture, PhotoType photoType,
        EventCallback<(PhotoType, byte[])> pictureChanged)
    {
        await service.Show<SelectPicturePopup>(null, x =>
        {
            x.Add(x => x.SavedPicture, picture);
            x.Add(x => x.PhotoType, photoType);
            x.Add(x => x.CroppedPictureChanged, pictureChanged);
        }, Options(ModalSize.Large));
    }

    public static async Task SettingsPopup(this IModalService service)
    {
        await service.Show<SettingsPopup>(null, x => { }, Options(ModalSize.Default));
    }

    public static async Task SubscriptionPopup(this IModalService service, bool isAuthenticated)
    {
        await service.Show<SubscriptionPopup>(null, x => { x.Add(x => x.IsAuthenticated, isAuthenticated); },
            Options(ModalSize.Large));
    }

    private static ModalInstanceOptions Options(ModalSize size)
    {
        return new ModalInstanceOptions
        {
            UseModalStructure = false,
            Centered = true,
            Size = size
        };
    }
}
