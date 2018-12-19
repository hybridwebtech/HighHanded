using System;
using System.Collections.Generic;

namespace HighHandedApp
{
    public class PlayHand
    {
        public static string INVALID_INPUT_MSG 
            = "Invalid input: null or empty string";

        public static string INSUFFICIENT_DATA_MSG
            = "Input data must contain exactly eleven characters";
        
        public static string TWO_HANDS_BETTER_THAN_ONE_MSG 
            = "Two hands must be specified, only one was detected";

        public static string AMBIGUOUS_INPUT_MSG
            = "Ambiguous input: more than two hands detected";

        public static string MALFORMED_INPUT_MSG
            = "Malformed input: both hands must contain five cards.";

        public static string ILLEGAL_INPUT_MSG
            = "Illegal character in hand";

        public static string LegalCharacters = "*23456789TJQKA";
                    
        public string Play(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return INVALID_INPUT_MSG;
            }

            if (input.Length != 11)
            {
                return INSUFFICIENT_DATA_MSG;
            }

            string[] hands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (hands.Length < 2)
            {
                return TWO_HANDS_BETTER_THAN_ONE_MSG;
            }
            else if (hands.Length > 2)
            {
                return AMBIGUOUS_INPUT_MSG;
            }

            string handA = SortHand( hands[0].ToUpper() );
            string handB = SortHand( hands[1].ToUpper() );

            if (handA.Length != 5 || handB.Length != 5)
            {
                return MALFORMED_INPUT_MSG;
            }

            if (!IsValidHand(handA) || !IsValidHand(handB))
            {
                return ILLEGAL_INPUT_MSG;
            }

            Tuple<HandRating, int> handARating = GetHandRating( handA );
            Tuple<HandRating, int> handBRating = GetHandRating( handB );

            string result = handARating.Item1.ToString() + " " + handBRating.Item1.ToString();

            return result;
        }

        public static bool IsValidHand(string hand)
        {
            foreach (var c in hand)
            {
                if (!LegalCharacters.Contains(c))
                    return false;
            }

            return true;
        }

        public static string SortHand( string unsorted )
        {
            List<char>[] cards = new List<char>[LegalCharacters.Length];
            string sorted = "";

            for ( int i = 0; i < LegalCharacters.Length; i++ )
            {
                cards[i] = new List<char>();
            }

            foreach ( char card in unsorted )
            {
                int index = LegalCharacters.IndexOf( card );

                cards[index].Add( card );
            }

            for ( int i = cards.Length - 1; i >= 0; i-- )
            {
                foreach ( char ch in cards[i] )
                {
                    sorted += ch;
                }
            }

            return sorted;
        }

        private static List<Tuple<HandRating, IPatternChecker>> _handCheckers =
            new List<Tuple<HandRating, IPatternChecker>>()
            {
                new Tuple<HandRating, IPatternChecker>( HandRating.FOUROFAKIND, new FourOfAKindPatternChecker() ),
                new Tuple<HandRating, IPatternChecker>( HandRating.FULLHOUSE, new FullHousePatternChecker()),
                new Tuple<HandRating, IPatternChecker>( HandRating.STRAIGHT, new StraightPatternChecker()),
                new Tuple<HandRating, IPatternChecker>( HandRating.THREEOFAKIND, new ThreeOfAKindPatternChecker()),
                new Tuple<HandRating, IPatternChecker>( HandRating.TWOPAIR, new TwoPairPatternChecker()),
                new Tuple<HandRating, IPatternChecker>( HandRating.PAIR, new PairPatternChecker()),
                new Tuple<HandRating, IPatternChecker>( HandRating.HIGHCARD, new HighCardPatternMatcher()),
            };

        public static Tuple<HandRating,int> GetHandRating( string hand )
        {
            IPatternChecker checker = new FourOfAKindPatternChecker();
            var result = checker.CheckHand( hand );
            if ( result >= 0 )
                return new Tuple<HandRating, int>( HandRating.FOUROFAKIND, result );
            
            checker = new FullHousePatternChecker();
            result = checker.CheckHand( hand );
            if ( result >= 0 )
                return new Tuple<HandRating, int>( HandRating.FULLHOUSE, result );
            
            checker = new StraightPatternChecker();
            result = checker.CheckHand( hand );
            if ( result >= 0 )
                return new Tuple<HandRating, int>( HandRating.STRAIGHT, result );
            
            checker = new ThreeOfAKindPatternChecker();
            result = checker.CheckHand( hand );
            if ( result >= 0 )
                return new Tuple<HandRating, int>( HandRating.THREEOFAKIND, result );
            
            checker = new TwoPairPatternChecker();
            result = checker.CheckHand( hand );
            if ( result >= 0 )
                return new Tuple<HandRating, int>( HandRating.TWOPAIR, result );
            
            checker = new PairPatternChecker();
            result = checker.CheckHand( hand );
            if ( result >= 0 )
                return new Tuple<HandRating, int>( HandRating.PAIR, result );
            
            checker = new HighCardPatternMatcher();
            result = checker.CheckHand( hand );
            if ( result >= 0 )
                return new Tuple<HandRating, int>( HandRating.HIGHCARD, result );            
            
//            foreach ( var patternTuple in _handCheckers )
//            {
//                int result = patternTuple.Item2.CheckHand( hand ); 
//                if ( result >= 0 )
//                {
//                    return new Tuple<HandRating, int>(patternTuple.Item1, result);
//                }
//            }

            return new Tuple<HandRating, int>( HandRating.NONE, -1 );
        }
    }
}