using System.Collections.Generic;
using HighHandedApp;

namespace HighHandedApp
{
    public class PairPatternChecker : PatternCheckerBase
    {
        public PairPatternChecker()
        {
            _patterns = new List<string>
            {
                "22", "33", "44", "55", "66", "77", "88", "99", "TT", "JJ", "QQ", "KK", "AA"
            };
        }
    }
}