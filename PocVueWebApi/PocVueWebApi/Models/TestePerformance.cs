using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocVueWebApi.Models
{
    public class TestePerformance
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string cidade { get; set; }
        public string nomeMae { get; set; }
        public string nomePai { get; set; }
        public string Pais { get; set; }
        public string Nacionalidade { get; set; }
        public string casa { get; set; }
        public string bairro { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}