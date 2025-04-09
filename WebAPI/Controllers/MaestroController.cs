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
    public class MaestroController : ApiController
    {
        // GET api/<controller>
        public List<Maestro> Get()
        {
            return MaestroData.Listar();
        }

        // GET api/<controller>/5
        public Maestro Get(int id)
        {
            return MaestroData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Maestro oMestro)
        {
            return MaestroData.Registrar(oMestro);
        }


        // PUT api/<controller>/5
        public bool Put([FromBody] Maestro oMaestro)
        {
            return MaestroData.Modificar(oMaestro);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return MaestroData.Eliminar(id);
        }
    }
}