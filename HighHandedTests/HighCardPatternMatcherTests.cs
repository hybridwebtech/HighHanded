using HighHandedApp;
using NUnit.Framework;

namespace HighHandedTests
{
    [TestFixture]
    public class HighCardPatternMatcherTests
    {
        [Test]
        public void Test_Unhandled_Match()
        {
            var checker = new HighCardPatternMatcher();
            
            Assert.AreEqual( -1, checker.CheckHand( "Z2345" ) );
        }

        [Test]
        public void Test_Match_Based_On_Leading_Card()
        {
            var checker = new HighCardPatternMatcher();
            
            Assert.AreEqual( 0, checker.CheckHand( "2AKQJ" ) );
            Assert.AreEqual( 12, checker.CheckHand( "AKQJ2" ) );
        }
    }
}