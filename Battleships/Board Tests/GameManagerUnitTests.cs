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
            var amiralGemisi = new Target(4, "east", "amiralGemisi");
            var kruvazor = new Target(3, "north", "kruvazor");
            var mayinGemisi = new Target(2, "east", "mayinGemisi");
            var denizalti = new Target(1, "north", "denizalti");

            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);
            var game = new Battleships.GameManager(console, playerBoard, computerBoard, boardRenderer, targets);
            game.Initialize();
            game.Play();

            Assert.AreEqual(game.Message, "Please enter the coordinates");
        }

        [TestMethod]
        public void Oyuncunun_Haklari_Bitince_Oyun_Sonlanır()
        {
            var computerBoard = new BoardManager(10, 10);
            var playerBoard = new BoardManager(10, 10);
            var boardRenderer = new BoardRenderer(10, 10);
            IConsole console = new SystemConsole();
            List<Target> targets = new List<Target>();

            var game = new Battleships.GameManager(console, playerBoard, computerBoard, boardRenderer, targets);

            game.Initialize();
            game.Play();


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
            var denizalti = new Target(1, "north", "denizalti");
            targets.Add(denizalti);

            game.Play();
        }
    }
}
