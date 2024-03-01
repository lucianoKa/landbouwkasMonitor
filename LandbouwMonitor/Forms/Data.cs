using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using LBM.Controls.ZonesMGV;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LBM
{
    public partial class Data : KryptonForm
    {
        private WaitWnd _waitForm = new WaitWnd();
        private EF.Root data;

        public Data()
        {
            InitializeComponent();

            btnSave.Enabled = false;
        }      

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            DataGridViewColumnCollection columns = dgvZones.Columns;
            columns.Add(DataGridColumnFactory.TextColumnStyle("ZoneNaamEx", "Zone"));
            columns[columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async void BtnGetData_Click(object sender, EventArgs e)
        {
            //Show WaitForm
            _waitForm.Show(this.ParentForm);

            Json.Root root = await DataHelper.RetreiveData();
            data = DataHelper.JsonToEf(root);

            txtName.Text = data.Metadata.Name;
            txtDate.Text = data.Metadata.CreatedAt.ToString("ddd dd MMM yyyy");
            txtTime.Text = data.Metadata.CreatedAt.ToString("HH:mm");
            txtMeasurementsAmount.Text = data.Record.Metingen.Count.ToString();
            txtZoneAmount.Text = data.Record.Metingen[0].Zones.Count.ToString();

            BindingSource bs = new BindingSource
            {
                DataSource = data.Record.Metingen[0].Zones
            };

            dgvZones.DataSource = bs;
            dgvZones.Dock = DockStyle.Fill;

            //Add the grid
            pnlData.Controls.Add(dgvZones);
            dgvZones.SetChild();

            //Close waitform
            _waitForm.Close();

            btnSave.Enabled = true;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnGetData.Enabled = false;

            //Show WaitForm
            _waitForm.Show(this.ParentForm, "Data wordt opgeslagen...");

            await DataHelper.SaveToDatabase(data);

            //Close waitform
            _waitForm.Close();

            //Show message
            MessageBox.Show(this.ParentForm, "Gegevens zijn opgeslagen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


            btnGetData.Enabled = true;
        }
    }
}
