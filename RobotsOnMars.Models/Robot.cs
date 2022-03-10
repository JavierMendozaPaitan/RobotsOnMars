using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Models
{
    public class Robot
    {
        public Position InitialPosition { get; set; }
        public Position LastPosition { get; set; }
        public CoordinatePoint CautionLocation { get; set; }
        public bool HasDropDown { get; set; } = false;
        public List<string> Instructions { get; set; }
    }
}
