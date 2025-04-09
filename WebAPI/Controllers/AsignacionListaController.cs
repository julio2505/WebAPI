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
    public class AsignacionesListaController : ApiController
    {
        // GET api/<controller>
        public List<AsignacionesLista> Get()
        {
            return AsignacionesData.ListarCursosMaestros();
        }

        
    }
}