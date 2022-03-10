using RobotsOnMars.Abstractions;
using RobotsOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Engines
{
    public class InputEngine : IInputEngine
    {
        public List<string> GetInstructions(string input)
        {
            try
            {
                if (input.Length > 100)
                {
                    throw new InvalidOperationException("Max string length is 100");
                }
                var list = new List<string>();
                var arr = input.ToCharArray();
                foreach (var item in arr)
                {
                    list.Add(item.ToString().ToUpper());
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public CoordinatePoint GetMaxExtension(string input)
        {
            try
            {
                if (input.Length > 100)
                {
                    throw new InvalidOperationException("Max string length is 100");
                }
                var str = input.Split(" ");
                var point = new CoordinatePoint
                {
                    X = Convert.ToInt32(str[0]),
                    Y = Convert.ToInt32(str[1])
                };
                if(point.X > 50 || point.Y > 50)
                {
                    throw new InvalidOperationException("Max coordinate value is 50");
                }

                return point;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public Position GetPosition(string input)
        {
            try
            {
                if (input.Length > 100)
                {
                    throw new InvalidOperationException("Max string length is 100");
                }
                var str = input.Split(" ");
                var position = new Position
                {
                    Location = new CoordinatePoint
                    {
                        X = Convert.ToInt32(str[0]),
                        Y = Convert.ToInt32(str[1])
                    },
                    Orientation = Enum.Parse<Orientation>(str[2], true)
                };
                if (position.Location.X > 50 || position.Location.Y > 50)
                {
                    throw new InvalidOperationException("Max coordinate value is 50");
                }

                return position;
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
