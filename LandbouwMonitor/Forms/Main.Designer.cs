using System.Windows.Forms;

namespace LBM
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ribbon = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
            this.buttonSpecHelp = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonContextMenuItem1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.tabHome = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.kgrOperations = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnGetData = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnShowData = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupSeparator1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator();
            this.kryptonRibbonGroupTriple3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnGraphics = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnAnalytics = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupSeparator2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator();
            this.kryptonRibbonGroupTriple1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnClose = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.tabView = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.kgrArrange = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple4 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.buttonCascade = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.buttonTileHorizontal = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.buttonTileVertical = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupTriple5 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnStyles = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.KcmPalette = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonRibbonGroup3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.StyleManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecHelp});
            this.ribbon.InDesignHelperMode = true;
            this.ribbon.Name = "ribbon";
            this.ribbon.QATLocation = ComponentFactory.Krypton.Ribbon.QATLocation.Hidden;
            this.ribbon.RibbonAppButton.AppButtonMenuItems.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem1});
            this.ribbon.RibbonAppButton.AppButtonShowRecentDocs = false;
            this.ribbon.RibbonTabs.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab[] {
            this.tabHome,
            this.tabView});
            this.ribbon.SelectedContext = null;
            this.ribbon.SelectedTab = this.tabView;
            this.ribbon.Size = new System.Drawing.Size(923, 135);
            this.ribbon.TabIndex = 0;
            // 
            // buttonSpecHelp
            // 
            this.buttonSpecHelp.Image = ((System.Drawing.Image)(resources.GetObject("buttonSpecHelp.Image")));
            this.buttonSpecHelp.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.ButtonSpec;
            this.buttonSpecHelp.UniqueName = "06E98F3735BC4B1106E98F3735BC4B11";
            this.buttonSpecHelp.Click += new System.EventHandler(this.ButtonSpecHelp_Click);
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("kryptonContextMenuItem1.Image")));
            this.kryptonContextMenuItem1.Text = "Sluit applicatie";
            this.kryptonContextMenuItem1.Click += new System.EventHandler(this.AppMenu_Click);
            // 
            // tabHome
            // 
            this.tabHome.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kgrOperations});
            this.tabHome.KeyTip = "H";
            this.tabHome.Text = "Home";
            // 
            // kgrOperations
            // 
            this.kgrOperations.DialogBoxLauncher = false;
            this.kgrOperations.Image = ((System.Drawing.Image)(resources.GetObject("kgrOperations.Image")));
            this.kgrOperations.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple2,
            this.kryptonRibbonGroupSeparator1,
            this.kryptonRibbonGroupTriple3,
            this.kryptonRibbonGroupSeparator2,
            this.kryptonRibbonGroupTriple1});
            this.kgrOperations.KeyTipGroup = "O";
            this.kgrOperations.TextLine1 = "Operations";
            // 
            // kryptonRibbonGroupTriple2
            // 
            this.kryptonRibbonGroupTriple2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnGetData,
            this.btnShowData});
            // 
            // btnGetData
            // 
            this.btnGetData.ImageLarge = ((System.Drawing.Image)(resources.GetObject("btnGetData.ImageLarge")));
            this.btnGetData.ImageSmall = ((System.Drawing.Image)(resources.GetObject("btnGetData.ImageSmall")));
            this.btnGetData.KeyTip = "N";
            this.btnGetData.TextLine1 = "Get data";
            this.btnGetData.Click += new System.EventHandler(this.BtnGetData_Click);
            // 
            // btnShowData
            // 
            this.btnShowData.ImageLarge = ((System.Drawing.Image)(resources.GetObject("btnShowData.ImageLarge")));
            this.btnShowData.ImageSmall = ((System.Drawing.Image)(resources.GetObject("btnShowData.ImageSmall")));
            this.btnShowData.TextLine1 = "Show data";
            this.btnShowData.Click += new System.EventHandler(this.BtnShowData_Click);
            // 
            // kryptonRibbonGroupTriple3
            // 
            this.kryptonRibbonGroupTriple3.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnGraphics,
            this.btnAnalytics});
            // 
            // btnGraphics
            // 
            this.btnGraphics.ImageLarge = ((System.Drawing.Image)(resources.GetObject("btnGraphics.ImageLarge")));
            this.btnGraphics.ImageSmall = ((System.Drawing.Image)(resources.GetObject("btnGraphics.ImageSmall")));
            this.btnGraphics.KeyTip = "X";
            this.btnGraphics.TextLine1 = "Graphics";
            this.btnGraphics.Click += new System.EventHandler(this.BtnGraphics_Click);
            // 
            // btnAnalytics
            // 
            this.btnAnalytics.ImageLarge = ((System.Drawing.Image)(resources.GetObject("btnAnalytics.ImageLarge")));
            this.btnAnalytics.ImageSmall = ((System.Drawing.Image)(resources.GetObject("btnAnalytics.ImageSmall")));
            this.btnAnalytics.KeyTip = "A";
            this.btnAnalytics.TextLine1 = "Analytics";
            this.btnAnalytics.Click += new System.EventHandler(this.BtnAnalytics_Click);
            // 
            // kryptonRibbonGroupTriple1
            // 
            this.kryptonRibbonGroupTriple1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnClose});
            // 
            // btnClose
            // 
            this.btnClose.ImageLarge = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageLarge")));
            this.btnClose.ImageSmall = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageSmall")));
            this.btnClose.KeyTip = "C";
            this.btnClose.TextLine1 = "Sluit ";
            this.btnClose.TextLine2 = "Applicatie";
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // tabView
            // 
            this.tabView.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kgrArrange});
            this.tabView.Text = "View";
            // 
            // kgrArrange
            // 
            this.kgrArrange.DialogBoxLauncher = false;
            this.kgrArrange.Image = ((System.Drawing.Image)(resources.GetObject("kgrArrange.Image")));
            this.kgrArrange.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple4,
            this.kryptonRibbonGroupTriple5});
            this.kgrArrange.KeyTipGroup = "A";
            this.kgrArrange.TextLine1 = "Arrange";
            // 
            // kryptonRibbonGroupTriple4
            // 
            this.kryptonRibbonGroupTriple4.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.buttonCascade,
            this.buttonTileHorizontal,
            this.buttonTileVertical});
            // 
            // buttonCascade
            // 
            this.buttonCascade.ImageLarge = ((System.Drawing.Image)(resources.GetObject("buttonCascade.ImageLarge")));
            this.buttonCascade.ImageSmall = ((System.Drawing.Image)(resources.GetObject("buttonCascade.ImageSmall")));
            this.buttonCascade.KeyTip = "C";
            this.buttonCascade.TextLine1 = "Cascade";
            this.buttonCascade.Click += new System.EventHandler(this.ButtonCascade_Click);
            // 
            // buttonTileHorizontal
            // 
            this.buttonTileHorizontal.ImageLarge = ((System.Drawing.Image)(resources.GetObject("buttonTileHorizontal.ImageLarge")));
            this.buttonTileHorizontal.ImageSmall = ((System.Drawing.Image)(resources.GetObject("buttonTileHorizontal.ImageSmall")));
            this.buttonTileHorizontal.KeyTip = "H";
            this.buttonTileHorizontal.TextLine1 = "Tile";
            this.buttonTileHorizontal.TextLine2 = "Horizontal";
            this.buttonTileHorizontal.Click += new System.EventHandler(this.ButtonTileHorizontal_Click);
            // 
            // buttonTileVertical
            // 
            this.buttonTileVertical.ImageLarge = ((System.Drawing.Image)(resources.GetObject("buttonTileVertical.ImageLarge")));
            this.buttonTileVertical.ImageSmall = ((System.Drawing.Image)(resources.GetObject("buttonTileVertical.ImageSmall")));
            this.buttonTileVertical.KeyTip = "V";
            this.buttonTileVertical.TextLine1 = "Tile";
            this.buttonTileVertical.TextLine2 = "Vertical";
            this.buttonTileVertical.Click += new System.EventHandler(this.ButtonTileVertical_Click);
            // 
            // kryptonRibbonGroupTriple5
            // 
            this.kryptonRibbonGroupTriple5.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnStyles});
            // 
            // btnStyles
            // 
            this.btnStyles.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.DropDown;
            this.btnStyles.ImageLarge = ((System.Drawing.Image)(resources.GetObject("btnStyles.ImageLarge")));
            this.btnStyles.ImageSmall = ((System.Drawing.Image)(resources.GetObject("btnStyles.ImageSmall")));
            this.btnStyles.KryptonContextMenu = this.KcmPalette;
            this.btnStyles.Click += new System.EventHandler(this.BtnStyles_Click);
            // 
            // KcmPalette
            // 
            this.KcmPalette.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems2});
            // 
            // StyleManager
            // 
            this.StyleManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.ProfessionalSystem;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(923, 635);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(461, 419);
            this.Name = "Main";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Landbouw Monitor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.Resize += new System.EventHandler(this.Main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Ribbon.KryptonRibbon ribbon;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab tabHome;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kgrOperations;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnGetData;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple3;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnGraphics;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnAnalytics;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kgrArrange;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple4;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton buttonCascade;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton buttonTileHorizontal;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton buttonTileVertical;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecHelp;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
        private ComponentFactory.Krypton.Toolkit.KryptonManager StyleManager;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnShowData;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab tabView;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup3;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnClose;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple5;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnStyles;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu KcmPalette;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems2;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
    }
}

