using System;
namespace TurtleChallenge
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var gameProcess = new GameProcess();

            gameProcess.RequestParameters(args);

            gameProcess.ExecuteGame();

            Console.ReadKey();
        }
    }
}
