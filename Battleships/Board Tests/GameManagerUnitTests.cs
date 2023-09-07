using Battleships;
using NUnit.Framework;

namespace Board_Tests;

[TestFixture]
public class GameManagerUnitTests : Spec
{
    [Test]
    public void After_initialization_game_asks_for_coordinates()
    {
        var game = GiveMe.AGameManager();

        game.Initialize();

        Assert.AreEqual("\n\nPlease enter the coordinate (E.g. A,7)", game.Message, game.Message);
    }

    [Test]
    public void Game_ends_when_player_is_out_of_lives()
    {
        var game = GiveMe.AGameManager();
        game.Initialize();
        game.SetPlayerLives(2);

        game.UpdateGame(true, "A,1");
        game.UpdateGame(true, "A,1");

        Assert.AreEqual("Out of lives...", game.Message, game.Message);
    }

    [Test]
    public void Game_ends_when_all_targets_are_hit()
    {
        var game = GiveMe.AGameManager(targetList: GiveMe.ATargetList(1));
        game.Initialize();

        game.UpdateGame(true, "D,5");
        game.UpdateGame(true, "H,3");
        game.UpdateGame(true, "H,7");
        game.UpdateGame(true, "J,8");

        Assert.AreEqual("You won !", game.Message, game.Message);
    }
}
