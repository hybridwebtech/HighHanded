using HighHandedApp;
using NUnit.Framework;

namespace HighHandedTests
{
    [TestFixture]
    public class TwoPairPatternCheckerTests
    {
        [Test]
        public void Test_With_No_Pairs()
        {
            var checker = new TwoPairPatternChecker();

            Assert.AreEqual( -1, checker.CheckHand( "AKQJT" ));
        }
        
        [Test]
        public void Test_With_One_Pairs()
        {
            var checker = new TwoPairPatternChecker();

            Assert.AreEqual( -1, checker.CheckHand( "AKKJT" ));
        }
        
        [Test]
        public void Test_With_Two_Pairs()
        {
            var checker = new TwoPairPatternChecker();

            Assert.AreEqual( 12, checker.CheckHand( "AAQ77" ));
        }
    }
}