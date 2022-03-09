using RobotsOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Abstractions
{
    public interface IInputEngine
    {
        CoordinatePoint GetMaxExtension(string input);
        Position GetPosition(string input);
        List<string> GetInstructions(string input);
    }
}
