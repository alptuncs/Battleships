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
    public void Game_allows_using_premade_board()
    {
        var game = GiveMe.AGameManager(board: GiveMe.ABoardManager(withShips: true), targetList: GiveMe.ATargetList(empty: true));
        
        game.Initialize();

        game.ComputerBoard.PlacedShips.ShouldBe(1);
    }

    [Test]
    public void Game_allows_placing_ships_when_given_a_premade_board()
    {
        var game = GiveMe.AGameManager(board: GiveMe.ABoardManager(withShips: true), targetList: GiveMe.ATargetList(2));

        game.Initialize();

        game.ComputerBoard.PlacedShips.ShouldBe(3);
    }

    [Test]
    public void Game_ends_when_player_is_out_of_lives()
    {
        var game = GiveMe.AGameManager();
        game.Initialize();
        game.SetPlayerLives(1);

        game.UpdateGame(true, "A,1");

        game.Message.ShouldBe("Out of lives...");
    }

    [Test]
    public void Game_ends_when_all_targets_are_hit()
    {
        var game = GiveMe.AGameManager(board: GiveMe.ABoardManager(withShips: true), targetList: GiveMe.ATargetList(empty: true));
        game.Initialize();

        game.UpdateGame(true, "A,1");

        game.Message.ShouldBe("You won !");
    }
}
