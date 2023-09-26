namespace Battleships;

public class GameRunner
{
    readonly Game game;

    public Game Game => game;

    public GameRunner(Game game)
    {
        this.game = game;
    }

    public void Play()
    {
        game.Initialize();

        while (game.ShouldRun())
        {
            game.RenderGame();
        }

        game.RenderGame();
    }
}
