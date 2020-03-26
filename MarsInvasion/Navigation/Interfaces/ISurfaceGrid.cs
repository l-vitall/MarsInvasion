using MarsInvasion.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsInvasion.Navigation.Interfaces
{
    public interface ISurfaceGrid
    {
        bool IsValidPosition(SurfacePosition position);

        bool IsDeadScentMovement(SurfacePosition position, SurfaceDirection direction);
        SurfacePosition Move(SurfacePosition fromPosition, SurfaceDirection direction);
    }
}
