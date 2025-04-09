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
    public class InscripcionesController : ApiController
    {
        // GET api/<controller>
        public List<Inscripciones> Get()
        {
            return InscripcionesData.Listar();
        }

        // GET api/<controller>/5
        public Inscripciones Get(int id)
        {
            return InscripcionesData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Inscripciones oInscripciones)
        {
            return InscripcionesData.Registrar(oInscripciones);
        }


        // PUT api/<controller>/5
        public bool Put([FromBody] Inscripciones oInscripciones)
        {
            return InscripcionesData.Modificar(oInscripciones);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return InscripcionesData.Eliminar(id);
        }
    }
}