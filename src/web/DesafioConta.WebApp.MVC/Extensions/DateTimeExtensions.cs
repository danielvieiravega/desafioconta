using System;

namespace DesafioConta.WebApp.MVC.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime UnixBaseDate = new DateTime(1970, 1, 1, 0, 0, 0);

        public static long ToUnixTimeStamp(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return (long)dateTime.Value.Subtract(UnixBaseDate).TotalSeconds;

            return 0;
        }

        public static long ToUnixTimeStamp(this DateTime dateTime) => (long)dateTime.Subtract(UnixBaseDate).TotalSeconds;

        public static DateTime FromUnixTimestamp(this long timestamp) => UnixBaseDate.AddSeconds(timestamp);
    }
}
