namespace Battleships;

internal class Program
{
    static void Main(string[] args)
    {
        GameSession gameSession = new GameSession(new GameManagerFactory().Create());

        gameSession.Play();
    }
}
