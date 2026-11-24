using Microsoft.AspNetCore.Components;

namespace MM.WEB.Modules.Common
{
    public partial class Country
    {
        [Parameter] public MM.Common.Enums.Country? SelectedValue { get; set; }
        [Parameter] public EventCallback<MM.Common.Enums.Country?> SelectedValueChanged { get; set; }

        public IEnumerable<EnumFieldObject<MM.Common.Enums.Country>> Countries { get; set; } = [];
        public IEnumerable<EnumFieldObject<MM.Common.Enums.Country>> FilteredCountries =>
            Countries.Where(w => string.Equals(w.Group, Continent, StringComparison.OrdinalIgnoreCase)).OrderBy(o => o.Name, StringComparer.OrdinalIgnoreCase);

        public string? Continent { get; set; }

        protected override void OnInitialized()
        {
            Countries = EnumHelper.GetList<MM.Common.Enums.Country>();
            Continent = SelectedValue?.GetFieldSettings().Group;
        }
    }
}