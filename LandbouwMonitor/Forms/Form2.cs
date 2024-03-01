// *****************************************************************************
// 
//  © Component Factory Pty Ltd 2012. All rights reserved.
//	The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, PO Box 1504, 
//  Glen Waverley, Vic 3150, Australia and are supplied subject to licence terms.
// 
//  Version 4.6.0.0 	www.ComponentFactory.com
// *****************************************************************************

using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;

namespace LBM
{
    public partial class Form2 : KryptonForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) 
            {
                // Remember to unhook from static event, otherwise 
                // this object cannot be garbage collected later on
                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnPaletteChanged);

                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }       

        private void Form2_Load(object sender, EventArgs e)
        {
            // Set correct initial radio button setting
            UpdateRadioButtons();

            // Hook into changes in the global palette
            KryptonManager.GlobalPaletteChanged += new EventHandler(OnPaletteChanged);
        }

        private void radioSystem_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSystem.Checked)
                kryptonManager.GlobalPaletteMode = PaletteModeManager.ProfessionalSystem;
        }

        private void radioOffice2003_CheckedChanged(object sender, EventArgs e)
        {
            if (radioOffice2003.Checked)
                kryptonManager.GlobalPaletteMode = PaletteModeManager.ProfessionalOffice2003;
        }

        private void radio2010Blue_CheckedChanged(object sender, EventArgs e)
        {
            if (radio2010Blue.Checked)
                kryptonManager.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
        }

        private void radio2010Silver_CheckedChanged(object sender, EventArgs e)
        {
            if (radio2010Silver.Checked)
                kryptonManager.GlobalPaletteMode = PaletteModeManager.Office2010Silver;
        }

        private void radio2010Black_CheckedChanged(object sender, EventArgs e)
        {
            if (radio2010Black.Checked)
                kryptonManager.GlobalPaletteMode = PaletteModeManager.Office2010Black;
        }

        private void radioBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBlue.Checked)
                kryptonManager.GlobalPaletteMode = PaletteModeManager.Office2007Blue;
        }

        private void radioSilver_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSilver.Checked)
                kryptonManager.GlobalPaletteMode = PaletteModeManager.Office2007Silver;
        }

        private void radioBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBlack.Checked)
                kryptonManager.GlobalPaletteMode = PaletteModeManager.Office2007Black;
        }

        private void radioSparkleBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSparkleBlue.Checked)
                kryptonManager.GlobalPaletteMode = PaletteModeManager.SparkleBlue;
        }

        private void radioSparkleOrange_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSparkleOrange.Checked)
                kryptonManager.GlobalPaletteMode = PaletteModeManager.SparkleOrange;
        }

        private void radioSparklePurple_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSparklePurple.Checked)
                kryptonManager.GlobalPaletteMode = PaletteModeManager.SparklePurple;
        }

        private void OnPaletteChanged(object sender, EventArgs e)
        {
            // Update buttons to reflect the new palette setting
            UpdateRadioButtons();
        }

        private void UpdateRadioButtons()
        {
            switch(kryptonManager.GlobalPaletteMode)
            {
                case PaletteModeManager.ProfessionalSystem:
                    radioSystem.Checked = true;
                    break;
                case PaletteModeManager.ProfessionalOffice2003:
                    radioOffice2003.Checked = true;
                    break;
                case PaletteModeManager.Office2007Blue:
                    radioBlue.Checked = true;
                    break;
                case PaletteModeManager.Office2007Silver:
                    radioSilver.Checked = true;
                    break;
                case PaletteModeManager.Office2007Black:
                    radioBlack.Checked = true;
                    break;
                case PaletteModeManager.SparkleBlue:
                    radioSparkleBlue.Checked = true;
                    break;
                case PaletteModeManager.SparkleOrange:
                    radioSparkleOrange.Checked = true;
                    break;
                case PaletteModeManager.SparklePurple:
                    radioSparklePurple.Checked = true;
                    break;
                case PaletteModeManager.Office2010Blue:
                    radio2010Blue.Checked = true;
                    break;
                case PaletteModeManager.Office2010Silver:
                    radio2010Silver.Checked = true;
                    break;
                case PaletteModeManager.Office2010Black:
                    radio2010Black.Checked = true;
                    break;
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            //TabPage  tab = tabControl1.SelectedTab;

            //Font BoldFont = new Font(tabControl1.Font.Name, 10, FontStyle.Bold);
            //tab.Font = BoldFont;
            
            //Refresh();
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {

            // Identify which TabPage is currently selected
            TabPage SelectedTab = tabControl1.TabPages[e.Index];

            // Get the area of the header of this TabPage
            Rectangle HeaderRect = tabControl1.GetTabRect(e.Index);

            // Create a Brush to paint the Text
            SolidBrush TextBrush = new SolidBrush(Color.Black);

            // Set the Alignment of the Text
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // Paint the Text using the appropriate Bold setting 
            if (Convert.ToBoolean(e.State & DrawItemState.Selected))
            {
                Font BoldFont = new Font(tabControl1.Font.Name, tabControl1.Font.Size, FontStyle.Bold);
                e.Graphics.DrawString(SelectedTab.Text, BoldFont, TextBrush, HeaderRect, sf);
            }
            else
                e.Graphics.DrawString(SelectedTab.Text, e.Font, TextBrush, HeaderRect, sf);

            // Job done - dispose of the Brush
            TextBrush.Dispose();
        }

    }
}
