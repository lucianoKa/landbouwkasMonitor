using System.Drawing;
using System.Windows.Forms;

namespace LBM
{
    public partial class WaitForm : Form
    {
        public WaitForm(string text)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            label2.Text = text;
            
        }
        public WaitForm(Form parent, string text)
        {
            InitializeComponent();
            label2.Text = text;
            if (parent != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(parent.Location.X + parent.Width / 2 - this.Width / 2, parent.Location.Y + parent.Height / 2 - this.Height / 2);
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }
        }
        public void CloseLoadingForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            label1.Image?.Dispose();
        }
    }
}
