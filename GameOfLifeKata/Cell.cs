namespace GameOfLifeKata
{
    public class Cell
    {
        private bool alive;
        public bool Alive
        {
            get { return alive; }
            set
            {
                alive = value;
                dead = !alive;
            }
        }

        private bool dead;
        public bool Dead
        {
            get { return dead; }
            set
            {
                dead = value;
                Alive = !dead;
            }
        }

    }
}
