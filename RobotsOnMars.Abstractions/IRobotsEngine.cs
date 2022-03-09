using RobotsOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Abstractions
{
    public interface IRobotsEngine
    {
        Robot GenerateRobot(string input);
        List<Robot> GenerateRobotsList(List<string> input);
    }
}
