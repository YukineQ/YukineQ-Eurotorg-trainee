using Eurotorg_trainee.Helpers;
using System;

namespace Eurotorg_trainee.Service
{
    public enum Periodicity_
    {
        EVERYDAY,
        EVERYMONTH
    }

    public class ExRatesOptions
    {
        public static (string, string) Periodicity(Periodicity_ periodicity) => ("periodicity", periodicity.ToString("D"));

        public static (string, string) OnDate(DateTime date) => ("onDate", DateToString.Convert(date));

        private static (string, string) StartDate(DateTime startDate) => ("startDate", DateToString.Convert(startDate));

        private static (string, string) EndDate(DateTime endDate) => ("endDate", DateToString.Convert(endDate));

        public static (string, string)[] DynamicsOptions(DateTime endDate) 
        {
            var startDate = endDate.AddDays(-364);

            return new (string, string)[]
            {
                StartDate(startDate),
                EndDate(endDate)
            };
        }

        public static (string, string)[] Default() => new (string, string)[]
        {
            Periodicity(Periodicity_.EVERYDAY),
        };
    }
}
