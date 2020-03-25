using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Enums;

namespace TurtleChallenge.Entities
{
    public class State
    {
        public Board Board { get; set; }

        public State(Board _board)
        {
            Board = _board;
        }

        public bool IsOutsideOfBounds(Turtle turtle)
        {
            if (turtle.Xposition > Board.GetXlength() || turtle.Xposition < 0 || turtle.Yposition < 0 || turtle.Yposition > Board.GetYlength())
            {
                return true;
            }
            return false;
        }

        public bool IsExit(Turtle turtle)
        {
            if (Board.Size[turtle.Xposition, turtle.Yposition] == (int)EnumStates.Exit)
            {
                return true;
            }
            return false;
        }

        public bool IsHitMine(Turtle turtle)
        {
            if (Board.Size[turtle.Xposition, turtle.Yposition] == (int)EnumStates.Mine)
            {
                return true;
            }
            return false;
        }

        public bool IsStillInDange(Turtle turtle)
        {
            if (Board.Size[turtle.Xposition, turtle.Yposition] == (int)EnumStates.Empty)
            {
                return true;
            }
            return false;
        }
    }
}
