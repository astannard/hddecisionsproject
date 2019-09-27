using System;

namespace CardenceLogic
{


    public static class CardApplicationProcessor
    {
        public static CardType ProcessApplication(ApplicantDetailsModel model)
        {
            if (model.Age < 18)
                return CardType.None;

            //Put this in explicitly so that if the order is refactored the lagic stays true
            if (model.Age >= 18 && model.AnnualIncome < 30000m)
                return CardType.Vanquis;

            if (model.Age >= 18 && model.AnnualIncome >= 30000m)
                return CardType.Barclaycard;


            return CardType.None;
        }
    }

    public class ApplicantDetailsModel
    {
        public decimal AnnualIncome { get; set; }
        public int Age { get; set; }
    }

    public enum CardType
    {
        Barclaycard,
        Vanquis,
        None
    }

}
