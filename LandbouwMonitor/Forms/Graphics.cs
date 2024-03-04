using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace LBM
{
    public partial class Graphics : KryptonForm
    {
        #region Constructor
        public Graphics()
        {
            InitializeComponent();
        }
        #endregion

        #region FormEvents
        private void Graphics_Load(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Now;
            dtpFrom.Value = DateTime.Now.AddDays(-25);

            PopulateChoices();

            WindowState = FormWindowState.Maximized;
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

        private void BtnShow_Click(object sender, EventArgs e)
        {
            //Reset time to 00:00
            var dtFrom = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0);
            var dtTo = dtpTo.Value;

            List<EF.Gewas> gewassen;
            switch ((Choices)cbChoice.SelectedValue)
            {
                case Choices.Zone:
                    //Get data in Zone
                    List<EF.Gewas>  perZone = DataHelper.GetGewassen(dtFrom, dtTo).Where(x => x.ZoneNaam.ToLower() == cbSubselection.Text.ToLower()).ToList();
                    
                    //Get gewassen in this Zone
                    var kind = perZone.Select(x => x.GewasNaam).Distinct().ToList();

                    // create source per gewas
                    List<EF.Gewas> gewassen1 = perZone.Where(x => x.GewasNaam.ToLower() == kind[0].ToLower()).ToList();
                    List<EF.Gewas> gewassen2 = null;
                    if (kind.Count > 1)
                    {
                        gewassen2 = perZone.Where(x => x.GewasNaam.ToLower() == kind[1].ToLower()).ToList();
                    }

                    FillGraphZone(gewassen1, gewassen2); 

                    break;
                case Choices.Gewas:
                    gewassen = DataHelper.GetGewassen(dtFrom, dtTo).Where(x => x.GewasNaam.ToLower() == cbSubselection.Text.ToLower()).ToList();

                    FillGraphGewassen(gewassen);
                    break;
            }
        }

        private void CbChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSubselection();
            cbSubselection.Enabled = true;

            PopulateValues();
            cbValues.Enabled = true;

            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;

            btnShow.Enabled = true;
            btnCopy.Enabled = true;
            btnPrint.Enabled = true;
        }

        #endregion

        #region Private Methods
        private void FillGraphGewassen(List<EF.Gewas> gewassen)
        {
            //Clear Graphs
            GraphPanel.Controls.Clear();

            //Create a Graph Control
            GraphCtrl = new GraphControl(new Font("Arial", 12), new Font("Arial", 10), new Font("Arial", 8), "dd-MM-yyyy")
            {
                TabIndex = 0,
                Dock = DockStyle.Fill,
                Name = cbSubselection.Text,
            };

            //Add Graph Control to the form
            GraphPanel.Controls.Add(GraphCtrl);

            //Add series
            switch ((Values)cbValues.SelectedValue)
            {
                case Values.Temperature:
                    GraphCtrl.AddPointsSerie("Temp", Axes.VerticalPrimary, "Temperatuur", Color.Blue);
                    break;
                case Values.Moist:
                    GraphCtrl.AddPointsSerie("Moist", Axes.VerticalPrimary, "Vochtigheid", Color.Green);
                    break;

                case Values.Soil:
                    GraphCtrl.AddPointsSerie("Nitro", Axes.VerticalPrimary, "Stikstof", Color.Purple );
                    GraphCtrl.AddPointsSerie("Phospor", Axes.VerticalSecondary, "Fosfor", Color.Navy);
                    GraphCtrl.AddPointsSerie("Potas", Axes.VerticalSecondary, "Kalium", Color.Red);
                    break;
                case Values.TemperatureMoist:
                    GraphCtrl.AddPointsSerie("Temp", Axes.VerticalPrimary, "Temperatuur", Color.Blue);
                    GraphCtrl.AddPointsSerie("Moist", Axes.VerticalSecondary, "Vochtigheid", Color.Green);
                    break;
            }

            //Add points to the series
            foreach (var gewas in gewassen)
            {
                switch ((Values)cbValues.SelectedValue)
                {
                    case Values.Temperature:
                        GraphCtrl.GetPointsSerie("Temp").AddPointD(gewas.MeetDatum, (double)gewas.TWaarde);
                        break;
                    case Values.Moist:
                        GraphCtrl.GetPointsSerie("Moist").AddPointD(gewas.MeetDatum, (double)gewas.VWaarde);
                        break;
                    case Values.Soil:
                        GraphCtrl.GetPointsSerie("Nitro").AddPointD(gewas.MeetDatum, gewas.Stikstof);
                        GraphCtrl.GetPointsSerie("Phospor").AddPointD(gewas.MeetDatum, gewas.Fosfor);
                        GraphCtrl.GetPointsSerie("Potas").AddPointD(gewas.MeetDatum, gewas.Kalium);
                        break;
                    case Values.TemperatureMoist:
                        GraphCtrl.GetPointsSerie("Temp").AddPointD(gewas.MeetDatum, (double)gewas.TWaarde);
                        GraphCtrl.GetPointsSerie("Moist").AddPointD(gewas.MeetDatum, (double)gewas.VWaarde);
                        break;
                }
            }
        }

        private void FillGraphZone(List<EF.Gewas> gewassen1, List<EF.Gewas> gewassen2)
        {
            //Clear Graphs
            GraphPanel.Controls.Clear();

            //Create a Graph Control
            GraphCtrl = new GraphControl(new Font("Arial", 12), new Font("Arial", 10), new Font("Arial", 8), "dd-MM-yyyy")
            {
                TabIndex = 0,
                Dock = DockStyle.Fill,
                Name = cbSubselection.Text,
            };

            //Add Graph Control to the form
            GraphPanel.Controls.Add(GraphCtrl);

            #region Gewas1
            if (gewassen1 != null)
            {
                string gewasNaam1 = gewassen1.Select(x => x.GewasNaam).Distinct().FirstOrDefault();

                //Add series Gewas 1
                switch ((Values)cbValues.SelectedValue)
                {
                    case Values.Temperature:
                        GraphCtrl.AddPointsSerie("Temp1", Axes.VerticalPrimary, "Temp. - " + gewasNaam1, Color.Blue);
                        break;
                    case Values.Moist:
                        GraphCtrl.AddPointsSerie("Moist1", Axes.VerticalPrimary, "Vocht. - " + gewasNaam1, Color.Green);
                        break;

                    case Values.Soil:
                        //Gewas1
                        GraphCtrl.AddPointsSerie("Nitro1", Axes.VerticalPrimary, "Stikstof - " + gewasNaam1, Color.Purple);
                        GraphCtrl.AddPointsSerie("Phospor1", Axes.VerticalSecondary, "Fosfor - " + gewasNaam1, Color.Navy);
                        GraphCtrl.AddPointsSerie("Potas1", Axes.VerticalSecondary, "Kalium - " + gewasNaam1, Color.Red);
                        break;
                    case Values.TemperatureMoist:
                        //Gewas1
                        GraphCtrl.AddPointsSerie("Temp1", Axes.VerticalPrimary, "Temp. - " + gewasNaam1, Color.Blue);
                        GraphCtrl.AddPointsSerie("Moist1", Axes.VerticalSecondary, "Vocht. - " + gewasNaam1, Color.Green);
                        break;
                }

                //Add points to the series forgewas1
                foreach (var gewas in gewassen1)
                {
                    switch ((Values)cbValues.SelectedValue)
                    {
                        case Values.Temperature:
                            GraphCtrl.GetPointsSerie("Temp1").AddPointD(gewas.MeetDatum, (double)gewas.TWaarde);
                            break;
                        case Values.Moist:
                            GraphCtrl.GetPointsSerie("Moist1").AddPointD(gewas.MeetDatum, (double)gewas.VWaarde);
                            break;
                        case Values.Soil:
                            GraphCtrl.GetPointsSerie("Nitro1").AddPointD(gewas.MeetDatum, gewas.Stikstof);
                            GraphCtrl.GetPointsSerie("Phospor1").AddPointD(gewas.MeetDatum, gewas.Fosfor);
                            GraphCtrl.GetPointsSerie("Potas1").AddPointD(gewas.MeetDatum, gewas.Kalium);
                            break;
                        case Values.TemperatureMoist:
                            GraphCtrl.GetPointsSerie("Temp1").AddPointD(gewas.MeetDatum, (double)gewas.TWaarde);
                            GraphCtrl.GetPointsSerie("Moist1").AddPointD(gewas.MeetDatum, (double)gewas.VWaarde);
                            break;
                    }
                }
            }
            #endregion

            #region Gewas2
            if (gewassen2 != null)
            {
                string gewasNaam2 = gewassen2.Select(x => x.GewasNaam).Distinct().FirstOrDefault();

                //Add series Gewas 2
                switch ((Values)cbValues.SelectedValue)
                {
                    case Values.Temperature:
                        GraphCtrl.AddPointsSerie("Temp2", Axes.VerticalSecondary, "Temp. - " + gewasNaam2, Color.Red);
                        break;
                    case Values.Moist:
                        GraphCtrl.AddPointsSerie("Moist2", Axes.VerticalSecondary, "Vocht. - " + gewasNaam2, Color.LightSeaGreen);
                        break;

                    case Values.Soil:
                        GraphCtrl.AddPointsSerie("Nitro2", Axes.VerticalPrimary, "Stikstof - " + gewasNaam2, Color.Gray);
                        GraphCtrl.AddPointsSerie("Phospor2", Axes.VerticalSecondary, "Fosfor - " + gewasNaam2, Color.Aquamarine);
                        GraphCtrl.AddPointsSerie("Potas2", Axes.VerticalSecondary, "Kalium - " + gewasNaam2, Color.Green);
                        break;
                    case Values.TemperatureMoist:
                        GraphCtrl.AddPointsSerie("Temp2", Axes.VerticalPrimary, "Temp. - " + gewasNaam2, Color.Red);
                        GraphCtrl.AddPointsSerie("Moist2", Axes.VerticalSecondary, "Vocht - " + gewasNaam2, Color.LightSeaGreen);
                        break;
                }

                foreach (var gewas in gewassen2)
                {
                    switch ((Values)cbValues.SelectedValue)
                    {
                        case Values.Temperature:
                            GraphCtrl.GetPointsSerie("Temp2").AddPointD(gewas.MeetDatum, (double)gewas.TWaarde);
                            break;
                        case Values.Moist:
                            GraphCtrl.GetPointsSerie("Moist2").AddPointD(gewas.MeetDatum, (double)gewas.VWaarde);
                            break;
                        case Values.Soil:
                            GraphCtrl.GetPointsSerie("Nitro2").AddPointD(gewas.MeetDatum, gewas.Stikstof);
                            GraphCtrl.GetPointsSerie("Phospor2").AddPointD(gewas.MeetDatum, gewas.Fosfor);
                            GraphCtrl.GetPointsSerie("Potas2").AddPointD(gewas.MeetDatum, gewas.Kalium);
                            break;
                        case Values.TemperatureMoist:
                            GraphCtrl.GetPointsSerie("Temp2").AddPointD(gewas.MeetDatum, (double)gewas.TWaarde);
                            GraphCtrl.GetPointsSerie("Moist2").AddPointD(gewas.MeetDatum, (double)gewas.VWaarde);
                            break;
                    }
                }
            }
            #endregion 
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
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }

        private void PopulateValues()
        {
            cbValues.DisplayMember = "Description";
            cbValues.ValueMember = "Value";
            cbValues.DataSource = Enum.GetValues(typeof(Values))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }
        #endregion


    }
}
