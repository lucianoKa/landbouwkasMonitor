namespace LBM
{
    partial class MsgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgBox));
            this.OKButton = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.YESButton = new System.Windows.Forms.Button();
            this.NOButton = new System.Windows.Forms.Button();
            this.IconPictureBox = new System.Windows.Forms.PictureBox();
            this.MessageRichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(12, 90);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Visible = false;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(306, 90);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Visible = false;
            // 
            // YESButton
            // 
            this.YESButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.YESButton.Location = new System.Drawing.Point(110, 90);
            this.YESButton.Name = "YESButton";
            this.YESButton.Size = new System.Drawing.Size(75, 23);
            this.YESButton.TabIndex = 3;
            this.YESButton.Text = "Oui";
            this.YESButton.UseVisualStyleBackColor = true;
            this.YESButton.Visible = false;
            // 
            // NOButton
            // 
            this.NOButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.NOButton.Location = new System.Drawing.Point(208, 90);
            this.NOButton.Name = "NOButton";
            this.NOButton.Size = new System.Drawing.Size(75, 23);
            this.NOButton.TabIndex = 4;
            this.NOButton.Text = "Non";
            this.NOButton.UseVisualStyleBackColor = true;
            this.NOButton.Visible = false;
            // 
            // IconPictureBox
            // 
            this.IconPictureBox.Location = new System.Drawing.Point(9, 24);
            this.IconPictureBox.Name = "IconPictureBox";
            this.IconPictureBox.Size = new System.Drawing.Size(32, 32);
            this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.IconPictureBox.TabIndex = 5;
            this.IconPictureBox.TabStop = false;
            // 
            // MessageRichTextBox
            // 
            this.MessageRichTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MessageRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageRichTextBox.Location = new System.Drawing.Point(50, 0);
            this.MessageRichTextBox.Name = "MessageRichTextBox";
            this.MessageRichTextBox.Size = new System.Drawing.Size(345, 80);
            this.MessageRichTextBox.TabIndex = 6;
            this.MessageRichTextBox.Text = "";
            // 
            // MsgBox
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 125);
            this.ControlBox = false;
            this.Controls.Add(this.MessageRichTextBox);
            this.Controls.Add(this.IconPictureBox);
            this.Controls.Add(this.NOButton);
            this.Controls.Add(this.YESButton);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MsgBox";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MsgBox";
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button YESButton;
        private System.Windows.Forms.Button NOButton;
        private System.Windows.Forms.PictureBox IconPictureBox;
        private System.Windows.Forms.RichTextBox MessageRichTextBox;
    }
}