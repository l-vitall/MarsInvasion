using MarsInvasion.Navigation;
using MarsInvasion.RobotCommands;
using MarsInvasion.Robots.Interfaces;
using NUnit.Framework;

namespace MarsInvasion.Tests.ComponentTests
{
    [TestFixture]
    public class MarsInvasionControlCenterTests
    {
        RobotCommandsFactory _commandsFactory = new RobotCommandsFactory();

        [TestCase(5, 3, 1, 1, SurfaceDirection.Right, "RFRFRFRF", 1, 1, SurfaceDirection.Right, false)]
        [TestCase(5, 3, 3, 2, SurfaceDirection.Up, "FRRFLLFFRRFLL", 4, 2, SurfaceDirection.Up, false)]
        [TestCase(5, 3, 0, 3, SurfaceDirection.Left, "LLFFFLFLFL", 0, 4, SurfaceDirection.Right, true)]
        [TestCase(5, 3, 2, 3, SurfaceDirection.Up, "FRRFLLFFRRFLL", 3, 3, SurfaceDirection.Up, false)]
        [TestCase(5, 3, 3, 0, SurfaceDirection.Left, "LLFFFLFLFL", 4, 2, SurfaceDirection.Down, false)]
        public void Robot_Moves_As_Expected(int surfaceRowsCount, int surfaceColumnsCount, int robotPositionRow, int robotPositionColumn, SurfaceDirection surfaceDirection,
            string commandsString, int expectedPositionRow, int expectedPositionColumn, SurfaceDirection expectedDirection, bool expectedIsLost)
        {
            SurfaceGrid _marsSurface = new SurfaceGrid(surfaceRowsCount + 1, surfaceColumnsCount + 1);
            MarsInvasionControlCenter controlCenter = new MarsInvasionControlCenter(_marsSurface);

            var position = new SurfacePosition(robotPositionRow, robotPositionColumn);
            var newRobot = controlCenter.AddNewRobot(position, surfaceDirection);

            if (!newRobot.IsLost)
            {
                var commandSet = RobotCommandSet.Create(_commandsFactory, commandsString);
                newRobot.ExecuteCommands(commandSet);
                PrintPosition(newRobot);
            }
            else
                PrintPosition(newRobot);

            Assert.AreEqual(expectedPositionRow, newRobot.Position.Row);
            Assert.AreEqual(expectedPositionColumn, newRobot.Position.Column);
            Assert.AreEqual(expectedDirection, newRobot.Direction);
            Assert.AreEqual(expectedIsLost, newRobot.IsLost);
        }

        [Test]
        public void Robot_Not_Move_If_Scent_Exist()
        {
            SurfaceGrid _marsSurface = new SurfaceGrid(2, 2);
            MarsInvasionControlCenter controlCenter = new MarsInvasionControlCenter(_marsSurface);

            //First robot is being lost
            var position = new SurfacePosition(1, 1);
            var newRobot = controlCenter.AddNewRobot(position, SurfaceDirection.Up);

            var commandSet = RobotCommandSet.Create(_commandsFactory, "F");
            newRobot.ExecuteCommands(commandSet);

            Assert.IsTrue(newRobot.IsLost);

            //Second robot is not lost
            newRobot = controlCenter.AddNewRobot(position, SurfaceDirection.Up);
            newRobot.ExecuteCommands(commandSet);

            Assert.IsFalse(newRobot.IsLost);
            Assert.AreEqual(1, newRobot.Position.Row);
            Assert.AreEqual(1, newRobot.Position.Column);
        }

        public void GetCommand_Should_Success(int surfaceRowsCount, int surfaceColumnsCount, int robotPositionRow, int robotPositionColumn, SurfaceDirection surfaceDirection,
            string commandsString, int expectedPositionRow, int expectedPositionColumn, SurfaceDirection expectedDirection, bool expectedIsLost)
        {
            SurfaceGrid _marsSurface = new SurfaceGrid(surfaceRowsCount + 1, surfaceColumnsCount + 1);
            MarsInvasionControlCenter controlCenter = new MarsInvasionControlCenter(_marsSurface);

            var position = new SurfacePosition(robotPositionRow, robotPositionColumn);
            var newRobot = controlCenter.AddNewRobot(position, surfaceDirection);

            if (!newRobot.IsLost)
            {
                var commandSet = RobotCommandSet.Create(_commandsFactory, commandsString);
                newRobot.ExecuteCommands(commandSet);
                PrintPosition(newRobot);
            }
            else
                PrintPosition(newRobot);

            Assert.AreEqual(expectedPositionRow, newRobot.Position.Row);
            Assert.AreEqual(expectedPositionColumn, newRobot.Position.Column);
            Assert.AreEqual(expectedDirection, newRobot.Direction);
            Assert.AreEqual(expectedIsLost, newRobot.IsLost);
        }

        private static void PrintPosition(IRobot newRobot)
        {
            TestContext.Out.WriteLine($"Robot position: {newRobot.Position.Row} {newRobot.Position.Column} {newRobot.Direction}{(newRobot.IsLost ? " LOST" : string.Empty)}");
        }
    }
}
