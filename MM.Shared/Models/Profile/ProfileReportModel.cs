using System;

namespace MM.Shared.Models.Profile
{
    public class ProfileReportModel
    {
        public DateTime DtInsert { get; set; } = DateTime.UtcNow;
        public ReportType Type { get; set; }
    }
}