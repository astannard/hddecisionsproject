using System;
namespace CardenceLogic
{
    public static class AgeCalculator
    {
        public static int HowOldAmI(DateTime dob,  DateTime? now = null)
        {
            if (!now.HasValue)
                now = DateTime.Now;

            // now = now.HasValue ? now.Value : DateTime.Now;
            var yeardiff = now.Value.Year - dob.Year;

            if (now.Value.Month > dob.Month)
                return yeardiff;

            if (now.Value.Month < dob.Month)
                return yeardiff - 1;

            if(now.Value.Month == dob.Month)
            {
                return yeardiff - (now.Value.Day >= dob.Day ? 0 : 1 );
            }

            return -1;
        }
    }
}
