namespace LBM
{
    partial class Analytics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analytics));
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.DataPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRanges = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnShow = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSubSelection = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbSubselection = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblChoise = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbChoice = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpTo = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtpFrom = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubselection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChoice)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.DataPanel);
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1725, 647);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // DataPanel
            // 
            this.DataPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataPanel.Location = new System.Drawing.Point(12, 201);
            this.DataPanel.Margin = new System.Windows.Forms.Padding(4);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(1699, 433);
            this.DataPanel.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnRanges);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1701, 173);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // btnRanges
            // 
            this.btnRanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRanges.Location = new System.Drawing.Point(1448, 92);
            this.btnRanges.Name = "btnRanges";
            this.btnRanges.Size = new System.Drawing.Size(232, 48);
            this.btnRanges.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRanges.TabIndex = 35;
            this.btnRanges.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnRanges.Values.Image")));
            this.btnRanges.Values.Text = "  Toon Marges";
            this.btnRanges.Visible = false;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Enabled = false;
            this.btnShow.Location = new System.Drawing.Point(1448, 23);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(232, 48);
            this.btnShow.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.TabIndex = 34;
            this.btnShow.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Values.Image")));
            this.btnShow.Values.Text = "  Toon gegevens";
            this.btnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblSubSelection);
            this.groupBox3.Controls.Add(this.cbSubselection);
            this.groupBox3.Controls.Add(this.lblChoise);
            this.groupBox3.Controls.Add(this.cbChoice);
            this.groupBox3.Location = new System.Drawing.Point(18, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 119);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            // 
            // lblSubSelection
            // 
            this.lblSubSelection.Location = new System.Drawing.Point(223, 26);
            this.lblSubSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSubSelection.Name = "lblSubSelection";
            this.lblSubSelection.Size = new System.Drawing.Size(115, 24);
            this.lblSubSelection.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubSelection.TabIndex = 30;
            this.lblSubSelection.Values.Text = "Zone/Gewas";
            // 
            // cbSubselection
            // 
            this.cbSubselection.DropDownWidth = 182;
            this.cbSubselection.Enabled = false;
            this.cbSubselection.FormattingEnabled = true;
            this.cbSubselection.Location = new System.Drawing.Point(223, 55);
            this.cbSubselection.Name = "cbSubselection";
            this.cbSubselection.Size = new System.Drawing.Size(182, 25);
            this.cbSubselection.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubselection.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubselection.TabIndex = 29;
            // 
            // lblChoise
            // 
            this.lblChoise.Location = new System.Drawing.Point(17, 26);
            this.lblChoise.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblChoise.Name = "lblChoise";
            this.lblChoise.Size = new System.Drawing.Size(142, 24);
            this.lblChoise.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoise.TabIndex = 28;
            this.lblChoise.Values.Text = "Selecteer keuze";
            // 
            // cbChoice
            // 
            this.cbChoice.DropDownWidth = 182;
            this.cbChoice.FormattingEnabled = true;
            this.cbChoice.Location = new System.Drawing.Point(17, 55);
            this.cbChoice.Name = "cbChoice";
            this.cbChoice.Size = new System.Drawing.Size(182, 25);
            this.cbChoice.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChoice.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChoice.TabIndex = 27;
            this.cbChoice.SelectedIndexChanged += new System.EventHandler(this.CbChoice_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kryptonLabel1);
            this.groupBox2.Controls.Add(this.kryptonLabel3);
            this.groupBox2.Controls.Add(this.kryptonLabel2);
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.dtpFrom);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(477, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 119);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = false;
            this.kryptonLabel1.Location = new System.Drawing.Point(4, 13);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(359, 24);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 36;
            this.kryptonLabel1.Values.Text = "Selecteer Periode";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(225, 47);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(39, 24);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 35;
            this.kryptonLabel3.Values.Text = "Tot";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(17, 48);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(44, 24);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 34;
            this.kryptonLabel2.Values.Text = "Van";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd MMMM yyyy";
            this.dtpTo.Enabled = false;
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(225, 76);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(178, 25);
            this.dtpTo.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.TabIndex = 33;
            this.dtpTo.ValueNullable = new System.DateTime(2024, 3, 2, 19, 21, 0, 0);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd MMMM yyyy";
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(22, 76);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(178, 25);
            this.dtpFrom.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.TabIndex = 32;
            this.dtpFrom.ValueNullable = new System.DateTime(2024, 12, 2, 19, 21, 0, 0);
            // 
            // Analytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1725, 647);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Analytics";
            this.Text = "Landbouw Monitor";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubselection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChoice)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnShow;
        private System.Windows.Forms.GroupBox groupBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSubSelection;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbSubselection;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblChoise;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbChoice;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpTo;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpFrom;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRanges;
        private System.Windows.Forms.Panel DataPanel;
    }
}