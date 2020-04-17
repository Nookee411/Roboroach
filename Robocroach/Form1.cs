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
        int algStep=0;
        readonly string COCKROACH_NAME = "../../cockroach1.png";
        public Form1()
        {
            InitializeComponent();
            LC = new List<Cockroach>();
            PB = new List<PictureBox>();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Cockroach cockroach = new Cockroach(new Bitmap(COCKROACH_NAME));
            PictureBox p = new PictureBox();
            p.BackColor = Color.Transparent;
            cockroach.Show(p, panelField);
            p.MouseMove += new MouseEventHandler(IMouseMove);
            p.MouseDown += new MouseEventHandler(IMouseDown);
            PB.Add(p);
            LC.Add(cockroach);
            activeCockroach= cockroach;
            pictureboxWork = p;
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
                activeCockroach.RePaint(pictureboxWork);
                algStep++;
            }
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            if(activeCockroach!=null)
                activeCockroach.Step();
            Algorithm.Items.Add((sender as Button).Text);
        }
    }
}
