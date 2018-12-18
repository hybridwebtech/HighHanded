using NUnit.Framework;
using HighHandedApp;

namespace Tests
{
    public class TestPlayHand
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Null_Input()
        {
            var playHand = new PlayHand();

            string result = playHand.Play(null);
            
            Assert.AreEqual( PlayHand.INVALID_INPUT_MSG, result);
        }

        [Test]
        public void Test_Empty_Input()
        {
            var playHand = new PlayHand();

            string result = playHand.Play("");
            
            Assert.AreEqual( PlayHand.INVALID_INPUT_MSG, result);            
        }

        [Test]
        public void Test_All_Whitespace()
        {
            var playHand = new PlayHand();

            string result = playHand.Play("");
            
            Assert.AreEqual( PlayHand.INVALID_INPUT_MSG, result);                        
        }

        [Test]
        public void Test_Too_Few_Characters()
        {
            var playHand = new PlayHand();

            string result = playHand.Play("12345678");
            
            Assert.AreEqual( PlayHand.INSUFFICIENT_DATA_MSG, result);                                    
        }
        
        [Test]
        public void Test_Too_Many_Characters()
        {
            var playHand = new PlayHand();

            string result = playHand.Play("123456789ABC");
            
            Assert.AreEqual( PlayHand.INSUFFICIENT_DATA_MSG, result);                                    
        }
        
        [Test]
        public void Test_Cannot_Tokenize_Input()
        {
            var playHand = new PlayHand();

            string result = playHand.Play("123456789AB");
            
            Assert.AreEqual( PlayHand.TWO_HANDS_BETTER_THAN_ONE_MSG, result);                                    
        }
        
        [Test]
        public void Test_Too_Many_Tokens()
        {
            var playHand = new PlayHand();

            string result = playHand.Play("1234 678 AB");
            
            Assert.AreEqual( PlayHand.AMBIGUOUS_INPUT_MSG, result);                                    
        }
        
        [Test]
        public void Test_Unsymmetric_Tokens()
        {
            var playHand = new PlayHand();

            string result = playHand.Play("123456 1234");
            
            Assert.AreEqual( PlayHand.MALFORMED_INPUT_MSG, result);                                    
        }

        [Test]
        public void Test_IsValid_Hand_With_Illegal_Input()
        {
            Assert.IsFalse(PlayHand.IsValidHand("1234%"));
        }
        
        [Test]
        public void Test_IsValid_Hand_With_Legal_Input()
        {
            Assert.IsTrue(PlayHand.IsValidHand("*2345"));
            Assert.IsTrue(PlayHand.IsValidHand("AAKKK"));
        }        
        
        [Test]
        public void Test_Illegal_Charaters()
        {
            var playHand = new PlayHand();

            string result = playHand.Play("*2345 *234%");
            
            Assert.AreEqual( PlayHand.ILLEGAL_INPUT_MSG, result);                                    
        }
    }
}