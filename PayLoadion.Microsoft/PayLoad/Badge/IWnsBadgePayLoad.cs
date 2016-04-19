using PayLoadion.Microsoft.PayLoad.Badge.Enums;

namespace PayLoadion.Microsoft.PayLoad.Badge
{
    public interface IWnsBadgePayLoad : IWnsPayLoad
    {
        int? BadgeCount { get; }

        WnsBadgeValueEnum BadgeValue { get; }
    }
}