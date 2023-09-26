using Battleships;
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
        var gameRunner = GiveMe.AGameRunner();

        gameRunner.Play();
        gameRunner.PauseGame();

        Mock.Get(gameRunner.Game.GameUserInterface).Verify(c => c.ShowMessage(Messages.ENTER_COORDS), Times.AtLeastOnce);
    }

    [Test]
    public void Game_allows_using_premade_board()
    {
        var game = GiveMe.AGame(board: GiveMe.ABoardWithShip(height: 10, width: 10, coordinate: GiveMe.ACoordinate(1, 1)), targetList: GiveMe.ATargetList(empty: true));

        game.Initialize();

        game.Board.PlacedShips.ShouldBe(1);
    }

    [Test]
    public void Game_allows_placing_ships_when_given_a_premade_board()
    {
        var game = GiveMe.AGame(board: GiveMe.ABoardWithShip(height: 10, width: 10, coordinate: GiveMe.ACoordinate(1, 1)), targetList: GiveMe.ATargetList(2));

        game.Initialize();

        game.Board.PlacedShips.ShouldBe(3);
    }

    [Test]
    public async Task Game_ends_when_player_is_out_of_lives()
    {
        var gameSession = GiveMe.AGameRunner(GiveMe.AGame(player: GiveMe.APlayer(lives: 0)));

        await gameSession.Play();

        Mock.Get(gameSession.Game.GameUserInterface).Verify(c => c.ShowMessage("Out of lives..."), Times.AtLeastOnce);
    }

    [Test]
    public void Game_ends_when_all_targets_are_hit()
    {
        var game = GiveMe.AGame(board: GiveMe.ABoardWithShip(height: 10, width: 10, coordinate: GiveMe.ACoordinate(1, 1)), targetList: GiveMe.ATargetList(empty: true));
        var gameInputController = MockMe.AnInputController(game);
        var gameSession = GiveMe.AGameRunner(game);

        var play = Task.Factory.StartNew(() => gameSession.Play());
        var fire = Task.Factory.StartNew(() => { gameInputController.RegisterFireMissileEvent(GiveMe.ACoordinate(1, 1)); });
        Task.WaitAll(play, fire);

        Mock.Get(gameSession.Game.GameUserInterface).Verify(c => c.ShowMessage("You won !"), Times.AtLeastOnce);
    }
}
