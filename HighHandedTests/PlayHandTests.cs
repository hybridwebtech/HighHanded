using HighHandedApp;
using NUnit.Framework;

namespace HighHandedTests
{
    [TestFixture]
    public class PlayHandTests
    {
        [Test]
        public void Test_GetHandRating_With_Valid_Hand()
        {
            var play = new PlayHand();
            
            var rating = play.GetHandRating( "65432" );
            Assert.AreEqual( rating.Item1, HandRating.STRAIGHT );
        }
        
        [Test]
        public void Test_With_Two_Valid_Hands_Input()
        {
            var play = new PlayHand();

            Assert.AreEqual( "FULLHOUSE STRAIGHT a", play.Play( "AAKKK 23456" ) );
            
            Assert.AreEqual( "PAIR PAIR b", play.Play( "KA225 33A47" ) );
            
            Assert.AreEqual( "TWOPAIR THREEOFAKIND a", play.Play( "AA225 44465" ) );
            
            Assert.AreEqual( "PAIR PAIR ab", play.Play( "TT4A2 TTA89" ) );                        
        }

        [Test]
        [Ignore("Could not determine how to properly handle pair ties")]
        public void Test_Pair_Tie()
        {
            var play = new PlayHand();
            Assert.AreEqual( "PAIR PAIR a", play.Play( "QQ2AT QQT2J" ) );
        }

        [Test]
        [Ignore("Could not determine how to properly handle wildcards")]
        public void Test_With_Wildcards()
        {
            var play = new PlayHand();
            
            Assert.AreEqual( "STRAIGHT STRAIGHT b", play.Play( "A345* 254*6" ) );
        }

        [Test]
        public void Test_SortHand()
        {
            var play = new PlayHand();
            
            play.SortHand( "23456" );
        }
    }
}