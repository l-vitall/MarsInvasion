using MarsInvasion.Navigation;
using MarsInvasion.Navigation.Interfaces;
using MarsInvasion.RobotCommands.Interfaces;
using MarsInvasion.Robots.Interfaces;
using System;

namespace MarsInvasion.RobotCommands
{
    public class TurnLeft : IRobotCommand
    {
        public void Execute(IRobot robot, ISurfaceGrid surface)
        {
            switch(robot.Direction)
            {
                case SurfaceDirection.Up:
                    robot.SetDirection(SurfaceDirection.Left);
                    break;
                case SurfaceDirection.Left:
                    robot.SetDirection(SurfaceDirection.Down);
                    break;
                case SurfaceDirection.Down:
                    robot.SetDirection(SurfaceDirection.Right);
                    break;
                case SurfaceDirection.Right:
                    robot.SetDirection(SurfaceDirection.Up);
                    break;
                default:
                    throw new ArgumentException(nameof(robot.Direction), "Current direction is not supported");
            }
        }
    }
}
