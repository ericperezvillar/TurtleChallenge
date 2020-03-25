using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Entities;

namespace TurtleChallenge.Interfaces
{
    public interface IGameRepository
    {
       GameSetting PopulateGameSetting(List<string> listOfRows);

       List<List<string>> PopulateMoves(List<string> listOfRows);
    }
}
