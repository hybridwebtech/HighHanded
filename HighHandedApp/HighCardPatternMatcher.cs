using System;
using System.Collections.Generic;

namespace HighHandedApp
{
    /// <summary>
    /// Definition of all character patterns which match the HIGHCARD pattern
    /// </summary>
    public class HighCardPatternMatcher: IPatternChecker
    {
        private List<string> _patterns;

        public HighCardPatternMatcher() : base()
        {
            _patterns = new List<string>()
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A",
            };
        }
        
        /// <summary>
        /// Special override to handle the HIGHCARD pattern.
        /// Since all hands are sorted from highest to lowest card,
        /// the HIGHCARD is the first in the string, and we
        /// just need to retrieve the index of that character in the list of matches.
        /// </summary>
        /// <param name="hand">String containing a sorted poker hand</param>
        /// <param name="exclude">Not used in this pattern</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the string does not contain exactly five characters</exception>
        /// <exception cref="Exception">Thrown if the pattern list has not been initialized</exception>
        public int CheckHand( string hand, int exclude = -1 )
        {
            if ( string.IsNullOrWhiteSpace( hand ) || hand.Length != 5 )
            {
                throw new ArgumentOutOfRangeException();
            }

            if ( _patterns.Count == 0 )
            {
                throw new Exception( "Pattern list has not been initialized" );
            }

            for ( int i = _patterns.Count - 1; i >= 0; i-- )
            {
                if ( hand.StartsWith( _patterns[i] ) )
                {
                    return i;
                }
            }

            return -1;
        }        
    }
}