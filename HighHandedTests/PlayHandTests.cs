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
            var rating = PlayHand.GetHandRating( "65432" );
        }
        
        [Test]
        public void Test_With_Two_Valid_Hands_Input()
        {
            var play = new PlayHand();

            Assert.AreEqual( "FULLHOUSE STRAIGHT a", play.Play( "AAKKK 23456" ) );
            
            Assert.AreEqual( "PAIR PAIR b", play.Play( "KA225 33A47" ) );
            
            Assert.AreEqual( "TWOPAIR THREEOFAKIND a", play.Play( "AA225 44465" ) );
            
            Assert.AreEqual( "PAIR PAIR ab", play.Play( "TT4A2 TTA89" ) );
                        
            Assert.AreEqual( "PAIR PAIR a", play.Play( "QQ2AT QQT2J" ) );
        }

        [Test]
        public void Test_With_Wildcards()
        {
            var play = new PlayHand();
            
            Assert.AreEqual( "STRAIGHT STRAIGHT b", play.Play( "A345* 254*6" ) );
        }

        [Test]
        public void Test_SortHand()
        {
            PlayHand.SortHand( "23456" );
        }
    }
}