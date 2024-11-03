using MM.WEB.Core.Enum;

namespace MM.WEB.Core.Models
{
    public class AffinityVM(Section section, CompatibilityItem Item, bool HaveAffinity)
    {
        public Section Section { get; set; } = section;
        public CompatibilityItem Item { get; set; } = Item;
        public bool HaveAffinity { get; set; } = HaveAffinity;
    }
}