using Microsoft.Extensions.Logging;

namespace MM.API.Core
{
    internal static partial class LogMessages
    {
        [LoggerMessage(Level = LogLevel.Warning, Message = "{method} - Id {Id}, RequestCharge {RequestCharge}")]
        public static partial void RequestCharge(this ILogger logger, string method, string id, double requestCharge);
    }
}