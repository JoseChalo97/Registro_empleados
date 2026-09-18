using System;

namespace Registro_empleados
{
    public class Empleado
    {
  
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public decimal SalarioBase { get; set; }
        public int HorasExtra { get; set; }

       
        public decimal PagoTotal()
        {
            return SalarioBase + (HorasExtra * 50.00m);
        }

        public override string ToString()
        {
            return $"{Id,-3} {Nombre,-20} Q {PagoTotal(),8:N2}";
        }
    }
}