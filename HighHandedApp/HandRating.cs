namespace HighHandedApp
{
    /// <summary>
    /// Enumeration of the names of all recognized winning hands
    /// </summary>
    public enum HandRating
    {
        NONE = 0,
        HIGHCARD = 1,
        PAIR,
        TWOPAIR,
        THREEOFAKIND,
        STRAIGHT,
        FULLHOUSE,
        FOUROFAKIND,
    }
}