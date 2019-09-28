using System;
using System.Collections.Generic;
using CardenceLogic.Models;

namespace CardenceLogic
{
    public interface ICardDataService
    {

        List<DailyUsage> GetUsageOverTime();
        CardDetails ProcessApplication(decimal income, DateTime dob, string firstname, string lastname);

    }
}
