﻿using Battleships;
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
            game.UpdateGame(true, "1,1");

            Assert.AreEqual("Please enter the coordinates", game.Message.GetMessage(), game.Message.GetMessage());
        }

        [TestMethod]
        public void Oyuncunun_Haklari_Bitince_Oyun_Sonlanır()
        {
            var computerBoard = new BoardManager(10, 10);
            var playerBoard = new BoardManager(10, 10);
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
            game.UpdateGame(true, "1,1");
            game.UpdateGame(true, "1,1");

            Assert.AreEqual("Out of lives...", game.Message.GetMessage(), game.Message.GetMessage());


        }
        [TestMethod]
        public void Tum_Gemiler_Vurulunca_Oyun_Sonlanir()
        {
            var computerBoard = new BoardManager(10, 10);
            var playerBoard = new BoardManager(10, 10);
            var boardRenderer = new BoardRenderer(10, 10);
            IConsole console = new SystemConsole();
            var targetFactory = new TargetFactory();
            List<ITarget> targets = new List<ITarget>();
            var denizalti = targetFactory.Create(Direction.North(), "denizalti");
            targets.Add(denizalti);

            var game = new Battleships.GameManager(console, computerBoard, boardRenderer, targets);


            game.Initialize();
            game.UpdateGame(true, "4,5");
            game.UpdateGame(true, "8,3");
            game.UpdateGame(true, "8,7");
            game.UpdateGame(true, "10,8");

            Assert.AreEqual("You won !", game.Message.GetMessage(), game.Message.GetMessage());
        }
    }
}
