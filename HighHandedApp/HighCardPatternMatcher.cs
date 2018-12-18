using System;
using System.Collections.Generic;

namespace HighHandedApp
{
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
        
        public int CheckHand( string hand )
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