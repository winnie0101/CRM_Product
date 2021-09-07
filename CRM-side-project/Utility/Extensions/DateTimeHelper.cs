using System;

namespace CRM_side_project.Utility.Extensions
{
    internal static class DateTimeHelper
    {
        internal static long ToUnixTimeSeconds(this DateTime foo)
        {
            return ((DateTimeOffset)foo).ToUnixTimeSeconds();
        }

        internal static long? ToUnixTimeSeconds(this DateTime? foo)
        {
            if (foo.HasValue)
            {
                return ((DateTimeOffset)foo).ToUnixTimeSeconds();
            }

            return null;
        }

        internal static DateTime ToUtcDateTime(this long timestamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timestamp).ToLocalTime();
            return dateTime;
        }
    }
}