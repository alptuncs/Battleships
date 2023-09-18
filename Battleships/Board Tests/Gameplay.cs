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
        var gameSession = GiveMe.AGameSession();

        gameSession.Play();

        Mock.Get(gameSession.GameManager.GameManagerConsole).Verify(c => c.WriteLine("\n\n\nPlease enter the coordinate (E.g. A,7)"), Times.AtLeastOnce);
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
        var gameSession = GiveMe.AGameSession(GiveMe.AGameManager(player: GiveMe.APlayer(lives: 0)));

        gameSession.Play();

        Mock.Get(gameSession.GameManager.GameManagerConsole).Verify(c => c.WriteLine("\nOut of lives..."), Times.AtLeastOnce);
    }

    [Test]
    public void Game_ends_when_all_targets_are_hit()
    {
        var gameSession = GiveMe.AGameSession(GiveMe.AGameManager(
            console: MockMe.AConsole("A,1"),
            board: GiveMe.ABoard(withShips: true),
            targetList: GiveMe.ATargetList(empty: true)
        ));

        gameSession.Play();

        gameSession.GameManager.Message.ShouldBe("You won !");
    }
}
