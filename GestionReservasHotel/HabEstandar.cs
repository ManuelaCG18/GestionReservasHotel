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
    public partial class HabEstandar : Form
    {
        public HabEstandar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreCliente = txtNombreCliente.Text;
                int numeroHabitacion = int.Parse(txtNumHabitacion.Text);
                DateTime fechaReserva = dtpFechaReserva.Value;
                int noches = int.Parse(txtNoches.Text);

                
                Reserva nuevaReserva = ReservaFactory.CrearReserva("Estandar", nombreCliente, numeroHabitacion, fechaReserva, noches);

                
                decimal total = nuevaReserva.CalcularCostoTotal();
              


                dataGridView1.Rows.Add(numeroHabitacion, nombreCliente, fechaReserva.ToShortDateString(), noches, total);

                
                GestorReservas.Instancia.AgregarReserva(nuevaReserva);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
