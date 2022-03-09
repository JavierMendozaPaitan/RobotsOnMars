using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Models
{
    public class Position
    {
        public CoordinatePoint Location { get; set; }
        public Orientation Orientation { get; set; }
        public bool IsLost { get; set; } = false;
    }
}
