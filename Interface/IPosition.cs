using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotWars.Interface
{
    public interface IPosition
    {
        /// <summary>
        /// StartMoving interface
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="moves"></param>
        void StartMoving(List<int> maxPoints, string moves);
    }
}
