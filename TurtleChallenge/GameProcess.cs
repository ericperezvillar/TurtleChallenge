using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallenge.Entities;
using TurtleChallenge.Enums;
using TurtleChallenge.Interfaces;
using TurtleChallenge.Repository;

namespace TurtleChallenge
{
    public class GameProcess
    {
        public IFileService FileService { get; set; }
        public IGameRepository GameRepository { get; set; }
        public GameSetting GameSetting;
        public List<List<string>> Sequences; 
        public State GameState;
        private Turtle _turtle;

        public GameProcess()
        {
            InitializeServices();
        }

        public void RequestParameters(string[] args)
        {
            try
            {
                string gameFileName = args[0];
                var listOfParametersGame = FileService.ReadInputFile(gameFileName);

                GameSetting = GameRepository.PopulateGameSetting(listOfParametersGame);

                string sequencesFileName = args[1];
                var listOfParametersMoves = FileService.ReadInputFile(sequencesFileName);

                Sequences = GameRepository.PopulateMoves(listOfParametersMoves);
            }
            catch (Exception)
            {
                PrintMessage("Error trying to read the file. Please run this program again.");
                Environment.Exit(0);
            }
           
        }

        public void ExecuteGame()
        {
            try
            {
                InitializeGame();

                ProcessGame();
            }
            catch (Exception)
            {
                PrintMessage("Error trying to read the moves file. Please run this program again.");
                Environment.Exit(0);
            }
        }

        private void InitializeGame()
        {
            var board = PopulateBoard();
            GameState = new State(board);
        }

        private void ProcessGame()
        {
            int i = 0;

            foreach (var sequence in Sequences)
            {
                InitiliazeTurtleForSequence();

                i++;
                PrintMessage(string.Format("Sequence number {0}: ", i));

                foreach (var move in sequence)
                {
                    if (move == "m")
                    {
                        _turtle.MoveTurtle();
                    }
                    else if (move == "r")
                    {
                        _turtle.RotateTurtle();
                    }

                    if (GameState.IsOutsideOfBounds(_turtle))
                    {
                        PrintMessage("Turtle outside bounds \n");
                        goto breakLoops; 
                    }

                    if (GameState.IsHitMine(_turtle))
                    {
                        PrintMessage("Hit Mine! \n");
                        goto breakLoops;
                    }

                    if (GameState.IsExit(_turtle))
                    {
                        PrintMessage("Sucess :) \n");
                        goto breakLoops;
                    }
                }

                if (GameState.IsStillInDange(_turtle))
                {
                    PrintMessage("Missing Turtle on board \n");
                }

                breakLoops:;
            }
        }

        private void InitiliazeTurtleForSequence()
        {
            _turtle = Turtle.GetInstance();
            _turtle.Direction = GameSetting.InitialDirection;
            _turtle.InitializeVector(GameSetting.InitialPosition.GetLength(0), GameSetting.InitialPosition.GetLength(1));
        }

        private Board PopulateBoard()
        {
            var board = GameSetting.Board;
            for (int x = 0; x < board.GetXlength(); x++)
            {
                for (int y = 0; y < board.GetYlength(); y++)
                {
                    if (GameSetting.ListOfMines.Any(m => m.Xposition == x && m.Yposition == y))
                    {
                        board.Size[x, y] = (int)EnumStates.Mine;
                    }
                    else if (GameSetting.ExitPosition.Xposition == x && GameSetting.ExitPosition.Yposition == y)
                    {
                        board.Size[x, y] = (int)EnumStates.Exit;
                    }
                }
            }
            return board;
        }

        private void PrintMessage(string message)
        {
            Console.Write(message);
        }

        private void InitializeServices()
        {
            FileService = new FileService();
            GameRepository = new GameRepository(FileService);
        }
    }
}
