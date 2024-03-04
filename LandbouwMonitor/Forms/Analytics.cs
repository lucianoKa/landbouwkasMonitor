using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using LBM.Controls.ZonesMGV;
using Newtonsoft.Json.Linq;
using static LBM.EF;

namespace LBM
{
    public partial class Analytics : KryptonForm
    {
        private List<EF.Marge> marges;

        public Analytics()
        {
            InitializeComponent();
        }


        #region FormEvents
        private void Form2_Load(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Now;
            dtpFrom.Value = DateTime.Now.AddDays(-25);

            //Fill combox
            PopulateChoices();

            WindowState = FormWindowState.Maximized;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            //Reset time to 00:00
            var dtFrom = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0);
            var dtTo = dtpTo.Value;

            //Get Marges
            marges = DataHelper.GetMarges();

            List<EF.Gewas> gewassen = null;
            switch ((Choices)cbChoice.SelectedValue)
            {
                case Choices.All:
                    gewassen = DataHelper.GetGewassen(dtFrom, dtTo).ToList();
                    break;
                case Choices.Zone:
                    //Get data in Zone
                    gewassen = DataHelper.GetGewassen(dtFrom, dtTo).Where(x => x.ZoneNaam.ToLower() == cbSubselection.Text.ToLower()).ToList();

                    break;
                case Choices.Gewas:
                    gewassen = DataHelper.GetGewassen(dtFrom, dtTo).Where(x => x.GewasNaam.ToLower() == cbSubselection.Text.ToLower()).ToList();

                    break;
            }

            PopulateData(gewassen);
        }

        private void CbChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSubselection();
            cbSubselection.Enabled = true;

            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;

            btnShow.Enabled = true;
        }

        #endregion

        #region Private Methods
        private void PopulateData(List<EF.Gewas> gewassen)
        {
            //Clear Grid
            DataPanel.Controls.Clear();

            //Create a Graph Control
            KryptonDataGridView dgvData = new KryptonDataGridView()
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = true,
                AllowUserToResizeColumns = true,
                ReadOnly = true,
            };

            //Add Graph Control to the form
            DataPanel.Controls.Add(dgvData);

            dgvData.RowHeadersVisible = false;
            dgvData.CellFormatting += DgvData_CellFormatting;

            //Build Columns
            ConfigColumns(dgvData);

            //Filldata
            dgvData.DataSource = gewassen;
        }

        private void DgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = sender as DataGridView;
            var colName = dgv.Columns[e.ColumnIndex].Name;
            var gewas = dgv[dgv.Columns["Gewasnaam"].Index, e.RowIndex].Value.ToString();

            //EF.Marge marge = marges.Where(x => x.Key == colName && x.GewasNaam == gewas).FirstOrDefault();

            //if (marge != null)
            //{
            //    var cellValue = Convert.ToDecimal(dgv[marge.Field, e.RowIndex].Value);

            //    Color cellColor = Color.Black;
            //    if (cellValue <= marge.Min)
            //    {
            //        cellColor = Color.Red;
            //    }
            //    else if (cellValue >= marge.Max)
            //    {
            //        cellColor = Color.Blue;
            //    }

            //    dgv[colName, e.RowIndex].Style.ForeColor = cellColor;
            //}


            var d = new DictMarges();
            if (d.GetMarges.ContainsKey(colName))
            {
                var marges = new DictMarges().GetMarges[colName];

                var cellValue = Convert.ToDecimal(dgv[marges.Field, e.RowIndex].Value);

                var cell = dgv[colName, e.RowIndex];
                cell.Style.ForeColor = cellValue <= marges.Min ? Color.Red : cellValue > marges.Max ? Color.Blue : Color.Black;

            }
        }

        private void PopulateSubselection()
        {
            switch ((Choices)cbChoice.SelectedValue)
            {
                case Choices.Zone:
                    //Set Label text
                    lblSubSelection.Text = "Kies Zone";

                    //Setup data binding
                    cbSubselection.DataSource = DataHelper.GetZoneList();
                    cbSubselection.DisplayMember = "Zonenaam";
                    //cbSubselection.ValueMember = "Zonenaam";
                    break;
                case Choices.Gewas:
                    lblSubSelection.Text = "Kies gewas";

                    //Setup data binding
                    cbSubselection.DataSource = DataHelper.GetGewassenList();
                    cbSubselection.DisplayMember = "Gewasnaam";
                    //cbSubselection.ValueMember = "Gewasnaam";
                    break;
            }
        }

        private void PopulateChoices()
        {
            cbChoice.DisplayMember = "Description";
            cbChoice.ValueMember = "Value";
            cbChoice.DataSource = Enum.GetValues(typeof(Choices))
                .Cast<Choices>()
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }

        private void ConfigColumns(KryptonDataGridView dgvData)
        {
            //StackedHeaderDecorator st = new StackedHeaderDecorator(dgvData);
            //dgvData.Columns.Add(DataGridColumnFactory.TextColumnStyle("Id", "No."));
            //dgvData.Columns.Add(DataGridColumnFactory.DateColumnStyle("Meetdatum", "Datum"));
            //dgvData.Columns.Add(DataGridColumnFactory.TimeColumnStyle("Meetdatum", "Tijd"));
            //if ((Choices)cbChoice.SelectedValue != Choices.Zone)
            //{
            //    dgvData.Columns.Add(DataGridColumnFactory.TextColumnStyle("ZoneNaam", "Zone"));
            //}
            //dgvData.Columns.Add(DataGridColumnFactory.DateColumnStyle("Gewasnaam", "Naam"));
            //dgvData.Columns.Add(DataGridColumnFactory.TextColumnStyle("Temperatuur", "Temperatuur"));
            //dgvData.Columns.Add(DataGridColumnFactory.TextColumnStyle("Vochtigheid", "Vochtigheid"));

            //dgvData.Columns.Add(DataGridColumnFactory.DecimalColumnStyle("PH", "Bodemgezondheid.PH", 1));
            //dgvData.Columns.Add(DataGridColumnFactory.DecimalColumnStyle("Stikstof", "Bodemgezondheid.Stikstof", 1));
            //dgvData.Columns.Add(DataGridColumnFactory.DecimalColumnStyle("Fosfor", "Bodemgezondheid.Fosfor", 1));
            //dgvData.Columns.Add(DataGridColumnFactory.DecimalColumnStyle("Kalium", "Bodemgezondheid.Kalium", 1));
            //dgvData.Columns.Add(DataGridColumnFactory.TextColumnStyle("Intensiteit", "Zonlicht.Intensiteit"));
            //dgvData.Columns.Add(DataGridColumnFactory.DecimalColumnStyle("Urenperdag", "Zonlicht.Uren p/d", 0));

            DataGridViewColumnCollection columns = dgvData.Columns;
            columns.Add(DataGridColumnFactory.TextColumnStyle("Id", "No."));
            columns.Add(DataGridColumnFactory.DateColumnStyle("Meetdatum", "Datum"));
            columns.Add(DataGridColumnFactory.TimeColumnStyle("Meetdatum", "Tijd"));
            if ((Choices)cbChoice.SelectedValue != Choices.Zone)
            {
                columns.Add(DataGridColumnFactory.TextColumnStyle("ZoneNaam", "Zone"));
            }
            columns.Add(DataGridColumnFactory.DateColumnStyle("Gewasnaam", "Naam"));
            columns.Add(DataGridColumnFactory.TextColumnStyle("Temperatuur", "Temperatuur"));
            columns.Add(DataGridColumnFactory.DecimalColumnStyle("TWaarde", "TWaarde", 2, true, false));
            columns.Add(DataGridColumnFactory.TextColumnStyle("Vochtigheid", "Vochtigheid"));
            columns.Add(DataGridColumnFactory.DecimalColumnStyle("VWaarde", "VWaarde", 2, true, false));
            columns.Add(DataGridColumnFactory.DecimalColumnStyle("PH", "PH", 1));
            columns.Add(DataGridColumnFactory.DecimalColumnStyle("Stikstof", "Stikstof", 1));
            columns.Add(DataGridColumnFactory.DecimalColumnStyle("Fosfor", "Fosfor", 1));
            columns.Add(DataGridColumnFactory.DecimalColumnStyle("Kalium", "Kalium", 1));
            columns.Add(DataGridColumnFactory.TextColumnStyle("Intensiteit", "Intensiteit"));
            columns.Add(DataGridColumnFactory.DecimalColumnStyle("Urenperdag", "Uren p/d", 0));
            columns.Add(DataGridColumnFactory.TextColumnStyle("Blank", ""));

            columns[columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            columns[1].Width = 150;
        }

        #endregion
    }
}
