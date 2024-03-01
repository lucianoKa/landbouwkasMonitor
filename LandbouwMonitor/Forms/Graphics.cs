using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace LBM
{
    public partial class Graphics : KryptonForm
    {
        public Graphics()
        {
            InitializeComponent();

            FillGraph();
        }        

        private void Form2_Load(object sender, EventArgs e)
        {
          this.WindowState = FormWindowState.Maximized;
        }

        private void FillGraph()
        {
            //Create a Graph Control
            GraphCtrl = new GraphControl(new Font("Arial", 12), new Font("Arial", 10), new Font("Arial", 8), "dd-MM-yyyy")
            {
                TabIndex = 0,
                Dock = DockStyle.Fill,
                Name = "Graph 1"
            };

            //Add Graph Control to the form
            GraphPanel.Controls.Add(GraphCtrl);

            //Add series
            GraphCtrl.AddPointsSerie("Serie1", Axes.VerticalPrimary, "Serie 1", Color.Blue);
            GraphCtrl.AddPointsSerie("Serie2", Axes.VerticalPrimary, "Serie 2", Color.Orange);
            GraphCtrl.AddPointsSerie("Serie3", Axes.VerticalSecondary, "Serie 3", Color.DarkGreen);
            GraphCtrl.AddPointsSerie("Serie4", Axes.VerticalSecondary, "Serie 4", Color.Yellow);

            //Add points to the series
            const int Multiplier = 10;
            Random r = new Random();
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            double d = 0;
            double y1 = 0;
            double y2 = 5;
            double y3 = -20;
            double y4 = -25;
            for (int i = 0; i < 400; i++)
            {
                d = r.NextDouble() - 0.5;
                y1 += d * Multiplier;
                d = r.NextDouble() - 0.5;
                y2 += d * Multiplier;
                d = r.NextDouble() - 0.5;
                y3 += d * Multiplier;
                d = r.NextDouble() - 0.5;
                y4 += d * Multiplier;
                GraphCtrl.GetPointsSerie("Serie1").AddPointD(dt.AddHours(i), y1);
                GraphCtrl.GetPointsSerie("Serie2").AddPointD(dt.AddHours(i), y2);
                GraphCtrl.GetPointsSerie("Serie3").AddPointD(dt.AddHours(i), y3);
                GraphCtrl.GetPointsSerie("Serie4").AddPointD(dt.AddHours(i), y4);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument1.Print();
            MessageBox.Show("Graph printed!");
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            GraphCtrl.DrawGraph(e.Graphics, e.MarginBounds);
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            Bitmap Bmp = new Bitmap(800, 400);

            Bmp.SetResolution(100, 100);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(Bmp);
            g.Clear(Color.White);
            GraphCtrl.DrawGraph(g, new Rectangle(new Point(0, 0), Bmp.Size));
            Clipboard.SetImage(Bmp);
            MessageBox.Show("Graph copied to the Clipboard!");
        }
    }
}
