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
    }
}