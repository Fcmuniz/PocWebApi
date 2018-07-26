using LiteDB;
using PocVueWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocVueWebApi.DAO
{
    public static class Contexto
    {
        private static string arquivo = @"C:\Temp\Clientes.db";

        public static List<Cliente> ListarClientes()
        {
          
            using (var db = new LiteDatabase(arquivo))
            {
                var ctx = db.GetCollection<Cliente>("clientes");
                if (ctx.FindAll().Count() == 0)
                    MassaDados();

                return ctx.FindAll().ToList();
            }


        }


        public static List<Cidades> ListarCidades()
        {


            using (var db = new LiteDatabase(arquivo))
            {
                var ctx = db.GetCollection<Cidades>("cidades");
               
                if (ctx.FindAll().Count() == 0)
                    MassaDadosCidade();

                return ctx.FindAll().ToList();
            }

        }

        public static void InserirCliente(Cliente cli)
        {
            using (var db = new LiteDatabase(arquivo))
            {
                var ctx = db.GetCollection<Cliente>("clientes");
             
                var valor = 0;
                foreach (var item in ctx.FindAll())
                {
                    valor = item.Id;
                    if (valor < item.Id)
                    {
                        valor = item.Id;
                    }
                }
                cli.Id = valor+1;

                if(cli.Id != 0)
                ctx.Insert(cli);
            }
        }

        public static void DeleteCli(Cliente cli)
        {
            using (var db = new LiteDatabase(arquivo))
            {
                var ctx = db.GetCollection<Cliente>("clientes");
                ctx.Delete(cli.Id);
                //    ctx.Delete(cli);
            }
        }

        public static void UpdateCli(Cliente cli)
        {
            using (var db = new LiteDatabase(arquivo))
            {
                var ctx = db.GetCollection<Cliente>("clientes");
                ctx.Update(cli);
                //    ctx.Delete(cli);
            }
        }

        private static void MassaDados()
        {
            using (var db = new LiteDatabase(arquivo))
            {
                var ctx = db.GetCollection<Cliente>("clientes");
                var cliente = new Cliente()
                {
                    Id = 1,
                    Nome = "Felipe 1",
                    CPF = "111.111.111-11"
                };
                ctx.Insert(cliente);
                cliente = new Cliente()
                {
                    Id = 2,
                    Nome = "Felipe 2",
                    CPF = "222.222.222-22"
                };
                ctx.Insert(cliente);
                cliente = new Cliente()
                {
                    Id = 3,
                    Nome = "Felipe 3",
                    CPF = "333.333.333-33"
                };
                ctx.Insert(cliente);
            }
        }

        private static void MassaDadosCidade()
        {
            using (var db = new LiteDatabase(arquivo))
            {
                var ctx = db.GetCollection<Cidades>("cidades");
                var cidade = new Cidades()
                {
                    Id = 1,
                    Nome = " Alberta",
              
                };
                ctx.Insert(cidade);
                cidade = new Cidades()
                {
                    Id = 2,
                    Nome = "Colúmbia Britânica",
                
                };
                ctx.Insert(cidade);
                cidade = new Cidades()
                {
                    Id = 3,
                    Nome = " Manitoba",
                
                };
                ctx.Insert(cidade);
                cidade = new Cidades()
                {
                    Id = 4,
                    Nome = "New Brunswick",

                };
                ctx.Insert(cidade);
                cidade = new Cidades()
                {
                    Id = 5,
                    Nome = "Terra Nova e Labrador",

                };
                ctx.Insert(cidade);
                cidade = new Cidades()
                {
                    Id = 60,
                    Nome = "Nova Escócia",

                };
                ctx.Insert(cidade);
                cidade = new Cidades()
                {
                    Id = 6,
                    Nome = "Ontário",

                };
                ctx.Insert(cidade);
                cidade = new Cidades()
                {
                    Id = 7,
                    Nome = "Ilha do Príncipe Eduardo",

                };
                ctx.Insert(cidade);
                cidade = new Cidades()
                {
                    Id = 8,
                    Nome = "Quebec",

                };
                ctx.Insert(cidade);
             
                cidade = new Cidades()
                {
                    Id = 9,
                    Nome = "Saskatchewan",

                };
                ctx.Insert(cidade);
           
                cidade = new Cidades()
                {
                    Id = 10,
                    Nome = " Territórios do Noroeste",

                };
                ctx.Insert(cidade);
               
                cidade = new Cidades()
                {
                    Id = 11,
                    Nome = "Nunavut",

                };
                ctx.Insert(cidade);
             
                cidade = new Cidades()
                {
                    Id = 12,
                    Nome = "Yukon",

                };
                ctx.Insert(cidade);
            }
        }
    }
}