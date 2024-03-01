using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using LBM.Controls.ZonesMGV;

namespace LBM
{
    public partial class Metingen : KryptonForm
    {
        private WaitWnd _waitForm = new WaitWnd();

        public Metingen()
        {
            InitializeComponent();
        }      

        private async void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            DataGridViewColumnCollection columns = dgvMetingen.Columns;
            columns.Add(DataGridColumnFactory.TextColumnStyle("Name", "Naam"));
            columns.Add(DataGridColumnFactory.DateColumnStyle("Meetdatum", "Datum"));
            columns.Add(DataGridColumnFactory.TimeColumnStyle("Meetdatum", "Tijd"));
            columns.Add(DataGridColumnFactory.TextColumnStyle("Blank", ""));
            columns[columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            columns[1].Width = 150;

            await LoadData();
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            //Show WaitForm
            _waitForm.Show(this.ParentForm);

            await LoadData();

            //Close waitform
            _waitForm.Close();
        }

        private async Task LoadData()
        {
            btnRefresh.Enabled = false;

            //Show WaitForm
            _waitForm.Show(this.ParentForm);

            dgvMetingen.Rows.Clear();

            await Task.Delay(TimeSpan.FromSeconds(1));

            List<EF.Meting> metingen = DataHelper.GetMetingen();

            BindingSource bs = new BindingSource
            {
                DataSource = metingen
            };

            //Bind datasource
            dgvMetingen.DataSource = bs;

            //Add the grid
            pnlData.Controls.Add(dgvMetingen);
            dgvMetingen.SetChild();

            //Close waitform
            _waitForm.Close();

            btnRefresh.Enabled = true;

        }
    }
}
