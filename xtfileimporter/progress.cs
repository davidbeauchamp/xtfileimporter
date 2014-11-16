using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace xtfileimporter
{
    public partial class progress : Form
    {
        public progress()
        {
            InitializeComponent();
        }
        public void setLabel(string text)
        {
            _message.Text = text;
        }
        public void setMaxValue(int value)
        {
            _progress.Maximum = value;
        }
        public void setProgressValue(int value)
        {
            _progress.Value = value;
        }
        public void incremenet(int step = 1)
        {
            _progress.Value += step;
        }
    }
}
