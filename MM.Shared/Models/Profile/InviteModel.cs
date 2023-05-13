using System;
using System.Collections.Generic;
using MM.Shared.Core;
using MM.Shared.Core.Models;

namespace MM.Shared.Models.Profile
{
    public class InviteModel : PrivateMainDocument
    {
        public InviteModel() : base(DocumentType.Invite)
        {
        }

        public List<Invite> Invites { get; set; } = new();

        //public void UpdateData()
        //{
        //    DtUpdate = DateTime.UtcNow;
        //}

        //public override void SetIds(string email)
        //{
        //    this.SetId(email);
        //    this.SetPartitionKey(email);
        //}

        public override bool HasValidData()
        {
            throw new NotImplementedException();
        }
    }

    public class Invite
    {
        public Invite(string UserId, string UserEmail, InviteType Type)
        {
            this.UserId = UserId;
            this.UserEmail = UserEmail;
            this.Type = Type;
        }

        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public DateTime DtInvite { get; set; } = DateTime.UtcNow;
        public InviteType Type { get; set; }
        public bool Accepted { get; set; }
    }

    public enum InviteType
    {
        Partner = 1
    }
}