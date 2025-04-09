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
    public class CursoController : ApiController
    {
        // GET api/<controller>
        public List<Curso> Get()
        {
            return CursoData.Listar();
        }

        // GET api/<controller>/5
        public Curso Get(int id)
        {
            return CursoData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Curso oCurso)
        {
            return CursoData.Registrar(oCurso);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Curso oUsuario)
        {
            return CursoData.Modificar(oUsuario);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return CursoData.Eliminar(id);
        }
    }
}