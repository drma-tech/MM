using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.Shared.Requests
{
    public class PhotoRequest
    {
        public PhotoType PhotoType { get; set; }
        public byte[] Buffer { get; set; } = [];
    }
}