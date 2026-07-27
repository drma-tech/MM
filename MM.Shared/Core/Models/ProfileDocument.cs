namespace MM.Shared.Core.Models;

public readonly record struct ProfileIdentity(string? DocId) : ICosmosIdentity
{
    public string Id => DocId!;
    public string? RawId => DocId?.RemovePrefix();
    public object Key => Id;
}

public abstract class ProfileDocument(ProfileIdentity identity) : CosmosDocument(identity)
{
}