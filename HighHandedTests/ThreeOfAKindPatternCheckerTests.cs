using HighHandedApp;
using NUnit.Framework;

namespace HighHandedTests
{
    [TestFixture]
    public class ThreeOfAKindPatternCheckerTests
    {
        [Test]
        public void Test_With_No_Triple_In_Data()
        {            
            var checker = new ThreeOfAKindPatternChecker();
            
            Assert.AreEqual( -1, checker.CheckHand( "23456" ) );
            Assert.AreEqual( -1, checker.CheckHand( "AKQJT" ) );
        }
        
        [Test]
        public void Test_With_Repeat_But_No_Triple_In_Data()
        {
            var checker = new ThreeOfAKindPatternChecker();
            
            Assert.AreEqual( -1, checker.CheckHand( "23252" ) );
            Assert.AreEqual( -1, checker.CheckHand( "23422" ) );
            Assert.AreEqual( -1, checker.CheckHand( "AKAJA" ) );
        }

        [Test]
        public void Test_With_Triple_In_Data()
        {
            var checker = new ThreeOfAKindPatternChecker();
            
            Assert.AreEqual( 0, checker.CheckHand( "22245" ) );
            Assert.AreEqual( 0, checker.CheckHand( "32225" ) );
            Assert.AreEqual( 12, checker.CheckHand( "AAA57" ) );
        }
        
        [Test]
        public void Test_With_Triple_and_Pair_In_Data_Should_Return_Triple()
        {
            var checker = new ThreeOfAKindPatternChecker();
            
            Assert.AreEqual( 1, checker.CheckHand( "22333" ) );
            Assert.AreEqual( 0, checker.CheckHand( "33222" ) );
            Assert.AreEqual( 12, checker.CheckHand( "AAAK7" ) );
            Assert.AreEqual( 12, checker.CheckHand( "KKAAA" ) );
            Assert.AreEqual( 12, checker.CheckHand( "KAAAK" ) );
        }
    }
}