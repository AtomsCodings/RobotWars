using RobotWars.Interface;
using RobotWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotWars.Position
{
    /// <summary>
    /// Position class
    /// </summary>
    public class Position : Models.Position, IPosition 
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Position()
        {
            X = Y = 0;
            Direction = Directions.N;
            penalty = 0;
        }

        /// <summary>
        /// Rotate 90 degrees left
        /// </summary>
        private void Rotate90Left()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Rotate 90 degrees right
        /// </summary>
        private void Rotate90Right()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Move in same direction
        /// </summary>
        private void MoveInSameDirection()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Y ++;
                    break;
                case Directions.S:
                    this.Y --; 
                    break;
                case Directions.E:
                    this.X ++;
                    break;
                case Directions.W:
                    this.X --;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Start moving
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="moves"></param>
        public void StartMoving(List<int> maxPoints, string moves)
        {
            int xMaxPoint = maxPoints[0];
            int yMaxPoint = maxPoints[1];

            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        this.MoveInSameDirection();
                        PenaltyCalc(xMaxPoint, yMaxPoint);
                        break;
                    case 'L':
                        this.Rotate90Left();
                        break;
                    case 'R':
                        this.Rotate90Right();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Perform penality calculation
        /// </summary>
        /// <param name="xMaxPoint"></param>
        /// <param name="yMaxPoint"></param>
        public void PenaltyCalc(int xMaxPoint, int yMaxPoint)
        {
            //penality calcaulted if robot is outside of grid boundary
            if (this.X < 0 || this.X > xMaxPoint || this.Y < 0 || this.Y > yMaxPoint)
            {
                penalty++;

                //reset so that the robot does not move forwards if outside of the grid boundary
                if (this.X < 0)
                {
                    this.X = 0;
                }
                if (this.X > xMaxPoint)
                {
                    this.X = xMaxPoint;
                }
                if (this.Y < 0)
                {
                    this.Y = 0;
                }
                if (this.Y > yMaxPoint)
                {
                    this.Y = yMaxPoint;
                }
            }
        }
    }
}
