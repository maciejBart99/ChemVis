using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChemVis
{
    public partial class Autorzy : Form
    {
        public Autorzy(VSEPR vs)
        {
            InitializeComponent();
            label1.Text += vs.settings.Version;
        }

        private void Autorzy_Load(object sender, EventArgs e)
        {

        }
    }
}
