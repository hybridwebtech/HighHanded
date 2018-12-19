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

        private static List<Tuple<HandRating, IPatternChecker>> _handCheckers 
            = new List<Tuple<HandRating, IPatternChecker>>();
        
        public PlayHand()
        {
            _handCheckers.Add( new Tuple<HandRating, IPatternChecker>( HandRating.FOUROFAKIND,
                new FourOfAKindPatternChecker() ));
            _handCheckers.Add( new Tuple<HandRating, IPatternChecker>( HandRating.FULLHOUSE, 
                new FullHousePatternChecker() ) );
            _handCheckers.Add( new Tuple<HandRating, IPatternChecker>( HandRating.STRAIGHT, 
                new StraightPatternChecker() ) );
            _handCheckers.Add( new Tuple<HandRating, IPatternChecker>( HandRating.THREEOFAKIND,
                new ThreeOfAKindPatternChecker() ) );
            _handCheckers.Add( new Tuple<HandRating, IPatternChecker>( HandRating.TWOPAIR, 
                new TwoPairPatternChecker() ) );
            _handCheckers.Add( new Tuple<HandRating, IPatternChecker>( HandRating.PAIR, 
                new PairPatternChecker() ) );
            _handCheckers.Add( new Tuple<HandRating, IPatternChecker>( HandRating.HIGHCARD, 
                new HighCardPatternMatcher() ) );
        }

        /// <summary>
        /// Evaluate both hands, determine which pattern each hand represents
        /// (i.e. High Card, Straight, etc.) and determine which hand is winning
        /// </summary>
        /// <param name="input">String containing pair of five-character poker hands</param>
        /// <returns>String containing which hand pattern was found for each hand,
        /// and which hand wins, or both hands if a tie is encountered.
        /// </returns>
        /// <remarks>
        /// This is the driver function of the poker game. Call this method to
        /// evaluate pairs of poker hands.
        /// This method performs extensive validation of its inputs; violations are returned
        /// as descriptive error messages in place of an evaluation of the poker hands. 
        /// </remarks>
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

            //
            // Isolate each poker hand
            string[] hands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (hands.Length < 2)
            {
                return TWO_HANDS_BETTER_THAN_ONE_MSG;
            }
            else if (hands.Length > 2)
            {
                return AMBIGUOUS_INPUT_MSG;
            }

            //
            // Force each hand to upper case for correct pattern matching.
            string handA = hands[0].ToUpper();
            string handB = hands[1].ToUpper();

            //
            // Each hand must have five characters, no more, no less
            if (handA.Length != 5 || handB.Length != 5)
            {
                return MALFORMED_INPUT_MSG;
            }
            
            //
            // Make sure each hand contains only the recognized poker symbols.
            if (!IsValidHand(handA) || !IsValidHand(handB))
            {
                return ILLEGAL_INPUT_MSG;
            }

            //
            // Sort both hands to decreasing card value.
            // This is required so that the strongest pattern is found
            // for each hand.
            handA = SortHand( handA );
            handB = SortHand( handB );

            //
            // Generate ratings for each hand
            Tuple<HandRating, int> handARating = GetHandRating( handA );
            Tuple<HandRating, int> handBRating = GetHandRating( handB );

            //
            // Compose the result: Name of match (if any) for each hand plus an indication
            // of which hand wins, indicated by greater strength match.
            // Note that ties are identified by both hands having the same match 
            // (e.g. both are STRAIGHT, etc.) AND both have the same pattern match index.
            // For pattern match strength, using STRAIGHT as the example,
            // "76543" would be a stronger result than "65432".
            string result = handARating.Item1.ToString() + " " + handBRating.Item1.ToString() + " ";

            if ( handARating.Item2 == handBRating.Item2 )
            {
                result += "ab";
            }
            else
            {
                result += handARating.Item2 > handBRating.Item2 ? "a" : "b";
            }

            return result;
        }

        /// <summary>
        /// Determine whether a hand is valid; i.e. all characters in the
        /// hand belong to the set of legal characters.
        /// </summary>
        /// <param name="hand">String containing hand to be validated</param>
        /// <returns>True if hand is valid, False otherwise</returns>
        public bool IsValidHand(string hand)
        {
            foreach (var c in hand)
            {
                if (!LegalCharacters.Contains(c))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Sort a poker hand into higher to lower order, left to right.
        /// E.g. "2KA3T" would be sorted to "AKT32"
        /// </summary>
        /// <param name="unsorted">The unsorted poker hand</param>
        /// <returns>Sorted poker hand</returns>
        /// <remarks>
        /// Sorting is required for correct pattern matching.
        /// Since we cannot use characterset-based collation for sorting,
        /// we implement our on sorting.
        /// </remarks>
        public string SortHand( string unsorted )
        {
            //
            // Define bins to hold instances of each recognized character.
            // One bin per legal character.
            // Since many characters can occur more than once in a hand,
            // we need to use list of character to hold an unknown
            // number of each character.
            List<char>[] cards = new List<char>[LegalCharacters.Length];
            string sorted = "";

            //
            // Initialize the bins
            for ( int i = 0; i < LegalCharacters.Length; i++ )
            {
                cards[i] = new List<char>();
            }

            //
            // Put each card/character in the poker hand into its correct bin.
            // Use the index of the character in the list of legal characters
            // to determine which bin to put the character in
            foreach ( char card in unsorted )
            {
                int index = LegalCharacters.IndexOf( card );

                cards[index].Add( card );
            }

            //
            // All sorted. Traverse the bins in reverse order
            // to compose the sorted string.
            // Reverse order iteration forces highest-to-lowest
            // occurrences of characters in the string
            // i.e. "A" is highest and must come first if it
            // was originally present, followed by "K", etc.
            for ( int i = cards.Length - 1; i >= 0; i-- )
            {
                foreach ( char ch in cards[i] )
                {
                    sorted += ch;
                }
            }

            return sorted;
        }

        /// <summary>
        /// Compute a rating for the specified poker hand.
        /// Identify which hand (i.e. HIGHCARD, STRAIGHT, etc)
        /// matches the input.
        /// </summary>
        /// <param name="hand">The sorted poker hand</param>
        /// <returns>A Tuple containing the enum of the identified poker hand, and an index of the matching pattern</returns>
        public Tuple<HandRating,int> GetHandRating( string hand )
        {
            //
            // Iterate over all defined patterns, from STRONGEST pattern to WEAKEST.
            // We do strongest to weakest because some strong patterns contain
            // weaker patterns as subsets, and we want to identify the strongest
            // pattern first.
            foreach ( var patternTuple in _handCheckers )
            {
                int result = patternTuple.Item2.CheckHand( hand ); 
                if ( result >= 0 )
                {
                    return new Tuple<HandRating, int>(patternTuple.Item1, result);
                }
            }

            //
            // If this line is reached, no pattern was identified, so return such information
            return new Tuple<HandRating, int>( HandRating.NONE, -1 );
        }
    }
}