using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robocroach.State
{
    abstract class DirectionState
    {
        protected Bitmap image;
        protected const int step = 30;
        protected Dictionary<string, Direction> Trends = new Dictionary<string, Direction>()
        {
            {"Up", Direction.Up },
            {"Down", Direction.Down },
            {"Left", Direction.Left },
            {"Right", Direction.Right }
        };
            abstract public void Step(ref int X, ref int Y);
            abstract public DirectionState ChangeTrend(string command);
            Direction Trend { get; }
            virtual public Bitmap Image { get; }

    }
}
