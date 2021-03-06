﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace xtfileimporter
{
    public partial class outputlog : Form
    {
        public outputlog()
        {
            InitializeComponent();
        }

        public void setText(string text)
        {
            output.Text = text;
            output.ReadOnly = true;
        }
        
        private void _close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _clear_Click(object sender, EventArgs e)
        {
            output.Clear();
        }
    }
}
