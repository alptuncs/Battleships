using Battleships;
using NUnit.Framework;

namespace Board_Tests;

[TestFixture]
public class BoardManagerUnitTests : Spec
{
    [Test]
    public void Places_target_at_the_given_coordinate()
    {
        var boardManager = GiveMe.ABoardManager();

        boardManager.PlaceShip(GiveMe.ACoordinate(3, 2), GiveMe.ATarget());

        Assert.IsTrue(boardManager.HasShip(GiveMe.ACoordinate(3, 2)));
    }

    [Test]
    public void Places_target_based_on_given_direction()
    {
        var boardManager = GiveMe.ABoardManager();

        boardManager.PlaceShip(GiveMe.ACoordinate(3, 2), GiveMe.ATarget(Direction.East(), "amiralgemisi"));

        Assert.IsTrue(boardManager.HasShip(GiveMe.ACoordinate(3, 3)));
    }

    [Test]
    public void Randomly_places_given_targets()
    {
        var boardManager = GiveMe.ABoardManager();

        boardManager.PlaceShip(4, GiveMe.ATarget());

        Assert.AreEqual(4, boardManager.PlacedShips);
    }

    [Test]
    public void Gives_an_error_if_the_given_targets_do_not_fit_on_the_board()
    {
        var boardManager = GiveMe.ABoardManager();

        Assert.Throws<InvalidOperationException>(() => boardManager.PlaceShip(101, GiveMe.ATarget()));
    }

    [Test]
    public void BoardManager_hits_the_given_coordinate()
    {
        var boardManager = GiveMe.ABoardManager();

        boardManager.HitSquare(GiveMe.ACoordinate(2, 5));

        Assert.IsTrue(boardManager.IsHit(GiveMe.ACoordinate(2, 5)));
    }

    [Test]
    public void Can_place_submarine_at_the_edge_of_the_board_facing_outside()
    {
        var boardManager = GiveMe.ABoardManager(1, 1);

        boardManager.PlaceShip(GiveMe.ACoordinate(0, 0), GiveMe.ATarget(Direction.North(), "denizalti"));

        Assert.IsTrue(boardManager.HasShip(GiveMe.ACoordinate(0, 0)));
    }
}
