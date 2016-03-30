using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Locadora
{
    public partial class Sobre : Form
    {
        Inicial frmInicial;

        public Sobre(Inicial ini)
        {
            InitializeComponent();
            frmInicial = ini;
        }

        private void Sobre_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
        }
    }
}
