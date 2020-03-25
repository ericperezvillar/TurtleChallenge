using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Entities
{
    public class Board
    {
        public int[,] Size;

        public Board() { }

        public int GetXlength()
        {
            return Size.GetLength(0);
        }

        public int GetYlength()
        {
            return Size.GetLength(1);
        }
    }
}
