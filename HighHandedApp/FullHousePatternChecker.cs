using System;

namespace HighHandedApp
{
    public class FullHousePatternChecker: IPatternChecker
    {
        public int CheckHand( string hand, int exclude = -1 )
        {
            var threeChecker = new ThreeOfAKindPatternChecker();

            int triple1 = threeChecker.CheckHand( hand );
             
            if ( triple1 >= 0 )
            {
                var pairChecker = new PairPatternChecker();

                int pair1 = pairChecker.CheckHand( hand, triple1 );

                if ( pair1 >= 0 )
                {
                    return triple1;
                }
            }

            return -1;            
        }
    }
}