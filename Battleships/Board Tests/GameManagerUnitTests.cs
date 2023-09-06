using Battleships;
using NUnit.Framework;

namespace Board_Tests;

[TestFixture]
public class GameManagerUnitTests : Spec
{
    [Test]
    public void Oyunu_olusturup_kullanicidan_koordinat_ister()
    {
        var computerBoard = new BoardManagerFactory().Create(10, 10);
        var boardRenderer = new BoardRenderer(10, 10);
        IConsole console = new SystemConsole();
        var targetFactory = new TargetFactory();
        List<ITarget> targets = new List<ITarget>();
        ITarget amiralGemisi = targetFactory.Create(Direction.East(), "amiralgemisi");
        ITarget kruvazor = targetFactory.Create(Direction.North(), "kruvazor");
        ITarget mayinGemisi = targetFactory.Create(Direction.East(), "mayingemisi");
        ITarget denizalti = targetFactory.Create(Direction.North(), "denizalti");

        targets.Add(amiralGemisi);
        targets.Add(kruvazor);
        targets.Add(mayinGemisi);
        targets.Add(denizalti);
        var game = new Battleships.GameManager(console, computerBoard, boardRenderer, targets);
        game.Initialize();

        Assert.AreEqual("\n\nPlease enter the coordinate (E.g. A,7)", game.Message, game.Message);
    }

    [Test]
    public void Oyuncunun_haklari_bitince_oyun_sonlanir()
    {
        var computerBoard = new BoardManagerFactory().Create(10, 10);
        var boardRenderer = new BoardRenderer(10, 10);
        IConsole console = new SystemConsole();
        var targetFactory = new TargetFactory();
        List<ITarget> targets = new List<ITarget>();
        ITarget amiralGemisi = targetFactory.Create(Direction.East(), "amiralgemisi");
        ITarget kruvazor = targetFactory.Create(Direction.North(), "kruvazor");
        ITarget mayinGemisi = targetFactory.Create(Direction.East(), "mayingemisi");
        ITarget denizalti = targetFactory.Create(Direction.North(), "denizalti");

        targets.Add(amiralGemisi);
        targets.Add(kruvazor);
        targets.Add(mayinGemisi);
        targets.Add(denizalti);

        var game = new Battleships.GameManager(console, computerBoard, boardRenderer, targets);

        game.Initialize();
        game.SetPlayerLives(2);
        game.UpdateGame(true, "A,1");
        game.UpdateGame(true, "A,1");

        Assert.AreEqual("Out of lives...", game.Message, game.Message);
    }

    [Test]
    public void Tum_gemiler_vurulunca_oyun_sonlanir()
    {
        var computerBoard = new BoardManagerFactory().Create(10, 10);
        var boardRenderer = new BoardRenderer(10, 10);
        IConsole console = new SystemConsole();
        var targetFactory = new TargetFactory();
        List<ITarget> targets = new List<ITarget>();
        var denizalti = targetFactory.Create(Direction.North(), "denizalti");
        targets.Add(denizalti);

        var game = new Battleships.GameManager(console, computerBoard, boardRenderer, targets);

        game.Initialize();
        game.UpdateGame(true, "D,5");
        game.UpdateGame(true, "H,3");
        game.UpdateGame(true, "H,7");
        game.UpdateGame(true, "J,8");

        Assert.AreEqual("You won !", game.Message, game.Message);
    }
}
