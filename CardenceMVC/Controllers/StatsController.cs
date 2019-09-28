using System;
using CardenceLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CardenceMVC.Controllers
{
    public class StatsController : Controller
    {
        private readonly ILogger<StatsController> _logger;
        private readonly ICardDataService _cardDataService;

        public StatsController(ILogger<StatsController> logger, ICardDataService cardDataService)
        {
            _logger = logger;
            _cardDataService = cardDataService;
        }


        public IActionResult Index()
        {
            var stats = _cardDataService.GetUsageOverTime();
            return View(stats);
        }
    }
}
