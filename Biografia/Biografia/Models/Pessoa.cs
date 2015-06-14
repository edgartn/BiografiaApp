using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biografia.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Biografia { get; set; }
    }
}