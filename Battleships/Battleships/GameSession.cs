namespace Battleships;

public class GameSession
{
    GameManager gameManager;

    public GameManager GameManager => gameManager;

    public GameSession(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void Play()
    {
        gameManager.Initialize();

        while (gameManager.ShouldRun())
        {
            gameManager.RenderGame();
        }

        gameManager.RenderGame();
    }
}
