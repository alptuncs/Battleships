using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Board_Tests
{
    [TestClass]
    public class GameManagerUnitTests
    {
        [TestMethod]
        public void Oyunu_Olusturup_Kullanicidan_Koordinat_Ister()
        {
            var computerBoard = new BoardManager(10, 10);
            var playerBoard = new BoardManager(10, 10);
            var boardRenderer = new BoardRenderer(10, 10);
            IConsole console = new SystemConsole();
            List<Target> targets = new List<Target>();
            Target amiralGemisi = new Target(4, Direction.East, "amiralGemisi");
            Target kruvazor = new Target(3, Direction.North, "kruvazor");
            Target mayinGemisi = new Target(2, Direction.East, "mayinGemisi");
            Target denizalti = new Target(1, Direction.North, "denizalti");

            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);
            var game = new Battleships.GameManager(console, playerBoard, computerBoard, boardRenderer, targets);
            game.Initialize();
            game.SetDefaultGameMessage();

            Assert.AreEqual("Please enter the coordinates", game.Message, game.Message);
        }

        [TestMethod]
        public void Oyuncunun_Haklari_Bitince_Oyun_Sonlanır()
        {
            var computerBoard = new BoardManager(10, 10);
            var playerBoard = new BoardManager(10, 10);
            var boardRenderer = new BoardRenderer(10, 10);
            IConsole console = new SystemConsole();
            List<Target> targets = new List<Target>();
            Target amiralGemisi = new Target(4, Direction.East, "amiralGemisi");
            Target kruvazor = new Target(3, Direction.North, "kruvazor");
            Target mayinGemisi = new Target(2, Direction.East, "mayinGemisi");
            Target denizalti = new Target(1, Direction.North, "denizalti");
            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);

            var game = new Battleships.GameManager(console, playerBoard, computerBoard, boardRenderer, targets);

            game.Initialize();

            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");
            game.UpdateGame("1,1");

            Assert.AreEqual("Out of lives...", game.Message, game.Message);


        }
        [TestMethod]
        public void Tum_Gemiler_Vurulunca_Oyun_Sonlanir()
        {
            var computerBoard = new BoardManager(10, 10);
            var playerBoard = new BoardManager(10, 10);
            var boardRenderer = new BoardRenderer(10, 10);
            IConsole console = new SystemConsole();
            List<Target> targets = new List<Target>();

            var game = new Battleships.GameManager(console, playerBoard, computerBoard, boardRenderer, targets);
            var denizalti = new Target(1, Direction.North, "denizalti");
            targets.Add(denizalti);

            game.Initialize();
            game.UpdateGame("1,1");
        }
    }
}
