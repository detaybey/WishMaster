using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Tools
{
    public static class Sandbox
    {
        private static readonly Random random = new Random();

        public static string CurrentHourSixDigits()
        {
            return DateTime.Now.ToString("HHmmss");
        }

        public static string CurrentDayTwoDigits()
        {
            return DateTime.Now.Day.ToString("d2");
        }

        public static string CurrentMonthTwoDigits()
        {
            return DateTime.Now.Month.ToString("d2");
        }

        public static string CurrentYearFourDigits()
        {
            return DateTime.Now.Year.ToString();
        }

        public static string GenerateLongRandomNumeric()
        {
            int a = random.Next(int.MaxValue);
            long b = random.Next(int.MaxValue) ^ 1000;
            return (a + b + DateTime.Now.Ticks).ToString("D19");
        }

        public static string RandomPhoneNumber()
        {
            int p = random.Next(int.MaxValue);
            return "1800" + p.ToString("D6");
        }

        public static string RandomLUHN()
        {
            int p = random.Next(int.MaxValue);
            return p.ToString("D7").Substring(0,7);
        }
    }
}
