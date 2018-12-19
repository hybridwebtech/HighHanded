using System.Collections.Generic;

namespace HighHandedApp
{
    /// <summary>
    /// Definition of all character patterns which match the STRAIGHT pattern
    /// </summary>
    public class StraightPatternChecker: PatternCheckerBase
    {
        public StraightPatternChecker() : base()
        {
            _patterns = new List<string>()
            {
                "5432*", "65432", "76543", "87654", "98765", "T9876", "JT987", "QJT98", "KQJT9", "AKQJT", 
            };
        }
    }
}