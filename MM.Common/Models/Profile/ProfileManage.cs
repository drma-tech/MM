using MM.Common.Models.Auth;

namespace MM.Common.Models.Profile
{
    public class ProfileManage
    {
        public AuthPrincipal? Principal { get; set; }
        public ProfileModel? Profile { get; set; }
    }
}