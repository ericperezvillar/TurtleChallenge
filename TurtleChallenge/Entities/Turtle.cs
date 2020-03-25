using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Enums;
using TurtleChallenge.Interfaces;

namespace TurtleChallenge.Entities
{
    public class Turtle : Vector, ITurtle
    {
        private Turtle() { }

        private static Turtle _turtleSigleton = null;

        public static Turtle GetInstance()
        {
            if (_turtleSigleton == null)
            {
                _turtleSigleton = new Turtle();
            }

            return (_turtleSigleton);
            
        }

        public DirectionEnum Direction { get; set; }

        public void MoveTurtle()
        {
            switch (Direction)
            {
                case DirectionEnum.North:
                    Yposition = Yposition - 1;
                    break;
                case DirectionEnum.West:
                    Xposition = Xposition - 1;
                    break;
                case DirectionEnum.East:
                    Xposition = Xposition + 1;
                    break;
                case DirectionEnum.South:
                    Yposition = Yposition + 1;
                    break;
            }
        }

        public void RotateTurtle()
        {
            switch (Direction)
            {
                case DirectionEnum.North:
                    Direction = DirectionEnum.East;
                    break;
                case DirectionEnum.West:
                    Direction = DirectionEnum.North;
                    break;
                case DirectionEnum.East:
                    Direction = DirectionEnum.South;
                    break;
                case DirectionEnum.South:
                    Direction = DirectionEnum.West;
                    break;
            }
        }
    }
}
