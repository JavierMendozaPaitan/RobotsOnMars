using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Models
{
    public class Robot
    {
        public CoordinatePoint InitialLocation { get; set; }
        public CoordinatePoint CurrentLocation { get; set; }
        public CoordinatePoint CautionLocation { get; set; }
        public bool HasDropDown { get; set; }
        public Orientation InitialOrientation { get; set; }
        public Orientation CurrentOrientation { get; set; }
        public List<string> Instructions { get; set; }
    }
}
