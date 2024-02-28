using System.Threading;
using System.Windows.Forms;

namespace LBM
{
    public class WaitWnd
    {
        WaitForm loadingForm;
        Thread loadthread;

        public string Text { get; set; }

        public void Show(string text = "Reading files, please wait...")
        {
            Cursor.Current = Cursors.WaitCursor;
            Text = text;
            loadthread = new Thread(new ThreadStart(LoadingProcessEx));
            loadthread.Start();
        }

        public void Show(Form parent, string text = "Reading files, please wait...")
        {
            Cursor.Current = Cursors.WaitCursor;
            Text = text;
            loadthread = new Thread(new ParameterizedThreadStart(LoadingProcessEx));
            loadthread.Start(parent);
        }
        public void Close()
        {
            Cursor.Current = Cursors.Default;
            if (loadingForm != null)
            {
                loadingForm.BeginInvoke(new ThreadStart(loadingForm.CloseLoadingForm));
                loadingForm = null;
                loadthread = null;
            }
        }

        private void LoadingProcessEx()
        {
            loadingForm = new WaitForm(Text); 
            loadingForm.ShowDialog();
        }

        private void LoadingProcessEx(object parent)
        {
            Form Cparent = parent as Form;
            loadingForm = new WaitForm(Cparent, Text);
            loadingForm.ShowDialog();
        }
    }
}
