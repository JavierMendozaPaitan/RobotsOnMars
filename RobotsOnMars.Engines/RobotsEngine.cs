using RobotsOnMars.Abstractions;
using RobotsOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Engines
{
    public class RobotsEngine : IRobotsEngine
    {
        private readonly IInputEngine _inputEngine;
        public RobotsEngine()
        {
            _inputEngine = new InputEngine();
        }
        public Robot GenerateRobot(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new ArgumentNullException("Input for Robot cannot be null");
                }
                var str = input.Split(";");
                var initialPosition = _inputEngine.GetPosition(str[0]);
                var robot = new Robot
                {
                    InitialPosition = initialPosition,
                    CurrentPosition = initialPosition,
                    Instructions = _inputEngine.GetInstructions(str[1])
                };

                return robot;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Robot> GenerateRobotsList(List<string> input)
        {
            try
            {
                var list = new List<Robot>();
                foreach (var item in input)
                {
                    var robot = GenerateRobot(item);
                    list.Add(robot);
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
