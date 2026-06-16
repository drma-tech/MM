using MM.Shared.Models.Auth;

namespace MM.Shared.Models.Profile
{
    public class ProfileManage
    {
        public AuthPrincipal? Principal { get; set; }
        public ProfileModel? Profile { get; set; }
    }
}