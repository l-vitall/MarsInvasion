namespace MarsInvasion.RobotCommands.Interfaces
{
    public interface IRobotCommandsFactory
    {
        IRobotCommand GetCommand(char commandString);
    }
}
