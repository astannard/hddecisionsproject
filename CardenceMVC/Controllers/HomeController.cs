using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CardenceMVC.Models;
using CardenceLogic;

namespace CardenceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICardDataService _cardDataService;

        public HomeController(ILogger<HomeController> logger, ICardDataService cardDataService)
        {
            _logger = logger;
            _cardDataService = cardDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CardEnquiryPostModel formDetails)
        {

            var result = _cardDataService.ProcessApplication(formDetails.AnnualIncomeAsDecimal, formDetails.DOB, formDetails.FirstName, formDetails.LastName);
            return View("Result", new CardEnquiryResultViewModel {
                Card=result.Card,
                CardDisplay = result.CardDisplay,
                CardAPR = result.CardAPR,
                CardPromo = result.CardPromo
            });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
