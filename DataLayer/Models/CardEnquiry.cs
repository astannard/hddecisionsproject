using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    [Table("CardEnquiries")]
    public class CardEnquiry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public decimal AnnualIncome { get; set; }
        public DateTime Dob { get; set; }
        public String CardType { get; set; }

    }
}
