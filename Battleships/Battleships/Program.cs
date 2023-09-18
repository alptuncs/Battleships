namespace Battleships;

internal class Program
{
    static void Main(string[] args)
    {
        GameSession gameSession = new GameSession(new GameManagerFactory().Create(new AsciiGameUserInterface<IBattleshipGameObjectFactory>(new SystemConsole(), 10, 10, new AsciiBattleShipGameObjectFactory(), new ConsoleGameInputController())));

        gameSession.Play();
    }
}
