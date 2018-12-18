using NUnit.Framework;
using HighHandedApp;

namespace HighHandedTests
{
    [TestFixture]
    public class PairPatternCheckerTests
    {
        [Test]
        public void Test_With_No_Pairs_In_Data()
        {
            var checker = new PairPatternChecker();
            
            Assert.AreEqual( -1, checker.CheckHand( "23456" ) );
            Assert.AreEqual( -1, checker.CheckHand( "AKQJT" ) );
        }
        
        [Test]
        public void Test_With_Repeat_But_No_Pairs_In_Data()
        {
            var checker = new PairPatternChecker();
            
            Assert.AreEqual( -1, checker.CheckHand( "23256" ) );
            Assert.AreEqual( -1, checker.CheckHand( "23452" ) );
            Assert.AreEqual( -1, checker.CheckHand( "AKQJA" ) );
        }

        [Test]
        public void Test_With_Single_Pair_In_Data()
        {
            var checker = new PairPatternChecker();
            
            Assert.AreEqual( 0, checker.CheckHand( "22345" ) );
            Assert.AreEqual( 0, checker.CheckHand( "34225" ) );
            Assert.AreEqual( 12, checker.CheckHand( "AA357" ) );
        }
        
        [Test]
        public void Test_With_Two_Pair_In_Data_Should_Return_Highest_Pair()
        {
            var checker = new PairPatternChecker();
            
            Assert.AreEqual( 1, checker.CheckHand( "22335" ) );
            Assert.AreEqual( 1, checker.CheckHand( "33225" ) );
            Assert.AreEqual( 12, checker.CheckHand( "AAKK7" ) );
            Assert.AreEqual( 12, checker.CheckHand( "KKAA7" ) );
        }

        [Test]
        public void Test_GetPairStringByIndex_With_InvalidIndex_Should_Return_Empty_String()
        {
            var checker = new PairPatternChecker();

            Assert.AreEqual("", checker.GetPairStringByIndex( -1 ));
            
            Assert.AreEqual("", checker.GetPairStringByIndex( 13 ));
        }
        
        [Test]
        public void Test_GetPairStringByIndex_With_ValidIndex_Should_Return_Valid_Pair_String()
        {
            var checker = new PairPatternChecker();

            Assert.AreEqual("22", checker.GetPairStringByIndex( 0 ));
            
            Assert.AreEqual("AA", checker.GetPairStringByIndex( 12 ));
        }        
    }
}