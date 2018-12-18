using System;
using HighHandedApp;
using NUnit.Framework;

namespace HighHandedTests
{
    [TestFixture]
    public class FourOfAKindPatternCheckerTests
    {
        [Test]
        public void Test_Null_Input()
        {
            var checker = new FourOfAKindPatternChecker();
            
            Assert.Throws<ArgumentOutOfRangeException>( () => checker.CheckHand( null ));
            Assert.Throws<ArgumentOutOfRangeException>( () => checker.CheckHand( "" ));
        }
        
        [Test]
        public void Test_Wrong_Argument_Size()
        {
            var checker = new FourOfAKindPatternChecker();
            
            Assert.Throws<ArgumentOutOfRangeException>( () => checker.CheckHand( "1234" ));
            Assert.Throws<ArgumentOutOfRangeException>( () => checker.CheckHand( "123456" ));
        }

        [Test]
        public void Test_With_Unsupported_Patterns()
        {
            var checker = new FourOfAKindPatternChecker();
            
            Assert.AreEqual(-1, checker.CheckHand( "RRRR2" ));
            Assert.AreEqual(-1, checker.CheckHand( "AAA22" ));
        }
        
        [Test]
        public void Test_With_Supported_Patterns()
        {
            var checker = new FourOfAKindPatternChecker();
            
            Assert.AreEqual(0, checker.CheckHand( "2222*" ));
            Assert.AreEqual(0, checker.CheckHand( "*2222" ));
            
            Assert.AreEqual(1, checker.CheckHand( "3333*" ));
            Assert.AreEqual(1, checker.CheckHand( "*3333" ));
            
            Assert.AreEqual(2, checker.CheckHand( "4444*" ));
            Assert.AreEqual(2, checker.CheckHand( "*4444" ));
            
            Assert.AreEqual(3, checker.CheckHand( "5555*" ));
            Assert.AreEqual(3, checker.CheckHand( "*5555" ));
            
            Assert.AreEqual(4, checker.CheckHand( "6666*" ));
            Assert.AreEqual(4, checker.CheckHand( "*6666" ));
            
            Assert.AreEqual(5, checker.CheckHand( "7777*" ));
            Assert.AreEqual(5, checker.CheckHand( "*7777" ));
            
            Assert.AreEqual(6, checker.CheckHand( "8888*" ));
            Assert.AreEqual(6, checker.CheckHand( "*8888" ));
            
            Assert.AreEqual(7, checker.CheckHand( "9999*" ));
            Assert.AreEqual(7, checker.CheckHand( "*9999" ));
            
            Assert.AreEqual(8, checker.CheckHand( "TTTT*" ));
            Assert.AreEqual(8, checker.CheckHand( "*TTTT" ));
            
            Assert.AreEqual(9, checker.CheckHand( "JJJJ*" ));
            Assert.AreEqual(9, checker.CheckHand( "*JJJJ" ));
            
            Assert.AreEqual(10, checker.CheckHand( "QQQQ*" ));
            Assert.AreEqual(10, checker.CheckHand( "*QQQQ" ));
            
            Assert.AreEqual(11, checker.CheckHand( "KKKK*" ));
            Assert.AreEqual(11, checker.CheckHand( "*KKKK" ));
            
            Assert.AreEqual(12, checker.CheckHand( "AAAA*" ));
            Assert.AreEqual(12, checker.CheckHand( "*AAAA" ));            
        }
    }
}