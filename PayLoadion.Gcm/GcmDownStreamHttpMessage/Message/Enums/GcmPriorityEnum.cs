using System.Runtime.Serialization;

namespace PayLoadion.Gcm.GcmDownStreamHttpMessage.Message.Enums
{
    /// <summary>
    /// Represents the priority
    /// </summary>
    public enum GcmPriorityEnum
    {
        /// <summary>
        /// Normal priority
        /// </summary>
        [EnumMember(Value = "normal")]
        Normal,
        /// <summary>
        /// High priority
        /// </summary>
        [EnumMember(Value = "high")]
        High
    }
}
