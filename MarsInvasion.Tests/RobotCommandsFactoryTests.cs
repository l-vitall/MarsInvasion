using MarsInvasion.RobotCommands;
using NUnit.Framework;
using System;

namespace MarsInvasion.Tests
{
    [TestFixture]
    public class RobotCommandsFactoryTests
    {
        [TestCase('R')]
        [TestCase('F')]
        [TestCase('L')]
        public void GetCommand_Should_Success(char command)
        {
            var commandsFactory = new RobotCommandsFactory();
            Assert.NotNull(commandsFactory.GetCommand(command));
        }

        [TestCase('Y')]
        public void GetCommand_Invalid_Command_Throws(char command)
        {
            var commandsFactory = new RobotCommandsFactory();
            Assert.Throws<ArgumentOutOfRangeException>(() => commandsFactory.GetCommand(command));
        }
    }
}