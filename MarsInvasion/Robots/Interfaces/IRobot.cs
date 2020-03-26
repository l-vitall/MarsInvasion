using MarsInvasion.Navigation;

namespace MarsInvasion.Robots.Interfaces
{
    public interface IRobot
    {
        SurfacePosition Position { get; }
        SurfaceDirection Direction { get; }

        bool IsLost { get; }

        void ExecuteCommands(RobotCommandSet commandSet);
        void SetDirection(SurfaceDirection newDirection);
        void SetPosition(SurfacePosition newPosition);
    }
}
