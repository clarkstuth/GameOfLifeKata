using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeKata
{
    public class Game
    {
        public Cell[,] GameBoard { get; private set; }

        public Game(int boardWidth, int boardHeight)
        {
            GameBoard = new Cell[boardWidth, boardHeight];

            InitializeGame();
        }

        private void InitializeGame()
        {
            for (var x = 0; x < GameBoard.Length/GameBoard.GetLength(1); x++)
            {
                for (var y = 0; y < GameBoard.GetLength(1); y++)
                {
                    GameBoard[x, y] = new Cell();
                }
            }
        }

        private void StartRandomCell(Random random)
        {
            int col, row;
            do
            {
                col = random.Next(GameBoard.Length / GameBoard.GetLength(1));
                row = random.Next(GameBoard.GetLength(1));
            } while (GameBoard[col,row].Alive);
            GameBoard[col,row].Alive = true;
        }

        public void StartGame(int numberOfAliveCells)
        {
            var aliveCells = 0;
            while (aliveCells < numberOfAliveCells)
            {
                var random = new Random();
                StartRandomCell(random);
                ++aliveCells;
            }
        }
    }
}
