using System;

namespace GimnasioAPI.Models
{
    // Esta clase representa la tabla "Socios" en la base de datos
    public class Socio
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
        // El apto médico es clave para saber si lo dejamos pasar
        public DateTime AptoMedicoVencimiento { get; set; }
        
        // true = Activo, false = Inactivo
        public bool Estado { get; set; } 
    }
}