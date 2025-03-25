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

                // Intentar agregar la reserva a la lista (Si hay duplicado, lanzará una excepción)
                GestorReservas.Instancia.AgregarReserva(nuevaReserva);

                // Si la reserva fue agregada correctamente, calcular el total y agregar al DataGridView
                decimal total = nuevaReserva.CalcularCostoTotal();
                dataGridView1.Rows.Add(numeroHabitacion, nombreCliente, fechaReserva.ToShortDateString(), noches, total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
