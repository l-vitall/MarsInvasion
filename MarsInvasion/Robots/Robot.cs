using MarsInvasion.Navigation;
using MarsInvasion.Navigation.Interfaces;
using MarsInvasion.Robots.Interfaces;
using System;

namespace MarsInvasion.Robots
{
    public class Robot : IRobot
    {
        private readonly ISurfaceGrid _marsSurface;

        public SurfacePosition Position { get; private set; }
        public SurfaceDirection Direction { get; private set; }

        public bool IsLost { get; private set; }

        public Robot(ISurfaceGrid marsSurface, SurfacePosition position, SurfaceDirection direction)
        {
            Position = position;
            Direction = direction;

            _marsSurface = marsSurface ?? throw new ArgumentNullException(nameof(marsSurface));
            IsLost = !_marsSurface.IsValidPosition(position);
        }

        public void ExecuteCommands(RobotCommandSet commandSet)
        {
            CheckIfLost();

            foreach (var command in commandSet.Commands)
            {
                try
                {
                    command.Execute(this, _marsSurface);
                }
                catch (RobotLostException)
                {
                    IsLost = true;
                    break;
                }
            }
        }

        private void CheckIfLost()
        {
            if (IsLost)
                throw new InvalidOperationException("Unable to execute commands for the lost robot");
        }

        public void SetDirection(SurfaceDirection newDirection)
        {
            Direction = newDirection;
        }

        public void SetPosition(SurfacePosition newPosition)
        {
            Position = newPosition;
        }
    }
}
