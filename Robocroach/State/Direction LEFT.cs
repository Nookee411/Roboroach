﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Robocroach.State
{
    class Direction_LEFT:DirectionState,IDirection
    {
        public Direction_LEFT(Bitmap image)
        {
            this.image = image;
        }


        /// <summary>
        /// Gets current direction
        /// </summary>
        public Direction Trend => Direction.Left;

        public Bitmap Image => this.image;

        /// <summary>
        /// Changes coordinates according to the current direction
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void Step(ref int X, ref int Y)
        {
            X -= step;
        }

        public IDirection ChangeTrend(string command)
        {
            Direction newtrend = Trends[command];
            switch (newtrend)
            {
                case Direction.Up:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return new Direction_UP(image);
                case Direction.Right:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return new Direction_RIGHT(image);
                case Direction.Down:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    return new Direction_DOWN(image);
                default: return new Direction_LEFT(image);
            }
        }
    }
}
