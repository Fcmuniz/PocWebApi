using PocVueWebApi.DAO;
using PocVueWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace PocVueWebApi.Controllers
{
    [EnableCors(origins: "http://localhost:53947", headers: "*", methods: "*")]
    public class ClienteController : ApiController
    {

        
        [ActionName("ListarClientes")]
        [HttpGet]
        public IEnumerable<Cliente> ListarClientes()
        {
            //return clientes;
            var cli = Contexto.ListarClientes();
            return cli.ToList();
        }

      
      
        [ActionName("ListarCidades")]
        [HttpGet]
        public IEnumerable<Cidades> Get(string q)
        {
            if (q == null)
                q = "";
          
            //return clientes;
            var cidade = Contexto.ListarCidades().Where(x => x.Nome.Contains(q)).ToList();
            return cidade.ToList();
        }

        [Route("api/cliente/DelCli")]
        public void DelCli([FromBody] Cliente cl)
        {
            Contexto.DeleteCli(cl);
            //clientes.Add(cl);
        }


        [Route("api/cliente/NovoCliente")]
        public void NovoCliente([FromBody] Cliente cl)
        {
            Contexto.InserirCliente(cl);
            //clientes.Add(cl);
        }

        [Route("api/cliente/UpdateCli")]
       public void UpdateCli([FromBody] Cliente cl)
        {
            Contexto.UpdateCli(cl);
            //clientes.Add(cl);
        }


    }
}
