using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardenceLogic;
using CardenceLogic.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cardence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardEnquiryController : ControllerBase
    {
        private readonly DataContext _ctx;
        private readonly ILogger<CardEnquiryController> _logger;
        private readonly CardDataService _dataSrvc;
        public CardEnquiryController(ILogger<CardEnquiryController> logger, DataContext ctx, CardDataService dataService)
        {
            _logger = logger;
            _ctx = ctx;
            _dataSrvc = dataService;
        }

        [HttpPost]
        public CardDetails Post(CardEnquiryPostModel model)
        {
            return _dataSrvc.ProcessApplication(model.AnnualIncomeAsDecimal, model.DOB, model.FirstName, model.LastName);
        }



        [HttpGet]
        public List<DailyUsage> Get()
        {
            return _dataSrvc.GetUsageOverTime();

        }

    }






}
