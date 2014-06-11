using System;
using GameOfLifeKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeKataTests
{
    [TestClass]
    public class GameBoardTest
    {
        int Height { get; set; }
        int Width { get; set; }
        int NumCells { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            Height = 2;
            Width = 3;
            NumCells = 3;
        }

        [TestMethod]
        public void GameShouldCreateGameBoardWithHeight2ShouldReturnGameBoardOfHeight2()
        {
            var game = InitializeGame();

            Assert.AreEqual(Height, game.GameBoard.Rank);
        }

        private Game InitializeGame()
        {
            var game = new Game(Width, Height);
            return game;
        }

        [TestMethod]
        public void GameShouldCreateGameBoardWithWidth3ShouldReturnGameBoardOfWidth3()
        {
            var game = InitializeGame();

            Assert.AreEqual(Width, game.GameBoard.Length/game.GameBoard.Rank);
        }

        [TestMethod]
        public void GameBoardShouldBePopulatedWithCells()
        {
            var game = InitializeGame();

            Assert.IsInstanceOfType(game.GameBoard[0,0], typeof(Cell));
        }

        [TestMethod]
        public void CellsShouldStartDead()
        {
            var game = InitializeGame();

            foreach (var cell in game.GameBoard)
            {
                Assert.IsFalse(cell.Alive);
            }
        }

        [TestMethod]
        public void StartingTheGameShouldMakeTheSpecifiedNumberOfCellsTurnAlive()
        {
            var game = InitializeGame();
            game.StartGame(NumCells);

            var cellCount = 0;
            foreach (var cell in game.GameBoard)
            {
                if (cell.Alive) cellCount++;
                Console.WriteLine("test");
            }
            Assert.AreEqual(NumCells, cellCount);
        }

        [TestMethod]
        public void GameStartsShouldBeRandom()
        {
            var game = InitializeGame();
            game.StartGame(NumCells);

            var game2 = InitializeGame();
            game2.StartGame(NumCells);

            Assert.AreNotEqual(game.GameBoard, game2.GameBoard);
        }

        [TestMethod]
        public void StartGameShouldSetTurnNumberTo1()
        {
            var game = InitializeGame();
            game.StartGame(NumCells);

            Assert.AreEqual(1, game.TurnNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StartingAGameASecondTimeShouldGenerateInvalidOperationException()
        {
            var game = InitializeGame();
            game.StartGame(NumCells);
            game.StartGame(NumCells);
        }

        [TestMethod]
        public void ProceedShouldMoveGameToNextTurn()
        {
            var game = InitializeGame();
            game.StartGame(NumCells);
            game.Proceed();
        }



    }
}
