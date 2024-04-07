namespace MM.Shared.Models
{
    public class AffinityVM(Section section, CompatibilityItem Item, bool HaveAffinity)
    {
        public Section Section { get; set; } = section;
        public CompatibilityItem Item { get; set; } = Item;
        public bool HaveAffinity { get; set; } = HaveAffinity;
    }
}