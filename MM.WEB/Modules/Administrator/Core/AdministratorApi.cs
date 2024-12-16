﻿using MM.Shared.Models.Support;

namespace MM.WEB.Modules.Administrator.Core
{
    public class AdministratorApi(IHttpClientFactory factory) : ApiCosmos<EmailDocument>(factory)
    {
        private struct Endpoint
        {
            public const string GetEmails = "adm/emails";
            public const string EmailUpdate = "adm/emails/update";
            public const string SendEmail = "adm/send-email";
        }

        public async Task<HashSet<EmailDocument>> GetEmails()
        {
            return await GetListAsync(Endpoint.GetEmails, null);
        }

        public async Task SendEmail(SendEmail inbound)
        {
            await PostAsync(Endpoint.SendEmail, null, inbound);
        }

        public async Task EmailUpdate(EmailDocument email)
        {
            await PostAsync(Endpoint.EmailUpdate, null, email);
        }
    }
}