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
    public class AsignacionesController : ApiController
    {
        // GET api/<controller>
        public List<Asignaciones> Get()
        {
            return AsignacionesData.Listar();
        }

        // GET api/<controller>/5
        public Asignaciones Get(int id)
        {
            return AsignacionesData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Asignaciones oAsignaciones)
        {
            return AsignacionesData.Registrar(oAsignaciones);
        }


        // PUT api/<controller>/5
        public bool Put([FromBody] Asignaciones oAsignaciones)
        {
            return AsignacionesData.Modificar(oAsignaciones);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return AsignacionesData.Eliminar(id);
        }
    }
}