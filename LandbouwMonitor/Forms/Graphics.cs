﻿using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;

namespace LBM
{
    public partial class Graphics : KryptonForm
    {
        public Graphics()
        {
            InitializeComponent();
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
          this.WindowState = FormWindowState.Maximized;
        }

        
    }
}
