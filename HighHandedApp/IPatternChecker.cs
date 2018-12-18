namespace HighHandedApp
{
    public interface IPatternChecker
    {
        int CheckHand( string hand, int exclude = -1 );
    }
}