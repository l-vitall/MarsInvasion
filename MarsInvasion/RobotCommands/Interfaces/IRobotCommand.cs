using MarsInvasion.Navigation.Interfaces;
using MarsInvasion.Robots.Interfaces;

namespace MarsInvasion.RobotCommands.Interfaces
{
    public interface IRobotCommand
    {
        public void Execute(IRobot robot, ISurfaceGrid surface);
    }
}
