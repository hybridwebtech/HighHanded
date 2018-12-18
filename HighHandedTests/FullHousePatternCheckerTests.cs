using HighHandedApp;
using NUnit.Framework;

namespace HighHandedTests
{
    [TestFixture]
    public class FullHousePatternCheckerTests
    {
        [Test]
        public void Test_With_No_Pair_Or_Three()
        {
            var checker = new FullHousePatternChecker();
            
            Assert.AreEqual( -1, checker.CheckHand( "AKQJT" ) );
        }
        
        [Test]
        public void Test_With_Pair_But_No_Three()
        {
            var checker = new FullHousePatternChecker();
            
            Assert.AreEqual( -1, checker.CheckHand( "AAKQJ" ) );
        }
        
        [Test]
        public void Test_With_Three_But_No_Pair()
        {
            var checker = new FullHousePatternChecker();
            
            Assert.AreEqual( -1, checker.CheckHand( "AAAKQ" ) );
        }
        
        [Test]
        public void Test_With_Pair_And_Three()
        {
            var checker = new FullHousePatternChecker();
            
            Assert.AreEqual( 11, checker.CheckHand( "AAKKK" ) );
        }
        
        [Test]
        public void Test_With_Three_And_Pair()
        {
            var checker = new FullHousePatternChecker();
            
            Assert.AreEqual( 12, checker.CheckHand( "AAAKK" ) );
        }        
    }
}