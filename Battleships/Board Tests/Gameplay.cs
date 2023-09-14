using Moq;
using NUnit.Framework;
using Shouldly;

namespace Board_Tests;

[TestFixture]
public class Gameplay : Spec
{
    [Test]
    public void When_the_game_starts_it_asks_for_coordinates()
    {
        var console = MockMe.AConsole();
        var game = GiveMe.AGameManager(console: console);
        game.Initialize();
        var gameSession = GiveMe.AGameSession(game);

        gameSession.Play();

        Mock.Get(console).Verify(c => c.WriteLine("\n\n\nPlease enter the coordinate (E.g. A,7)"), Times.AtLeastOnce);
    }

    [Test]
    public void Game_allows_using_premade_board()
    {
        var game = GiveMe.AGameManager(board: GiveMe.ABoard(withShips: true), targetList: GiveMe.ATargetList(empty: true));

        game.Initialize();

        game.ComputerBoard.PlacedShips.ShouldBe(1);
    }

    [Test]
    public void Game_allows_placing_ships_when_given_a_premade_board()
    {
        var game = GiveMe.AGameManager(board: GiveMe.ABoard(withShips: true), targetList: GiveMe.ATargetList(2));

        game.Initialize();

        game.ComputerBoard.PlacedShips.ShouldBe(3);
    }

    [Test]
    public void Game_ends_when_player_is_out_of_lives()
    {
        var game = GiveMe.AGameManager();
        game.SetPlayerLives(0);
        var gameSession = GiveMe.AGameSession(game);

        gameSession.Play();

        gameSession.GameManager.Message.ShouldBe("Out of lives...");
    }

    [Test]
    public void Game_ends_when_all_targets_are_hit()
    {
        var game = GiveMe.AGameManager(targetList: GiveMe.ATargetList(empty: true));
        game.Initialize();
        var gameSession = GiveMe.AGameSession(game);

        gameSession.Play();

        gameSession.GameManager.Message.ShouldBe("You won !");
    }
}
