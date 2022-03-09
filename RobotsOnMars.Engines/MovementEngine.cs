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
        public Position GetLastPosition(Position initialPosition, CoordinatePoint maxExtension, List<string> instructions)
        {
            var position = new Position
            {
                Location = initialPosition.Location,
                Orientation = initialPosition.Orientation
            };
            foreach (var item in instructions)
            {                
                position.Orientation = OrientationActions.GetNewOrientation(position.Orientation, item);
                position.Location = TranslationActions.GetNewLocation(position.Location, position.Orientation, item);
                position = TranslationActions.GetValidatedPosition(position, maxExtension);
                if (position.IsLost)
                {
                    break;
                }
            }

            return position;
        }
    }
}
