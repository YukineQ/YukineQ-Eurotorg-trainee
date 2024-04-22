using System;

namespace Eurotorg_trainee.Helpers
{
    public class DateConveter
    {
        public static string Convert(DateTime dateToConver, string format = "yyyy-MM-dd")
        {
            return dateToConver.ToString(format);
        }
    }
}
