using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeKata
{
    public static class DataExtensions
    {
        public static int GetWidth(this Cell[,] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }
            return arr.Length/arr.GetHeight();
        }

        public static int GetHeight(this Cell[,] arr)
        {
            return arr.GetLength(0);
        }

    }
}
