using RobotsOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Engines.Actions
{
    public static class OrientationActions
    {
        public static Orientation GetNewOrientation(Orientation orientation, string rotation)
        {
            var newOrientation = Orientation.Unknown;
            switch(orientation, rotation)
            {
                case (Orientation.N, "R"):
                    newOrientation = Orientation.E;
                    break;
                case (Orientation.N, "L"):
                    newOrientation = Orientation.W;
                    break;
                case (Orientation.N, "F"):
                    newOrientation = Orientation.N;
                    break;
                case (Orientation.E, "R"):
                    newOrientation = Orientation.S;
                    break;
                case (Orientation.E, "L"):
                    newOrientation = Orientation.N;
                    break;
                case (Orientation.E, "F"):
                    newOrientation = Orientation.E;
                    break;
                case (Orientation.S, "R"):
                    newOrientation = Orientation.W;
                    break;
                case (Orientation.S, "L"):
                    newOrientation = Orientation.E;
                    break;
                case (Orientation.S, "F"):
                    newOrientation = Orientation.S;
                    break;
                case (Orientation.W, "R"):
                    newOrientation = Orientation.N;
                    break;
                case (Orientation.W, "L"):
                    newOrientation = Orientation.S;
                    break;
                case (Orientation.W, "F"):
                    newOrientation = Orientation.W;
                    break;
                default:
                    break;
            }

            return newOrientation;
        }
    }
}
