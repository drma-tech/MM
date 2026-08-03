using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class InteractionModel(string? id) : MainDocument(new MainIdentity(MainType.Interaction, FormatId(id)))
{
    public ISet<InteractionEvent> EventsUserA { get; set; } = new HashSet<InteractionEvent>();
    public ISet<InteractionEvent> EventsUserB { get; set; } = new HashSet<InteractionEvent>();

    public InteractionStatus Status { get; set; } = InteractionStatus.Explorer;

    /// <summary>
    ///     Format the id of the InteractionModel
    /// </summary>
    /// <param name="idUsers">guid:guid</param>
    /// <returns></returns>
    public static string FormatId(string? idUsers)
    {
        ArgumentNullException.ThrowIfNull(idUsers);

        var ids = idUsers.Split(':');
        return string.Join('-', ids.Order(StringComparer.OrdinalIgnoreCase));
    }

    public ISet<InteractionEvent> GetMyEvents(string? userId)
    {
        var ids = Id.Split(":")[1];
        var arrIds = ids.Split('-');

        if (string.Equals(arrIds[0], userId, StringComparison.OrdinalIgnoreCase))
            return EventsUserA;
        return EventsUserB;
    }

    public void AddEventUser(string? triggerUserId, EventType type, Origin origin)
    {
        if (Id.Empty()) throw new NotificationException("must initialize the interaction first");

        var ids = Id.Split(":")[1];
        var arrIds = ids.Split('-');

        if (string.Equals(arrIds[0], triggerUserId, StringComparison.OrdinalIgnoreCase))
            EventsUserA.Add(new InteractionEvent { Type = type, Origin = origin });
        else
            EventsUserB.Add(new InteractionEvent { Type = type, Origin = origin });
    }

    protected override object?[] EqualityValues => [Id];
}

public class InteractionEvent
{
    public EventType Type { get; set; }
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    public Origin Origin { get; set; }
}

public enum EventType
{
    Like = 1,
    Dislike = 2,
    Dating = 3,
    Feedback = 4,
    Relationship = 5,

    Delete = 8,
    Report = 9,
}