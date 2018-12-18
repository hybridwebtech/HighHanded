using System;
using System.Collections.Generic;

namespace HighHandedApp
{
    public class FourOfAKindPatternChecker
    {
        private static List<string> _patterns = new List<string>
        {
            "2222", "3333", "4444", "5555", "6666", "7777", "8888", "9999", "TTTT", "JJJJ", "QQQQ", "KKKK", "AAAA"
        };
        
        public static int CheckHand( string hand )
        {
            if ( string.IsNullOrWhiteSpace( hand ) || hand.Length != 5 )
            {
                throw new ArgumentOutOfRangeException();
            }

            for ( int i = 0; i < _patterns.Count; i++ )
            {
                if ( hand.Contains( _patterns[i] ) )
                {
                    return i;
                }
            }

            return -1;
        }
    }
}