using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AlumnoController : ApiController
    {
        // GET api/<controller>
        public List<Alumno> Get()
        {
            return AlumnoData.Listar();
        }

        // GET api/<controller>/5
        public Alumno Get(int id)
        {
            return AlumnoData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Alumno oAlumno)
        {
            return AlumnoData.Registrar(oAlumno);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Alumno oAlumno)
        {
            return AlumnoData.Modificar(oAlumno);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return AlumnoData.Eliminar(id);
        }
    }
}