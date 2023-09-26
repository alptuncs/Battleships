namespace Battleships;

internal class Program
{
    static void Main(string[] args)
    {
        GameRunner gameSession = new GameRunner(new GameManagerFactory().Create(new AsciiGameUserInterface<IBattleshipGameObjectFactory>(new SystemConsole(), 10, 10, new AsciiBattleShipGameObjectFactory(), new ConsoleGameInputController())));

        gameSession.Play();
    }
}
