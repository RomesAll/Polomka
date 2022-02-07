using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolomkaProgramm
{
    public partial class Avtorizacie : Form
    {
        public Avtorizacie()
        {
            InitializeComponent();
            ClassConnectBD.Connvetion();
            button1.Click += (s,e) => 
            {
                new MainAdministator().Show();
                this.Hide();
            };
        }

        private void Avtorizacie_Load(object sender, EventArgs e)
        {

        }
    }
}
