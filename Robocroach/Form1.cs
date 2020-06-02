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
    enum direction : byte {Up,Right,Down,Left };
    public partial class Form1 : Form
    {
        Cockroach activeCockroach;
        PictureBox pictureboxWork;
        List<Cockroach> LC;
        List<PictureBox> PB;
        List<int> selectedRoaches;
        bool selectionActive = false;
        int algStep=0;
        string cockroach_Skin = "../../cockroach1.png";
        public Form1()
        {
            InitializeComponent();
            LC = new List<Cockroach>();
            PB = new List<PictureBox>();
            selectedRoaches = new List<int>();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Cockroach cockroach = new Cockroach(new Bitmap(cockroach_Skin));
            PictureBox p = new PictureBox();
            p.BackColor = Color.Transparent;
            activeCockroach = cockroach;
            pictureboxWork = p;
            show();
            p.MouseMove += new MouseEventHandler(IMouseMove);
            p.MouseDown += new MouseEventHandler(IMouseDown);
            PB.Add(p);
            LC.Add(activeCockroach);
            panelField.AllowDrop = true;
        }

        private void IMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int k = PB.IndexOf(sender as PictureBox);//запоминаем номер нажатого компонента
                pictureboxWork = sender as PictureBox;//объявляет его рабочим
                activeCockroach = LC[k];//по найденному номеру находим Таракана в списке
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
            activeCockroach.X = picture.Location.X;
            activeCockroach.Y = picture.Location.Y;
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
                    activeCockroach.Step();
                else
                    activeCockroach.ChangeTrend(s[0]);
                RePaint();
                algStep++;
            }
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            if(activeCockroach!=null)
                activeCockroach.Step();
            Algorithm.Items.Add((sender as Button).Text);
        }
        public void RePaint() //Paintint image with new location
        {
            pictureboxWork.Bounds = new Rectangle(activeCockroach.X,activeCockroach.Y, activeCockroach.image.Width, activeCockroach.image.Height);//New bounds
            pictureboxWork.Image = activeCockroach.image;
        }
        public void show() //setting location of cockroach
        {
            //setting location for image
            activeCockroach.X = (panelField.Width - activeCockroach.image.Width) / 2;
            activeCockroach.Y = (panelField.Height -activeCockroach.image.Height) / 2;
            RePaint();
            //Setting contol over picturebox to panel
            panelField.Controls.Add(pictureboxWork);

        }

        private void buttonChangeSkin_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            cockroach_Skin = file.FileName;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //selection activated
            if (e.KeyCode == Keys.Control)
                selectionActive = true;
                
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //selection deactivated
            if (e.KeyCode == Keys.Control)
                selectionActive = false;
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void panelField_Click(object sender, EventArgs e)
        {

        }

        private void panelField_MouseDown(object sender, MouseEventArgs e)
        {
            //if we have selection active, add roach to party, otherwise clear party
            if (selectionActive)
            {
                if(e.Button == MouseButtons.Left)
                {
                    panelField.BackColor = Color.Red;
                }
            }
            else
                selectedRoaches.Clear();
        }
    }
}
