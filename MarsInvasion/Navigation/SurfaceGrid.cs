using MarsInvasion.Navigation.Interfaces;
using System;

namespace MarsInvasion.Navigation
{
    public class SurfaceGrid : ISurfaceGrid
    {
        public const int MaxCoordinate = 50;

        private int _rowsCount;
        private int _columnsCount;

        private bool[] _leftColumnRobotScents;
        private bool[] _rightColumnRobotScents;

        private bool[] _upperRowRobotScents;
        private bool[] _bottomRowRobotScents;

        public SurfaceGrid(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0 || rowsCount > MaxCoordinate)
                throw new ArgumentException($"rowsCount must be greater than zero and less than {MaxCoordinate}");

            if (columnsCount <= 0 || rowsCount > MaxCoordinate)
                throw new ArgumentException("columnsCount must be greater than zero and less than {MaxCoordinate}");

            _rowsCount = rowsCount;
            _columnsCount = columnsCount;

            _leftColumnRobotScents = new bool[_rowsCount];
            _rightColumnRobotScents = new bool[_rowsCount];
            _upperRowRobotScents = new bool[_columnsCount];
            _bottomRowRobotScents = new bool[_columnsCount];
        }

        public bool IsValidPosition(SurfacePosition position)
        {
            return position.Row >= 0
                && position.Column >= 0
                && position.Row < _rowsCount
                && position.Column < _columnsCount;
        }

        public bool IsDeadScentMovement(SurfacePosition position, SurfaceDirection direction)
        {
            if (position.Column == 0 && direction == SurfaceDirection.Left)
            {
                return _leftColumnRobotScents[position.Row];
            }
            else if (position.Column == _columnsCount - 1 && direction == SurfaceDirection.Right)
            {
                return _rightColumnRobotScents[position.Row];
            }
            else if (position.Row == 0 && direction == SurfaceDirection.Down)
            {
                return _bottomRowRobotScents[position.Column];
            }
            else if (position.Row == _rowsCount - 1 && direction == SurfaceDirection.Up)
            {
                return _upperRowRobotScents[position.Column];
            }

            return false;
        }

        public SurfacePosition Move(SurfacePosition position, SurfaceDirection direction)
        {
            if (IsLost(position, direction))
                throw new RobotLostException();

            var newPosition = new SurfacePosition(position.Row, position.Column);

            switch (direction)
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
                    throw new ArgumentException(nameof(direction), "Direction is not supported: " + direction);
            }

            return newPosition;
        }

        private bool IsLost(SurfacePosition position, SurfaceDirection direction)
        {
            if (position.Column == 0 && direction == SurfaceDirection.Left)
            {
                _leftColumnRobotScents[position.Row] = true;
                return true;
            }
            else if (position.Column == _columnsCount - 1 && direction == SurfaceDirection.Right)
            {
                _rightColumnRobotScents[position.Row] = true;
                return true;
            }
            else if (position.Row == 0 && direction == SurfaceDirection.Down)
            {
                _bottomRowRobotScents[position.Column] = true;
                return true;
            }
            else if (position.Row == _rowsCount - 1 && direction == SurfaceDirection.Up)
            {
                _upperRowRobotScents[position.Column] = true;
                return true;
            }

            return false;
        }
    }
}
