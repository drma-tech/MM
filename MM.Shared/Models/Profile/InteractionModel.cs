namespace MM.Shared.Models.Profile;

public class InteractionModel : ProtectedMainDocument
{
    public InteractionModel() : base(DocumentType.Interaction)
    {
    }

    public List<InteractionEvent> EventsUserA { get; set; } = [];
    public List<InteractionEvent> EventsUserB { get; set; } = [];

    public InteractionStatus Status { get; set; } = InteractionStatus.Explorer;

    public new void Initialize(string? idUsers)
    {
        if (string.IsNullOrEmpty(idUsers)) throw new ArgumentNullException(nameof(idUsers));

        base.Initialize(FormatId(idUsers));
    }

    /// <summary>
    ///     Format the id of the InteractionModel
    /// </summary>
    /// <param name="idUsers">guid:guid</param>
    /// <returns></returns>
    public static string FormatId(string idUsers)
    {
        var ids = idUsers.Split(':');
        return string.Join("-", ids.Order());
    }

    public List<InteractionEvent> GetMyEvents(string? userId)
    {
        var ids = Id.Split(":")[1];
        var arrIds = ids.Split('-');

        if (arrIds[0] == userId)
            return EventsUserA;
        return EventsUserB;
    }

    public void AddEventUser(string? trigguerUserId, EventType type, Origin origin)
    {
        if (Id.Empty()) throw new NotificationException("must initialize the interaction first");

        var ids = Id.Split(":")[1];
        var arrIds = ids.Split('-');

        if (arrIds[0] == trigguerUserId)
            EventsUserA.Add(new InteractionEvent { Type = type, Origin = origin });
        else
            EventsUserB.Add(new InteractionEvent { Type = type, Origin = origin });
    }

    public override bool HasValidData()
    {
        return EventsUserA.Count != 0 || EventsUserB.Count != 0;
    }
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
    Report = 9
}