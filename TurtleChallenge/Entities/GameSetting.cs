using System;
using System.Collections.Generic;
using TurtleChallenge.Enums;

namespace TurtleChallenge.Entities
{
    public class GameSetting
    {
        public GameSetting()
        {
            ListOfMines = new List<Mine>();
        }

        public int[,] InitialPosition;

        public DirectionEnum InitialDirection;

        public Board Board { get; set; }

        public Turtle Turtle { get; set; }

        public ExitGame ExitPosition { get; set; }

        public List<Mine> ListOfMines { get; set; }

    }
}
