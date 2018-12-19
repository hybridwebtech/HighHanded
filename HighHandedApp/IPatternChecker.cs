namespace HighHandedApp
{
    /// <summary>
    /// Define interface that all pattern checker classes must implement
    /// </summary>
    public interface IPatternChecker
    {
        /// <summary>
        /// Check a hand for a matching pattern
        /// </summary>
        /// <param name="hand">String containing poker hand to be checked</param>
        /// <param name="exclude">Index of a sub-pattern to be ignored</param>
        /// <returns>Zero or greater if a match was detected, -1 otherwise</returns>
        int CheckHand( string hand, int exclude = -1 );
    }
}