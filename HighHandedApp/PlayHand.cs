using System;

namespace HighHandedApp
{
    public class PlayHand
    {
        public string Play(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Invalid input: null or empty string";
            }

            string[] hands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (hands.Length < 2)
            {
                return "Two hands must be specified, only one was detected";
            }
            else if (hands.Length > 2)
            {
                return "Ambiguous input: more than two hands detected";
            }

            string handA = hands[0];
            string handB = hands[1];

            if (handA.Length != 5 || handB.Length != 5)
            {
                return "Malformed input: both hands must contain five cards.";
            }
            
            throw new NotImplementedException();
        }
    }
}