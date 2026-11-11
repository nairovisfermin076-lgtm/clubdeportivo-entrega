using System;
using System.Collections.Generic;
using System.Text;

namespace CLUB_DEPORTIVO
{
    public class Persona
    {
        // Atributos como propiedades para permitir acceso y persistencia
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }

        // Constructor
        public Persona(string nombre, string apellido, string tipoDocumento, string numeroDocumento)
        {
            Nombre = nombre;
            Apellido = apellido;
            TipoDocumento = tipoDocumento;
            Documento = numeroDocumento;
        }
    }
}
