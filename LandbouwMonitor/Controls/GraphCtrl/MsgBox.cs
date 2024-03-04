using System.Drawing;
using System.Windows.Forms;

namespace LBM
{
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
        }

        public MsgBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            InitializeComponent();
            switch(buttons)
            {
                case MessageBoxButtons.OK:
                    OKButton.Visible = true;
                    OKButton.Location = new Point((this.Size.Width - OKButton.Size.Width) / 2, OKButton.Location.Y);
                    break;
                case MessageBoxButtons.OKCancel:
                    OKButton.Visible = true;
                    ButtonCancel.Visible = true;
                    OKButton.Location = new Point((this.Width - OKButton.Width - ButtonCancel.Width) / 3, OKButton.Location.Y);
                    ButtonCancel.Location = new Point((2 * (this.Width - OKButton.Width - ButtonCancel.Width) / 3) + OKButton.Width, ButtonCancel.Location.Y);
                    break;
                case MessageBoxButtons.YesNo:
                    YESButton.Visible = true;
                    NOButton.Visible = true;
                    YESButton.Location = new Point((this.Width - YESButton.Width - NOButton.Width) / 3, YESButton.Location.Y);
                    NOButton.Location = new Point((2 * (this.Width - YESButton.Width - NOButton.Width) / 3) + YESButton.Width, NOButton.Location.Y);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    YESButton.Visible = true;
                    NOButton.Visible = true;
                    ButtonCancel.Visible = true;
                    YESButton.Location = new Point((this.Width - YESButton.Width - NOButton.Width - ButtonCancel.Width) / 4, YESButton.Location.Y);
                    NOButton.Location = new Point((2 * (this.Width - YESButton.Width - NOButton.Width - ButtonCancel.Width) / 4) + YESButton.Width, NOButton.Location.Y);
                    ButtonCancel.Location = new Point((3 * (this.Width - YESButton.Width - NOButton.Width - ButtonCancel.Width) / 4) + YESButton.Width + NOButton.Width, ButtonCancel.Location.Y);
                    break;
                default:
                    break;
            }
            
            switch(icon)
            {
                case MessageBoxIcon.Error:
                    IconPictureBox.Image = SystemIcons.Error.ToBitmap();
                    break;
                case MessageBoxIcon.Exclamation:
                    IconPictureBox.Image = SystemIcons.Exclamation.ToBitmap();
                    break;
                case MessageBoxIcon.Information:
                    IconPictureBox.Image = SystemIcons.Information.ToBitmap();
                    break;
                case MessageBoxIcon.Question:
                    IconPictureBox.Image = SystemIcons.Question.ToBitmap();
                    break;
            }
            this.Text = caption;
            MessageRichTextBox.Text = text;
            //MessageRichTextBox.DeselectAll();
        }
    }
}
