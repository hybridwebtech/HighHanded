using System;

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

            string handA = hands[0];
            string handB = hands[1];

            if (handA.Length != 5 || handB.Length != 5)
            {
                return MALFORMED_INPUT_MSG;
            }

            if (!IsValidHand(handA) || !IsValidHand(handB))
            {
                return ILLEGAL_INPUT_MSG;
            }
            
            throw new NotImplementedException();
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
    }
}