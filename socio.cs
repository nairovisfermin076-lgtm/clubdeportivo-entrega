using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CLUB_DEPORTIVO
{
    public class Socio : Persona
    {
        // Exponer FechaAlta como propiedad pública de solo lectura externa
        public DateTime FechaAlta { get; private set; }

        public Socio(string nombre, string apellido, string tipoDocumento, string numeroDocumento) : base(nombre, apellido, tipoDocumento, numeroDocumento)
        {
            // Agrego la fecha de alta como atributo de la clase socio
            FechaAlta = DateTime.Now;
        }
    }
}
