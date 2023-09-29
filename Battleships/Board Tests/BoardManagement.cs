using Battleships;
using NUnit.Framework;
using Shouldly;

namespace Board_Tests;

[TestFixture]
public class BoardManagement : Spec
{
    [Test]
    public void Places_target_at_the_given_coordinate()
    {
        var board = GiveMe.ABoard();

        board.PlaceShip(GiveMe.ACoordinate(3, 2), GiveMe.ATarget());

        board[GiveMe.ACoordinate(3, 2)].HasShip.ShouldBeTrue();
    }

    [Test]
    public void Places_target_based_on_given_direction()
    {
        var board = GiveMe.ABoard();

        board.PlaceShip(GiveMe.ACoordinate(3, 2), GiveMe.ATarget(Direction.East(), "Battleship"));

        board[GiveMe.ACoordinate(3, 3)].HasShip.ShouldBeTrue();
    }

    [Test]
    public void Randomly_places_given_targets()
    {
        var board = GiveMe.ABoard();

        board.PlaceShip(4, GiveMe.ATarget());

        board.PlacedShips.ShouldBe(4);
    }

    [Test]
    public void Gives_an_error_if_the_given_targets_do_not_fit_on_the_board()
    {
        var board = GiveMe.ABoard();

        var task = () => board.PlaceShip(101, GiveMe.ATarget());

        task.ShouldThrow<InvalidOperationException>();
    }

    [Test]
    public void Hits_the_given_coordinate()
    {
        var cell = GiveMe.ACell();

        cell.HitSquare();

        cell.IsHit.ShouldBeTrue();
    }

    [Test]
    public void Can_place_submarine_at_the_edge_of_the_board_facing_outside()
    {
        var board = GiveMe.ABoard(1, 1);

        board.PlaceShip(GiveMe.ACoordinate(0, 0), GiveMe.ATarget(Direction.North(), "Submarine"));

        board[GiveMe.ACoordinate(0, 0)].HasShip.ShouldBeTrue();
    }
}
