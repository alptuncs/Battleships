using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Board_Tests
{
    [TestClass]
    public class BoardManagerUnitTests
    {
        [TestMethod]
        public void Gemiyi_dogru_koordinatta_yerlestirmeye_baslar()
        {
            var boardManager = new BoardManagerFactory().Create(10, 10);
            var targetFactory = new TargetFactory();
            ITarget amiralGemisi = targetFactory.Create(Direction.East(), "amiralgemisi");

            boardManager.PlaceShip(new Coordinate(3, 2), amiralGemisi);

            Assert.IsTrue(boardManager.HasShip(new Coordinate(3, 2)), "3,2 olmadı");
            Assert.IsFalse(boardManager.HasShip(new Coordinate(5, 5)), "5,5 hatalı yerleştirme");
        }
        [TestMethod]
        public void Gemiyi_yerlestirmeyi_dogru_koordinatta_bitirir()
        {
            var boardManager = new BoardManagerFactory().Create(10, 10);
            var targetFactory = new TargetFactory();
            ITarget amiralGemisi = targetFactory.Create(Direction.East(), "amiralgemisi");

            boardManager.PlaceShip(new Coordinate(3, 2), amiralGemisi);

            Assert.IsTrue(boardManager.HasShip(new Coordinate(3, 5)), "3,5 olmadı");
            Assert.IsFalse(boardManager.HasShip(new Coordinate(5, 5)), "5,5 hatalı yerleştirme");
        }
        [TestMethod]
        public void Belirli_sayida_gemiyi_rastgele_yerlestirir()
        {
            var boardManager = new BoardManagerFactory().Create(10, 10);
            var targetFactory = new TargetFactory();
            ITarget amiralGemisi = targetFactory.Create(Direction.East(), "amiralgemisi");
            ITarget kruvazor = targetFactory.Create(Direction.North(), "kruvazor");
            ITarget mayinGemisi = targetFactory.Create(Direction.East(), "mayingemisi");
            ITarget denizalti = targetFactory.Create(Direction.North(), "denizalti");

            List<ITarget> targets = new List<ITarget>();
            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);

            foreach (ITarget target in targets)
            {
                boardManager.PlaceShip(5 - target.Size, target);
            }

            Assert.AreEqual(boardManager.PlacedShips, 10);
        }

        [TestMethod]

        public void Kapasiteden_fazla_gemi_eklemez()
        {
            var boardManager = new BoardManagerFactory().Create(10, 10);
            var targetFactory = new TargetFactory();
            ITarget kruvazor = targetFactory.Create(Direction.North(), "kruvazor");

            Assert.ThrowsException<InvalidOperationException>(() => boardManager.PlaceShip(105, kruvazor));
        }

        [TestMethod]
        public void Saldiri_icin_koordinat_verilince_o_koordinati_vurur()
        {
            var boardManager = new BoardManagerFactory().Create(10, 10);
            var coordinate = new Coordinate(2, 5);
            boardManager.HitSquare(coordinate);

            Assert.IsTrue(boardManager.IsHit(coordinate));

        }
        [TestMethod]

        public void Tahtanin_kosesine_tahtanin_disina_bakicak_sekilde_denizalti_yerlestirir()
        {
            var boardManager = new BoardManagerFactory().Create(1, 1);
            var coordinate = new Coordinate(0, 0);
            var target = new TargetFactory().Create(Direction.North(), "denizalti");

            boardManager.PlaceShip(coordinate, target);

            Assert.IsTrue(boardManager.HasShip(coordinate));

        }
    }
}
