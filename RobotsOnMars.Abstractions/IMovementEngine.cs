using RobotsOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Abstractions
{
    public interface IMovementEngine
    {
        Position GetLastPosition(Position initialPosition, CoordinatePoint maxExtension, List<string> instructions);
    }
}
