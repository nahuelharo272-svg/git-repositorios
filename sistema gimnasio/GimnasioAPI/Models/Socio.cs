using System;

namespace GimnasioAPI.Models
{
    public class Socio
    {
        public int Id { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        
        // Clave para la recepción: saber cuándo se le vence el pago y el certificado médico
        public DateTime FechaVencimientoCuota { get; set; }
        public DateTime AptoMedicoVencimiento { get; set; }
        
        public bool Estado { get; set; } = true; // true para Activo
    }
}