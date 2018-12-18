using System;

namespace HighHandedApp
{
    public class TwoPairPatternChecker : IPatternChecker
    {
        public int CheckHand( string hand, int exclude = -1 )
        {
            var checker = new PairPatternChecker();

            int pair1 = checker.CheckHand( hand ); 
            if ( pair1 >= 0 )
            {
                int pair2 = checker.CheckHand( hand, pair1 );

                if ( pair2 >= 0 )
                {
                    return Math.Max( pair1, pair2 );
                }
            }

            return -1;
        }
    }
}