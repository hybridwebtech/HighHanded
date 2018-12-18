using System;
using System.Collections.Generic;

namespace HighHandedApp
{
    public class PatternCheckerBase
    {
        protected static List<string> _patterns = new List<string>();
        
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