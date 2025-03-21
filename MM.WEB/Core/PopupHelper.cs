using Blazorise;
using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Support;
using MM.WEB.Modules.Profile.Components;
using MM.WEB.Modules.Subscription.Components;
using MM.WEB.Modules.Support.Component;
using MM.WEB.Shared;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.WEB.Core
{
    public static class PopupHelper
    {
        public static readonly EventCallbackFactory Factory = new();

        public static async Task SettingsPopup(this IModalService service)
        {
            await service.Show<SettingsPopup>(null, x =>
            {
            }, Options(ModalSize.Default));
        }

        public static async Task NewTicket(this IModalService service, TicketType TicketType, EventCallback<TicketModel> Inserted, bool IsAuthenticated, string? UserId)
        {
            await service.Show<NewTicket>(null, x =>
            {
                x.Add(x => x.TicketType, TicketType);
                x.Add(x => x.Inserted, Inserted);
                x.Add(x => x.IsAuthenticated, IsAuthenticated);
                x.Add(x => x.UserId, UserId);
            }, Options(ModalSize.Default));
        }

        public static async Task SubscriptionPopup(this IModalService service, ClientePrincipal? client, bool IsAuthenticated)
        {
            await service.Show<SubscriptionPopup>(null, x =>
            {
                x.Add(x => x.Client, client);
                x.Add(x => x.IsAuthenticated, IsAuthenticated);
            }, Options(ModalSize.Large));
        }

        public static async Task SelectPicturePopup(this IModalService service, string? picture, PhotoType photoType, EventCallback<(PhotoType, byte[])> pictureChanged)
        {
            await service.Show<SelectPicturePopup>(null, x =>
            {
                x.Add(x => x.SavedPicture, picture);
                x.Add(x => x.PhotoType, photoType);
                x.Add(x => x.CroppedPictureChanged, pictureChanged);
            }, Options(ModalSize.Large));
        }

        public static async Task InvitePerEmail(this IModalService service, ClientePrincipal? principal, EventCallback<string> inviteSent)
        {
            await service.Show<InvitePerEmail>(null, x =>
            {
                x.Add(x => x.principal, principal);
                x.Add(x => x.InviteSent, inviteSent);
            }, Options(ModalSize.Default));
        }

        public static async Task OpenPopup<TComponent>(this IModalService service, Action<ModalProviderParameterBuilder<TComponent>> parameters, ModalSize size)
            where TComponent : IComponent
        {
            await service.Show(null, parameters, Options(size));
        }

        private static ModalInstanceOptions Options(ModalSize size) => new()
        {
            UseModalStructure = false,
            Centered = true,
            Size = size
        };
    }
}