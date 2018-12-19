using System;
using System.Collections.Generic;

namespace HighHandedApp
{
    public class PatternCheckerBase: IPatternChecker
    {
        protected List<string> _patterns = new List<string>();
        
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