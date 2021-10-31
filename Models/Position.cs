using RobotWars.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotWars.Models
{
    /// <summary>
    /// Position model class
    /// </summary>
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int penalty { get; set; }
        public Directions Direction { get; set; }
    }

    /// <summary>
    /// Directions enum
    /// </summary>
    public enum Directions
    {
        N = 1,//North
        S = 2,//South
        E = 3,//East
        W = 4//West
    }
}
