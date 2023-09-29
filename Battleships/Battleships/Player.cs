namespace Battleships;

public class Player
{
    public int Lives { get; private set; }
    public int Score { get; private set; }

    public bool HasLives => Lives > 0;

    public Player(int lives, int score)
    {
        Lives = lives;
        Score = score;
    }

    public void IncreaseScore(int scoreIncrease) =>
        Score += scoreIncrease;

    public void DecreaseLives() =>
        Lives--;
}
