using System;

namespace Cardence
{
    public class CardEnquiryPostModel
    {
        public DateTime DOB { get; set; }

     //   public string AnnualIncome { get; set; }

        public string Income { get; set; }

        public decimal AnnualIncomeAsDecimal { get
            {
                decimal income = 0m;
                if (!String.IsNullOrWhiteSpace(Income))
                {
                    if (Decimal.TryParse(Income, out income))
                    {
                        return income;
                    }
                }
                return 0m;
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
