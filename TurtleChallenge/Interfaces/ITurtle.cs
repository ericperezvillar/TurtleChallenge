using TurtleChallenge.Enums;

namespace TurtleChallenge.Interfaces
{
    public interface ITurtle
    {
        int Xposition { get; set; }

        int Yposition { get; set; }

        DirectionEnum Direction { get; set; }

        void MoveTurtle();

        void RotateTurtle();
    }
}