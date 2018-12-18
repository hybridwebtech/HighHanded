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
            Assert.Throws<ArgumentOutOfRangeException>( () => FourOfAKindPatternChecker.CheckHand( null ));
            Assert.Throws<ArgumentOutOfRangeException>( () => FourOfAKindPatternChecker.CheckHand( "" ));
        }
        
        [Test]
        public void Test_Wrong_Argument_Size()
        {
            Assert.Throws<ArgumentOutOfRangeException>( () => FourOfAKindPatternChecker.CheckHand( "1234" ));
            Assert.Throws<ArgumentOutOfRangeException>( () => FourOfAKindPatternChecker.CheckHand( "123456" ));
        }

        [Test]
        public void Test_With_Unsupported_Patterns()
        {
            Assert.AreEqual(-1, FourOfAKindPatternChecker.CheckHand( "RRRR2" ));
            Assert.AreEqual(-1, FourOfAKindPatternChecker.CheckHand( "AAA22" ));
        }
        
        [Test]
        public void Test_With_Supported_Patterns()
        {
            Assert.AreEqual(0, FourOfAKindPatternChecker.CheckHand( "2222*" ));
            Assert.AreEqual(0, FourOfAKindPatternChecker.CheckHand( "*2222" ));
            
            Assert.AreEqual(1, FourOfAKindPatternChecker.CheckHand( "3333*" ));
            Assert.AreEqual(1, FourOfAKindPatternChecker.CheckHand( "*3333" ));
            
            Assert.AreEqual(2, FourOfAKindPatternChecker.CheckHand( "4444*" ));
            Assert.AreEqual(2, FourOfAKindPatternChecker.CheckHand( "*4444" ));
            
            Assert.AreEqual(3, FourOfAKindPatternChecker.CheckHand( "5555*" ));
            Assert.AreEqual(3, FourOfAKindPatternChecker.CheckHand( "*5555" ));
            
            Assert.AreEqual(4, FourOfAKindPatternChecker.CheckHand( "6666*" ));
            Assert.AreEqual(4, FourOfAKindPatternChecker.CheckHand( "*6666" ));
            
            Assert.AreEqual(5, FourOfAKindPatternChecker.CheckHand( "7777*" ));
            Assert.AreEqual(5, FourOfAKindPatternChecker.CheckHand( "*7777" ));
            
            Assert.AreEqual(6, FourOfAKindPatternChecker.CheckHand( "8888*" ));
            Assert.AreEqual(6, FourOfAKindPatternChecker.CheckHand( "*8888" ));
            
            Assert.AreEqual(7, FourOfAKindPatternChecker.CheckHand( "9999*" ));
            Assert.AreEqual(7, FourOfAKindPatternChecker.CheckHand( "*9999" ));
            
            Assert.AreEqual(8, FourOfAKindPatternChecker.CheckHand( "TTTT*" ));
            Assert.AreEqual(8, FourOfAKindPatternChecker.CheckHand( "*TTTT" ));
            
            Assert.AreEqual(9, FourOfAKindPatternChecker.CheckHand( "JJJJ*" ));
            Assert.AreEqual(9, FourOfAKindPatternChecker.CheckHand( "*JJJJ" ));
            
            Assert.AreEqual(10, FourOfAKindPatternChecker.CheckHand( "QQQQ*" ));
            Assert.AreEqual(10, FourOfAKindPatternChecker.CheckHand( "*QQQQ" ));
            
            Assert.AreEqual(11, FourOfAKindPatternChecker.CheckHand( "KKKK*" ));
            Assert.AreEqual(11, FourOfAKindPatternChecker.CheckHand( "*KKKK" ));
            
            Assert.AreEqual(12, FourOfAKindPatternChecker.CheckHand( "AAAA*" ));
            Assert.AreEqual(12, FourOfAKindPatternChecker.CheckHand( "*AAAA" ));            
        }
    }
}