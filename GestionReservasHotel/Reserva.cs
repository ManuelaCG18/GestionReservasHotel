using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservasHotel
{
    public class Reserva
    {
        public string NombreCliente { get; set; }
        public int NumeroHabitacion { get; set; }
        public DateTime FechaReserva { get; set; }
        public int DuracionEstadia { get; set; }
        protected decimal PrecioNoche { get; set; }

        public Reserva(string nombre, int habitacion, DateTime fecha, int duracion, decimal precioNoche)
        {
            NombreCliente = nombre;
            NumeroHabitacion = habitacion;
            FechaReserva = fecha;
            DuracionEstadia = duracion;
            PrecioNoche = precioNoche;
        }

        public virtual decimal CalcularCostoTotal()
        {
            return DuracionEstadia * PrecioNoche;
        }
    }

    public class HabitacionEstandar : Reserva
    {
       public HabitacionEstandar(string nombre, int habitacion, DateTime fecha, int duracion) 
            : base(nombre, habitacion, fecha, duracion, 350000m)
        {
        }
        
    }

    public class HabitacionVip : Reserva
    {
        public HabitacionVip(string nombre, int habitacion, DateTime fecha, int duracion)
            : base(nombre, habitacion, fecha, duracion, 500000m)
        {
        }
    }


}
