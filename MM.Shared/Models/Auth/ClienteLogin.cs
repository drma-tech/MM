﻿namespace MM.Shared.Models.Auth
{
    public class ClienteLogin : PrivateMainDocument
    {
        public ClienteLogin() : base(DocumentType.Login)
        {
        }

        public string? UserId { get; set; }
        public DateTimeOffset[] Logins { get; set; } = [];
        public string[] Platforms { get; set; } = [];

        public override void Initialize(string userId)
        {
            base.Initialize(userId);
            UserId = userId;
        }

        public override bool HasValidData()
        {
            if (string.IsNullOrEmpty(UserId)) return false;
            if (UserId != Key) return false;

            return true;
        }
    }
}