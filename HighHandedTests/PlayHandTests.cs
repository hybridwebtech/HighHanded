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

            string result = play.Play( "AAKKK 23456" );
        }

        [Test]
        public void Test_SortHand()
        {
            PlayHand.SortHand( "23456" );
        }
    }
}