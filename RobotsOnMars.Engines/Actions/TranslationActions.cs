using RobotsOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Engines.Actions
{
    public static class TranslationActions
    {
        public static CoordinatePoint GetNewLocation(CoordinatePoint location, Orientation orientation, string rotation)
        {
            var newLocation = new CoordinatePoint
            {
                X = location.X,
                Y = location.Y
            };

            switch(orientation, rotation)
            {
                case (Orientation.N, "F"):
                    newLocation.Y += 1;
                    break;
                case (Orientation.S, "F"):
                    newLocation.Y -= 1;
                    break;
                case (Orientation.E, "F"):
                    newLocation.X += 1;
                    break;
                case (Orientation.W, "F"):
                    newLocation.X -= 1;
                    break;
                default:
                    break;
            }

            return newLocation;
        }

        public static CoordinatePoint GetLostLocation(CoordinatePoint location, CoordinatePoint maxExtension)
        {

        }
    }
}
