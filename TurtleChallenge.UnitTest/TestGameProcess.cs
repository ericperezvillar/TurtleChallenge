using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallenge.Entities;
using TurtleChallenge.Enums;

namespace TurtleChallenge.UnitTest
{
    [TestClass]
    public class TestGameProcess
    {
        public GameProcess GameProcess { get; set; }

        [TestInitialize]
        public void Setup()
        {
            GameProcess = new GameProcess();
        }

        [TestMethod]
        public void TestRequestParameters_HappyCase()
        {
            Assert.IsNull(GameProcess.GameSetting);
            Assert.IsNull(GameProcess.Sequences);
            var args = new string[]{"game-setting","moves"};
            GameProcess.RequestParameters(args);
            Assert.IsNotNull(GameProcess.GameSetting);
            Assert.IsNotNull(GameProcess.Sequences);
        }

        [TestMethod]
        public void TestExecuteGame()
        {
            var args = new string[] { "game-setting", "moves" };
            GameProcess.RequestParameters(args);
            GameProcess.ExecuteGame();
            Assert.IsNotNull(GameProcess.GameSetting);
            Assert.IsNotNull(GameProcess.Sequences);
        }

        [TestMethod]
        public void TestInitializeVector()
        {
            var turtle = Turtle.GetInstance();
            turtle.InitializeVector(0,1);
            turtle.Direction = DirectionEnum.North;
            Assert.AreEqual(turtle.Xposition,0);
            Assert.AreEqual(turtle.Yposition,1);
        }

    }
}
