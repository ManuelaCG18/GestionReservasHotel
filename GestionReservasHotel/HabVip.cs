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

                // nueva instancia de reserva con los nuevos datos
                Reserva nuevaReserva = ReservaFactory.CrearReserva("Vip", nombreCliente, numeroHabitacion, fechaReserva, noches);

                // llamada a AgregarReserva
                GestorReservas.Instancia.AgregarReserva(nuevaReserva);

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
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione una reserva para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int numeroHabitacion = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                DateTime fechaReserva = DateTime.Parse(filaSeleccionada.Cells[2].Value.ToString());


                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar esta reserva?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {

                    GestorReservas.Instancia.EliminarReserva(numeroHabitacion, fechaReserva.Date);



                    dataGridView1.Rows.Remove(filaSeleccionada);

                    MessageBox.Show("Reserva eliminada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione una reserva para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int numeroHabitacion = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                DateTime fechaReserva = DateTime.Parse(filaSeleccionada.Cells[2].Value.ToString());


                string nuevoNombre = txtNombreCliente.Text;
                int nuevoNumero = int.Parse(txtNumHabitacion.Text);
                DateTime nuevaFecha = dtpFechaReserva.Value;
                int nuevasNoches = int.Parse(txtNoches.Text);

                // nueva instancia de reserva con los nuevos datos
                Reserva nuevaReserva = ReservaFactory.CrearReserva("Vip", nuevoNombre, nuevoNumero, nuevaFecha, nuevasNoches);

                // llamada a EditarReserva
                GestorReservas.Instancia.EditarReserva(numeroHabitacion, fechaReserva.Date, nuevaReserva);


                filaSeleccionada.Cells[0].Value = nuevoNumero;
                filaSeleccionada.Cells[1].Value = nuevoNombre;
                filaSeleccionada.Cells[2].Value = nuevaFecha.ToShortDateString();
                filaSeleccionada.Cells[3].Value = nuevasNoches;
                filaSeleccionada.Cells[4].Value = nuevaReserva.CalcularCostoTotal();

                MessageBox.Show("Reserva editada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
