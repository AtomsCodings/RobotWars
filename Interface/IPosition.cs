using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotWars.Interface
{
    public interface IPosition
    {
        void StartMoving(List<int> maxPoints, string moves);
    }
}
