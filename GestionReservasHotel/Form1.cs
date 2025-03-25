using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionReservasHotel
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReservaEst_Click(object sender, EventArgs e)
        {
            HabEstandar habEstandar = new HabEstandar();
            habEstandar.Show();
            this.Hide();
        }

        private void btnReservaVip_Click(object sender, EventArgs e)
        {
            HabVip habVip = new HabVip();
            habVip.Show();
            this.Hide();
        }
    }
}
