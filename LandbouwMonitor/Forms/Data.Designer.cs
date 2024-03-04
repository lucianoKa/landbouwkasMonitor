namespace LBM
{
    partial class Data
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Data));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgvZones = new LBM.Controls.ZonesMGV.ZonesMGV();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtZoneAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMeasurementsAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtTime = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnGetData = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.grpData.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnSave);
            this.kryptonPanel1.Controls.Add(this.grpData);
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1200, 588);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1065, 549);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 29);
            this.btnSave.TabIndex = 15;
            this.btnSave.Values.Text = "Gegevens opslaan";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // grpData
            // 
            this.grpData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpData.Controls.Add(this.pnlData);
            this.grpData.Location = new System.Drawing.Point(11, 158);
            this.grpData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpData.Name = "grpData";
            this.grpData.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpData.Size = new System.Drawing.Size(1180, 377);
            this.grpData.TabIndex = 10;
            this.grpData.TabStop = false;
            this.grpData.Text = "Metingen";
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.Controls.Add(this.dgvZones);
            this.pnlData.Location = new System.Drawing.Point(14, 31);
            this.pnlData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1149, 325);
            this.pnlData.TabIndex = 1;
            // 
            // dgvZones
            // 
            this.dgvZones.AllowUserToAddRows = false;
            this.dgvZones.AllowUserToDeleteRows = false;
            this.dgvZones.AllowUserToResizeRows = false;
            this.dgvZones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvZones.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvZones.Location = new System.Drawing.Point(0, 0);
            this.dgvZones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvZones.MultiSelect = false;
            this.dgvZones.Name = "dgvZones";
            this.dgvZones.ReadOnly = true;
            this.dgvZones.RowHeadersWidth = 51;
            this.dgvZones.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvZones.RowTemplate.Height = 24;
            this.dgvZones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvZones.ShowCellToolTips = false;
            this.dgvZones.Size = new System.Drawing.Size(1149, 325);
            this.dgvZones.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.kryptonLabel4);
            this.groupBox1.Controls.Add(this.txtZoneAmount);
            this.groupBox1.Controls.Add(this.kryptonLabel3);
            this.groupBox1.Controls.Add(this.txtMeasurementsAmount);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.btnGetData);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(1180, 141);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(272, 63);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel4.TabIndex = 20;
            this.kryptonLabel4.Values.Text = "Aantal zones:";
            // 
            // txtZoneAmount
            // 
            this.txtZoneAmount.Location = new System.Drawing.Point(382, 63);
            this.txtZoneAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtZoneAmount.Name = "txtZoneAmount";
            this.txtZoneAmount.ReadOnly = true;
            this.txtZoneAmount.Size = new System.Drawing.Size(53, 23);
            this.txtZoneAmount.TabIndex = 19;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(272, 28);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(103, 20);
            this.kryptonLabel3.TabIndex = 18;
            this.kryptonLabel3.Values.Text = "Aantal metingen:";
            // 
            // txtMeasurementsAmount
            // 
            this.txtMeasurementsAmount.Location = new System.Drawing.Point(382, 28);
            this.txtMeasurementsAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMeasurementsAmount.Name = "txtMeasurementsAmount";
            this.txtMeasurementsAmount.ReadOnly = true;
            this.txtMeasurementsAmount.Size = new System.Drawing.Size(53, 23);
            this.txtMeasurementsAmount.TabIndex = 17;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(14, 98);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel2.TabIndex = 16;
            this.kryptonLabel2.Values.Text = "Tijdstip:";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(81, 98);
            this.txtTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(73, 23);
            this.txtTime.TabIndex = 15;
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Location = new System.Drawing.Point(1066, 25);
            this.btnGetData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(97, 24);
            this.btnGetData.TabIndex = 14;
            this.btnGetData.Values.Text = "Get data";
            this.btnGetData.Click += new System.EventHandler(this.BtnGetData_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(14, 63);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(50, 20);
            this.kryptonLabel1.TabIndex = 13;
            this.kryptonLabel1.Values.Text = "Datum:";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(81, 63);
            this.txtDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 11;
            this.label1.Values.Text = "Meting:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(81, 28);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(152, 23);
            this.txtName.TabIndex = 10;
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 588);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Data";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Retrieve Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGetData;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMeasurementsAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTime;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Panel pnlData;
        private Controls.ZonesMGV.ZonesMGV dgvZones;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtZoneAmount;
    }
}