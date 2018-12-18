using HighHandedApp;
using NUnit.Framework;

namespace HighHandedTests
{
    [TestFixture]
    public class StraightPatternCheckerTests
    {
        [Test]
        public void Test_With_Duplicate_Card()
        {
            var checker = new StraightPatternChecker();
            
            Assert.AreEqual( -1, checker.CheckHand( "65433" ) );
            Assert.AreEqual( -1, checker.CheckHand( "66543" ) );
        }
        
        [Test]
        public void Test_With_Reversed_Straight_Should_Return_NoMatch()
        {
            var checker = new StraightPatternChecker();
            
            Assert.AreEqual( -1, checker.CheckHand( "23456" ) );
        }
        
        [Test]
        public void Test_Lowest_Straight_Should_Return_Lowest_Match()
        {
            var checker = new StraightPatternChecker();
            
            Assert.AreEqual( 0, checker.CheckHand( "5432*" ) );
        }
        
        [Test]
        public void Test_Highest_Straight_Should_Return_Highest_Match()
        {
            var checker = new StraightPatternChecker();
            
            Assert.AreEqual( 9, checker.CheckHand( "AKQJT" ) );
        }        
    }
}