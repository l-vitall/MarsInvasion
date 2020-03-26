using MarsInvasion.Navigation;
using MarsInvasion.Navigation.Interfaces;
using MarsInvasion.RobotCommands.Interfaces;
using MarsInvasion.Robots.Interfaces;
using System;

namespace MarsInvasion.RobotCommands
{
    class MoveStepFoward : IRobotCommand
    {
        public void Execute(IRobot robot, ISurfaceGrid surfaceGrid)
        {
            var newPosition = new SurfacePosition(robot.Position.Row, robot.Position.Column);

            switch (robot.Direction)
            {
                case SurfaceDirection.Up:
                    newPosition.Row++;
                    break;
                case SurfaceDirection.Left:
                    newPosition.Column--;
                    break;
                case SurfaceDirection.Down:
                    newPosition.Row--;
                    break;
                case SurfaceDirection.Right:
                    newPosition.Column++;
                    break;
                default:
                    throw new ArgumentException(nameof(robot.Direction), "Direction is not supported: " + robot.Direction);
            }

            if (!surfaceGrid.IsDeadScentMovement(robot.Position, robot.Direction))
            {
                try
                {
                    surfaceGrid.Move(robot.Position, robot.Direction);
                }
                finally 
                {
                    robot.SetPosition(newPosition);
                }
            }
        }
    }
}
