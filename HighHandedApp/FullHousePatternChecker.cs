using System;

namespace HighHandedApp
{
    /// <summary>
    /// Definition of all character patterns which match the FULLHOUSE pattern
    /// </summary>
    /// <remarks>
    /// Since the FULLHOUSE pattern actually contains PAIR and THREEOFAKIND as sub-patterns
    /// we do not subclass PatternCheckerBase, but implement our own CheckHand
    /// </remarks>
    public class FullHousePatternChecker: IPatternChecker
    {
        /// <summary>
        /// Special override to handle location of PAIR and THREEOFAKIND sub-patterns,
        /// which comprise FULLHOUSE.
        /// </summary>
        /// <param name="hand">String containing the poker hand to be processed</param>
        /// <param name="exclude">Required in definition of <see cref="IPatternChecker"/></param>
        /// <returns>Indication of whether FULLHOUSE pattern was located, otherwise -1</returns>
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