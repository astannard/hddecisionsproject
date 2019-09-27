using CardenceLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardenceUnitTests
{



    [TestClass]
    public class CardSelectionUnitTest
    {
        [TestMethod]
        public void TestUnder18()
        {
            Assert.AreEqual(CardType.None, CardApplicationProcessor.ProcessApplication(new ApplicantDetailsModel { Age = 17, AnnualIncome = 15000.00m }));
            Assert.AreEqual(CardType.None, CardApplicationProcessor.ProcessApplication(new ApplicantDetailsModel { Age = 17, AnnualIncome = 35000.00m }));

            Assert.AreEqual(CardType.None, CardApplicationProcessor.ProcessApplication(new ApplicantDetailsModel { Age = 0, AnnualIncome = 15000.00m }));
            Assert.AreEqual(CardType.None, CardApplicationProcessor.ProcessApplication(new ApplicantDetailsModel { Age = 0, AnnualIncome = 35000.00m }));
        }


        [TestMethod]
        public void TestOver18Over30k()
        {

            Assert.AreEqual(CardType.Barclaycard, CardApplicationProcessor.ProcessApplication(new ApplicantDetailsModel { Age = 18, AnnualIncome = 30000.01m }));
            Assert.AreEqual(CardType.Barclaycard, CardApplicationProcessor.ProcessApplication(new ApplicantDetailsModel { Age = 19, AnnualIncome = 30000.01m }));

        }


        [TestMethod]
        public void TestOver18Under30k()
        {
            Assert.AreEqual(CardType.Vanquis, CardApplicationProcessor.ProcessApplication(new ApplicantDetailsModel { Age = 18, AnnualIncome = 15000.00m }));
            Assert.AreEqual(CardType.Vanquis, CardApplicationProcessor.ProcessApplication(new ApplicantDetailsModel { Age = 19, AnnualIncome = 15000.00m }));


        }


        [TestMethod]
        public void TestOver18On30k()
        {

            //I have made the decision to interpret Over 18 as 18 and Over
            //I am also interpreting over 30k as 30k and over

            Assert.AreEqual(CardType.Barclaycard, CardApplicationProcessor.ProcessApplication(new ApplicantDetailsModel { Age = 18, AnnualIncome = 30000.00m }));
            Assert.AreEqual(CardType.Barclaycard, CardApplicationProcessor.ProcessApplication(new ApplicantDetailsModel { Age = 19, AnnualIncome = 30000.00m }));

        }

    }
}
