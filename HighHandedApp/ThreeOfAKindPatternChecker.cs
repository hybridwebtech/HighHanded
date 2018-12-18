using System.Collections.Generic;

namespace HighHandedApp
{
    public class ThreeOfAKindPatternChecker : PatternCheckerBase
    {
        public ThreeOfAKindPatternChecker() : base()
        {
            _patterns = new List<string>
            {
                "222", "333", "444", "555", "666", "777", "888", "999", "TTT", "JJJ", "QQQ", "KKK", "AAA"
            };
        }
    }
}