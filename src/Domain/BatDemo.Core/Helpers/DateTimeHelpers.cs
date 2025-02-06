using DocumentFormat.OpenXml.InkML;
using System;

namespace BatDemo.Helpers
{
    public static class DateTimeHelpers
    {
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp, bool local = true)
        {
            // Unix timestamp is seconds past epoch
            var offset = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp);
            DateTime dateTime = local ? offset.LocalDateTime: offset.UtcDateTime;
            return dateTime;
        }

        public static long DateTimeToUnixTimeStamp(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.Now;
            }
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixTimestamp = (long)(dateTime.Value.ToUniversalTime() - unixEpoch).TotalSeconds;
            return unixTimestamp;
        }
    }
}






