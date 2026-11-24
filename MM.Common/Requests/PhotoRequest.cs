using static MM.Common.Core.Helper.ImageHelper;

namespace MM.Common.Requests;

public class PhotoRequest
{
    public PhotoType PhotoType { get; set; }
    public byte[] Buffer { get; set; } = [];
}