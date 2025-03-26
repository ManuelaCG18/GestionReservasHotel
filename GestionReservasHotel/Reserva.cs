using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservasHotel
{
    public abstract class Reserva
    {
        // al ser una clase con un metodo abstracto, obliga a las subclases a definir su propia implementacion
        public string NombreCliente { get; set; }
        public int NumeroHabitacion { get; set; }
        public DateTime FechaReserva { get; set; }
        public int DuracionEstadia { get; set; }
        public decimal TarifaFija { get; protected set; }

        public Reserva(string nombre, int habitacion, DateTime fecha, int duracion, decimal tarifaFija)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del cliente es OBLIGATORIO. :)");
            }

            if (duracion <= 1) 
            {
                throw new ArgumentException("La duración de la estadía debe ser mayor a 1 noche. (Mínimo 2 noches) :)");
            }


            NombreCliente = nombre;
            NumeroHabitacion = habitacion;
            FechaReserva = fecha;
            DuracionEstadia = duracion;
            TarifaFija = tarifaFija; 
        }

        public abstract decimal CalcularCostoTotal();
    }

    public class HabitacionEstandar : Reserva
    {
        public HabitacionEstandar(string nombre, int habitacion, DateTime fecha, int duracion)
            : base(nombre, habitacion, fecha, duracion, 350000)
        {
            
        }

        public override decimal CalcularCostoTotal()
        {
            return TarifaFija * DuracionEstadia;
        }
    }

    public class HabitacionVip : Reserva
    {
        private const decimal DescuentoVIP = 0.2m;
        public HabitacionVip(string nombre, int habitacion, DateTime fecha, int duracion)
            : base(nombre, habitacion, fecha, duracion, 500000)
        {
          
        }

        public override decimal CalcularCostoTotal()
        {
            decimal costoTotal = TarifaFija * DuracionEstadia;
            if (DuracionEstadia > 5)
            {
                costoTotal -= costoTotal * DescuentoVIP;
            }
            return costoTotal;
        }
    }



    public class GestorReservas
    {
        private static GestorReservas instancia;
        private List<Reserva> reservas;

        private GestorReservas()
        {
            reservas = new List<Reserva>();
        }

        public static GestorReservas Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new GestorReservas();
                }
                return instancia;
            }
        }

        public string AgregarReserva(Reserva reserva)
        {
            try
            {
                if (reservas.Any(r => r.NumeroHabitacion == reserva.NumeroHabitacion && r.FechaReserva.Date == reserva.FechaReserva.Date))
                {
                    return "Ya existe una reserva para esta habitación en la misma fecha.";
                }

                reservas.Add(reserva);
                return "Reserva agregada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al agregar reserva: {ex.Message}";
            }
        }

        public string EliminarReserva(int numeroHabitacion, DateTime fechaReserva)
        {
            try
            {
                var reserva = reservas.FirstOrDefault(r => r.NumeroHabitacion == numeroHabitacion && r.FechaReserva.Date == fechaReserva.Date);
                if (reserva == null)
                {
                    return "La reserva no existe.";
                }

                reservas.Remove(reserva);
                return "Reserva eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar reserva: {ex.Message}";
            }
        }

        public void EditarReserva(int numeroHabitacion, DateTime fechaReserva, Reserva nuevaReserva)
        {
            var reserva = reservas.FirstOrDefault(r => r.NumeroHabitacion == numeroHabitacion && r.FechaReserva.Date == fechaReserva.Date);
            if (reserva == null)
            {
                throw new Exception("La reserva no existe.");
            }

            reserva.NombreCliente = nuevaReserva.NombreCliente;
            reserva.NumeroHabitacion = nuevaReserva.NumeroHabitacion;
            reserva.FechaReserva = nuevaReserva.FechaReserva;
            reserva.DuracionEstadia = nuevaReserva.DuracionEstadia;
        }



    }



    public static class ReservaFactory
    {
        public static Reserva CrearReserva(string tipo, string nombre, int habitacion, DateTime fecha, int duracion)
        {
            if (string.IsNullOrWhiteSpace(nombre) || duracion < 1)
                throw new Exception("Datos invalidos :( ");

            switch (tipo)
            {
                case "Estandar":
                    return new HabitacionEstandar(nombre, habitacion, fecha, duracion);
                case "Vip":
                    return new HabitacionVip(nombre, habitacion, fecha, duracion);
                default:
                    throw new ArgumentException("Tipo de reserva invalido :( ");
            }
        }
    }
}
