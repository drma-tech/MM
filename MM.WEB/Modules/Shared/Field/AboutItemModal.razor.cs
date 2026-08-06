using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Profile;
using MM.WEB.Core.Enum;
using MM.WEB.Core.Models;
using MudBlazor;

namespace MM.WEB.Modules.Shared.Field
{
    public partial class AboutItemModal<TValue>
    {
        [CascadingParameter] private IMudDialogInstance? MudDialog { get; set; }

        [Parameter] public IEnumerable<string> PreferenceValues { get; set; } = [];
        [Parameter] public IEnumerable<string> ExpectedValues { get; set; } = [];
        [Parameter] public IEnumerable<TValue> ViewValues { get; set; } = [];
        [Parameter] public IEnumerable<AffinityVM> Affinities { get; set; } = [];

        [Parameter] public CompatibilityType Type { get; set; }
        [Parameter] public CompatibilityItem Item { get; set; }
        [Parameter] public ProfileModel? Profile { get; set; }
        [Parameter] public FilterModel? Filter { get; set; }
        [Parameter] public string? WhyImportant { get; set; }
        [Parameter] public string? Tips { get; set; }

        [Parameter, EditorRequired] public bool ShowDescription { get; set; }

        private Severity GetSeverity(TValue? value = default)
        {
            if (!Affinities.Any(s => s.Item == Item)) //if the attribute is not mapped to affinity, it remains neutral
            {
                return Severity.Normal;
            }

            if (Affinities.Single(s => s.Item == Item).HaveAffinity) //if it is mapped and has affinity
            {
                if (value == null)
                {
                    return Severity.Success;
                }

                if (value is Enum result && Type == CompatibilityType.Enum)
                {
                    if (!ExpectedValues.Any() || ExpectedValues.Contains(result.GetFieldSettings().Name, StringComparer.OrdinalIgnoreCase))
                        return Severity.Success;
                    return Severity.Warning;
                }

                return Severity.Success;
            }

            //if mapped but without affinity
            return Severity.Error;
        }

        private Dictionary<string, string> GetTips()
        {
            if (string.IsNullOrEmpty(Tips)) return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            var values = Tips.Split("|");
            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            for (var i = 0; i < values.Length; i += 2)
            {
                var key = values[i]?.Trim();
                if (string.IsNullOrEmpty(key))
                    continue;

                // If a value is missing (odd number of tokens), indicate it instead of throwing
                var val = (i + 1) < values.Length && !string.IsNullOrEmpty(values[i + 1])
                    ? values[i + 1].Trim()
                    : Translations.Module.Profile.Undefined;

                // Use indexer to avoid exception on duplicate keys
                result[key] = val;
            }

            return result;
        }

        private async Task FeedbackClick()
        {
            await DialogService!.ShowMessageBoxAsync("Feedback", Translations.Module.Profile.CompatibilityDeveloping);
        }

        private void CloseClick()
        {
            MudDialog?.Close();
        }
    }
}
