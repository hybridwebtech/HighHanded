using System.Collections.Generic;
using HighHandedApp;

namespace HighHandedApp
{
    /// <summary>
    /// Definition of all character patterns which match the PAIR pattern
    /// </summary>
    public class PairPatternChecker : PatternCheckerBase
    {
        public PairPatternChecker()
        {
            _patterns = new List<string>
            {
                "22", "33", "44", "55", "66", "77", "88", "99", "TT", "JJ", "QQ", "KK", "AA"
            };
        }

        /// <summary>
        /// Return the subpattern at the spefied index
        /// </summary>
        /// <param name="index">Index of a previously determined match</param>
        /// <returns>Matching pattern, or empty string if index is out-of-range</returns>
        /// <remarks>
        /// This method will be typically used prior to calling <see cref="PatternCheckerBase"/>.CheckHand
        /// with a non-default exclusion.
        /// </remarks>
        public string GetPairStringByIndex( int index )
        {
            if ( index >= 0 && index < _patterns.Count )
            {
                return _patterns[index];
            }

            return "";
        }
    }
}