using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace Robocroach.State
{
    class Direction_DOWN:DirectionState
    {
        public Direction_DOWN(Bitmap image)
        {
            this.image = image;
        }


        /// <summary>
        /// Gets current direction
        /// </summary>
        public Direction Trend => Direction.Down;

        override public Bitmap Image => this.image;

        /// <summary>
        /// Changes coordinates according to the current direction
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        override public void Step(ref int X, ref int Y)
        {
            Y += step;
        }

        override public DirectionState ChangeTrend(string command)
        {
            Direction newtrend = Trends[command];
            switch (newtrend)
            {
                case Direction.Left:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return new Direction_LEFT(image);
                case Direction.Up:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return new Direction_UP(image);
                case Direction.Right:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    return new Direction_RIGHT(image);
                default: return new Direction_DOWN(image);
            }
        }
    }
}
