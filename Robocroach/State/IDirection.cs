using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robocroach
{
    interface IDirection
    {
        void Step(ref int X, ref int Y);
        IDirection ChangeTrend(string command);
        Direction Trend { get; }
        Bitmap Image { get; }
        
    }
}
