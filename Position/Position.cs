using RobotWars.Interface;
using RobotWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotWars.Position
{
    public class Position : Models.Position, IPosition 
    {
        public Position()
        {
            X = Y = 0;
            Direction = Directions.N;
            penalty = 0;
        }

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
