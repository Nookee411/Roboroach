using Robocroach.State;
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
        private int x;
        private int y;
        public Bitmap image;
        const int step = 30;
        DirectionState direction;
        //Loaction
        public Cockroach(Bitmap _image)
        {
            this.image = _image;
            direction = new Direction_RIGHT(image);
        }
        public int X 
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        //Repainting picture



        public void Step()
        {
            direction.Step(ref x,ref y);
        }

        public void ChangeTrend(string command)
        {
            direction = direction.ChangeTrend(command);
            image = direction.Image;
        }
    }
}
