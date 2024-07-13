﻿using System.Text.Json.Serialization;

namespace MM.Shared.Core
{
    public abstract class CosmosDocument
    {
        private readonly bool FixedId = false;

        protected CosmosDocument()
        {
            FixedId = false;
        }

        protected CosmosDocument(string id)
        {
            Id = id;

            FixedId = true;
        }

        [JsonInclude]
        public string Id { get; set; } = string.Empty;

        [JsonInclude]
        public DateTimeOffset DtInsert { get; set; } = DateTimeOffset.UtcNow;

        [JsonInclude]
        public DateTimeOffset? DtUpdate { get; set; } = null;

        public abstract bool HasValidData();

        protected void SetIds(string id)
        {
            if (FixedId) throw new InvalidOperationException();

            Id = id;
        }

        public virtual void Update()
        {
            DtUpdate = DateTimeOffset.UtcNow;
        }
    }
}