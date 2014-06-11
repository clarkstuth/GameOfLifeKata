using GameOfLifeKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeKataTests
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void SettingACellToAliveShouldSetDeadToFalse()
        {
            var cell = new Cell { Alive = true };
            Assert.IsFalse(cell.Dead);
        }

        [TestMethod]
        public void SettingACellToDeadShouldSetAliveToFalse()
        {
            var cell = new Cell { Dead = true };
            Assert.IsFalse(cell.Alive);
        }

        [TestMethod]
        public void ChangingACellFromAliveEqualsTrueToFalseShouldSetDeadToTrue()
        {
            var cell = new Cell {Alive = true};
            cell.Alive = false;
            Assert.IsTrue(cell.Dead);
        }

        [TestMethod]
        public void ChangingACellFromDeadEqualsTrueToFalseShouldSetAliveToTrue()
        {
            var cell = new Cell {Dead = true};
            cell.Dead = false;
            Assert.IsTrue(cell.Alive);
        }

    }
}
