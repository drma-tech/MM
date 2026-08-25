namespace MM.WEB.Modules
{
    public partial class TipsPage
    {
        public IEnumerable<EnumFieldObject<Category>> CategoryList { get; set; } = [];

        private List<string?> Options { get; set; } = [];
        private string? filter;

        protected override async Task LoadStaticDataAsync()
        {
            filter = Culture;

            CategoryList = EnumHelper.GetList<Category>().Where(p => p.Value != Category.INTEREST);

            Options.Add("en");
            Options.Add("pt");
            Options.Add("es");
            Options.Add("fr");
            Options.Add("it");
            Options.Add("de");
        }
    }
}