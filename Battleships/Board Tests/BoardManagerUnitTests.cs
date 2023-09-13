using Battleships;
using NUnit.Framework;
using Shouldly;

namespace Board_Tests;

[TestFixture]
public class BoardManagerUnitTests : Spec
{
    [Test]
    public void Places_target_at_the_given_coordinate()
    {
        var boardManager = GiveMe.ABoardManager();

        boardManager.PlaceShip(GiveMe.ACoordinate(3, 2), GiveMe.ATarget());

        boardManager[GiveMe.ACoordinate(3, 2)].HasShip.ShouldBeTrue();
    }

    [Test]
    public void Places_target_based_on_given_direction()
    {
        var boardManager = GiveMe.ABoardManager();

        boardManager.PlaceShip(GiveMe.ACoordinate(3, 2), GiveMe.ATarget(Direction.East(), "Battleship"));

        boardManager[GiveMe.ACoordinate(3, 3)].HasShip.ShouldBeTrue();
    }

    [Test]
    public void Randomly_places_given_targets()
    {
        var boardManager = GiveMe.ABoardManager();

        boardManager.PlaceShip(4, GiveMe.ATarget());

        boardManager.PlacedShips.ShouldBe(4);
    }

    [Test]
    public void Gives_an_error_if_the_given_targets_do_not_fit_on_the_board()
    {
        var boardManager = GiveMe.ABoardManager();

        var task = () => boardManager.PlaceShip(101, GiveMe.ATarget());

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
        var boardManager = GiveMe.ABoardManager(1, 1);

        boardManager.PlaceShip(GiveMe.ACoordinate(0, 0), GiveMe.ATarget(Direction.North(), "Submarine"));

        boardManager[GiveMe.ACoordinate(0, 0)].HasShip.ShouldBeTrue();
    }
}
