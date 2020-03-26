using MarsInvasion.RobotCommands.Interfaces;
using System;
using System.Collections.Generic;

namespace MarsInvasion.RobotCommands
{
    public class RobotCommandsFactory : IRobotCommandsFactory
    {
        private Dictionary<char, IRobotCommand> _knownCommands;

        public RobotCommandsFactory()
        {
            _knownCommands = new Dictionary<char, IRobotCommand>(3);

            _knownCommands.Add('F', new MoveStepFoward());
            _knownCommands.Add('R', new TurnRight());
            _knownCommands.Add('L', new TurnLeft());
        }

        public IRobotCommand GetCommand(char command)
        {
            if (_knownCommands.TryGetValue(char.ToUpper(command), out var robotCommand))
                return robotCommand;

            throw new ArgumentOutOfRangeException(nameof(command), $"Command not supported: '{command}'");
        }
    }
}
