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

        Mock.Get(gameRunner.Game.GameUserInterface).Verify(c => c.ShowMessage("Please enter the coordinate (E.g. A,7)"), Times.AtLeastOnce);
    }

    [Test]
    public void Game_allows_using_premade_board()
    {
        var game = GiveMe.AGame(board: GiveMe.ABoard(), targetList: GiveMe.ATargetList(empty: true));

        game.Initialize();

        game.Board.PlacedShips.ShouldBe(1);
    }

    [Test]
    public void Game_allows_placing_ships_when_given_a_premade_board()
    {
        var game = GiveMe.AGame(board: GiveMe.ABoard(), targetList: GiveMe.ATargetList(2));

        game.Initialize();

        game.Board.PlacedShips.ShouldBe(3);
    }

    [Test]
    public void Game_ends_when_player_is_out_of_lives()
    {
        var gameSession = GiveMe.AGameRunner(GiveMe.AGame(player: GiveMe.APlayer(lives: 0)));

        gameSession.Play();

        Mock.Get(gameSession.Game.GameUserInterface).Verify(c => c.ShowMessage("Out of lives..."), Times.AtLeastOnce);
    }

    [Test]
    public void Game_ends_when_all_targets_are_hit()
    {
        var gameSession = GiveMe.AGameRunner(GiveMe.AGame(
            board: GiveMe.ABoard(),
            targetList: GiveMe.ATargetList(empty: true)
        ));

        gameSession.Play();

        Mock.Get(gameSession.Game.GameUserInterface).Verify(c => c.ShowMessage("You won !"), Times.AtLeastOnce);
    }
}

/* 
Oyun başlayınca koordinat ister,
Oyuncu koordinat girene kadar ayrı bir şekilde render etmeye devam eder,
Oyuncunun hakkı kalmayınca oyun biter,
Tüm gemiler vurulunca oyun biter,
Gemileri verilen kordinata yerleştirir,
Komşu karesinde gemi olan yere gemi yerleştirilmez,
Input'u kontrol eder
GameController Lazım
 */
