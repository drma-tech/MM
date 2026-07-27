namespace MM.Shared.Core.Models;

using Json = System.Text.Json.Serialization;

public readonly record struct SafetyIdentity(string? DocId) : ICosmosIdentity
{
    public string Id => DocId!;
    public string? RawId => DocId?.RemovePrefix();
    public object Key => Id;
}

public abstract class SafetyDocument(SafetyIdentity identity, TtlCache ttl) : CosmosDocument(identity)
{
    [Json.JsonInclude]
    public TtlCache Ttl { get; init; } = ttl;
}