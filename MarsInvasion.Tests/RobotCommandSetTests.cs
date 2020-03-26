using MarsInvasion.RobotCommands;
using MarsInvasion.RobotCommands.Interfaces;
using NUnit.Framework;
using System;

namespace MarsInvasion.Tests
{
    [TestFixture]
    public class RobotCommandSetTests
    {
        private IRobotCommandsFactory _commandsFactory = new RobotCommandsFactory();

        [TestCase("RFRFRFRF", 8)]
        [TestCase("FRRFLLFFRRFLL", 13)]
        [TestCase("LLFFFLFLFL", 10)]
        public void Create_Should_Success(string commandsString, int expectedLength)
        {
            RobotCommandSet commandSet = RobotCommandSet.Create(_commandsFactory, commandsString);
            Assert.AreEqual(expectedLength, commandSet.Commands.Count);
        }

        [TestCase("LLFFFLFLFLLLFFFLFLFLLLFFFLFLFLLLFFFLFLFLLLFFFLFLFLLLFFFLFLFL")]
        public void Create_Too_Long_Command_Throws(string commandsString)
        {
            Assert.Throws<ArgumentOutOfRangeException>(()=> RobotCommandSet.Create(_commandsFactory, commandsString));
        }
    }
}