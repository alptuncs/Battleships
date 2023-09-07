using NUnit.Framework;
using Shouldly;

namespace Board_Tests;

[TestFixture]
public class GameManagerUnitTests : Spec
{
    [Test]
    public void After_initialization_game_asks_for_coordinates()
    {
        var game = GiveMe.AGameManager();

        game.Initialize();

        game.Message.ShouldBe("\n\nPlease enter the coordinate (E.g. A,7)");
    }

    [Test]
    public void Game_ends_when_player_is_out_of_lives()
    {
        var game = GiveMe.AGameManager();
        game.Initialize();
        game.SetPlayerLives(2);

        game.UpdateGame(true, "A,1");
        game.UpdateGame(true, "A,1");

        game.Message.ShouldBe("Out of lives...");
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

        game.Message.ShouldBe("You won !");
    }
}
