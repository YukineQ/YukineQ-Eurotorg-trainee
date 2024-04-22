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

        public static (string, string)[] Default() => new (string, string)[]
        {
            Periodicity(Periodicity_.EVERYDAY),
        };
    }
}
