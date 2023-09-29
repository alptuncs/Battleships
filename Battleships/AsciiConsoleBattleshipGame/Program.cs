using Battleships;

namespace AsciiConsoleBattleshipGame;

internal class Program
{
    static async Task Main(string[] args)
    {
        GameRunner gameSession = new GameRunner(new GameManagerFactory().Create(new AsciiGameUserInterface<IBattleshipGameObjectFactory>(new SystemConsole(), 10, 10, new AsciiBattleShipGameObjectFactory(), new ConsoleInputController())));

        Console.WriteLine("Test");

        await gameSession.Play();
    }
}