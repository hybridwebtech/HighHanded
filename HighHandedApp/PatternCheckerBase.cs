using System;
using System.Collections.Generic;

namespace HighHandedApp
{
    /// <summary>
    /// PatternCheckerBase - base class for all Pattern Checker classes.
    /// All pattern checker classes have common functionality: iterate
    /// over all defined patterns and check each pattern for a match in the input hand.
    /// This functionality is captured in the base class
    /// </summary>
    public class PatternCheckerBase: IPatternChecker
    {
        protected List<string> _patterns = new List<string>();
        
        /// <summary>
        /// Look for a match of one of the pre-defined patterns in
        /// the specified hand.
        /// </summary>
        /// <param name="hand">The input hand</param>
        /// <param name="exclude">An exlusion code, to be ignored if encountered during iteration</param>
        /// <returns>A code, which if zero or greater, indicates that a match was found, and what was matched.
        /// Basically an index into the pattern list.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">If the input hand is null or whitespace or less than five characters</exception>
        /// <exception cref="Exception">If the pattern list has not been initialized</exception>
        /// <remarks>Exclusion is used in circumstances where a smaller length pattern could be
        /// located in a larger pattern, and we have already identified the smaller pattern.
        /// </remarks>
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
                if ( exclude >= 0 && i == exclude )
                {
                    continue;
                }
                
                if ( hand.Contains( _patterns[i] ) )
                {
                    return i;
                }
            }

            return -1;
        }
    }
}