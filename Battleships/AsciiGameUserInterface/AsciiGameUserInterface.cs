using System.Text;

namespace Battleships;

public class AsciiGameUserInterface<TGameObjectFactory> : IGameUserInterface<TGameObjectFactory> where TGameObjectFactory : IGameObjectFactory
{
    private readonly IConsole console;
    private readonly char[,] screen;

    private string message;

    public List<StatusField> Status => new();

    public TGameObjectFactory GameObjectFactory { get; }
    public IGameInputController GameInputController { get; }

    public AsciiGameUserInterface(IConsole console, int width, int height, TGameObjectFactory gameObjectFactory, IBattleShipInputController gameInputController)
    {
        this.console = console;
        this.screen = new char[width, height];

        GameObjectFactory = gameObjectFactory;
        GameInputController = gameInputController;

        console.SetOutputEncoding(Encoding.GetEncoding("iso-8859-1"));
    }

    public void Draw(IGameObject gameObject, Coordinate coordinate)
    {
        if (gameObject is not IAsciiGameObject asciiGameObject) { return; }

        var graphics = asciiGameObject.Graphics;

        for (int x = 0; x < graphics.GetLength(0); x++)
        {
            for (int y = 0; y < graphics.GetLength(1); y++)
            {
                screen[x + coordinate.XPos, y + coordinate.YPos] = graphics[x, y];
            }
        }
    }

    public void ShowMessage(string text) =>
        message = text;

    public void Paint()
    {
        console.Clear();

        console.WriteLine(message);

        for (int x = 0; x < screen.GetLength(0); x++)
        {
            for (int y = 0; y < screen.GetLength(1); y++)
            {
                if (screen[x, y] is default(char)) { continue; }

                console.Write(screen[x, y]);
                //screen[x, y] = default;
            }

            console.WriteLine("");
        }

        console.WriteLine(string.Join(" | ", Status.Select(s => $"{s.Label} : {s.Value}")));
    }
}
