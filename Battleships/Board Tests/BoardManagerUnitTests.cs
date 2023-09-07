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

        boardManager.HasShip(GiveMe.ACoordinate(3, 2)).ShouldBeTrue();
    }

    [Test]
    public void Places_target_based_on_given_direction()
    {
        var boardManager = GiveMe.ABoardManager();

        boardManager.PlaceShip(GiveMe.ACoordinate(3, 2), GiveMe.ATarget(Direction.East(), "amiralgemisi"));

        boardManager.HasShip(GiveMe.ACoordinate(3, 3)).ShouldBeTrue();
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
    public void BoardManager_hits_the_given_coordinate()
    {
        var boardManager = GiveMe.ABoardManager();

        boardManager.HitSquare(GiveMe.ACoordinate(2, 5));

        boardManager.IsHit(GiveMe.ACoordinate(2, 5)).ShouldBeTrue();
    }

    [Test]
    public void Can_place_submarine_at_the_edge_of_the_board_facing_outside()
    {
        var boardManager = GiveMe.ABoardManager(1, 1);

        boardManager.PlaceShip(GiveMe.ACoordinate(0, 0), GiveMe.ATarget(Direction.North(), "denizalti"));

        boardManager.HasShip(GiveMe.ACoordinate(0, 0)).ShouldBeTrue();
    }
}
