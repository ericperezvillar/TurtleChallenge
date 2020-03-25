using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TurtleChallenge.Enums;
using TurtleChallenge.Interfaces;

namespace TurtleChallenge
{
    public class FileService : IFileService
    {
        public List<string> ReadInputFile(string file)
        {
            var fileFolder = Environment.CurrentDirectory;
            string path = Path.Combine(fileFolder, string.Format("{0}.csv", file));

            var reader = File.ReadAllLines(path);

            return reader.ToList();  
        }

        public List<int[,]> GetStructureGameSetting(List<string> rowsToProcess)
        {
            var listOfPosition = new List<int[,]>();

            foreach (var item in rowsToProcess)
            {
                var row = item.Split(',').ToArray();
                var position = new int[Convert.ToInt32(row[1]), Convert.ToInt32(row[2])];
                listOfPosition.Add(position);
            }
               
            return listOfPosition;
        }

        public List<string> GetRowsToProcess(List<string> listOfRows, string propertyToFind)
        {
            return listOfRows.Where(x => x.Contains(propertyToFind)).ToList();
        }

        public DirectionEnum GetTurtleStartingFacingPosition(List<string> rowsToProcess)
        {
            var readRow = rowsToProcess.FirstOrDefault().Split(',').ToArray();

            var facing = Enum.Parse(typeof(DirectionEnum), readRow[3]);

            return (DirectionEnum) facing;
        }

        public List<List<string>> GetStructureMoves(List<string> listOfRows)
        {
            var listOfSequences = new List<List<string>>();
            
            foreach (var row in listOfRows.Select(item => item.Split(',').ToArray()))
            {
                var listOfMoves = new List<string>();

                for (int i = 1; i < row.Length; i++)
                {
                    listOfMoves.Add(row[i]);
                }
                listOfSequences.Add(listOfMoves);
            }

            return listOfSequences;
        }
    }
}
