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
        private readonly IMovementEngine _movementEngine;
        public RobotsEngine()
        {
            _inputEngine = new InputEngine();
            _movementEngine = new MovementEngine();
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
                    LastPosition = initialPosition,
                    CautionLocation = new CoordinatePoint
                    {
                        X = 1000,
                        Y = 1000
                    },
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

        public string LastPositionInfoToPrint(Robot robot)
        {
            var isLost = robot.HasDropDown ? "LOST" : string.Empty;
            var info = $"{robot.LastPosition.Location.X} " +
                $"{robot.LastPosition.Location.Y} " +
                $"{robot.LastPosition.Orientation} " +
                $"{isLost}";

            return info;
        }

        public void SetLastPosition(Robot robot, Mars mars)
        {
            try
            {
                var cautionPoints = mars.RobotsOnMars.Select(x => x.CautionLocation).ToList();
                robot.LastPosition = _movementEngine.GetLastPosition(robot.InitialPosition, cautionPoints, mars.MaxExtension, robot.Instructions);
                if (robot.LastPosition.IsLost)
                {
                    robot.HasDropDown = true;
                    robot.CautionLocation = robot.LastPosition.Location;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
