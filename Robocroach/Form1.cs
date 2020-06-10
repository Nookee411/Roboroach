using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robocroach
{
    enum Direction : byte {Up,Right,Down,Left };
    public partial class Form1 : Form
    {
        List<Cockroach> activeCockroach;
        List<PictureBox> pictureboxWork;
        List<Cockroach> LC;
        List<PictureBox> PB;
        int algStep=0;
        string cockroach_Skin = "../../cockroach1.png";
        public Form1()
        {
            InitializeComponent();
            LC = new List<Cockroach>();
            PB = new List<PictureBox>();
            activeCockroach = new List<Cockroach>();
            pictureboxWork = new List<PictureBox>();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {

            Cockroach cockroach = new Cockroach(new Bitmap(cockroach_Skin));
            cockroach.image = new Bitmap(cockroach.image, new Size(100, 100));
            PictureBox p = new PictureBox();
            p.BackColor = Color.Transparent;
            activeCockroach.Clear();
            activeCockroach.Add(cockroach);
            pictureboxWork.Clear();
            pictureboxWork.Add(p);
            show();
            p.MouseMove += new MouseEventHandler(IMouseMove);
            p.MouseDown += new MouseEventHandler(IMouseDown);
            PB.Add(p);
            LC.Add(cockroach);
            panelField.AllowDrop = true;
        }

        private void IMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int k = PB.IndexOf(sender as PictureBox);//запоминаем номер нажатого компонента
                //объявляет его рабочим
                if (ModifierKeys!=Keys.Control)
                {
                    
                    for (int i = 0; i < pictureboxWork.Count; i++)
                        pictureboxWork[i].BackColor = Color.Transparent;
                    activeCockroach.Clear();
                    pictureboxWork.Clear();
                }
                pictureboxWork.Add(sender as PictureBox);
                pictureboxWork[pictureboxWork.Count - 1].BackColor = Color.Blue;
                if(k>=0)
                    activeCockroach.Add(LC[k]);//по найденному номеру находим Таракана
            }
            else if(e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < pictureboxWork.Count; i++)
                    pictureboxWork[i].BackColor = Color.Transparent;
                activeCockroach.Clear();
                pictureboxWork.Clear();
            }
        }

        private void IMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox picture = sender as PictureBox;
                picture.Tag = new Point(e.X, e.Y);//запоминаем координаты мыши на момент начала
            picture.DoDragDrop(sender, DragDropEffects.Move);//начинаем перетаскивание ЧЕГО и с КАКИМ ЭФФЕКТОМ
            }
        }

        private void panelField_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void panelField_DragDrop(object sender, DragEventArgs e)
        {
            //извлекаем PictureBox
            PictureBox picture = (PictureBox)e.Data.GetData(typeof(PictureBox));
            Panel panel = sender as Panel; 
            //получаем клиентские координаты в момент отпускания кнопки
            Point pointDrop = panel.PointToClient(new Point(e.X, e.Y));
            //извлекаем клиентские координаты мыши в момент начала перетскивания
            Point pointDrag = (Point)picture.Tag;
            //вычисляем и устанавливаем Location для PictureBox в Panel
            picture.Location = pointDrop;
            //устанавливаем координаты для X и Y для рабочего таракана
            for (int i = 0; i < activeCockroach.Count; i++)
            {
                activeCockroach[i].X = picture.Location.X;
                activeCockroach[i].Y = picture.Location.Y;
                
            }
            picture.Parent = panel;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Add((sender as Button).Text);
        }
        
        private void buttonClear_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Clear();
            timerAlgorithm.Stop();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            algStep = 0;
            timerAlgorithm.Start();
        }

        private void timerAlgorithm_Tick(object sender, EventArgs e)
        {
            if (algStep == Algorithm.Items.Count) //конец алгоритма
            {
                timerAlgorithm.Stop();
            }
            else//выполнение команды из списка
            {
                string s = (string)Algorithm.Items[algStep];
                Algorithm.SetSelected(algStep, true);
                if (s == "Step")
                {
                    for (int i = 0; i < activeCockroach.Count; i++)
                        activeCockroach[i].Step();
                }

                else
                {
                    for(int i=0;i<activeCockroach.Count;i++)
                        activeCockroach[i].ChangeTrend(s);
                }
                RePaint();
                algStep++;
            }
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            if(activeCockroach!=null)
                foreach (Cockroach active in activeCockroach)
                    active.Step();
            Algorithm.Items.Add((sender as Button).Text);
        }
        public void RePaint() //Paintint image with new location
        {
            for(int i=0;i<activeCockroach.Count;i++)
            { 
                pictureboxWork[i].Bounds = new Rectangle(activeCockroach[i].X, activeCockroach[i].Y, activeCockroach[i].image.Width, activeCockroach[i].image.Height);//New bounds
                pictureboxWork[i].Image = activeCockroach[i].image;
            }
        }
        public void show() //setting location of cockroach
        {
            for (int i = 0; i < activeCockroach.Count; i++)
            {
                //setting location for image
                activeCockroach[i].X = (panelField.Width - activeCockroach[i].image.Width) / 2;
                activeCockroach[i].Y = (panelField.Height - activeCockroach[i].image.Height) / 2;
                RePaint();
                //Setting contol over picturebox to panel
                panelField.Controls.Add(pictureboxWork[i]);
            }

        }

        private void buttonChangeSkin_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            if(file.FileName!="")
                cockroach_Skin = file.FileName;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
            for(int i=0;i<activeCockroach.Count;i++)
            {
                pictureboxWork[i].Dispose();
                LC.Remove(activeCockroach[i]);
                PB.Remove(pictureboxWork[i]);
            }
            activeCockroach.Clear();
            pictureboxWork.Clear();
            panelField.Refresh();
            RePaint();
        }
    }
}
