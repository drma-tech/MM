using FluentValidation;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Profile.Core;

namespace MM.Shared.Core.Helper;

public static class ProfileHelper
{
    public static int GetAge(this DateTime? date)
    {
        if (date == null) return 0;

        return GetAge(date.Value);
    }

    public static int GetAge(this DateTime date)
    {
        var years = DateTime.UtcNow.Year - date.Year;
        if (date.Month > DateTime.UtcNow.Month ||
            (date.Month == DateTime.UtcNow.Month && date.Day > DateTime.UtcNow.Day))
            years--;

        return years;
    }

    public static ProfileValidation Validator { get; set; } = new();

    public static readonly IReadOnlyDictionary<Category, int> TotalRules = new Dictionary<Category, int>
    {
        { Category.BASIC, 9 },
        { Category.BIO, 4 },
        { Category.LIFESTYLE, 11 },
        { Category.PERSONALITY, 7 },
        { Category.INTEREST, 3 },
        { Category.RELATIONSHIP, 5 },
        { Category.GOAL, 4 },
    };

    public static bool IsValid(this ProfileModel? profile, Category tab)
    {
        if (profile == null) return false;

        var ruleSet = tab.ToString();

        return Validator.Validate(profile, o => o.IncludeRuleSets(ruleSet)).IsValid;
    }

    public static (int total, int failed) GetCompletion(this ProfileModel? profile, Category tab)
    {
        if (profile == null) return (0, 0);

        if (tab == Category.INTEREST)
        {
            var filled = 0;

            if (profile.Food.Count != 0) filled++;
            if (profile.Vacation.Count != 0) filled++;
            if (profile.Sports.Count != 0) filled++;
            if (profile.LeisureActivities.Count != 0) filled++;
            if (profile.MusicGenre.Count != 0) filled++;
            if (profile.MovieGenre.Count != 0) filled++;
            if (profile.TVGenre.Count != 0) filled++;
            if (profile.ReadingGenre.Count != 0) filled++;

            const int minimum = 3;

            int failed = Math.Max(minimum - filled, 0);

            return (minimum, failed);
        }

        var ruleSet = tab.ToString();

        var result = Validator.Validate(profile, o => o.IncludeRuleSets(ruleSet));

        var totalRules = TotalRules[tab];

        var failedRules = result.Errors
            .Select(e => e.PropertyName)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Count();

        return (totalRules, failedRules);
    }

    public static double GetCompletionPercentage(this ProfileModel? profile, Category tab)
    {
        var (total, failed) = profile.GetCompletion(tab);

        var completed = total - failed;

        return (double)completed / total;
    }

    public static double GetOverallCompletionPercentage(this ProfileModel? profile)
    {
        if (profile == null) return 0;

        var tabs = Enum.GetValues<Category>();

        int totalAll = 0;
        int completedAll = 0;

        foreach (var tab in tabs)
        {
            var (total, failed) = profile.GetCompletion(tab);

            totalAll += total;
            completedAll += (total - failed);
        }

        if (totalAll == 0) return 0;

        return (double)completedAll / totalAll;
    }
}