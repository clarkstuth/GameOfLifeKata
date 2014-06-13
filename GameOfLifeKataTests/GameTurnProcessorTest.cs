using GameOfLifeKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeKataTests
{
    [TestClass]
    public class GameTurnProcessorTest
    {
        private GameTurnProcessor Processor { get; set; }

        private static Cell DeadCell()
        {
            return new Cell {Dead = true};
        }

        private static Cell AliveCell()
        {
            return new Cell {Alive = true};
        }

        [TestInitialize]
        public void SetUp()
        {
            Processor = new GameTurnProcessor();
        }

        [TestMethod]
        public void GetNextGameStateShouldReturnNewInstanceOfGameBoard()
        {
            var board = new Cell[0, 0];
            var newBoard = Processor.GetNextGameState(board);
            Assert.AreNotSame(board, newBoard);
        }

        [TestMethod]
        public void AnyLiveCellWithFewerThanTwoLiveNeighboursDiesWithNonAliveNearby()
        {
            var gameState = new [,]
            {
                {AliveCell(), DeadCell()},
                {DeadCell(), DeadCell()}
            };
            var nextState = Processor.GetNextGameState(gameState);

            Assert.IsFalse(nextState[0,0].Alive);
        }

    }
}
