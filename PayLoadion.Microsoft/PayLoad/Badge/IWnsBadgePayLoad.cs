using PayLoadion.Microsoft.PayLoad.Badge.Enums;

namespace PayLoadion.Microsoft.PayLoad.Badge
{
    public interface IWnsBadgePayLoad : IWnsPayLoad
    {

    }

    public interface IWnsBadgeNumericPayLoad : IWnsBadgePayLoad
    {
        int? BadgeCount { get; }
    }

    public interface IWnsBadgeGlyphPayLoad : IWnsBadgePayLoad
    {
        WnsBadgeGlyphValueEnum GlyphValue { get; }
    }
}