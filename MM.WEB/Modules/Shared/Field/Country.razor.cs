using Microsoft.AspNetCore.Components;

namespace MM.WEB.Modules.Shared.Field
{
    public partial class Country
    {
        [Parameter] public MM.Shared.Enums.Country? SelectedValue { get; set; }
        [Parameter] public EventCallback<MM.Shared.Enums.Country?> SelectedValueChanged { get; set; }

        public IEnumerable<EnumFieldObject<MM.Shared.Enums.Country>> Countries { get; set; } = [];
        public IEnumerable<EnumFieldObject<MM.Shared.Enums.Country>> FilteredCountries =>
            Countries.Where(w => string.Equals(w.Group, Continent, StringComparison.OrdinalIgnoreCase)).OrderBy(o => o.Name, StringComparer.OrdinalIgnoreCase);

        public string? Continent { get; set; }

        protected override void OnInitialized()
        {
            Countries = EnumHelper.GetList<MM.Shared.Enums.Country>();
            Continent = SelectedValue?.GetFieldSettings().Group;
        }
    }
}