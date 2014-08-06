using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MislakaInterface
{
    class Common
    {
        public static DateTime? ConvertDate(string str)
        {
            DateTime date;
            if (DateTime.TryParseExact(str, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else
                return null;
        }

        public static DateTime? ConvertDatetime(string str)
        {
            DateTime date;
            if (DateTime.TryParseExact(str, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else
                return null;
        }

        public static DateTime? ConvertDateMonth(string str)
        {
            DateTime date;
            str += "01"; // Adding the 1st day of the month
            if (DateTime.TryParseExact(str, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else
                return null;
        }

    }
}
