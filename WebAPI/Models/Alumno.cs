using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Alumno
    {
            public int IdAlumno { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string FechaNacimiento { get; set; }
            public string Numero_unico { get; set; }

    }
}