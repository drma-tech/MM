using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Profile;
using MM.WEB.Core.Models;
using MudBlazor;

namespace MM.WEB.Modules.Profile
{
    public partial class CardCompatibilityComponent
    {
        [Parameter] public ProfileModel? User { get; set; }
        [Parameter] public FilterModel? Filter { get; set; }
        [Parameter] public ProfileModel? View { get; set; }
        [Parameter] public IReadOnlyCollection<AffinityVM> Affinities { get; set; } = [];

        private int totPercAff => Affinities.GetPercentAffinity();

        // protected override async Task OnInitializedAsync()
        // {
        //    if (View != null && User != null && User.DtInsert > DateTime.Now.AddDays(-7) && !LocalStorage.ContainKey("item_mais_detalhes"))
        //    {
        //        await Toast.Info("Clique em cada um dos itens para obter mais detalhes");
        //        LocalStorage.SetItem("item_mais_detalhes", true);
        //    }
        // }

        // public Background GetBackground(Section? category)
        // {
        //     var perc = Affinities.GetPercentAffinity(category);

        //     if (perc >= 80)
        //     {
        //         return Background.Success;
        //     }

        //     if (perc >= 60)
        //     {
        //         return Background.Warning;
        //     }

        //     return Background.Danger;
        // }

        public Color GetColor(Section? category)
        {
            var perc = Affinities.GetPercentAffinity(category);

            if (perc >= 80)
            {
                return Color.Success;
            }

            if (perc >= 60)
            {
                return Color.Warning;
            }

            return Color.Error;
        }

        public Severity GetSeverity(Section? category)
        {
            var perc = Affinities.GetPercentAffinity(category);

            if (perc >= 80)
            {
                return Severity.Success;
            }

            if (perc >= 60)
            {
                return Severity.Warning;
            }

            return Severity.Error;
        }

        public string? GetIcon(Section? category)
        {
            var perc = Affinities.GetPercentAffinity(category);

            if (perc >= 80)
            {
                return IconsFA.Solid.Icon("face-smile").Animation(category == null ? IconAnimation.Bounce : IconAnimation.None).Font;
            }

            if (perc >= 60)
            {
                return IconsFA.Solid.Icon("face-meh").Animation(category == null ? IconAnimation.Beat : IconAnimation.None).Font;
            }

            return IconsFA.Solid.Icon("face-frown").Animation(category == null ? IconAnimation.Fade : IconAnimation.None).Font;
        }
    }
}
