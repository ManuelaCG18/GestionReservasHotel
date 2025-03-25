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
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione una reserva para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los valores de la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int numeroHabitacion = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                DateTime fechaReserva = DateTime.Parse(filaSeleccionada.Cells[2].Value.ToString());

                // Confirmación antes de eliminar
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar esta reserva?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Eliminar del gestor de reservas
                    GestorReservas.Instancia.EliminarReserva(numeroHabitacion, fechaReserva);

                    // Eliminar la fila del DataGridView
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

                // Obtener los valores actuales
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int numeroHabitacion = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                DateTime fechaReserva = DateTime.Parse(filaSeleccionada.Cells[2].Value.ToString());

                // Obtener los nuevos valores desde los TextBox
                string nuevoNombre = txtNombreCliente.Text;
                int nuevoNumero = int.Parse(txtNumHabitacion.Text);
                DateTime nuevaFecha = dtpFechaReserva.Value;
                int nuevasNoches = int.Parse(txtNoches.Text);

                // Crear nueva reserva con los datos editados
                Reserva nuevaReserva = ReservaFactory.CrearReserva("Estandar", nuevoNombre, nuevoNumero, nuevaFecha, nuevasNoches);

                // Editar en el gestor
                GestorReservas.Instancia.EditarReserva(numeroHabitacion, fechaReserva, nuevaReserva);

                // Actualizar el DataGridView con los nuevos datos
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
