using CardenceLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgeCalcTests
{



    [TestClass]
    public class AgeCalcTests
    {
        [TestMethod]
        public void TestNotHadBirthdayThisYear()
        {
            Assert.AreEqual(17, AgeCalculator.HowOldAmI(new System.DateTime(2002 ,3 ,10), new System.DateTime(2020, 2, 10)));
            Assert.AreEqual(17, AgeCalculator.HowOldAmI(new System.DateTime(2002, 3, 10), new System.DateTime(2020, 3,  9)));
        }


        [TestMethod]
        public void TestHadBirthdayThisYear()
        {
            Assert.AreEqual(18, AgeCalculator.HowOldAmI(new System.DateTime(2002, 3, 10), new System.DateTime(2020, 3, 11)));
            Assert.AreEqual(18, AgeCalculator.HowOldAmI(new System.DateTime(2002, 3, 10), new System.DateTime(2020, 4, 9)));
        }


        [TestMethod]
        public void TestItsMyBirthday()
        {
            Assert.AreEqual(18, AgeCalculator.HowOldAmI(new System.DateTime(2002, 3, 10), new System.DateTime(2020, 3, 10, 12, 12, 12)));
        }


    }
}
