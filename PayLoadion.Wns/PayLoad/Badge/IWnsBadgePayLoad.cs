using PayLoadion.Wns.PayLoad.Badge.Enums;

namespace PayLoadion.Wns.PayLoad.Badge
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