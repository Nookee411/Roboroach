using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robocroach
{
    class Cockroach
    {
        private Bitmap image;
        direction trend = direction.Right;
        const int step = 30;
        //Loaction
        public Cockroach(Bitmap _Image)
        {
            this.image = _Image;
        }
        public int X { get; set; }
        public int Y { get; set; }

        

        public void Show(PictureBox picture, Panel owner)
        {
            //setting location for image
            X = (owner.Width - image.Width) / 2;
            Y = (owner.Height - image.Height) / 2;
            RePaint(picture);
            //Setting contol over picturebox to panel
            owner.Controls.Add(picture);

        }
        public void Step()
        {
            switch (trend)
            {
                case direction.Right:
                    X += step; break;
                case direction.Left:
                    X -= step; break;
                case direction.Up:
                    Y -= step; break;
                case direction.Down:
                    Y += step; break;
            }
        }

        public void ChangeTrend(char c)
        {
            direction newtrend = trend;
            for (direction y = direction.Up; y <= direction.Left; y++)
                if (char.ToLower(c) == char.ToLower(y.ToString()[0]))
                {
                    newtrend = y;
                    break;
                }
            switch (trend)
            {
                case direction.Up:
                    switch (newtrend)
                    {
                        case direction.Right:
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case direction.Down:
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case direction.Left:
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    break;
                case direction.Right:
                    switch (newtrend)
                    {
                        case direction.Down:
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case direction.Left:
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case direction.Up:
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    break;
                case direction.Down:
                    switch (newtrend)
                    {
                        case direction.Left:
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case direction.Up:
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case direction.Right:
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    break;
                case direction.Left:
                    switch (newtrend)
                    {
                        case direction.Up:
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case direction.Right:
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case direction.Down:
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    break;
            }
            trend = newtrend;
        }
    }
}
