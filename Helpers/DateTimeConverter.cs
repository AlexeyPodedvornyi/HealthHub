using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Helpers
{
    public class DateTimeConverter
    {
        static public DateOnly ConvertToDateOnly(DateTime? dateTime)
        {
            var dt = dateTime!.Value;
            return new DateOnly(dt.Year, dt.Month, dt.Day);
        }

    }
}
