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
    public partial class HabVip: Form
    {
        public HabVip()
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

                // Crear reserva VIP
                Reserva nuevaReserva = ReservaFactory.CrearReserva("Vip", nombreCliente, numeroHabitacion, fechaReserva, noches);

                // Calcular el total
                decimal total = nuevaReserva.CalcularCostoTotal();

                // Agregar al DataGridView
                dataGridView1.Rows.Add(numeroHabitacion, nombreCliente, fechaReserva.ToShortDateString(), noches, total);

                // Guardar en la lista de reservas
                GestorReservas.Instancia.AgregarReserva(nuevaReserva);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
