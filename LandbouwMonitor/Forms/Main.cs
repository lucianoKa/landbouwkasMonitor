using System;
using System.Windows.Forms;

using ComponentFactory.Krypton.Toolkit;

namespace LBM
{
    public partial class Main : KryptonForm
    {
        #region Constructor
        public Main()
        {
            InitializeComponent();

            CreateContextMenu();
        }
        #endregion 

        #region Events

        #region Home Tab
        private void BtnGetData_Click(object sender, EventArgs e)
        {
            OpenChild("Data");
        }

        private void BtnShowData_Click(object sender, EventArgs e)
        {
            OpenChild("Metingen");
        }

        private void BtnGraphics_Click(object sender, EventArgs e)
        {
            OpenChild("Graphics");
        }

        private void BtnAnalytics_Click(object sender, EventArgs e)
        {
            OpenChild("Analytics");
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion 

        #region View Tab
        private void ButtonCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void ButtonTileHorizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ButtonTileVertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void ButtonSpecHelp_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void BtnStyles_Click(object sender, EventArgs e)
        {
            UncheckItems();

            KryptonContextMenuItem item = (KryptonContextMenuItem)sender;

            StyleManager.GlobalPaletteMode = (PaletteModeManager)item.Tag;

            item.Checked = true;
        }

        private void AppMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion 

        #region Form events
        private void Main_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        #endregion

        #region ContextMenu

        private void CreateContextMenu()
        {
            kryptonContextMenuItems2.Items.Add(new KryptonContextMenuItem(){ Text = "Professional", Tag = PaletteModeManager.ProfessionalSystem});
            kryptonContextMenuItems2.Items.Add(new KryptonContextMenuItem() { Text = "Office 2003", Tag = PaletteModeManager.ProfessionalOffice2003 });
            kryptonContextMenuItems2.Items.Add(new KryptonContextMenuItem() { Text = "Office 2010 - Blue", Tag = PaletteModeManager.Office2010Blue });
            kryptonContextMenuItems2.Items.Add(new KryptonContextMenuItem() { Text = "Office 2010 - Silver", Tag = PaletteModeManager.Office2010Silver });
            kryptonContextMenuItems2.Items.Add(new KryptonContextMenuItem() { Text = "Office 2010 - Black", Tag = PaletteModeManager.Office2010Black });
            kryptonContextMenuItems2.Items.Add(new KryptonContextMenuItem() { Text = "Office 2007 - Blue", Tag = PaletteModeManager.Office2007Blue });
            kryptonContextMenuItems2.Items.Add(new KryptonContextMenuItem() { Text = "Office 2007 - Silver", Tag = PaletteModeManager.Office2007Silver });
            kryptonContextMenuItems2.Items.Add(new KryptonContextMenuItem() { Text = "Office 2007 - Black", Tag = PaletteModeManager.Office2007Black });
            kryptonContextMenuItems2.Items.Add(new KryptonContextMenuItem() { Text = "Sparkle - Blue", Tag = PaletteModeManager.SparkleBlue });
            kryptonContextMenuItems2.Items.Add(new KryptonContextMenuItem() { Text = "Sparkle - Orange", Tag = PaletteModeManager.SparkleOrange });
            kryptonContextMenuItems2.Items.Add(new KryptonContextMenuItem() { Text = "Sparkle - Purple", Tag = PaletteModeManager.SparklePurple });

            // Add Click Events
            foreach (KryptonContextMenuItem item in kryptonContextMenuItems2.Items)
            {
                item.Click += BtnStyles_Click;
                item.Checked = (PaletteModeManager)item.Tag == StyleManager.GlobalPaletteMode;
            }
        }

        private void UncheckItems()
        {
            foreach (KryptonContextMenuItem item in kryptonContextMenuItems2.Items)
            { 
                item.Checked = false;
            }
        }

        #endregion

        #endregion

        #region Private Methods
        private void OpenChild(string formName)
        {
            var form = Activator.CreateInstance(Type.GetType("LBM." + formName)) as Form;

            //Close other forms first
            while (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }



        #endregion

        private void kryptonRibbonGroupButton1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }
    }
}
