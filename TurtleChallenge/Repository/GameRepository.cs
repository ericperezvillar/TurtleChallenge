using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Entities;
using TurtleChallenge.Enums;
using TurtleChallenge.Interfaces;

namespace TurtleChallenge.Repository
{
    public class GameRepository : IGameRepository
    {
        private IFileService FileService { get; set; }

        public GameRepository(IFileService fileService)
        {
            FileService = fileService;
        }

        public GameSetting PopulateGameSetting(List<string> listOfRows)
        {
            var gameSetting = new GameSetting();


            // Board
            var boardSize = GetGameProperty(listOfRows, "Board Size").FirstOrDefault();
            gameSetting.Board = new Board() {Size = boardSize };

            // Exit Position
            var exit = GetGameProperty(listOfRows, "Exit Position").FirstOrDefault();
            var exitPosition = new ExitGame();
            exitPosition.InitializeVector(exit.GetLength(0), exit.GetLength(1));
            gameSetting.ExitPosition = exitPosition;

            // Mines
            var listOfMines = GetGameProperty(listOfRows, "Mine");
            foreach (var minePosition in listOfMines)
            {
                var mine =  new Mine();
                mine.InitializeVector(minePosition.GetLength(0), minePosition.GetLength(1));
                gameSetting.ListOfMines.Add(mine);
            }

            // Starting Point
            const string turtleLabel = "Starting Position";
            var turtlePosition = GetGameProperty(listOfRows, turtleLabel).FirstOrDefault();
            var turtleDirection = GetTurtleStartingFacingPosition(listOfRows, turtleLabel);
            var turtle = Turtle.GetInstance();
            turtle.InitializeVector(turtlePosition.GetLength(0), turtlePosition.GetLength(1));
            turtle.Direction = turtleDirection;

            gameSetting.Turtle = turtle;
            gameSetting.InitialDirection = turtleDirection;
            gameSetting.InitialPosition = turtlePosition;

            return gameSetting;
        }

        public List<List<string>> PopulateMoves(List<string> listOfRows)
        {
            return FileService.GetStructureMoves(listOfRows);
        }

        //public List<List<string>> InitilizeTurtle()
        //{
        //    const string turtleLabel = "Starting Position";
        //    var turtlePosition = GetGameProperty(listOfRows, turtleLabel).FirstOrDefault();
        //    var turtleDirection = GetTurtleStartingFacingPosition(listOfRows, turtleLabel);
        //    var turtle = Turtle.GetInstance();
        //    turtle.InitializeVector(turtlePosition.GetLength(0), turtlePosition.GetLength(1));
        //    turtle.Direction = turtleDirection;
        //}

        private DirectionEnum GetTurtleStartingFacingPosition(List<string> listOfRows, string propertyToFind)
        {
            var rowsToProcess = FileService.GetRowsToProcess(listOfRows, propertyToFind);
            var direction = FileService.GetTurtleStartingFacingPosition(rowsToProcess);
            return direction;
        }
        
        private List<int[,]> GetGameProperty(List<string> listOfRows, string propertyToFind)
        {
            var rowsToProcess = FileService.GetRowsToProcess(listOfRows, propertyToFind);
            var listOfPositions = FileService.GetStructureGameSetting(rowsToProcess);
            return listOfPositions;
        }
    }
}
