using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Curso
    {
            public int IdCurso { get; set; }
            public string NombreCurso { get; set; }
            public string Descripcion { get; set; }
            public string Codigo_unico { get; set; }

    }
}