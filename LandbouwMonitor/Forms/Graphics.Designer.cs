namespace LBM
{
    partial class Graphics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graphics));
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCopy = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.GraphPanel = new System.Windows.Forms.Panel();
            this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnPrint);
            this.kryptonPanel1.Controls.Add(this.btnCopy);
            this.kryptonPanel1.Controls.Add(this.GraphPanel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(947, 544);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(603, 23);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(156, 48);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Values.Image")));
            this.btnPrint.Values.Text = "  Afdrukken";
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(778, 23);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(156, 48);
            this.btnCopy.TabIndex = 15;
            this.btnCopy.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Values.Image")));
            this.btnCopy.Values.Text = "Kopieren";
            this.btnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // GraphPanel
            // 
            this.GraphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphPanel.Location = new System.Drawing.Point(13, 96);
            this.GraphPanel.Margin = new System.Windows.Forms.Padding(4);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.Size = new System.Drawing.Size(921, 422);
            this.GraphPanel.TabIndex = 2;
            // 
            // PrintDocument1
            // 
            this.PrintDocument1.DocumentName = "Graph";
            // 
            // Graphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 544);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Graphics";
            this.Text = "Landbouw Monitor";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel GraphPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCopy;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
        private System.Drawing.Printing.PrintDocument PrintDocument1;
        LBM.GraphControl GraphCtrl;
    }
}