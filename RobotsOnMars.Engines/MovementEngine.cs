using RobotsOnMars.Abstractions;
using RobotsOnMars.Engines.Actions;
using RobotsOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Engines
{
    public class MovementEngine : IMovementEngine
    {
        public Position GetLastPosition(Position initialPosition, List<CoordinatePoint> cautionPoints, CoordinatePoint maxExtension, List<string> instructions)
        {
            var position = new Position
            {
                Location = initialPosition.Location,
                Orientation = initialPosition.Orientation
            };
            foreach (var item in instructions)
            {                
                position.Orientation = OrientationActions.GetNewOrientation(position.Orientation, item);
                var location = TranslationActions.GetNewLocation(position.Location, position.Orientation, item);
                var isCautionPoint = IsCautionPoint(location, cautionPoints);
                if (!isCautionPoint)
                {
                    position.Location = location;
                }
                position = TranslationActions.GetValidatedPosition(position, maxExtension);
                if (position.IsLost)
                {
                    break;
                }
            }

            return position;
        }

        private bool IsCautionPoint(CoordinatePoint location, List<CoordinatePoint> cautionPoints)
        {
            var isCautionPoint = false;
            foreach (var item in cautionPoints)
            {
                if(location.X.Equals(item.X) && location.Y.Equals(item.Y))
                {
                    isCautionPoint = true;
                    break;
                }
            }

            return isCautionPoint;
        }
    }
}
