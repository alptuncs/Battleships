using System.Threading.Tasks;

namespace Battleships;

public class GameRunner
{
    readonly Game game;

    public Game Game => game;
    private bool Paused { get; set; }

    public GameRunner(Game game)
    {
        this.game = game;
    }

    public async Task Play()
    {
        game.Initialize();

        await Task.Run(() =>
        {
            while (game.ShouldRun() && !Paused)
            {
                game.RenderGame();
            }
        });

        game.RenderGame();
    }

    public void PauseGame() =>
        Paused = true;
}
