namespace MM.Shared.Models.Profile
{
    public class MySuggestionsModel : PrivateMainDocument
    {
        public MySuggestionsModel() : base(DocumentType.Suggestions)
        {
        }

        public HashSet<PersonModel> Items { get; set; } = [];

        public override bool HasValidData()
        {
            return Items.Count != 0;
        }

        public override bool Equals(object? obj)
        {
            return obj is MySuggestionsModel q && q.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }
    }
}