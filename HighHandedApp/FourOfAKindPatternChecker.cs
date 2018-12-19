using System;
using System.Collections.Generic;

namespace HighHandedApp
{
    /// <summary>
    /// Definition of all character patterns which match the FOUROFAKIND pattern
    /// </summary>
    public class FourOfAKindPatternChecker : PatternCheckerBase
    {
        public FourOfAKindPatternChecker() : base()
        {
            _patterns = new List<string>
            {
                "2222", "3333", "4444", "5555", "6666", "7777", "8888", "9999", "TTTT", "JJJJ", "QQQQ", "KKKK", "AAAA"
            };
        }
    }
}