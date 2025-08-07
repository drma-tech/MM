using MM.Shared.Models.Auth;
using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Auth.Core
{
    public class SuperData
    {
        public ClientePrincipal? Principal { get; set; }
        public ClienteLogin? Login { get; set; }
        public FilterModel? Filter { get; set; }
        public SettingModel? Settings { get; set; }
        public MySuggestionsModel? Suggestions { get; set; }
        public MyLikesModel? Likes { get; set; }
        public MyMatchesModel? Matches { get; set; }
        //public MyInteractionsModel? Interactions { get; set; }
        public ValidationModel? Validations { get; set; }

    }
}
