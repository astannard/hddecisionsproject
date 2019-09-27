using System;
using System.ComponentModel;

namespace CardenceMVC
{
    public class CardEnquiryPostModel
    {
        [DisplayName("Date of birth")]
        public DateTime DOB { get; set; }

        //   public string AnnualIncome { get; set; }
        [DisplayName("Annual income")]
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

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }
    }
}
