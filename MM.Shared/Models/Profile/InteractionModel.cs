﻿namespace MM.Shared.Models.Profile
{
    public class InteractionModel : ProtectedMainDocument
    {
        public InteractionModel() : base(DocumentType.Interaction)
        {
        }

        public List<InteractionEvent> EventsUserA { get; set; } = [];
        public List<InteractionEvent> EventsUserB { get; set; } = [];

        public new void Initialize(string? idUsers)
        {
            if (string.IsNullOrEmpty(idUsers)) throw new ArgumentNullException(nameof(idUsers));

            base.Initialize(FormatId(idUsers));
        }

        /// <summary>
        /// Format the id of the InteractionModel
        /// </summary>
        /// <param name="idUsers">guid:guid</param>
        /// <returns></returns>
        public static string FormatId(string idUsers)
        {
            var ids = idUsers.Split(':');
            return string.Join("-", ids.Order());
        }

        public void AddEventUser(string? userId, EventType type)
        {
            if (Id.Empty()) throw new NotificationException("must initialize the interaction first");

            var ids = Id.Split('-');

            if (ids[0] == userId)
                EventsUserA.Add(new InteractionEvent { Type = type });
            else
                EventsUserB.Add(new InteractionEvent { Type = type });
        }

        public override bool Equals(object? obj)
        {
            return obj is InteractionModel q && q.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
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
    }

    public enum EventType
    {
        Like = 1,
        Dislike = 2
    }
}