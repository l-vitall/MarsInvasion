using MarsInvasion.Navigation;
using MarsInvasion.Robots;
using MarsInvasion.Robots.Interfaces;
using System;
using System.Collections.Generic;

namespace MarsInvasion
{
    public class MarsInvasionControlCenter
    {
        private SurfaceGrid _marsSurface;
        
        public LinkedList<Robot> Robots { get; private set; }

        public MarsInvasionControlCenter(SurfaceGrid marsSurface)
        {
            _marsSurface = marsSurface ?? throw new ArgumentNullException(nameof(marsSurface));
        }

        public IRobot AddNewRobot(SurfacePosition position, SurfaceDirection direction)
        {
            return new Robot(_marsSurface, position, direction);
        }
    }
}
