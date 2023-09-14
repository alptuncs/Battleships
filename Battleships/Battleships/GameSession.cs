namespace Battleships;

public class GameSession
{
    GameManager gameManager;

    public GameManager GameManager => gameManager;

    public GameSession(GameManager gameManager)
    {
        this.gameManager = gameManager;
        gameManager.Initialize();
    }

    public void Play()
    {
        while (gameManager.ShouldRun())
        {
            gameManager.RenderGame();
            gameManager.UpdateGame();
        }

        gameManager.RenderGame();
    }
}
