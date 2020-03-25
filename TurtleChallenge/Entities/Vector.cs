using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Entities
{
    public abstract class Vector
    {
        public int Xposition { get; set; }

        public int Yposition { get; set; }

        public void InitializeVector(int x, int y)
        {
            Xposition = x;
            Yposition = y;
        }
    }
}
