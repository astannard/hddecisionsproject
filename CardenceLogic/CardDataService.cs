using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.Extensions.Logging;
using CardenceLogic.Models;

namespace CardenceLogic
{
    public class CardDataService : ICardDataService
    {
        private  DataContext _ctx;
        private readonly ILogger<CardDataService> _logger;

        public CardDataService(ILogger<CardDataService> logger, DataContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }


        public List<DailyUsage> GetUsageOverTime()
        {
            var usageStats = _ctx.CardEnquiries
            .GroupBy(x => x.CreatedDate.Date)
            .Select(x => new DailyUsage
            {
                Useage = x.Count(),
                Day = (DateTime)x.Key
            }).OrderByDescending(x => x.Day).ToList();

            return usageStats;
        }


        public CardDetails ProcessApplication(decimal income, DateTime dob, string firstname, string lastname)
        {

            var cardType = CardApplicationProcessor.ProcessApplication(new ApplicantDetailsModel
            {
                Age = AgeCalculator.HowOldAmI(dob),
                AnnualIncome = income
            });
            try
            {
                _ctx.CardEnquiries.Add(new DataLayer.Models.CardEnquiry
                {
                    AnnualIncome = income,
                    CardType = cardType.ToString(),
                    CreatedDate = DateTime.Now,
                    Dob = dob,
                    FirstName = firstname,
                    LastName = lastname
                });
                _ctx.SaveChanges();
            }
            catch(Exception e)
            {
                _logger.LogError($"Error saving data occured due to {e.Message}");
            }
            
            return GetCardDetails(cardType);

        }

        private CardDetails GetCardDetails(CardType card)
        {
            var cardDetails = new CardDetails { Card = card.ToString() };

            switch (card)
            {
                case CardType.None:
                    cardDetails.CardDisplay = "no credit cards are available";
                    break;
                case CardType.Vanquis:
                    cardDetails.CardDisplay = "Vanquis";
                    cardDetails.CardPromo = "easy to get accepted and a reasonable APR";
                    cardDetails.CardAPR = "17.9% APR";
                    break;
                case CardType.Barclaycard:
                    cardDetails.CardDisplay = "Barclaycard";
                    cardDetails.CardPromo = "a card for the more distinguished applicant offering industry leading rates";
                    cardDetails.CardAPR = "12.9% APR";
                    break;
            }

            return cardDetails;
        }


    }
}
