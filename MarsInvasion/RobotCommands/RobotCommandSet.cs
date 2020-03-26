using MarsInvasion.RobotCommands.Interfaces;
using System;
using System.Collections.Generic;

namespace MarsInvasion
{
    public class RobotCommandSet
    {
        public const int MaxCommandStringLengh = 50;
        
        public IReadOnlyList<IRobotCommand> Commands { get; private set; }

        private RobotCommandSet(List<IRobotCommand> commands)
        {
            Commands = commands.AsReadOnly();
        }

        public static RobotCommandSet Create(IRobotCommandsFactory commandsFactory, string commandsString)
        {
            if (commandsString.Length > MaxCommandStringLengh)
                throw new ArgumentOutOfRangeException(nameof(commandsString), $"commandsString must be shorter than {MaxCommandStringLengh} commands");

            var commands = new List<IRobotCommand>();
            foreach (var command in commandsString)
                commands.Add(commandsFactory.GetCommand(command));

            return new RobotCommandSet(commands);
        }
    }
}
