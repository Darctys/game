using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace newGame
{
    [TestFixture]
    class Tests
    {
        private Woodman player;
        [SetUp]
        public void SetUp()
        {
            player = new Woodman(Map.mapWidth / 2 * Map.mapCell, Map.mapWidth / 2 * Map.mapCell);
        }

        [Test]
        public void Go()
        {
            player.speed = 3;
            player.MoveRight();
            Assert.AreEqual(Map.mapWidth / 2 * Map.mapCell + 3, player.locationX);
            SetUp();
            player.MoveLeft();
            Assert.AreEqual(Map.mapWidth / 2 * Map.mapCell - 3, player.locationX);
            SetUp();
            player.MoveDown();
            Assert.AreEqual(Map.mapWidth / 2 * Map.mapCell + 3, player.locationY);
            SetUp();
            player.MoveUp();
            Assert.AreEqual(Map.mapWidth / 2 * Map.mapCell - 3, player.locationY);
            player = new Woodman(Map.mapWidth / 2 * Map.mapCell, Map.mapWidth / 2 * Map.mapCell);
        }

        [Test]
        public void Take()
        {
            SetUp();
            Map.Init();
            Map.map[10, 10].wood = true;
            player.Take();
            Assert.AreEqual(false, Map.map[10, 10].wood);

        }

        [Test]
        public void Cut()
        {
            SetUp();
            Map.Init();
            Map.map[9, 10].wood = true;
            player.Cut(3);
            Assert.AreEqual(false, Map.map[9, 10].Tree);
        }

        [Test]
        public void UpdateInventory()
        {
            SetUp();
            Map.Init();
            Map.map[10, 10].leather = true;
            player.Take();
            Assert.AreEqual(4, Woodman.maxInventoty);
        }

        [Test]
        public void CampFireOff()
        {
            SetUp();
            Map.Init();
            var campFire = new CampFire();
            CampFire.health -= 1000;
            Assert.IsFalse(CampFire.DeterminStatus());
        }

        [Test]
        public void Put()
        {
            SetUp();
            Map.Init();
            CampFire.health = 100;
            Woodman.Inventory[1].wood = true;
            player.Put(4);
            Assert.AreEqual(200,CampFire.health);
        }
    }

   
}
