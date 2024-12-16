﻿using Newtonsoft.Json;

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

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "_etag")]
        public string? ETag { get; set; }

        [JsonProperty(PropertyName = "_ts")]
        public long Timestamp { get; set; }

        [JsonIgnore]
        public DateTime DateTime => DateTimeOffset.FromUnixTimeSeconds(Timestamp).UtcDateTime;

        public abstract bool HasValidData();

        public void SetIds(string id)
        {
            if (FixedId) throw new InvalidOperationException();

            Id = id;
        }
    }
}