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

        public static Position GetValidatedPosition(Position position, CoordinatePoint maxExtension)
        {
            var checkPosition = new Position
            {
                Location = position.Location,
                Orientation = position.Orientation
            };
            if(checkPosition.Location.X > maxExtension.X || 
                checkPosition.Location.Y > maxExtension.Y ||
                checkPosition.Location.X < 0 ||
                checkPosition.Location.Y < 0)
            {
                checkPosition.Location = GetLostLocation(checkPosition.Location, maxExtension);
                checkPosition.IsLost = true;
            }

            return checkPosition;
        }
        private static CoordinatePoint GetLostLocation(CoordinatePoint location, CoordinatePoint maxExtension)
        {
            var lostLocation = new CoordinatePoint
            {
                X = location.X,
                Y = location.Y
            };
            if(lostLocation.X > maxExtension.X)
            {
                lostLocation.X -= 1;
                if(lostLocation.Y > maxExtension.Y)
                {
                    lostLocation.Y -= 1;
                }
            }
            else if(lostLocation.Y > maxExtension.Y)
            {
                lostLocation.Y -= 1;
            }
            else if(lostLocation.X < 0)
            {
                lostLocation.X += 1;
            }
            else if(lostLocation.Y < 0)
            {
                lostLocation.Y += 1;
            }

            return lostLocation;
        }


    }
}
