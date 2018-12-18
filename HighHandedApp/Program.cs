using System;

namespace HighHandedApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("High Hand!");

            string buffer = Console.ReadLine();
            int numHands = 0;

            if (int.TryParse(buffer, out numHands) && numHands > 0)
            {
                for (int i = 0; i < numHands; i++)
                {
                    buffer = Console.ReadLine();

                    string result = ProcessInputAsHands(buffer);
                    
                    Console.WriteLine( result );
                }
            }
            else
            {
                Console.WriteLine("Missing or invalid number of hands. Terminating");
            }
        }

        private static string ProcessInputAsHands(string input)
        {
            var playHand = new PlayHand();

            return playHand.Play(input);
        }
    }
}
