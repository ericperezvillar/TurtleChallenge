using System;
using System.Collections.Generic;
using TurtleChallenge.Enums;

namespace TurtleChallenge.Interfaces
{
    public interface IFileService
    {
        List<string> ReadInputFile(string file);

        List<int[,]> GetStructureGameSetting(List<string> rowsToProces);

        List<List<string>> GetStructureMoves(List<string> listOfRows);

        DirectionEnum GetTurtleStartingFacingPosition(List<string> rowsToProces);

        List<string> GetRowsToProcess(List<string> listOfRows, string propertyToFind);
    }
}
