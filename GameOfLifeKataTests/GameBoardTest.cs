using System;
using System.Text;
using System.Collections.Generic;
using GameOfLifeKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeKataTests
{
    [TestClass]
    public class GameBoardTest
    {
        [TestMethod]
        public void GameShouldCreateGameBoardWithHeight2ShouldReturnGameBoardOfHeight2()
        {
            var height = 2;
            var width = 3;
            var game = InitializeGame(width, height);

            Assert.AreEqual(height, game.GameBoard.Rank);
        }

        private Game InitializeGame(int width, int height)
        {
            var game = new Game(width, height);
            return game;
        }

        [TestMethod]
        public void GameShouldCreateGameBoardWithWidth3ShouldReturnGameBoardOfWidth3()
        {
            var height = 2;
            var width = 3;
            var game = InitializeGame(width, height);

            Assert.AreEqual(width, game.GameBoard.Length/game.GameBoard.Rank);
        }

        [TestMethod]
        public void GameBoardShouldBePopulatedWithCells()
        {
            var height = 2;
            var width = 3;
            var game = InitializeGame(width, height);

            Assert.IsInstanceOfType(game.GameBoard[0,0], typeof(Cell));
        }

        [TestMethod]
        public void CellsShouldStartDead()
        {
            var height = 2;
            var width = 3;
            var game = InitializeGame(width, height);

            foreach (var cell in game.GameBoard)
            {
                Assert.IsFalse(cell.Alive);
            }
        }

        [TestMethod]
        public void StartingTheGameShouldMakeTheSpecifiedNumberOfCellsTurnAlive()
        {
            int numCells = 2;
            var height = 2;
            var width = 3;
            var game = InitializeGame(width, height);
            game.StartGame(numCells);

            int cellCount = 0;
            foreach (var cell in game.GameBoard)
            {
                if (cell.Alive) cellCount++;
                Console.WriteLine("test");
            }
            Assert.AreEqual(numCells, cellCount);
        }

        [TestMethod]
        public void GameStartsShouldBeRandom()
        {
            var width = 20;
            var height = 40;
            var numCells = 3;

            var game = InitializeGame(width, height);
            game.StartGame(numCells);

            var game2 = InitializeGame(width, height);
            game2.StartGame(numCells);

            Assert.AreNotEqual(game.GameBoard, game2.GameBoard);
        }



    }
}
