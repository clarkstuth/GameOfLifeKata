using System;

namespace GameOfLifeKata
{
    public class Game
    {
        public Cell[,] GameBoard { get; private set; }
        public int TurnNumber { get; private set; }

        private bool Started { get; set; }

        public Game(int boardWidth, int boardHeight)
        {
            GameBoard = new Cell[boardWidth, boardHeight];
            InitializeGame();
        }

        private void InitializeGame()
        {
            Started = false;
            for (var x = 0; x < GameBoard.GetWidth(); x++)
            {
                for (var y = 0; y < GameBoard.GetHeight(); y++)
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
                col = random.Next(GameBoard.GetWidth());
                row = random.Next(GameBoard.GetHeight());
            } while (GameBoard[col,row].Alive);
            GameBoard[col,row].Alive = true;
        }

        public void StartGame(int numberOfAliveCells)
        {
            if (Started)
                throw new InvalidOperationException("Game can not be started while already running.");

            Started = true;

            var aliveCells = 0;
            while (aliveCells < numberOfAliveCells)
            {
                var random = new Random();
                StartRandomCell(random);
                ++aliveCells;
            }
            TurnNumber = 1;
        }

        public void Proceed()
        {
            TurnNumber++;
        }
    }
}
